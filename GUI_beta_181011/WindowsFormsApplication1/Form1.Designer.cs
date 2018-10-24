namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.button_connect = new System.Windows.Forms.Button();
            this.comboBox_comPort = new System.Windows.Forms.ComboBox();
            this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
            this.comboBox_bits = new System.Windows.Forms.ComboBox();
            this.label_comPort = new System.Windows.Forms.Label();
            this.label_baudrate = new System.Windows.Forms.Label();
            this.label_bits = new System.Windows.Forms.Label();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.groupBox_comPort = new System.Windows.Forms.GroupBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.comboBox_stopBit = new System.Windows.Forms.ComboBox();
            this.label_stopBit = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.label_parity = new System.Windows.Forms.Label();
            this.groupBox_duty = new System.Windows.Forms.GroupBox();
            this.label_ms = new System.Windows.Forms.Label();
            this.comboBox_ms = new System.Windows.Forms.ComboBox();
            this.checkBox_cont = new System.Windows.Forms.CheckBox();
            this.button_set = new System.Windows.Forms.Button();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox_1ms = new System.Windows.Forms.GroupBox();
            this.label_duty = new System.Windows.Forms.Label();
            this.button_down = new System.Windows.Forms.Button();
            this.button_up = new System.Windows.Forms.Button();
            this.trackBar_1ms = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.domainUpDown_1ms = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ms1 = new System.Windows.Forms.ComboBox();
            this.checkBox_cont1 = new System.Windows.Forms.CheckBox();
            this.button_set1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox_comPort.SuspendLayout();
            this.groupBox_duty.SuspendLayout();
            this.groupBox_1ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1ms)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            resources.ApplyResources(this.button_connect, "button_connect");
            this.button_connect.Name = "button_connect";
            this.button_connect.Tag = "";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_comPort
            // 
            this.comboBox_comPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_comPort.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_comPort, "comboBox_comPort");
            this.comboBox_comPort.Name = "comboBox_comPort";
            // 
            // comboBox_baudrate
            // 
            this.comboBox_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_baudrate.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_baudrate, "comboBox_baudrate");
            this.comboBox_baudrate.Name = "comboBox_baudrate";
            // 
            // comboBox_bits
            // 
            this.comboBox_bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bits.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_bits, "comboBox_bits");
            this.comboBox_bits.Name = "comboBox_bits";
            // 
            // label_comPort
            // 
            resources.ApplyResources(this.label_comPort, "label_comPort");
            this.label_comPort.Name = "label_comPort";
            // 
            // label_baudrate
            // 
            resources.ApplyResources(this.label_baudrate, "label_baudrate");
            this.label_baudrate.Name = "label_baudrate";
            // 
            // label_bits
            // 
            resources.ApplyResources(this.label_bits, "label_bits");
            this.label_bits.Name = "label_bits";
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_parity.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_parity, "comboBox_parity");
            this.comboBox_parity.Name = "comboBox_parity";
            // 
            // groupBox_comPort
            // 
            this.groupBox_comPort.Controls.Add(this.button_refresh);
            this.groupBox_comPort.Controls.Add(this.comboBox_stopBit);
            this.groupBox_comPort.Controls.Add(this.label_stopBit);
            this.groupBox_comPort.Controls.Add(this.button_disconnect);
            this.groupBox_comPort.Controls.Add(this.label_parity);
            this.groupBox_comPort.Controls.Add(this.comboBox_comPort);
            this.groupBox_comPort.Controls.Add(this.comboBox_parity);
            this.groupBox_comPort.Controls.Add(this.button_connect);
            this.groupBox_comPort.Controls.Add(this.label_bits);
            this.groupBox_comPort.Controls.Add(this.comboBox_baudrate);
            this.groupBox_comPort.Controls.Add(this.label_baudrate);
            this.groupBox_comPort.Controls.Add(this.comboBox_bits);
            this.groupBox_comPort.Controls.Add(this.label_comPort);
            resources.ApplyResources(this.groupBox_comPort, "groupBox_comPort");
            this.groupBox_comPort.Name = "groupBox_comPort";
            this.groupBox_comPort.TabStop = false;
            // 
            // button_refresh
            // 
            resources.ApplyResources(this.button_refresh, "button_refresh");
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // comboBox_stopBit
            // 
            this.comboBox_stopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_stopBit.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_stopBit, "comboBox_stopBit");
            this.comboBox_stopBit.Name = "comboBox_stopBit";
            // 
            // label_stopBit
            // 
            resources.ApplyResources(this.label_stopBit, "label_stopBit");
            this.label_stopBit.Name = "label_stopBit";
            // 
            // button_disconnect
            // 
            resources.ApplyResources(this.button_disconnect, "button_disconnect");
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // label_parity
            // 
            resources.ApplyResources(this.label_parity, "label_parity");
            this.label_parity.Name = "label_parity";
            // 
            // groupBox_duty
            // 
            resources.ApplyResources(this.groupBox_duty, "groupBox_duty");
            this.groupBox_duty.Controls.Add(this.label_ms);
            this.groupBox_duty.Controls.Add(this.comboBox_ms);
            this.groupBox_duty.Controls.Add(this.checkBox_cont);
            this.groupBox_duty.Controls.Add(this.button_set);
            this.groupBox_duty.Controls.Add(this.radioButton0);
            this.groupBox_duty.Controls.Add(this.radioButton5);
            this.groupBox_duty.Controls.Add(this.radioButton4);
            this.groupBox_duty.Controls.Add(this.radioButton3);
            this.groupBox_duty.Controls.Add(this.radioButton2);
            this.groupBox_duty.Controls.Add(this.radioButton1);
            this.groupBox_duty.Name = "groupBox_duty";
            this.groupBox_duty.TabStop = false;
            // 
            // label_ms
            // 
            resources.ApplyResources(this.label_ms, "label_ms");
            this.label_ms.Name = "label_ms";
            // 
            // comboBox_ms
            // 
            this.comboBox_ms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ms.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_ms, "comboBox_ms");
            this.comboBox_ms.Name = "comboBox_ms";
            // 
            // checkBox_cont
            // 
            resources.ApplyResources(this.checkBox_cont, "checkBox_cont");
            this.checkBox_cont.Name = "checkBox_cont";
            this.checkBox_cont.UseVisualStyleBackColor = true;
            this.checkBox_cont.CheckedChanged += new System.EventHandler(this.checkBox_cont_CheckedChanged);
            // 
            // button_set
            // 
            resources.ApplyResources(this.button_set, "button_set");
            this.button_set.Name = "button_set";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            this.button_set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button_set_KeyPress);
            // 
            // radioButton0
            // 
            resources.ApplyResources(this.radioButton0, "radioButton0");
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.TabStop = true;
            this.radioButton0.UseVisualStyleBackColor = true;
            this.radioButton0.CheckedChanged += new System.EventHandler(this.radioButton0_CheckedChanged);
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox_1ms
            // 
            resources.ApplyResources(this.groupBox_1ms, "groupBox_1ms");
            this.groupBox_1ms.Controls.Add(this.label_duty);
            this.groupBox_1ms.Controls.Add(this.button_down);
            this.groupBox_1ms.Controls.Add(this.button_up);
            this.groupBox_1ms.Controls.Add(this.trackBar_1ms);
            this.groupBox_1ms.Controls.Add(this.label3);
            this.groupBox_1ms.Controls.Add(this.domainUpDown_1ms);
            this.groupBox_1ms.Controls.Add(this.label1);
            this.groupBox_1ms.Controls.Add(this.comboBox_ms1);
            this.groupBox_1ms.Controls.Add(this.checkBox_cont1);
            this.groupBox_1ms.Controls.Add(this.button_set1);
            this.groupBox_1ms.Name = "groupBox_1ms";
            this.groupBox_1ms.TabStop = false;
            // 
            // label_duty
            // 
            resources.ApplyResources(this.label_duty, "label_duty");
            this.label_duty.Name = "label_duty";
            // 
            // button_down
            // 
            resources.ApplyResources(this.button_down, "button_down");
            this.button_down.Name = "button_down";
            this.button_down.UseVisualStyleBackColor = true;
            this.button_down.Click += new System.EventHandler(this.button_down_Click);
            // 
            // button_up
            // 
            resources.ApplyResources(this.button_up, "button_up");
            this.button_up.Name = "button_up";
            this.button_up.UseVisualStyleBackColor = true;
            this.button_up.Click += new System.EventHandler(this.button_up_Click);
            // 
            // trackBar_1ms
            // 
            resources.ApplyResources(this.trackBar_1ms, "trackBar_1ms");
            this.trackBar_1ms.Maximum = 100;
            this.trackBar_1ms.Name = "trackBar_1ms";
            this.trackBar_1ms.Scroll += new System.EventHandler(this.trackBar_1ms_Scroll);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // domainUpDown_1ms
            // 
            resources.ApplyResources(this.domainUpDown_1ms, "domainUpDown_1ms");
            this.domainUpDown_1ms.Name = "domainUpDown_1ms";
            this.domainUpDown_1ms.SelectedItemChanged += new System.EventHandler(this.domainUpDown_1ms_SelectedItemChanged);
            this.domainUpDown_1ms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.domainUpDown_1ms_KeyDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBox_ms1
            // 
            this.comboBox_ms1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ms1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_ms1, "comboBox_ms1");
            this.comboBox_ms1.Name = "comboBox_ms1";
            // 
            // checkBox_cont1
            // 
            resources.ApplyResources(this.checkBox_cont1, "checkBox_cont1");
            this.checkBox_cont1.Name = "checkBox_cont1";
            this.checkBox_cont1.UseVisualStyleBackColor = true;
            this.checkBox_cont1.CheckedChanged += new System.EventHandler(this.checkBox_cont1_CheckedChanged);
            // 
            // button_set1
            // 
            resources.ApplyResources(this.button_set1, "button_set1");
            this.button_set1.Name = "button_set1";
            this.button_set1.UseVisualStyleBackColor = true;
            this.button_set1.Click += new System.EventHandler(this.button_set1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox_duty);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox_1ms);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_comPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_comPort.ResumeLayout(false);
            this.groupBox_comPort.PerformLayout();
            this.groupBox_duty.ResumeLayout(false);
            this.groupBox_duty.PerformLayout();
            this.groupBox_1ms.ResumeLayout(false);
            this.groupBox_1ms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1ms)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.ComboBox comboBox_comPort;
        private System.Windows.Forms.ComboBox comboBox_baudrate;
        private System.Windows.Forms.ComboBox comboBox_bits;
        private System.Windows.Forms.Label label_comPort;
        private System.Windows.Forms.Label label_baudrate;
        private System.Windows.Forms.Label label_bits;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.GroupBox groupBox_comPort;
        private System.Windows.Forms.Label label_parity;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Label label_stopBit;
        private System.Windows.Forms.ComboBox comboBox_stopBit;
        private System.Windows.Forms.GroupBox groupBox_duty;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.CheckBox checkBox_cont;
        private System.Windows.Forms.ComboBox comboBox_ms;
        private System.Windows.Forms.Label label_ms;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.GroupBox groupBox_1ms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ms1;
        private System.Windows.Forms.CheckBox checkBox_cont1;
        private System.Windows.Forms.Button button_set1;
        private System.Windows.Forms.DomainUpDown domainUpDown_1ms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_1ms;
        private System.Windows.Forms.Button button_down;
        private System.Windows.Forms.Button button_up;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label_duty;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

