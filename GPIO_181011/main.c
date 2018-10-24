/******************** (C) COPYRIGHT 2018 SONiX *******************************
* COMPANY:		SONiX
* DATE:				2018/01
* AUTHOR:			SA1
* IC:					SN32F700B
*____________________________________________________________________________
*	REVISION	Date				User		Description
*	1.0				2015/08/25	SA1			1. First version released
*																2. Compatible to CMSIS DFP Architecture in Keil MDK v5.X (http://www.keil.com/dd2/pack/)
*																3. Run HexConvert to generate bin file and show checksum after building.
*	1.2				2016/12/02	SA1			1. Fix GPIO_Interrupt in GPIO.c
*	1.4				2017/07/14	SA1			1. Update system_SN32F700B.c to V1.0.3
*																2. Fix __FLASH_LPM_PLL_MODE in Flash.h
*	2.0				2018/01/26	SA1			1. Add NotPinOut_GPIO_init to set the status of the GPIO which are NOT pin-out to input pull-up.
*																2. Add CodeOption_SN32F700B.s to modify Code option, please modify with Configuration Wizard, 
*																	 and Strongly recommend to keep CS0 for debugging with SN-LINK.
*
*____________________________________________________________________________
* THE PRESENT SOFTWARE WHICH IS FOR GUIDANCE ONLY AIMS AT PROVIDING CUSTOMERS
* WITH CODING INFORMATION REGARDING THEIR PRODUCTS TIME TO MARKET.
* SONiX SHALL NOT BE HELD LIABLE FOR ANY DIRECT, INDIRECT OR CONSEQUENTIAL 
* DAMAGES WITH RESPECT TO ANY CLAIMS ARISING FROM THE CONTENT OF SUCH SOFTWARE
* AND/OR THE USE MADE BY CUSTOMERS OF THE CODING INFORMATION CONTAINED HEREIN 
* IN CONNECTION WITH THEIR PRODUCTS.
*****************************************************************************/

/*_____ I N C L U D E S ____________________________________________________*/
#include <SN32F700B.h>
#include <SN32F700_Def.h>
#include "Interface\GPIO\GPIO.h"
#include "Utility\Utility.h"
#include "SysTick\SysTick.h"
#include <SN32F700B.h>
#include "UART\UART.h"
/*_____ D E C L A R A T I O N S ____________________________________________*/
void	NotPinOut_GPIO_init(void);


/*_____ D E F I N I T I O N S ______________________________________________*/
#ifndef	SN32F707B					//Do NOT Remove or Modify!!!
	#error Please install SONiX.SN32F7_DFP.1.4.3.pack or version >= 1.4.3
#endif
#define	PKG		SN32F707B		//User SHALL modify the package on demand (SN32F707B, SN32F706B, SN32F705B, SN32F7051B, SN32F704B, SN32F702B)


/*_____ M A C R O S ________________________________________________________*/


/*_____ F U N C T I O N S __________________________________________________*/
void setDuty(void);
	
/*****************************************************************************
* Function		: main
* Description	: This sample code includes IO toggle, IO config, rising, falling, both, 
								high level and low level trigger.
								Pin assign:
								P2.0 set as rising edge trigger. 
								P2.1 set as falling edge trigger.
								P2.2 set as both edge trigger.
								P2.3 set as high level trigger.
								P2.4 set as low level trigger.
								P2.5 I/O Toggle								
* Input			: None
* Output		: None
* Return		: None
* Note			: None
*****************************************************************************/
uint32_t cnt_limit = 0;
uint32_t cnt_on_1ms = 0;
uint32_t cnt = 0;

uint32_t _t = 0;

void setDuty(void)
{
	cnt_limit 	= 99;
	usr_duty 		= 1;
	
	//1ms of on and 4ms of off (overall 5ms)
	cnt_on_1ms 	= (uint32_t)(((float)cnt_limit / 1000.0) * 200.0); //1ms
}

#define _10us_cnt_limit 1	

uint64_t _10us_max = 0;				


//======1KHz 1%... ?

void _4us(void)
{
	//empty funtion with only high <-> low switching would take up 3~4 us for high signal of 100Hz @ 2ms precision.
}

uint64_t t0 = 0;
uint64_t t1 = 0;
#define bound			107
#define limit			((bound + (bound - 1)) % bound)		

int	main (void)
{
	uint32_t q1 = usr_duty;
	uint32_t q2 = 3;
	uint32_t q3 = 3;
	uint32_t q4 = 3;
	uint32_t q5 = 3;
	uint32_t q6 = 1;
	//User can configure System Clock with Configuration Wizard in system_SN32F700B.c
	SystemInit();
	SystemCoreClockUpdate();				//Must call for SN32F700B, Please do NOT remove!!!

	//Note: User can refer to ClockSwitch sample code to switch various HCLK if needed.

	//1. User SHALL define PKG on demand.
	//2. User SHALL set the status of the GPIO which are NOT pin-out to input pull-up.
	NotPinOut_GPIO_init();

	//--------------------------------------------------------------------------
	//User Code starts HERE!!!
	SysTick_Init();
	
	//GPIO init
	GPIO_Init();
	
	setDuty();
	
	UART0_Init();
	//UART1_Init();
	
	
	while(1)
	{
						
						GPIO_Clr(duty_port, duty_pin);
						q1 = 0; q6 = (23 * usr_duty) + 18;
						if(q2 > 0) q6 += (q2);
						if(q3 > 0) q6 *= (q3);
						if(q4 > 0) q6 /= (q4);
						if(q5 > 0) q6 -= (q5);
						
#if SYSTICK_IRQ == POLLING_METHOD
						if (SysTick->CTRL & SysTick_CTRL_COUNTFLAG_Msk)
						{
							__SYSTICK_CLEAR_COUNTER_AND_FLAG;
							/*
							freq = (freq + 1) % 1000;
							if(q1 > 0)
							{
								q6 = 1;
								if(q4 > 0) q6+= q4;
								if(q5 > 0) q6-= q5;
								if(q9 > 0) q6 *=q9;
								if(q10 > 0) q6 /=q10;
								UT_DelayNx10us(q6);
								q1--;
							}
							*/
							if(q1 == 0)
							{
								GPIO_Set(duty_port, duty_pin);
								while(q1 < q6) 
								{
									q1++;
								}
							}
						}
#endif
						/*
						if(q1 == 0) 
						{
							q1 = usr_duty;
							if(q2 > 0) q1+= q2;
							if(q3 > 0) q1-= q3;
							if(q7 > 0) q1 *=q7;
							if(q8 > 0) q1 /=q8;
							UT_DelayNx10us(q1);
						}
						*/
#if 0
		switch(opt)
		{
			case 0:	
				switch(t0)
				{
					case 0:
						break;
					case 4:
						if(usr_duty < 100)
						{
							t1 = 21;
							SN_GPIO2->BCLR|=(1<<5);//Clr
						}
						break;
					case limit:
						if(usr_duty > 0)
						{
							t1 = usr_duty * 1;
							SN_GPIO2->BSET|=(1<<5);//Set
						}
						break;
				}
				while(t1){t1--;}
				t0 = (t0 + 1) % bound;
				break;
			case 3:
				if(cnt > (cnt_on_1ms * usr_duty))
				{
					GPIO_Clr(duty_port, duty_pin);
				}else
				{
					if(usr_duty != 0)
					{
						//if(cnt == (cnt_on_1ms * usr_duty))
						{
							GPIO_Set(duty_port, duty_pin);
						}
					}
				}
				cnt = (cnt + 1) % cnt_limit;
				break;
			case 1:
#if SYSTICK_IRQ == POLLING_METHOD
				if (SysTick->CTRL & SysTick_CTRL_COUNTFLAG_Msk)
				{
					__SYSTICK_CLEAR_COUNTER_AND_FLAG;
					usr_Hz_cnt = (usr_Hz_cnt + 1) % _1000Hz;
		
					_10us_cnt = _10us_cnt_limit;
					_10us_cnt *= (42);
					_10us_cnt *= usr_duty;

#if 1				
					switch((usr_duty / 10))
					{
						case 0:
							_10us_cnt += 2;
							break;
						case 1:
							_10us_cnt += 14;
							break;
						case 2:
							_10us_cnt += 24;
							break;
						case 3:
							_10us_cnt += 40;
							break;
						case 4:
							_10us_cnt += 46;
							break;
						case 5:
							_10us_cnt += 53;
							break;
						case 6:
							_10us_cnt += 60;
							break;
						case 7:
							_10us_cnt += 71;
							break;
						case 8:
							_10us_cnt += 94;
							break;
						case 9:
							_10us_cnt += 94;
							break;
					}
#endif					
					
					_10us_cnt += quick_fix;
					
					if(_10us_cnt > (5 *quick_fix1))
					{
						_10us_cnt-=(5 *quick_fix1);
					}
					
					_10us_max = _10us_cnt;
					
					if(usr_duty > 0)
					{
						if(_10us_cnt == _10us_max)
						{
							GPIO_Set(duty_port, duty_pin);
						}
						while(_10us_cnt)
						{
							_10us_cnt--;
						}
					}
					
					if(usr_duty < 100)
					{
						GPIO_Clr(duty_port, duty_pin);
					}				
				}
				
#endif
				break;
		}
#endif		
	}
}

/*****************************************************************************
* Function		: NotPinOut_GPIO_init
* Description	: Set the status of the GPIO which are NOT pin-out to input pull-up. 
* Input				: None
* Output			: None
* Return			: None
* Note				: 1. User SHALL define PKG on demand.
*****************************************************************************/
void	NotPinOut_GPIO_init(void)
{
#if (PKG == SN32F706B)
	//set P0.0~P0.1 to input pull-up
	SN_GPIO0->CFG = 0xAAAAA0;
#elif (PKG == SN32F705B)
	//set P0.0~P0.1 to input pull-up
	SN_GPIO0->CFG = 0x00AAAAA0;
	//set P1.5, P1.8~P1.11 to input pull-up
	SN_GPIO1->CFG = 0x0000A2AA;
	//set P2.5~P2.9 to input pull-up
	SN_GPIO2->CFG = 0x000002AA;
	//set P3.0~P3.3 to input pull-up
	SN_GPIO3->CFG = 0x000AAA00;
#elif (PKG == SN32F7051B)
	//set P0.6~P0.7 to input pull-up
	SN_GPIO0->CFG = 0x00AA0AAA;
	//set P1.5, P1.8~P1.11 to input pull-up
	SN_GPIO1->CFG = 0x0000A2AA;
	//set P2.8~P2.9 to input pull-up
	SN_GPIO2->CFG = 0x0000AAAA;
	//set P3.0~P3.5 to input pull-up
	SN_GPIO3->CFG = 0x000AA000;
#elif (PKG == SN32F704B)
	//set P0.0~P0.1, P0.3 to input pull-up
	SN_GPIO0->CFG = 0x00AAAA20;
	//set P1.5, P1.8~P1.11 to input pull-up
	SN_GPIO1->CFG = 0x0000A2AA;
	//set P2.2~P2.9 to input pull-up
	SN_GPIO2->CFG = 0x0000000A;
	//set P3.0~P3.3 to input pull-up
	SN_GPIO3->CFG = 0x000AAA00;
#elif (PKG == SN32F702B)
	//set P0.3~P0.9 to input pull-up
	SN_GPIO0->CFG = 0x00A0002A;
	//set P1.5, P1.8, P1.10~P1.11 to input pull-up
	SN_GPIO1->CFG = 0x0008A2AA;
	//set P2.3~P2.9 to input pull-up
	SN_GPIO2->CFG = 0x0000002A;
	//set P3.0~P3.5, P3.7~P3.9 to input pull-up
	SN_GPIO3->CFG = 0x00002000;
#endif
}

/*****************************************************************************
* Function		: HardFault_Handler
* Description	: ISR of Hard fault interrupt
* Input			: None
* Output		: None
* Return		: None
* Note			: None
*****************************************************************************/
__irq void HardFault_Handler(void)
{
	NVIC_SystemReset();
}

