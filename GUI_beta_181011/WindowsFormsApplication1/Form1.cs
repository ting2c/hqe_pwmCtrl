using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int[] baudrates = { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 };
        int[] bits = { 5, 8, 9 };
        String[] portnames = SerialPort.GetPortNames();
        String[] parities = { "None", "Odd", "Even", "Mark", "Space" };
        String[] stopBits = { "1", "1.5", "2" };

        int selectedRadioBtn = 0;
        DateTime prevCmdDT = new DateTime(); //DateTime.Now;

        private Thread _thread = null;
        private volatile bool bMonitor = false;
        string command_str = "";

        int timespan_thread = 200;

        string[] hexValues;
        Byte[] value;
        int hex_chCnt = 0;
        int monitorCmdCnt = 0;

        bool invoked_F6_1 = false;
        bool invoked_F6_2 = false;
        int cntF6 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        protected int chkRadionButton()
        {
            int chkCnt = 0;
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        if (radioButton0.Checked)
                        {
                            chkCnt++;
                            selectedRadioBtn = i;
                        }
                        break;
                    case 1:
                        if (radioButton1.Checked)
                        {
                            chkCnt++;
                            selectedRadioBtn = i;
                        }
                        break;
                    case 2:
                        if (radioButton2.Checked)
                        {
                            chkCnt++;
                            selectedRadioBtn = i;
                        }
                        break;
                    case 3:
                        if (radioButton3.Checked)
                        {
                            chkCnt++;
                            selectedRadioBtn = i;
                        }
                        break;
                    case 4:
                        if (radioButton4.Checked)
                        {
                            chkCnt++;
                            selectedRadioBtn = i;
                        }
                        break;
                    case 5:
                        if (radioButton5.Checked)
                        {
                            chkCnt++;
                            selectedRadioBtn = i;
                        }
                        break;
                }
            }

            return chkCnt;
        }

        protected void init_status()
        {
            button_disconnect.Enabled = false;
            button_connect.Enabled = !button_disconnect.Enabled;
            groupBox_duty.Enabled = button_disconnect.Enabled;
            groupBox_1ms.Enabled = button_disconnect.Enabled;

            button_refresh.Enabled = button_connect.Enabled;
            comboBox_comPort.Enabled = button_connect.Enabled;
            comboBox_baudrate.Enabled = button_connect.Enabled;
            comboBox_stopBit.Enabled = button_connect.Enabled;
            comboBox_bits.Enabled = button_connect.Enabled;
            comboBox_parity.Enabled = button_connect.Enabled;

            radioButton1.Checked = true;
            checkBox_cont.Checked = false;

            if (comboBox_ms.Items.Count > 0)
            {
                foreach (int ms in comboBox_ms.Items)
                {
                    if (ms == 200)
                        comboBox_ms.SelectedItem = ms;
                }
            }

            checkBox_cont1.Checked = checkBox_cont.Checked;

            chkRadionButton();

            if (trackBar_1ms.Value > (selectedRadioBtn * 20))
            {
                trackBar_1ms.Value = (selectedRadioBtn * 20);
            }

            if (domainUpDown_1ms.Items.Count > 0)
            {
                foreach (int ms in domainUpDown_1ms.Items)
                {
                    if (ms == trackBar_1ms.Value)
                    {
                        domainUpDown_1ms.SelectedItem = trackBar_1ms.Value;
                    }
                }
            }

            if (comboBox_ms1.Items.Count > 0)
            {
                foreach (int ms in comboBox_ms1.Items)
                {
                    if (ms == timespan_thread)
                        comboBox_ms1.SelectedItem = ms;
                }
            }
            toolStripStatusLabel1.Text = "";

            bMonitor = false;
        }

        protected void refreshComPort()
        {
            if (comboBox_comPort.Items.Count > 0)
            {
                for (int i = 0; i < comboBox_comPort.Items.Count; i++)
                {
                    comboBox_comPort.Items.RemoveAt(i);
                }
            }

            portnames = SerialPort.GetPortNames();

            if (comboBox_comPort.Items.Count == 0)
            {
                foreach (String name in portnames)
                {
                    comboBox_comPort.Items.Add(name);
                }
                if (portnames.Length > 0)
                {
                    comboBox_comPort.SelectedIndex = 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (comboBox_baudrate.Items.Count > 0)
            {
                int i = 0;
                for (i = 0; i < comboBox_baudrate.Items.Count; i++)
                {
                    comboBox_baudrate.Items.RemoveAt(i);
                }
            }

            if (comboBox_baudrate.Items.Count == 0)
            {
                foreach (int baudrate in baudrates)
                {
                    comboBox_baudrate.Items.Add(baudrate.ToString());
                }

                if (comboBox_baudrate.Items.Count > 0)
                {
                    comboBox_baudrate.SelectedItem = "9600";
                }
            }

            if (comboBox_parity.Items.Count > 0)
            {
                for (int i = 0; i < comboBox_parity.Items.Count; i++)
                {
                    comboBox_parity.Items.RemoveAt(i);
                }
            }

            if (comboBox_parity.Items.Count == 0)
            {
                foreach (String parity in parities)
                {
                    comboBox_parity.Items.Add(parity);
                }
                if (parities.Length > 0)
                {
                    comboBox_parity.SelectedItem = "None";
                }
            }

            if (comboBox_stopBit.Items.Count > 0)
            {
                for (int i = 0; i < comboBox_stopBit.Items.Count; i++)
                {
                    comboBox_stopBit.Items.RemoveAt(i);
                }
            }
            if (comboBox_stopBit.Items.Count == 0)
            {
                foreach (String stopBit in stopBits)
                {
                    comboBox_stopBit.Items.Add(stopBit);
                }
                if (stopBits.Length > 0)
                {
                    comboBox_stopBit.SelectedItem = "1";
                }
            }

            if (comboBox_bits.Items.Count > 0)
            {
                for (int i = 0; i < comboBox_bits.Items.Count; i++)
                {
                    comboBox_bits.Items.RemoveAt(i);
                }
            }
            if (comboBox_bits.Items.Count == 0)
            {
                foreach (int bit in bits)
                {
                    comboBox_bits.Items.Add(bit);
                }
                if (bits.Length > 0)
                {
                    comboBox_bits.SelectedItem = 8;
                }
            }

            if (comboBox_ms.Items.Count > 0)
            {
                for (int i = 0; i < comboBox_ms.Items.Count; i++)
                {
                    comboBox_ms.Items.RemoveAt(i);
                }
            }
            if (comboBox_ms.Items.Count == 0)
            {
                for (int i = timespan_thread; i <= (timespan_thread * 5); i += (timespan_thread / 2))
                {
                    comboBox_ms.Items.Add(i);
                }
                if (comboBox_ms.Items.Count > 0)
                {
                    comboBox_ms.SelectedItem = timespan_thread;
                }
            }

            if (domainUpDown_1ms.Items.Count > 0)
            {
                for (int i = 0; i < domainUpDown_1ms.Items.Count; i++)
                {
                    domainUpDown_1ms.Items.RemoveAt(i);
                }
            }
            if (domainUpDown_1ms.Items.Count == 0)
            {
                for (int i = 0; i <= 100; i++)
                {
                    domainUpDown_1ms.Items.Add(i);
                }
                if (domainUpDown_1ms.Items.Count > 20)
                {
                    domainUpDown_1ms.SelectedItem = 20;
                    trackBar_1ms.Value = Convert.ToInt32(domainUpDown_1ms.SelectedItem);
                }
            }

            domainUpDown_1ms.TextAlign = HorizontalAlignment.Center;

            if (comboBox_ms1.Items.Count > 0)
            {
                for (int i = 0; i < comboBox_ms1.Items.Count; i++)
                {
                    comboBox_ms1.Items.RemoveAt(i);
                }
            }
            if (comboBox_ms1.Items.Count == 0)
            {
                for (int i = timespan_thread; i <= (timespan_thread * 5); i += (timespan_thread / 2))
                {
                    comboBox_ms1.Items.Add(i);
                }
                if (comboBox_ms1.Items.Count > 0)
                {
                    comboBox_ms1.SelectedItem = timespan_thread;
                }
            }

            refreshComPort();

            init_status();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String errMsg = "";
            if (portnames.Length == 0)
            {
                errMsg = "No available com port.";
            }
            else
            {
                String[] portNs = SerialPort.GetPortNames();
                int chkCnt = 0;
                foreach (String n in portNs)
                {
                    if (n == comboBox_comPort.SelectedItem.ToString())
                    {
                        chkCnt++;
                    }
                }
                if (chkCnt == 0)
                {
                    errMsg = comboBox_comPort.SelectedItem.ToString();
                    errMsg += " is no longer availble.";
                }
                else if (chkCnt > 1)
                {
                    errMsg = "Internal error on setting duty rate.";
                }
                else if (chkCnt == 1)
                {
                    if (!serialPort.IsOpen)
                    {
                        try
                        {
                            serialPort.PortName = comboBox_comPort.SelectedItem.ToString();
                            serialPort.BaudRate = Convert.ToInt32(comboBox_baudrate.SelectedItem);
                            serialPort.DataBits = Convert.ToInt32(comboBox_bits.SelectedItem);

                            switch (comboBox_parity.SelectedIndex)
                            {
                                case 0:
                                    serialPort.Parity = Parity.None;
                                    break;
                                case 1:
                                    serialPort.Parity = Parity.Odd;
                                    break;
                                case 2:
                                    serialPort.Parity = Parity.Even;
                                    break;
                                case 3:
                                    serialPort.Parity = Parity.Mark;
                                    break;
                                case 4:
                                    serialPort.Parity = Parity.Space;
                                    break;
                            }
                            switch (comboBox_stopBit.SelectedIndex)
                            {
                                case 0:
                                    serialPort.StopBits = StopBits.One;
                                    break;
                                case 1:
                                    serialPort.StopBits = StopBits.OnePointFive;
                                    break;
                                case 2:
                                    serialPort.StopBits = StopBits.Two;
                                    break;
                            }

                            serialPort.Open();
                            errMsg = serialPort.PortName + " is opened.";
                            errMsg += String.Format(" ({0}, {1}, {2}, {3})", serialPort.BaudRate, serialPort.DataBits, comboBox_stopBit.SelectedItem, serialPort.Parity.ToString().Substring(0, 1));

                            button_connect.Enabled = false;
                            button_disconnect.Enabled = !button_connect.Enabled;
                            groupBox_duty.Enabled = button_disconnect.Enabled;
                            groupBox_1ms.Enabled = button_disconnect.Enabled;

                            button_refresh.Enabled = button_connect.Enabled;
                            comboBox_comPort.Enabled = button_connect.Enabled;
                            comboBox_baudrate.Enabled = button_connect.Enabled;
                            comboBox_stopBit.Enabled = button_connect.Enabled;
                            comboBox_bits.Enabled = button_connect.Enabled;
                            comboBox_parity.Enabled = button_connect.Enabled;
                        }

                        catch (Exception ex)
                        {
                            if (ex is UnauthorizedAccessException)
                            {
                                errMsg = "Port Already Open.";
                            }
                            else
                            {
                                errMsg = "This protocol setting is not supported.";

                            }
                        }
                    }
                }

            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            String errMsg = "";
            if (serialPort.IsOpen)
            {
                try
                {
                    turnoff_Monitor();
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException)
                    {
                        errMsg = "Port Already Closed.";
                    }
                    else
                    {
                        errMsg = "";
                    }
                }
            }
            else
            {
                refreshComPort();
            }

            init_status();
            errMsg = serialPort.PortName + " is closed.";

            if (!String.IsNullOrEmpty(errMsg))
            {
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            String errMsg = "";

            if (chkRadionButton() == 1)
            {
                try
                {
                    if (checkBox_cont1.Checked)
                    {
                        checkBox_cont1.Checked = false;
                        checkBox_cont1_CheckedChanged(null, null);
                    }
                    if (check_strCmd())
                    //if (hex_check(command_str))
                    {
                        switch (checkBox_cont.Checked)
                        {
                            case false:
                                //TimeSpan timespan = DateTime.Now.Subtract(prevCmdDT);

                                //if (timespan.Milliseconds > Convert.ToInt32(comboBox_ms.SelectedItem))
                                {
                                    prevCmdDT = DateTime.Now;

                                    //sendHex(command_str);

                                    //string[] hexValues = command_str.Split(' ');
                                    //Byte[] value = new Byte[hexValues.Length];
                                    serialPort.Write(value, 0, hex_chCnt);

                                }
                                /*
                                else
                                {
                                    errMsg = "Too many settings within ";
                                    errMsg += Convert.ToInt32(comboBox_ms.SelectedItem);
                                    errMsg += " ms.";
                                }
                                */
                                break;
                            case true:
                                if (!bMonitor)
                                {
                                    turnon_Monitor();
                                    //button_set.Enabled = false;
                                    timespan_thread = Convert.ToInt32(comboBox_ms.SelectedItem);
                                    button_set.Text = "STOP";
                                    button_set.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    turnoff_Monitor();
                                    //button_set.Enabled = true;
                                    if (checkBox_cont.Checked)
                                    {
                                        button_set.Text = "START";
                                        button_set.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        button_set.Text = "SET";
                                        button_set.ForeColor = System.Drawing.Color.Black;
                                    }
                                }
                                break;
                        }

                        errMsg = "+Duty rate of ";
                        switch (selectedRadioBtn)
                        {
                            case 0:
                                errMsg += radioButton0.Text;
                                break;
                            case 1:
                                errMsg += radioButton1.Text;
                                break;
                            case 2:
                                errMsg += radioButton2.Text;
                                break;
                            case 3:
                                errMsg += radioButton3.Text;
                                break;
                            case 4:
                                errMsg += radioButton4.Text;
                                break;
                            case 5:
                                errMsg += radioButton5.Text;
                                break;
                        }
                        errMsg += " is set.";

                    }
                    else
                    {
                        errMsg = "Internal error on setting duty rate.";
                    }
                }
                catch (Exception ex)
                {
                    if (ex is OverflowException)
                    {
                        errMsg = "selected option is not in scope.";
                    }
                    else
                    {
                        errMsg = ex.Message;
                    }
                }

            }
            else
            {
                errMsg = "multiple radio buttons selected.";
            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void turnon_Monitor()
        {
            if (!bMonitor)
            {
                bMonitor = true;
                if (_thread == null)
                    _thread = new Thread(new ThreadStart(Monitoring));
                _thread.Start();
            }
        }

        private bool check_strCmd()
        {
            bool hex_check = true;
            Byte[] cmd_data = new Byte[2];
            cmd_data[0] = Convert.ToByte((selectedRadioBtn + 1));
            cmd_data[1] = cmd_data[0];

            //string command_str = "19 85 05 26 00 ";
            command_str = String.Format("{0:X2}", cmd_data[0]) + " ";
            command_str += String.Format("{0:X2}", cmd_data[0]) + " ";
            command_str += String.Format("{0:X2}", cmd_data[1]);

            hexValues = command_str.Split(' ');
            value = new Byte[hexValues.Length];
            hex_chCnt = 0;
            Regex hex_regex = new Regex(@"^[a-fA-F0-9][a-fA-F0-9]$");


            foreach (String hex in hexValues)
            {
                if (hex_regex.IsMatch(hex))
                {
                    value[hex_chCnt] = Convert.ToByte(hex, 16);
                    hex_chCnt++;
                }
                else
                {
                    hex_check = false;
                    break;
                }
            }
            return hex_check;
        }

        private void Monitoring()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    while (bMonitor)
                    {

                        if (invoked_F6_1 || invoked_F6_2)
                        {
                            string command_str1 = String.Format("{0:X2}", "F6") + " ";
                            if (invoked_F6_1)
                            {
                                command_str1 += String.Format("{0:X2}", "01") + " ";
                                command_str1 += String.Format("{0:X2}", "01");
                            }else
                            {
                                command_str1 += String.Format("{0:X2}", "02") + " ";
                                command_str1 += String.Format("{0:X2}", "02");
                            }

                            cntF6 = (cntF6 + 1) % 2;
                            if (invoked_F6_1)
                            {
                                if (cntF6 == 0)
                                {
                                    invoked_F6_1 = false;
                                }
                            }
                            else
                            {
                                if (cntF6 == 0)
                                {
                                    invoked_F6_2 = false;
                                }
                            }
                            this.mSent_data(command_str1);
                        }else
                        {
                            this.mSent_data(command_str);
                        }

                        
                        Thread.Sleep(timespan_thread);
                    }
                }
                else
                {
                    turnoff_Monitor();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void mSent_data(string text)
        {
            string[] hexValues = text.Split(' ');
            Byte[] value = new Byte[hexValues.Length];
            int i = 0;
            bool hex_check = true;
            Regex hex_regex = new Regex(@"^[a-fA-F0-9][a-fA-F0-9]$");
            foreach (String hex in hexValues)
            {
                if (hex_regex.IsMatch(hex))
                {
                    value[i] = Convert.ToByte(hex, 16);
                    i++;
                }
                else
                {
                    hex_check = false;
                    break;
                }
            }
            if (hex_check)
            {
                serialPort.Write(value, 0, i);
                monitorCmdCnt++;
            }
            else
                MessageBox.Show("Hex Input Error", "SpTerm Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_set_KeyPress(object sender, KeyPressEventArgs e)
        {
            button_set_Click(null, null);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            refreshComPort();
        }

        private void checkBox_cont_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cont.Checked)
            {
                if (checkBox_cont1.Checked)
                {
                    checkBox_cont1.Checked = false;
                    checkBox_cont1_CheckedChanged(null, null);
                }
                button_set.Text = "START";
                button_set.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                turnoff_Monitor();
                button_set.Text = "SET";
                button_set.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void turnoff_Monitor()
        {
            if (bMonitor)
            {
                bMonitor = false;
                //this.button_monitor.ForeColor = System.Drawing.Color.Black;
                //this.button_monitor.Text = "Start Receive";

                if (_thread.IsAlive)
                    _thread.Join((timespan_thread * 2));
                try
                {
                    if (_thread.IsAlive)
                        _thread.Abort();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                _thread = null;
            }
        }

        private void radioButton0_CheckedChanged(object sender, EventArgs e)
        {
            String errMsg = "";
            errMsg = "+Duty rate of ";
            errMsg += radioButton0.Text;
            errMsg += " is selected.";
            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
            chkRadionButton();
            check_strCmd();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            String errMsg = "";
            errMsg = "+Duty rate of ";
            errMsg += radioButton1.Text;
            errMsg += " is selected.";
            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
            chkRadionButton();
            check_strCmd();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            String errMsg = "";
            errMsg = "+Duty rate of ";
            errMsg += radioButton2.Text;
            errMsg += " is selected.";
            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
            chkRadionButton();
            check_strCmd();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            String errMsg = "";
            errMsg = "+Duty rate of ";
            errMsg += radioButton3.Text;
            errMsg += " is selected.";
            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
            chkRadionButton();
            check_strCmd();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            String errMsg = "";
            errMsg = "+Duty rate of ";
            errMsg += radioButton4.Text;
            errMsg += " is selected.";
            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
            chkRadionButton();
            check_strCmd();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            String errMsg = "";
            errMsg = "+Duty rate of ";
            errMsg += radioButton5.Text;
            errMsg += " is selected.";
            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (1 KHz)";
                toolStripStatusLabel1.Text = errMsg;
            }
            chkRadionButton();
            check_strCmd();
        }

        private void button_set1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            String errMsg = "";
            if (String.IsNullOrEmpty(domainUpDown_1ms.Text) ||
                (regex.IsMatch(domainUpDown_1ms.Text) == false))
            {
                errMsg = "Please enter numbers only.";
            }
            else if (regex.IsMatch(domainUpDown_1ms.Text.ToString()))
            {
                if (domainUpDown_1ms.SelectedItem == null)
                {
                    errMsg = "Entered item isn't supported.";
                }
                else
                {
                    TimeSpan timespan = DateTime.Now.Subtract(prevCmdDT);
                    /*
                    if (timespan.Milliseconds > Convert.ToInt32(comboBox_ms1.SelectedItem))
                    {
                        label_msg2.Text = "Too many settings within ";
                        label_msg2.Text += Convert.ToInt32(comboBox_ms1.SelectedItem);
                        label_msg2.Text += " ms.";
                    }else
                     * */
                    {
                        Byte[] cmd_data = new Byte[2];
                        cmd_data[0] = Convert.ToByte((Convert.ToInt32(domainUpDown_1ms.SelectedItem) + 1));
                        cmd_data[1] = cmd_data[0];

                        command_str = String.Format("{0:X2}", "F5") + " ";
                        command_str += String.Format("{0:X2}", cmd_data[0]) + " ";
                        command_str += String.Format("{0:X2}", cmd_data[1]);

                        string[] hexValues = command_str.Split(' ');
                        Byte[] value = new Byte[hexValues.Length];
                        int hex_chCnt = 0;
                        bool hex_check = true;
                        Regex hex_regex = new Regex(@"^[a-fA-F0-9][a-fA-F0-9]$");


                        foreach (String hex in hexValues)
                        {
                            if (hex_regex.IsMatch(hex))
                            {
                                value[hex_chCnt] = Convert.ToByte(hex, 16);
                                hex_chCnt++;
                            }
                            else
                            {
                                hex_check = false;
                                break;
                            }
                        }

                        if (hex_check)
                        //if (hex_check(command_str))
                        {
                            prevCmdDT = DateTime.Now;
                            //sendHex(command_str);

                            //string[] hexValues = command_str.Split(' ');
                            //Byte[] value = new Byte[hexValues.Length];

                            switch (checkBox_cont1.Checked)
                            {
                                case false:
                                    serialPort.Write(value, 0, hex_chCnt);
                                    break;
                                case true:
                                    if (!bMonitor)
                                    {
                                        turnon_Monitor();
                                        //button_set.Enabled = false;
                                        timespan_thread = Convert.ToInt32(comboBox_ms1.SelectedItem);
                                        button_set1.Text = "STOP";
                                        button_set1.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        turnoff_Monitor();
                                        //button_set.Enabled = true;
                                        if (checkBox_cont.Checked)
                                        {
                                            button_set1.Text = "START";
                                            button_set1.ForeColor = System.Drawing.Color.Red;
                                        }
                                        else
                                        {
                                            button_set1.Text = "SET";
                                            button_set1.ForeColor = System.Drawing.Color.Black;
                                        }
                                    }
                                    break;
                            }

                            errMsg = String.Format("+Duty rate of {0}% is set.", domainUpDown_1ms.SelectedItem.ToString());
                        }
                        else
                        {
                            errMsg = "Internal error on setting duty rate.";
                        }
                    }

                }
            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (100 Hz)";
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void domainUpDown_1ms_SelectedItemChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            String errMsg = "";
            if (regex.IsMatch(domainUpDown_1ms.Text))
            {
                int val = Convert.ToInt32(domainUpDown_1ms.Text);
                foreach (int ms in domainUpDown_1ms.Items)
                {
                    if (ms == val)
                    {
                        domainUpDown_1ms.SelectedItem = val;
                        trackBar_1ms.Value = Convert.ToInt32(domainUpDown_1ms.SelectedItem.ToString());

                        errMsg = String.Format("+Duty rate of {0}% is selected.", domainUpDown_1ms.SelectedItem.ToString());

                        UpdateCmdStr(1);
                    }
                }
            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (100 Hz)";
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void UpdateCmdStr(int opt)
        {
            String errMsg = "";
            if (checkBox_cont1.Checked)
            {
                Byte[] cmd_data = new Byte[2];
                cmd_data[0] = Convert.ToByte((Convert.ToInt32(domainUpDown_1ms.SelectedItem) + 1));
                cmd_data[1] = cmd_data[0];

                command_str = String.Format("{0:X2}", "F5") + " ";
                command_str += String.Format("{0:X2}", cmd_data[0]) + " ";
                command_str += String.Format("{0:X2}", cmd_data[1]);
                errMsg = String.Format("+Duty rate of {0}% is set.", domainUpDown_1ms.SelectedItem.ToString());
            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                switch (opt)
                {
                    case 0:
                        errMsg += " (1 KHz)";
                        break;
                    case 1:
                        errMsg += " (100 Hz)";
                        break;
                }
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void trackBar_1ms_Scroll(object sender, EventArgs e)
        {
            domainUpDown_1ms.SelectedItem = trackBar_1ms.Value;

            String errMsg = String.Format("+Duty rate of {0}% is selected.", domainUpDown_1ms.SelectedItem.ToString());

            UpdateCmdStr(1);

            if (!String.IsNullOrEmpty(errMsg))
            {
                errMsg += " (100 Hz)";
                toolStripStatusLabel1.Text = errMsg;
            }
        }

        private void groupBox_1ms_Enter(object sender, EventArgs e)
        {

        }

        private void button_up_Click(object sender, EventArgs e)
        {
            //F6 01 01
            button_up_down_Click(1);
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            //F6 02 02
            button_up_down_Click(2);
        }

        private void domainUpDown_1ms_KeyDown(object sender, KeyEventArgs e)
        {
            String keyText = e.KeyCode.ToString();
            Keys keyCode = e.KeyCode;

            switch (keyText)
            {
                case "Return":
                    button_set1_Click(null, null);
                    break;
            }

        }

        private void button_hz_up_Click(object sender, EventArgs e)
        {
        }

        private void button_up_down_Click(int opt)
        {
            switch (checkBox_cont1.Checked)
            {
                case true:
                    switch (opt)
                    {
                        case 1:
                            if (invoked_F6_1 == false)
                            {
                                invoked_F6_1 = true;
                            }
                            break;
                        case 2:
                            if (invoked_F6_2 == false)
                            {
                                invoked_F6_2 = true;
                            }
                            break;
                    }
                    break;
                case false:
                    Byte[] cmd_data = new Byte[2];

                    String strCmd = "";
                    String strOpt = "";
                    strCmd = String.Format("{0:X2}", "F6") + " ";

                    switch (opt)
                    {
                        case 1:
                            cmd_data[0] = 1;
                            strOpt = "01";
                            break;
                        case 2:
                            cmd_data[0] = 2;
                            strOpt = "02";
                            break;
                    }

                    cmd_data[1] = cmd_data[0];
                    strCmd += String.Format("{0:X2}", strOpt) + " ";
                    strCmd += String.Format("{0:X2}", strOpt);

                    string[] hexValues = strCmd.Split(' ');
                    Byte[] value = new Byte[hexValues.Length];
                    int hex_chCnt = 0;
                    bool hex_check = true;
                    Regex hex_regex = new Regex(@"^[a-fA-F0-9][a-fA-F0-9]$");

                    foreach (String hex in hexValues)
                    {
                        if (hex_regex.IsMatch(hex))
                        {
                            value[hex_chCnt] = Convert.ToByte(hex, 16);
                            hex_chCnt++;
                        }
                        else
                        {
                            hex_check = false;
                            break;
                        }
                    }

                    if (hex_check)
                    {
                        serialPort.Write(value, 0, hex_chCnt);
                    }
                    break;
            }
        }

        private void label_Hz_Click(object sender, EventArgs e)
        {

        }

        private void button_duty_Click(object sender, EventArgs e)
        {

        }

        private void button_dutyUp_Click(object sender, EventArgs e)
        {

        }

        private void button_dutyDown_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    checkBox_cont.Checked = false;
                    checkBox_cont_CheckedChanged(null, null);
                    break;
            }
        }

        private void checkBox_cont1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cont1.Checked)
            {
                button_set1.Text = "START";
                button_set1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                turnoff_Monitor();
                button_set1.Text = "SET";
                button_set1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_disconnect_Click(null, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String message = "";
            message += "If there is any quesiton,";
            message += "\n";
            message += "please seek help on www.huaquan-energy.com.tw";
            message += "\n";
            message += "\n";
            message += "Released on 2018/10/22.";
            message += "\n";
            
            
            String caption = "About HQE v0.0";
            MessageBox.Show(message, caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

        }
    }
}
