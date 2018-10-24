#ifndef __SN32F700B_SYSTICK_H
#define __SN32F700B_SYSTICK_H


/*_____ I N C L U D E S ____________________________________________________*/
#include <SN32F700B.h>
#include <SN32F700_Def.h>


/*_____ D E F I N I T I O N S ______________________________________________*/
#define	SYSTICK_IRQ		POLLING_METHOD			//INTERRUPT_METHOD:	Enable SysTick timer and interrupt
																					//POLLING_METHOD: 	Enable SysTick timer ONLY
//#define SYSTICK_IRQ   INTERRUPT_METHOD
/*_____ M A C R O S ________________________________________________________*/
#define	__SYSTICK_SET_TIMER_PERIOD(ms)		SysTick->LOAD = SystemCoreClock * ms /1000 - 1
#define	__SYSTICK_CLEAR_COUNTER_AND_FLAG	SysTick->VAL = 0xFF

extern uint64_t tmrCnt;
/*_____ D E C L A R A T I O N S ____________________________________________*/
void SysTick_Init(void);

extern uint32_t usr_Hz_cnt;
#define _100Hz	10
#define _1000Hz	100
#endif	/*__SN32F700B_SYSTICK_H*/
