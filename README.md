# Download files from:
	1. [TEXT TO SHOW](https://github.com/ywcheng8526/tool_pc/blob/master/GPIO_181011/obj/SN32F700B.hex)

	2. https://github.com/ywcheng8526/tool_pc/blob/master/GUI_beta_181011/WindowsFormsApplication1/bin/Debug/HQE_pwmGUI.exe

# GPIO_181011

Using P2.5(GPIO) of SONIX MCU as input (for seeting motor rpm) based on different duty rates with the following options:
	1. 100Hz: 0%, 1%, 2%, ..., 99%, 100%; ex. 0x02 0x02 0x02 for 1%
	2. 1KHz: 0%, 20%, 40%, 60%, 80%, 100%; with additional aids to fine tune duty rate for sake of convenience in experiment. 

# Taking commands via UART from pc(an additional RS232-USB convertor would be necessary) to SONIX MCU(UART0). 
# Motor driving part isn't part of this repository. 
