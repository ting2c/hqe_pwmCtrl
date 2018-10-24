#ifndef __SN32F700B_FLASH_H
#define __SN32F700B_FLASH_H

/*_____ I N C L U D E S ____________________________________________________*/
#include <SN32F700B.h>
#include "SN32F700_Def.h"


/*_____ D E F I N I T I O N S ______________________________________________*/
//FLASH HW
#define	FLASH_PAGE_SIZE							64
#define	FLASH_F700B_MAX_ROM_SIZE		0x7FFF


// Flash Control Register definitions
#define FLASH_PG										0x00000001
#define FLASH_PER										0x00000002
#define FLASH_MER										0x00000004
#define FLASH_START									0x00000040
#define FLASH_CHK										0x00000080

// Flash Status Register definitions
#define FLASH_BUSY									0x00000001
#define FLASH_ERR										0x00000004

#define	FLASH_WAIT_FOR_DONE		while (SN_FLASH->STATUS & FLASH_BUSY) {__nop();}


/*_____ M A C R O S ________________________________________________________*/

//Flash Low Power Mode
#define	__FLASH_LPM_DISABLE					SN_FLASH->LPCTRL = 0x5AFA0000;		//HCLK<=12MHz
#define	__FLASH_LPM_SLOW_MODE				SN_FLASH->LPCTRL = 0x5AFA0002;		//HCLK<=8KHz
#define	__FLASH_LPM_MEDIUM_MODE			SN_FLASH->LPCTRL = 0x5AFA0003;		//12MHz<HCLK<=24MHz
#define	__FLASH_LPM_PLL_MODE				SN_FLASH->LPCTRL = 0x5AFA0004;SN_FLASH->LPCTRL = 0x5AFA0005;SN_FLASH->LPCTRL = 0x5AFA000D;
#define	__FLASH_LPM_FAST_MODE				SN_FLASH->LPCTRL = 0x5AFA000D;		//HCLK>24MHz

//Flash Status
#define	__FLASH_CLEAR_ERROR_STATUS	SN_FLASH->STATUS &= ~FLASH_PGERR


/*_____ D E C L A R A T I O N S ____________________________________________*/
extern	uint32_t wFLASH_PGRAM[2];

void FLASH_MassErase (void);
void FLASH_EraseSector (uint32_t);
uint32_t FLASH_ProgramPage (uint32_t, uint32_t, uint8_t *);
uint16_t FLASH_Checksum(void);

#endif	/* __SN32F700B_FLASH_H */
