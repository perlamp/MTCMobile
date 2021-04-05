//updated 23 nov 16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProtocolC1218
{
    public class c1218
    {
        crc CRC = new crc();
        timer TIMER = new timer();

        /*
         ******************************************************************************
         * Constant Definitions
         ******************************************************************************
         */
        private const UInt16 constBri=1;

        /*===========================================================================*\
         * Communication channel settings
        \*===========================================================================*/
        public const UInt16 C1218_PACKET_OVERHEAD = 18;
        public const UInt16 C1218_DLL_OVERHEAD = 9;
        public const UInt16 C1218_PASS_LENGTH = 20;
        public const UInt16 C1218_USER_LENGTH = 10;
        public const UInt16 C1218_LOGON_TIMEOUT = 1000 * 60 / constBri;      //1 min
        public const UInt16 C1218_CHANNEL_TRAFIC_TIMEOUT = 6000 / constBri;      // 6 seconds
        public const UInt16 C1218_INTER_CHARACTER_TIMEOUT = 510 / constBri;    // 510 miliseconds
        public const UInt16 C1218_RESPONSE_TIMEOUT = (4 * 1000) / constBri;      // 2 seconds
        public const UInt16 C1218_MAX_NUM_RESPONSE = 3;

        /*===========================================================================*\
         *  C1218 packets lenght definition
        \*===========================================================================*/
        public const Byte C1218_NUM_PACKETS = 50;
        public const UInt16 C1218_PACKET_SIZE = 160;
        public const UInt16 C1218_APL_SIZE = C1218_NUM_PACKETS * C1218_PACKET_SIZE;

        public const UInt16 C1218_TX_BUFFER_LENGTH = 128;    /* Number of tx bytes. */
        public const UInt16 C1218_RX_BUFFER_LENGTH = 128;    /* Number of rx bytes. */

        /*===========================================================================*\
         *
         * 4.2. Layer 7—application layer APL
         *
         * 4.2.2. Language—protocol specifications for electric metering (“PSEM”)
         * The PSEM language consists of 9 services. Each service consists of a request and a response.
         * Each of these requests and responses is described in following service clauses.
         *
         * <requests>		::= <ident> | {Identification request}
         *						<read> | {Read request}
         *						<write> | {Write request}
         *						<logon> | {Logon request}
         *						<security> | {Security request}
         *						<logoff> | {Logoff request}
         *						<negotiate> | {Negotiate request}
         *						<wait> | {Wait request}
         *						<terminate> | {Terminate request}
         *
         * <responses>		::= <ident_r> | {Identification response}
         *						<read_r> | {Read response}
         *						<write_r> | {Write response}
         *						<logon_r> | {Logon response}
         *						<security_r> | {Security response}
         *						<logoff_r> | 333 {Logoff response}
         *						<negotiate_r> | {Negotiate response}
         *						<wait_r> | {Wait response}
         *						<terminate_r> | {Terminate response}
         *
         * 4.2.2.1. Request codes
         *
         * PSEM requests always include a one byte request code. Code numbers are assigned as follows:
         *
         * 00H-1FH Codes shall not be used to avoid confusion with response codes
         * 20H-7FH Codes are available for use within optical port protocol
         * 80H-FFH Codes shall be reserved for protocol extensions
         *
         * 4.2.2.2. Response codes
         *
         * PSEM responses always include a one byte response code. These codes are defined as follows:
         * 
         * <nok>	::= <err>|<sns>|<isc>|<onp>|<iar>|<bsy>|<dnr>|<dlk>|<rno>|<isss>
         *
         * <ok>		::= 00H		{Acknowledge—No problems, request accepted.}
         * <err>	::= 01H		{Error—This code is used to indicate rejection of the
         *						received service request. The reason for the rejection is
         *						not provided.}
         *
         * <sns>	::= 02H		{Service Not Supported—This application level error
         *						response will be sent to the device when the requested
         *						service is not supported. This error indicates that the
         *						message was valid, but the request could not be
         *						honored.}
         *
         * <isc>	::= 03H		{Insufficient Security Clearance—This application level
         *						error indicates that the current authorization level is
         *						insufficient to complete the request.}
         *
         * <onp>	::= 04H		{Operation Not Possible—This application level error will
         *						be sent to the device which requested an action that is
         *						not possible. This error indicates that the message was
         *						valid, but the message could not be processed. Covers
         *						conditions such as: Invalid Length, Invalid Offset}
         *
         * <iar>	::= 05H		{Inappropriate Action Requested—This application level
         *						error indicates that the action requested was
         *						inappropriate. Covers conditions such as write request
         *						to a read only table or an invalid table id.}
         *
         * <bsy>	::= 06H		{Device Busy—This application level error indicates that
         *						the request was not acted upon because the device was
         *						busy doing something else.}
         *
         * <dnr>	::= 07H		{Data Not Ready—This application level 385 error indicates
         *						that request was unsuccessful because the requested
         *						data is not ready to be accessed.}
         *
         * <dlk>	::= 08H		{Data Locked—This application level error indicates that
         *						the request was unsuccessful because the data cannot
         *						be accessed.}
         *
         * <rno>	::= 09H		{Renegotiate Request—This application level error
         *						indicates that the responding device wishes to return to
         *						the ID or base state and re-negotiate communication
         *						parameters.}
         *
         * <isss>	::= 0AH		{Invalid Service Sequence State—This application level
         *						error indicates that the request is not accepted at the
         *						current service sequence state. For more information on
         *						service sequence states, see Annex D.}
         *
         *				0BH-1FH {Codes are currently undefined, but are available for use within
         *						optical port protocol}
         *
         *				20H-7FH {Codes shall not be used to avoid confusion with request
         *						codes}
         *
         *				80H-FFH {Codes shall be reserved for protocol extensions}
         *
        \*===========================================================================*/

        /*===========================================================================*\
         * Services request codes:
        \*===========================================================================*/
        public const Byte IDENTIFICATION = 0x20;
        public const Byte FULL_READ = 0x30;
        public const Byte PREAD_OFFSET = 0x3F;
        public const Byte FULL_WRITE = 0x40;
        public const Byte PWRITE_OFFSET = 0x4F;
        public const Byte LOGON = 0x50;
        public const Byte SECURITY = 0x51;
        public const Byte LOGOFF = 0x52;
        public const Byte NEGOTIATE = 0X60;
        public const Byte WAIT = 0x70;
        public const Byte TERMINATE = 0x21;

        /*===========================================================================*\
         *  4.2.2.2. Response codes
        \*===========================================================================*/
        public const Byte C1218_OK = 0x00;
        public const Byte C1218_ERR = 0x01;
        public const Byte C1218_SNS = 0x02;
        public const Byte C1218_ISC = 0x03;
        public const Byte C1218_ONP = 0x04;
        public const Byte C1218_IAR = 0x05;
        public const Byte C1218_BSY = 0x06;
        public const Byte C1218_DNR = 0x07;
        public const Byte C1218_DLK = 0x08;
        public const Byte C1218_RNO = 0x09;
        public const Byte C1218_ISSS = 0x0A;

        public const Byte RESPONSE_CODE_INDEX = 0x00;
        public const Byte SERVICE_INDEX = 0x00;
        public const Byte SERVICE_R_OK = 0x00;
        public const Byte SERVICE_R_INDEX = 0x00;
        public const Byte STD = 0x00;	// 0x00 = C12.18
        public const Byte STD_INDEX = 0x01;
        public const Byte VER = 0x01;
        public const Byte VER_INDEX = 0x02;
        public const Byte REV = 0x00;
        public const Byte REV_INDEX = 0x03;
        public const Byte END_OF_LIST = 0x00;
        public const Byte END_OF_LIST_INDEX = 0x04;

        /*===========================================================================*\
         * C1218 Packet definition:
         *
         * <stp> <identity> <ctrl> <seq_nbr> <length> <data> <crc>
         * 1byte   1byte    1byte   1byte    2byte    n-byte  2byte
         *                                               
         * <stp>		::= EEH		{Start of packet character.}
         * <identity>	::= <byte>	{ C12.19 Device (end-device, table driven
         *							communication card, etc.) identity. It identifies
         *							the C12.19 Device in both the request and
         *							response packets.
         * <ctrl>		::= <byte>	{Control field.
         *							Bit 7. If true (1H) then this packet is part of a
         *							multiple packet transmission.
         *							
         *							Bit 6. If true (1H) then this packet is the first
         *							packet of a multiple packet transmission.
         *							
         *							Bit 5. Represents a toggle bit to reject duplicate
         *							packets. This bit shall be toggled for each new
         *							packet sent. Retransmitted packets keep the
         *							same state as the original packet sent. It should
         *							be noted that the initial state of the toggle bit is
         *							not specified and could initially be either 0 or 1.
         *							Bits 4 to 2, Reserved. The bits shall be set to
         *
         *							zero by the transmitter.
         *							Bit 0 to 1: DATA_FORMAT
         *							0 = C12.18 or C12.21
         *							1 = C12.22
         *							2 = Reserved
         *							3 = Reserved
         *
         *							C12.18 Compliant implementations shall set Bits
         *							0 and 1 to 0.}
         *
         * <length>		::= <word16> {Number of bytes of data in packet.}
         *
         * <data>		::= <byte>+ 1130 {<length> number of bytes of actual packet
         *							data. This value is limited by the maximum
         *							packet size minus the packet overhead of 8
         *							bytes. This value can never exceed 8183.}
         *
         * <crc>		::= <word16> {CCITT CRC standard polynomial X^16 + X^12 + X^5 + 1}
         *
         *
         * A duplicate packet is defined as a packet whose identity, toggle bit and valid
         * CRC are identical to those of the immediate previous packet. If a duplicate packet
         * is received by the target device, the target should disregard the duplicate packet
         * and return an <ack>. At the start of session, the toggle bit in the first packet
         * may assume either state.
         *
        \*===========================================================================*/
        public const Byte C1218_HEADER_LENGTH = 0x07;
        public const Byte C1218_STP = 0xEE;
        public const Byte C1218_ACK = 0x06;
        public const Byte C1218_NOK = 0x15;

        /*===========================================================================*\
         * C1218 Data positions in the frame
        \*===========================================================================*/
        public const Byte C1218_STP_INDEX = 0x00;
        public const Byte C1218_IDENTITY_INDEX = 0x01;
        public const Byte C1218_CTRL_INDEX = 0x02;
        public const Byte C1218_SEQ_NBR_INDEX = 0x03;
        public const Byte C1218_LENGTH_H_INDEX = 0x04;
        public const Byte C1218_LENGTH_L_INDEX = 0x05;
        public const Byte C1218_DATA_INDEX = 0x06;

        /*===========================================================================*\
         * C1218 Procedure data positions in the frame
        \*===========================================================================*/
        public const Byte PROCEDURE_OVERHEAD_SIZE = 3;
        public const Byte PROCEDURE_ID_INDEX = 5;
        public const Byte PROCEDURE_SEQ_NBR_INDEX = 7;
        public const Byte PROCEDURE_PARAMETER_INDEX = 8;

        public const Byte PROC_COMPLETED = 0;
        public const Byte PROC_ACCEPTED_NOT_COMPLETED = 1;
        public const Byte INVALID_PARAMETER = 2;
        public const Byte PROC_CONFLICT_WITH_SET_UP = 3;
        public const Byte PROC_IGNORED_TIME_CONSTRAIN = 4;
        public const Byte PROC_IGNORED_NO_AUTHORIZATION = 5;
        public const Byte PROC_IGNORED_UNRECOGNIZED_PROC = 6;

        /*
         ******************************************************************************
         * Enumerations and Structures and Typedefs                          
         ******************************************************************************
         */

        /*===========================================================================*\
         * C1218 Device Mode
        \*===========================================================================*/
        public enum c1218_device_mode : byte
        {
            END_DEVICE = 0x00,
            REQUESTER
        };

        /*===========================================================================*\
         * C1218 Application link layer state
        \*===========================================================================*/
        public enum c1218_apl_state : byte
        {
            BASE_STATE = 0x00,
            ID_STATE,
            SESSION_STATE,
        };

        /*===========================================================================*\
         * C1218 Data link layer rx state
        \*===========================================================================*/
        public enum c1218_dll_rx_state
        {
            C1218_RX_IDLE = 0x00,
            C1218_RX_STP,
            C1218_RX_IDENTITY,
            C1218_RX_CTRL,
            C1218_RX_SEQ_NBR,
            C1218_RX_LENGTH_H,
            C1218_RX_LENGTH_L,
            C1218_RX_DATA,
            C1218_RX_CRC_H,
            C1218_RX_CRC_L,
        };

        /*===========================================================================*\
         * C1218 Data link layer tx state
        \*===========================================================================*/
        public enum c1218_dll_tx_state
        {
            C1218_TX_IDLE = 0x00,
            C1218_TX_STP,
            C1218_TX_IDENTITY,
            C1218_TX_CTRL,
            C1218_TX_SEQ_NBR,
            C1218_TX_LENGTH_H,
            C1218_TX_LENGTH_L,
            C1218_TX_DATA,
            C1218_TX_CRC_H,
            C1218_TX_CRC_L,
            C1218_TX_WAITING_ACK,
        };

        public delegate void Callback();              // Function pointer typedef

        public struct c1218_services_pfunctions_type
        {
            public Callback identification;
            public Callback negotiate;
            public Callback logon;
            public Callback security;
            public Callback full_read;
            public Callback pread_offset;
            public Callback full_write;
            public Callback pwrite_offset;
            public Callback logoff;
            public Callback wait;
            public Callback terminate;
        };

        public struct c1218_user_pfunctions_type
        {
            public timer.Callback resend_response;
            public timer.Callback rx_abort;
            public timer.Callback tx_abort;
            public timer.Callback terminate_logon_session;
        };

        public struct c1218_control_type
        {
            //public xTaskHandle os_task_id;
            public timer.ms_timer_id_type logon_timer;
            public timer.ms_timer_id_type waiting_ack_timer;
            public timer.ms_timer_id_type response_timeout_timer; 
            public timer.ms_timer_id_type max_response_timeout_timer;
            public Boolean waiting_ack;
            public UInt16 apl_num_packets;
            public UInt16 apl_packet_size;
            public UInt16 dll_data_size;
            public Byte response_counter;
            public c1218_apl_state session_state;
            public UInt16 user_id;
            public Byte[] user;
            public Byte[] password;
            public c1218.c1218_device_mode device_mode;
        };

        public struct c1218_data_type
        {
            public Byte[] rx_data;
            public Byte[] tx_data;
        };

        public struct c1218_dll_type
        {
            public Byte rx_byte;
            public c1218_dll_rx_state rx_state;
            public Byte rx_error;
            public bool rx_ongoing;
            public bool rx_eop;
            public timer.ms_timer_id_type rx_timer;
            public timer.ms_timer_id_type ack_rx_timer;

            public UInt16 rx_data_length;
            public UInt16 rx_data_bytes;
            public UInt16 rx_data_bytes_remaining;
            public UInt16 rx_data_offset;

            public Byte[] rx_buffer;
            public UInt16 rx_buffer_bytes;
            public UInt16 rx_buffer_crc;

            public UInt16 rx_buffer_previous_crc;
            public Byte rx_buffer_previous_identity;
            public Byte rx_buffer_previous_toggle_bit;

            public Byte tx_byte;
            public c1218_dll_tx_state tx_state;
            public Byte tx_error;
            public Boolean tx_ongoing;
            public Boolean tx_eop;
            public timer.ms_timer_id_type tx_timer;
            public timer.ms_timer_id_type ack_tx_timer;

            public UInt16 tx_data_length;
            public UInt16 tx_data_bytes;
            public UInt16 tx_data_bytes_remaining;
            public UInt16 tx_data_offset;

            public Byte[] tx_buffer;
            public UInt16 tx_buffer_bytes;
            public UInt16 tx_buffer_crc;

            public Byte toggle_bit;
            public Byte[] st_08_data;
            public UInt16 st_08_length;

            public Boolean interrupt_context;
        };

        public struct c1218_hw_type
        {
            public System.IO.Ports.SerialPort serial_port;
        };

        public struct c1218_type
        {
            public c1218_services_pfunctions_type service;
            public c1218_control_type control;
            public c1218_data_type data;
            public c1218_dll_type dll;
            public c1218_user_pfunctions_type ufunction;
            public c1218_hw_type hw;
        };

        /*
         ******************************************************************************
         * Function Definitions
         ******************************************************************************
         */

        /** 
         ******************************************************************************
         * \fn void APP_vStruct_initialize(ref c1218_type c1218_client)
         * \brief 
         *
         * 
         *
         * \param *c1218_dll
         *	Pointer to ram memory location where C1218_DLL_TYPE packet is stored.
         * \retval void
         ******************************************************************************
         */
        public void APP_vStruct_initialize(ref c1218_type c1218_client)
        {
            /* Control structure initialization */
            c1218_client.control.session_state = c1218_apl_state.BASE_STATE;
            TIMER.reset_ms_timer((Byte)c1218_client.control.logon_timer);
            TIMER.reset_ms_timer((Byte)c1218_client.control.waiting_ack_timer);

            /* Data structure initialization */
            c1218_client.data.rx_data = new Byte[C1218_APL_SIZE];
            c1218_client.data.tx_data = new Byte[C1218_APL_SIZE];

            /* DLL structure initialization */
            c1218_client.dll.rx_state = (Byte)c1218_dll_rx_state.C1218_RX_IDLE;
            c1218_client.dll.rx_error = 0;
            c1218_client.dll.rx_eop = false;
            c1218_client.dll.rx_data_length = 0;
            c1218_client.dll.rx_data_bytes = 0;
            c1218_client.dll.rx_data_bytes_remaining = 0;
            c1218_client.dll.rx_buffer_bytes = 0;
            c1218_client.dll.rx_ongoing = false;
            c1218_client.dll.rx_buffer = new Byte[C1218_PACKET_SIZE + C1218_PACKET_OVERHEAD];
            TIMER.reset_ms_timer((Byte)c1218_client.dll.rx_timer);

            c1218_client.dll.tx_state = (Byte)c1218_dll_tx_state.C1218_TX_IDLE;
            c1218_client.dll.tx_error = 0;
            c1218_client.dll.tx_eop = false;
            c1218_client.dll.tx_data_length = 0;
            c1218_client.dll.tx_data_bytes = 0;
            c1218_client.dll.tx_data_bytes_remaining = 0;
            c1218_client.dll.tx_buffer_bytes = 0;
            c1218_client.dll.tx_ongoing = false;
            c1218_client.dll.tx_buffer = new Byte[C1218_PACKET_SIZE + C1218_PACKET_OVERHEAD];
            TIMER.reset_ms_timer((Byte)c1218_client.dll.tx_timer);
        }

        /** 
         ******************************************************************************
         * \fn void APP_vService_execute(ref c1218_type c1218_client)
         * \brief
         *
         * 
         *
         * \param *c1218_apl
         *	Pointer to ram memory location where C1218_APL_TYPE packet is stored.
         * \param *c1218_dll
         *	Pointer to ram memory location where C1218_DLL_TYPE packet is stored.
         * \retval void
         ******************************************************************************
         */
        public void APP_vService_execute(ref c1218_type c1218_client)
        {
            Byte error_id;

            switch (c1218_client.control.session_state)
            {
                case c1218_apl_state.BASE_STATE:
                    switch (c1218_client.data.rx_data[SERVICE_INDEX])
                    {
                        case IDENTIFICATION:
                            c1218_client.service.identification();
                            break;

                        case NEGOTIATE:
                        case LOGON:
                        case SECURITY:
                        case FULL_READ:
                        case PREAD_OFFSET:
                        case FULL_WRITE:
                        case PWRITE_OFFSET:
                        case LOGOFF:
                        case WAIT:
                        case TERMINATE:
                            error_id = C1218_ISSS;
                            APP_vSend_error_response(ref c1218_client, error_id);
                            break;

                        default:
                            break;
                    }
                    break;

                case c1218_apl_state.ID_STATE:
                    switch (c1218_client.data.rx_data[SERVICE_INDEX])
                    {
                        case NEGOTIATE:
                            c1218_client.service.negotiate();
                            break;

                        case WAIT:
                            c1218_client.service.wait();
                            break;

                        case TERMINATE:
                            c1218_client.service.terminate();
                            break;

                        case LOGON:
                            c1218_client.service.logon();
                            break;

                        case IDENTIFICATION:
                        case SECURITY:
                        case FULL_READ:
                        case PREAD_OFFSET:
                        case FULL_WRITE:
                        case PWRITE_OFFSET:
                        case LOGOFF:
                            error_id = C1218_ISSS;
                            APP_vSend_error_response(ref c1218_client, error_id);
                            break;

                        default:
                            break;
                    }
                    break;

                case c1218_apl_state.SESSION_STATE:
                    TIMER.start_ms_timer((Byte)c1218_client.control.logon_timer, C1218_LOGON_TIMEOUT, c1218_client.ufunction.terminate_logon_session);
                    switch (c1218_client.data.rx_data[SERVICE_INDEX])
                    {
                        case FULL_READ:
                            c1218_client.service.full_read();
                            break;

                        case PREAD_OFFSET:
                            c1218_client.service.pread_offset();
                            break;

                        case FULL_WRITE:
                            c1218_client.service.full_write();
                            break;

                        case PWRITE_OFFSET:
                            c1218_client.service.pwrite_offset();
                            break;

                        case SECURITY:
                            c1218_client.service.security();
                            break;

                        case WAIT:
                            c1218_client.service.wait();
                            break;

                        case TERMINATE:
                            c1218_client.service.terminate();
                            break;

                        case LOGOFF:
                            c1218_client.service.logoff();
                            break;

                        case IDENTIFICATION:
                        case NEGOTIATE:
                        case LOGON:
                            error_id = C1218_ISSS;
                            APP_vSend_error_response(ref c1218_client, error_id);
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    c1218_client.dll.rx_eop = false;
                    error_id = C1218_ERR;
                    APP_vSend_error_response(ref c1218_client, error_id);
                    break;
            }

            APP_vService_state_check(ref c1218_client);
        }

        /**
         ******************************************************************************
         * \fn void APP_vSend_response(ref c1218_type c1218_client)
         * \brief Put the first byte of the packet to the usart.
         *
         * Once the first byte is placed on the usart tx register, it will trigger
         * the usart tx register transmit complete interrupt, and the rest of the bytes of the frame
         * are transmitted in tx interrupt service routine.
         *
         * \param *c1218_dll
         *	Pointer to ram memory location where C1218_TYPE packet is stored.
         * \retval void
         ******************************************************************************
         */
        public void APP_vSend_response(ref c1218_type c1218_client)
        {
            UInt16 crc_calc;

            if (c1218_client.dll.tx_state == c1218_dll_tx_state.C1218_TX_IDLE)
            {
                if (c1218_client.dll.toggle_bit == 0x00)
                {
                    c1218_client.dll.toggle_bit = 0x20;
                }
                else
                {
                    c1218_client.dll.toggle_bit = 0x00;
                }

                c1218_client.dll.interrupt_context = true;
                c1218_client.dll.tx_error = 0;
                c1218_client.dll.tx_eop = false;
                c1218_client.dll.tx_buffer_bytes = 0;

                c1218_client.dll.tx_buffer[C1218_STP_INDEX] = C1218_STP;
                if (c1218_client.control.device_mode == c1218_device_mode.END_DEVICE)
                {
                    c1218_client.dll.tx_buffer[C1218_IDENTITY_INDEX] = c1218_client.dll.rx_buffer[C1218_IDENTITY_INDEX];
                }
                c1218_client.dll.tx_buffer[C1218_CTRL_INDEX] = c1218_client.dll.toggle_bit;
                c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] = 0;
                c1218_client.dll.tx_data_bytes_remaining = c1218_client.dll.tx_data_length;
                c1218_client.dll.tx_data_offset = 0;

                if (c1218_client.dll.tx_data_length > (C1218_PACKET_SIZE))
                {
                    c1218_client.dll.tx_data_bytes_remaining = C1218_PACKET_SIZE;

                    // Set first packet
                    c1218_client.dll.tx_buffer[C1218_CTRL_INDEX] |= 0xC0;

                    if ((c1218_client.dll.tx_data_length - c1218_client.dll.tx_data_bytes_remaining) % C1218_PACKET_SIZE == 0)
                    {
                        // Perfect divisor
                        c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] = (Byte)((c1218_client.dll.tx_data_length - c1218_client.dll.tx_data_bytes_remaining) / C1218_PACKET_SIZE);
                    }
                    else
                    {
                        // The number doesn't divide perfectly by divisor
                        c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] = (Byte)(1 + (c1218_client.dll.tx_data_length - c1218_client.dll.tx_data_bytes_remaining) / C1218_PACKET_SIZE);
                    }
                }

                c1218_client.dll.tx_buffer[C1218_LENGTH_H_INDEX] = (Byte)(c1218_client.dll.tx_data_bytes_remaining >> 8);
                c1218_client.dll.tx_buffer[C1218_LENGTH_L_INDEX] = (Byte)(c1218_client.dll.tx_data_bytes_remaining & 0x00FF);

                Array.Copy(c1218_client.data.tx_data, 0, c1218_client.dll.tx_buffer, C1218_DATA_INDEX, c1218_client.dll.tx_data_bytes_remaining);
                crc_calc = CRC.calc_crc16(c1218_client.dll.tx_buffer, (UInt16)(c1218_client.dll.tx_data_bytes_remaining + 6));

                c1218_client.dll.tx_buffer[c1218_client.dll.tx_data_bytes_remaining + 6] = (Byte)(crc_calc >> 8);
                c1218_client.dll.tx_buffer[c1218_client.dll.tx_data_bytes_remaining + 7] = (Byte)(crc_calc & 0x00FF);

                c1218_client.dll.tx_ongoing = true;

                TIMER.start_ms_timer((Byte)c1218_client.dll.tx_timer, C1218_INTER_CHARACTER_TIMEOUT, c1218_client.ufunction.tx_abort);
                c1218_client.control.response_counter = 0;
                c1218_client.dll.interrupt_context = false;

                c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_STP;
                for (UInt16 i = 0; i < c1218_client.dll.tx_data_length + 8; i++)
                {
                    APP_vTx_int_handler(ref c1218_client);
                }
            }
        }

        /**
         ******************************************************************************
         * \fn void APP_vResend_response(ref c1218_type c1218_client)
         * \brief Put the first byte of the packet to the usart.
         *
         * Once the first byte is placed on the usart tx register, it will trigger
         * the usart tx register transmit complete interrupt, and the rest of the bytes of the frame
         * are transmitted in tx interrupt service routine.
         *
         * \param *c1218_dll
         *	Pointer to ram memory location where C1218_DLL_TYPE packet is stored.
         * \retval void
         ******************************************************************************
         */
        public void APP_vResend_response(ref c1218_type c1218_client)
        {
            if (c1218_client.control.waiting_ack == true)
            {
                if (c1218_client.control.response_counter < C1218_MAX_NUM_RESPONSE)
                {
                    c1218_client.dll.tx_ongoing = true;
                    c1218_client.control.response_counter++;

                    c1218_client.dll.interrupt_context = true;
                    c1218_client.dll.tx_error = 0;
                    c1218_client.dll.tx_eop = false;
                    c1218_client.dll.tx_buffer_bytes = 0;
                    c1218_client.dll.tx_data_bytes_remaining = c1218_client.dll.tx_data_length;

                    TIMER.start_ms_timer((Byte)c1218_client.dll.tx_timer, C1218_INTER_CHARACTER_TIMEOUT, c1218_client.ufunction.tx_abort);
                    c1218_client.dll.interrupt_context = false;

                    c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_STP;
                    for (UInt16 i = 0; i < c1218_client.dll.tx_data_length + 8; i++)
                    {
                        APP_vTx_int_handler(ref c1218_client);
                    }

                }
                else
                {
                    TIMER.reset_ms_timer((Byte)c1218_client.control.waiting_ack_timer);
                    APP_vTerminate_logon_session(ref c1218_client);
                }
            }
        }

        /**
         ******************************************************************************
         * \fn void APP_vSend_next_packet((ref c1218_type c1218_client)
         * \brief Put the first byte of the packet to the usart.
         *
         * Once the first byte is placed on the usart tx register, it will trigger
         * the usart tx register empty interrupt, and the rest of the bytes of the frame
         * are transmitted in this interrupt service routine.
         *
         * \param *c1218
         *	Pointer to ram memory location where packet is stored.
         * \retval void
         ******************************************************************************
         */
        void APP_vSend_next_packet(ref c1218_type c1218_client)
        {
            UInt16 crc_calc;

            if ((c1218_client.dll.tx_state == c1218_dll_tx_state.C1218_TX_IDLE) && (c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] > 0))
            {
                if (c1218_client.dll.toggle_bit == 0x00)
                {
                    c1218_client.dll.toggle_bit = 0x20;
                }
                else
                {
                    c1218_client.dll.toggle_bit = 0x00;
                }

                c1218_client.dll.interrupt_context = true;
                c1218_client.dll.tx_error = 0;
                c1218_client.dll.tx_eop = false;
                c1218_client.dll.tx_buffer_bytes = 0;

                c1218_client.dll.tx_data_offset += C1218_PACKET_SIZE;
                c1218_client.dll.tx_buffer[C1218_STP_INDEX] = C1218_STP;
                if (c1218_client.control.device_mode == c1218_device_mode.END_DEVICE)
                {
                    c1218_client.dll.tx_buffer[C1218_IDENTITY_INDEX] = c1218_client.dll.rx_buffer[C1218_IDENTITY_INDEX];
                }
                c1218_client.dll.tx_buffer[C1218_CTRL_INDEX] = c1218_client.dll.toggle_bit;
                c1218_client.dll.tx_buffer[C1218_CTRL_INDEX] |= 0x80;
                c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX]--;

                if (c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] > 0)
                {
                    c1218_client.dll.tx_data_bytes_remaining = C1218_PACKET_SIZE;
                }
                else
                {
                    c1218_client.dll.tx_data_bytes_remaining = (UInt16)(c1218_client.dll.tx_data_length - c1218_client.dll.tx_data_offset);
                }

                c1218_client.dll.tx_buffer[C1218_LENGTH_H_INDEX] = (Byte)(c1218_client.dll.tx_data_bytes_remaining >> 8);
                c1218_client.dll.tx_buffer[C1218_LENGTH_L_INDEX] = (Byte)(c1218_client.dll.tx_data_bytes_remaining & 0x00FF);

                Array.Copy(c1218_client.data.tx_data, c1218_client.dll.tx_data_offset, c1218_client.dll.tx_buffer, C1218_DATA_INDEX, c1218_client.dll.tx_data_bytes_remaining);
                crc_calc = CRC.calc_crc16(c1218_client.dll.tx_buffer, (UInt16)(c1218_client.dll.tx_data_bytes_remaining + 6));

                c1218_client.dll.tx_buffer[c1218_client.dll.tx_data_bytes_remaining + 6] = (Byte)(crc_calc >> 8);
                c1218_client.dll.tx_buffer[c1218_client.dll.tx_data_bytes_remaining + 7] = (Byte)(crc_calc & 0x00FF);

                c1218_client.dll.tx_ongoing = true;

                TIMER.start_ms_timer((Byte)c1218_client.dll.tx_timer, C1218_INTER_CHARACTER_TIMEOUT, c1218_client.ufunction.tx_abort);
                c1218_client.control.response_counter = 0;
                c1218_client.dll.interrupt_context = false;

                c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_STP;
                for (UInt16 i = 0; i < c1218_client.dll.tx_data_length + 8; i++)
                {
                    APP_vTx_int_handler(ref c1218_client);
                }
            }
        }

        /**
         ******************************************************************************
         * \fn void APP_vService_state_check(ref c1218_type c1218_client)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public void APP_vService_state_check(ref c1218_type c1218_client)
        {
            if ((c1218_client.control.session_state != c1218_apl_state.BASE_STATE) &&
                (c1218_client.control.session_state != c1218_apl_state.ID_STATE) &&
                (c1218_client.control.session_state != c1218_apl_state.SESSION_STATE))
            {
                c1218_client.ufunction.terminate_logon_session();
            }
        }

        /**
         ******************************************************************************
         * \fn void APP_vSend_aok(ref c1218_type c1218_client)
         * \brief
         *
         * \param 
         * \retval
         ******************************************************************************
         */
        void APP_vSend_aok(ref c1218_type c1218_client)
        {
            Byte[] data = new Byte[1];
            data[0] = C1218_ACK;
            c1218_client.hw.serial_port.Write(data, 0, 1);
        }

        /**
         ******************************************************************************
         * \fn void APP_vSend_nok(ref c1218_type c1218_client)
         * \brief
         *
         * \param 
         * \retval
         ******************************************************************************
         */
        void APP_vSend_nok(ref c1218_type c1218_client)
        {
            Byte[] data = new Byte[1];
            data[0] = C1218_NOK;
            c1218_client.hw.serial_port.Write(data, 0, 1);
        }

        /**
         ******************************************************************************
         * \fn void APP_vSend_error_response(ref c1218_type c1218_client, uint8_t error_code)
         * \brief
         *
         * \param 
         * \retval
         ******************************************************************************
         */
        public void APP_vSend_error_response(ref c1218_type c1218_client, Byte error_code)
        {
            c1218_client.dll.tx_data_length = 0;
            c1218_client.data.tx_data[c1218_client.dll.tx_data_length++] = error_code;
            APP_vSend_response(ref c1218_client);
        }

        /**
         ******************************************************************************
         * \fn void APP_vRx_abort(ref c1218_type c1218_client)
         * \brief
         *
         * \param 
         * \retval
         ******************************************************************************
         */
        void APP_vRx_abort(ref c1218_type c1218_client)
        {
            c1218_client.dll.interrupt_context = true;

            TIMER.reset_ms_timer((Byte)c1218_client.dll.rx_timer);
            c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_IDLE;
            c1218_client.dll.rx_ongoing = false;
            c1218_client.ufunction.rx_abort();

            c1218_client.dll.interrupt_context = false;
        }

        /**
         ******************************************************************************
         * \fn void APP_vTx_abort(ref c1218_type c1218_client)
         * \brief
         *
         * \param 
         * \retval
         ******************************************************************************
         */
        void APP_vTx_abort(ref c1218_type c1218_client)
        {
            c1218_client.dll.interrupt_context = true;

            TIMER.reset_ms_timer((Byte)c1218_client.dll.tx_timer);
            c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_IDLE;
            c1218_client.dll.tx_ongoing = false;
            c1218_client.ufunction.tx_abort();

            c1218_client.dll.interrupt_context = false;
        }

        /**
         ******************************************************************************
         * \fn void APP_vTerminate_logon_session(ref c1218_type c1218_client)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vTerminate_logon_session(ref c1218_type c1218_client)
        {
            c1218_client.ufunction.rx_abort();
            c1218_client.ufunction.tx_abort();

            TIMER.reset_ms_timer((Byte)c1218_client.control.logon_timer);
            TIMER.reset_ms_timer((Byte)c1218_client.control.waiting_ack_timer);
            c1218_client.control.session_state = c1218_apl_state.BASE_STATE;
            c1218_client.control.waiting_ack = false;

            c1218_client.ufunction.terminate_logon_session();
        }

        /**
         ******************************************************************************
         * \fn void APP_vTx_int_handler(ref c1218_type c1218_client)
         * \brief Transmit byte complete interrupt service routine handler.
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public void APP_vTx_int_handler(ref c1218_type c1218_client)
        {
            try
            {
                Byte[] data = new Byte[1];

                c1218_client.dll.interrupt_context = true;
                c1218_client.dll.tx_ongoing = true;

                TIMER.reset_ms_timer((Byte)c1218_client.dll.tx_timer);

                switch (c1218_client.dll.tx_state)
                {
                    case c1218_dll_tx_state.C1218_TX_STP:
                        /* Send first data byte. */
                        if (c1218_client.dll.tx_buffer[C1218_STP_INDEX] == C1218_STP)
                        {
                            data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                            c1218_client.hw.serial_port.Write(data, 0, 1);
                            c1218_client.dll.tx_buffer_bytes++;
                            c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_IDENTITY;
                        }
                        else
                        {
                            c1218_client.ufunction.tx_abort();
                        }
                        break;

                    case c1218_dll_tx_state.C1218_TX_IDENTITY:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_CTRL;
                        break;

                    case c1218_dll_tx_state.C1218_TX_CTRL:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_SEQ_NBR;
                        break;

                    case c1218_dll_tx_state.C1218_TX_SEQ_NBR:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_LENGTH_H;
                        break;

                    case c1218_dll_tx_state.C1218_TX_LENGTH_H:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_LENGTH_L;
                        break;

                    case c1218_dll_tx_state.C1218_TX_LENGTH_L:
                        if (c1218_client.dll.tx_data_bytes_remaining > 0)
                        {
                            /* Send next data byte. */
                            data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                            c1218_client.hw.serial_port.Write(data, 0, 1);
                            c1218_client.dll.tx_buffer_bytes++;
                            c1218_client.dll.tx_data_bytes_remaining--;
                            c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_LENGTH_L;

                            if (c1218_client.dll.tx_data_bytes_remaining == 0)
                            {
                                /* Transmit complete, set tx idle state for new transmissions */
                                c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_DATA;
                            }
                        }
                        break;

                    case c1218_dll_tx_state.C1218_TX_DATA:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_CRC_H;
                        break;

                    case c1218_dll_tx_state.C1218_TX_CRC_H:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_CRC_L;
                        break;

                    case c1218_dll_tx_state.C1218_TX_CRC_L:
                        /* Send next data byte. */
                        data[0] = c1218_client.dll.tx_buffer[c1218_client.dll.tx_buffer_bytes];
                        c1218_client.hw.serial_port.Write(data, 0, 1);
                        c1218_client.dll.tx_buffer_bytes++;

                        c1218_client.control.waiting_ack = true;

                        TIMER.start_ms_timer((Byte)c1218_client.control.waiting_ack_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.resend_response);
                        TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);

                        if (c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] == 0)
                        {
                            c1218_client.dll.tx_eop = true;
                        }

                        c1218_client.dll.tx_ongoing = false;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_IDLE;
                        break;

                    default:
                        c1218_client.dll.tx_ongoing = false;
                        c1218_client.dll.tx_state = c1218_dll_tx_state.C1218_TX_IDLE;
                        break;
                }

                if (c1218_client.dll.tx_ongoing == true)
                {
                    TIMER.start_ms_timer((Byte)c1218_client.dll.tx_timer, C1218_INTER_CHARACTER_TIMEOUT, c1218_client.ufunction.tx_abort);
                }

                c1218_client.dll.interrupt_context = false;
            }
            catch (Exception ex)
            {
                c1218_client.ufunction.rx_abort();
                c1218_client.ufunction.tx_abort();
            }
        }

        /**
         ******************************************************************************
         * \fn void APP_vRx_int_handler(ref c1218_type c1218_client)
         * \brief Transmit byte complete interrupt service routine handler.
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public void APP_vRx_int_handler(ref c1218_type c1218_client)
        {
            Byte data;
            UInt16 crc_rx;
            UInt16 crc_calc;

            c1218_client.dll.interrupt_context = true;
            c1218_client.dll.rx_ongoing = true;

            TIMER.reset_ms_timer((Byte)c1218_client.dll.rx_timer);
            data = c1218_client.dll.rx_byte;

            switch (c1218_client.dll.rx_state)
            {
                case c1218_dll_rx_state.C1218_RX_IDLE:
                    if ((data == C1218_STP) /*&& (c1218_client.control.waiting_ack == false)*/)
                    {
                        c1218_client.dll.rx_buffer_bytes = 0;
                        c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                        c1218_client.dll.rx_buffer_bytes++;

                        c1218_client.dll.rx_data_length = 0;
                        c1218_client.dll.rx_data_bytes_remaining = 0;
                        c1218_client.dll.rx_error = 0;
                        c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_STP;

                        //
                        c1218_client.control.waiting_ack = false;
                        c1218_client.control.response_counter = 0;
                        c1218_client.dll.tx_ongoing = false;
                        TIMER.reset_ms_timer((Byte)c1218_client.control.waiting_ack_timer);
                        //

                        if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                        {
                            TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                        }
                    }
                    else if ((data == C1218_ACK) && (c1218_client.control.waiting_ack == true))
                    {
                        c1218_client.control.waiting_ack = false;
                        c1218_client.control.response_counter = 0;
                        c1218_client.dll.tx_ongoing = false;
                        TIMER.reset_ms_timer((Byte)c1218_client.control.waiting_ack_timer);

                        if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                        {
                            TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                        }

                        if (c1218_client.dll.tx_buffer[C1218_SEQ_NBR_INDEX] > 0)
                        {
                            APP_vSend_next_packet(ref c1218_client);
                        }
                    }
                    else if ((data == C1218_NOK) && (c1218_client.control.waiting_ack == true))
                    {
                        if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                        {
                            TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                        }

                        TIMER.reset_ms_timer((Byte)c1218_client.control.waiting_ack_timer);
                        APP_vResend_response(ref c1218_client);
                        c1218_client.control.response_counter = 0;
                    }
                    else
                    {
                        c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_IDLE;
                    }
                    break;

                case c1218_dll_rx_state.C1218_RX_STP:
                    c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    c1218_client.dll.rx_buffer_bytes++;
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_IDENTITY;
                    break;

                case c1218_dll_rx_state.C1218_RX_IDENTITY:
                    c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    c1218_client.dll.rx_buffer_bytes++;

                    if ((data == 0) || (data == 0x20) || ((data & 0xC0) == 0xC0))
                    {
                        c1218_client.dll.rx_data_offset = 0;
                    }
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_CTRL;
                    break;

                case c1218_dll_rx_state.C1218_RX_CTRL:
                    c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    c1218_client.dll.rx_buffer_bytes++;
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_SEQ_NBR;
                    break;

                case c1218_dll_rx_state.C1218_RX_SEQ_NBR:
                    c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    c1218_client.dll.rx_buffer_bytes++;
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_LENGTH_H;
                    break;

                case c1218_dll_rx_state.C1218_RX_LENGTH_H:
                    c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    c1218_client.dll.rx_buffer_bytes++;
                    c1218_client.dll.rx_data_bytes = 0;
                    c1218_client.dll.rx_data_bytes_remaining = (UInt16)(c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes - 2] << 8);
                    c1218_client.dll.rx_data_bytes_remaining |= (UInt16)(c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes - 1]);
                    c1218_client.dll.rx_data_length = c1218_client.dll.rx_data_bytes_remaining;
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_LENGTH_L;
                    break;

                case c1218_dll_rx_state.C1218_RX_LENGTH_L:
                    if (c1218_client.dll.rx_data_bytes_remaining > 0)
                    {
                        if (c1218_client.dll.rx_buffer_bytes < (C1218_PACKET_SIZE + C1218_PACKET_OVERHEAD))
                        {
                            c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                        }
                        else
                        {
                        }
                        c1218_client.dll.rx_buffer_bytes++;
                        c1218_client.dll.rx_data_bytes++;
                        c1218_client.dll.rx_data_bytes_remaining--;
                        c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_LENGTH_L;

                        if (c1218_client.dll.rx_data_bytes_remaining == 0)
                        {
                            c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_DATA;
                        }
                    }
                    break;

                case c1218_dll_rx_state.C1218_RX_DATA:
                    if (c1218_client.dll.rx_buffer_bytes < (C1218_PACKET_SIZE + C1218_PACKET_OVERHEAD))
                    {
                        c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    }
                    else
                    {
                    }
                    c1218_client.dll.rx_buffer_bytes++;
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_CRC_H;
                    break;

                case c1218_dll_rx_state.C1218_RX_CRC_H:
                    if (c1218_client.dll.rx_buffer_bytes < (C1218_PACKET_SIZE + C1218_PACKET_OVERHEAD))
                    {
                        c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes] = data;
                    }
                    else
                    {
                    }
                    c1218_client.dll.rx_buffer_bytes++;

                    crc_rx = (UInt16)(c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes - 2] << 8);
                    crc_rx |= (UInt16)(c1218_client.dll.rx_buffer[c1218_client.dll.rx_buffer_bytes - 1]);

                    crc_calc = CRC.calc_crc16(c1218_client.dll.rx_buffer, (UInt16)(c1218_client.dll.rx_buffer_bytes - 2));

                    if (crc_rx == crc_calc)
                    {
                        if ((c1218_client.dll.rx_buffer[C1218_CTRL_INDEX] & 0x80) == 0x80)
                        {
                            if ((c1218_client.dll.rx_buffer[C1218_CTRL_INDEX] & 0x40) == 0x40)
                            {
                                c1218_client.dll.rx_buffer_previous_identity = c1218_client.dll.rx_buffer[C1218_IDENTITY_INDEX];
                                c1218_client.dll.rx_buffer_previous_toggle_bit = (Byte)(c1218_client.dll.rx_buffer[C1218_CTRL_INDEX] & 0x20);
                                c1218_client.dll.rx_buffer_previous_crc = crc_rx;

                                if ((c1218_client.dll.rx_data_offset + c1218_client.dll.rx_data_bytes) < (C1218_NUM_PACKETS * C1218_PACKET_SIZE))
                                {
                                    Array.Copy(c1218_client.dll.rx_buffer, C1218_DATA_INDEX, c1218_client.data.rx_data, c1218_client.dll.rx_data_offset, c1218_client.dll.rx_data_bytes);
                                    c1218_client.dll.rx_data_offset += c1218_client.dll.rx_data_bytes;
                                    c1218_client.dll.rx_error = 0;
                                }
                                else
                                {
                                    c1218_client.dll.rx_data_offset += c1218_client.dll.rx_data_bytes;
                                    c1218_client.dll.rx_error = 1;
                                }
                            }
                            else
                            {
                                if ((c1218_client.dll.rx_buffer_previous_identity == c1218_client.dll.rx_buffer[C1218_IDENTITY_INDEX]) &&
                                     (c1218_client.dll.rx_buffer_previous_toggle_bit == (c1218_client.dll.rx_buffer[C1218_CTRL_INDEX] & 0x20)) &&
                                     (c1218_client.dll.rx_buffer_previous_crc == crc_rx))
                                {

                                }
                                else
                                {
                                    if ((c1218_client.dll.rx_data_offset + c1218_client.dll.rx_data_bytes) < (C1218_NUM_PACKETS * C1218_PACKET_SIZE))
                                    {
                                        Array.Copy(c1218_client.dll.rx_buffer, C1218_DATA_INDEX, c1218_client.data.rx_data, c1218_client.dll.rx_data_offset, c1218_client.dll.rx_data_bytes);
                                        c1218_client.dll.rx_data_offset += c1218_client.dll.rx_data_bytes;
                                        c1218_client.dll.rx_error = 0;

                                        c1218_client.dll.rx_buffer_previous_identity = c1218_client.dll.rx_buffer[C1218_IDENTITY_INDEX];
                                        c1218_client.dll.rx_buffer_previous_toggle_bit = (Byte)(c1218_client.dll.rx_buffer[C1218_CTRL_INDEX] & 0x20);
                                        c1218_client.dll.rx_buffer_previous_crc = crc_rx;
                                    }
                                    else
                                    {
                                        c1218_client.dll.rx_data_offset += c1218_client.dll.rx_data_bytes;
                                        c1218_client.dll.rx_error = 1;

                                        c1218_client.dll.rx_buffer_previous_identity = c1218_client.dll.rx_buffer[C1218_IDENTITY_INDEX];
                                        c1218_client.dll.rx_buffer_previous_toggle_bit = (Byte)(c1218_client.dll.rx_buffer[C1218_CTRL_INDEX] & 0x20);
                                        c1218_client.dll.rx_buffer_previous_crc = crc_rx;
                                    }
                                }
                            }

                            if (c1218_client.dll.rx_error == 0)
                            {
                                //Thread.Sleep(300); // parche por ccg
                                APP_vSend_aok(ref c1218_client);
                                
                                if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                                {
                                    TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                                }
                            }
                            else
                            {
                                //Thread.Sleep(300); // parche por ccg
                                APP_vSend_nok(ref c1218_client);

                                if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                                {
                                    TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                                }
                            }
                        }
                        else
                        {
                            if ((c1218_client.dll.rx_data_offset + c1218_client.dll.rx_data_bytes) < (C1218_NUM_PACKETS * C1218_PACKET_SIZE))
                            {
                                Array.Copy(c1218_client.dll.rx_buffer, C1218_DATA_INDEX, c1218_client.data.rx_data, c1218_client.dll.rx_data_offset, c1218_client.dll.rx_data_bytes);
                                c1218_client.dll.rx_data_offset += c1218_client.dll.rx_data_bytes;
                                c1218_client.dll.rx_error = 0;

                                //Thread.Sleep(300); // parche por ccg
                                APP_vSend_aok(ref c1218_client);

                                if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                                {
                                    TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                                }
                            }
                            else
                            {
                                c1218_client.dll.rx_data_offset += c1218_client.dll.rx_data_bytes;
                                c1218_client.dll.rx_error = 1;

                                //Thread.Sleep(300); // parche por ccg
                                APP_vSend_nok(ref c1218_client);

                                if (c1218_client.control.device_mode == c1218_device_mode.REQUESTER)
                                {
                                    TIMER.start_ms_timer((Byte)c1218_client.control.response_timeout_timer, C1218_RESPONSE_TIMEOUT, c1218_client.ufunction.rx_abort);
                                }
                            }
                        }
                    }
                    else
                    {
                        c1218_client.dll.rx_error = 1;
                        APP_vSend_nok(ref c1218_client);
                    }

                    if (c1218_client.dll.rx_buffer[C1218_SEQ_NBR_INDEX] == 0)
                    {
                        c1218_client.dll.rx_eop = true;
                    }

                    c1218_client.dll.rx_ongoing = false;

                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_IDLE;

                    break;

                default:
                    c1218_client.dll.rx_state = c1218_dll_rx_state.C1218_RX_IDLE;
                    c1218_client.dll.rx_ongoing = false;
                    break;
            }

            if (c1218_client.dll.rx_ongoing == true)
            {
                TIMER.start_ms_timer((Byte)c1218_client.dll.rx_timer, C1218_INTER_CHARACTER_TIMEOUT, c1218_client.ufunction.rx_abort);
            }

            c1218_client.dll.interrupt_context = false;
        }
    }
}

