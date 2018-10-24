;/******************************************************************************
; * @file     CodeOption_SN32F700B.s
; * @brief    Code option setup file for SONIX SN32F700B Device Series
; * @version  V1.0.0
; * @date     2018/01/26
; *------- <<< Use Configuration Wizard in Context Menu >>> ------------------
; *
; * @note
; * Copyright (C) 2017-2018 ARM Limited. All rights reserved.
; *
; * @par
; * ARM Limited (ARM) is supplying this software for use with Cortex-M 
; * processor based microcontrollers.  This file can be freely distributed 
; * within development tools that are supporting such ARM based processors. 
; *
; * @par
; * THIS SOFTWARE IS PROVIDED "AS IS".  NO WARRANTIES, WHETHER EXPRESS, IMPLIED
; * OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, IMPLIED WARRANTIES OF
; * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE APPLY TO THIS SOFTWARE.
; * ARM SHALL NOT, IN ANY CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL, OR
; * CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.
; *
; ******************************************************************************/


    AREA    |.ARM.__at_0x1FFF2000|, CODE, READONLY	;AREA CODE;    Define,CODE,READONLY
; <h> Code Option
;   <o.16..31> Code Security
;		<0x0000=> CS0
;		<0x5A5A=> CS1
;		<0xA5A5=> CS2
;   <o.0> Boot Loader Enable
;		<0=> Enable
;		<1=> Disable
; </h>
Code_Option		EQU		0x00000002




	DCD Code_Option;

	END
