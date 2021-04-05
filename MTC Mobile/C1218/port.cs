//updated 23 nov 16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolC1218
{
    public class port
    {
        c1218 C1218 = new c1218();
        timer TIMER = new timer();
        crc CRC = new crc();

        /*
         ******************************************************************************
         * Constant Definitions
         ******************************************************************************
         */
        public const Byte NULL_RESPONSE = 0xFF;
        private const UInt16 constBri = 1;


        /*===========================================================================*\
         *  C1218 end device identity
        \*===========================================================================*/
        public const Byte PORT1_C1218_DEVICE_IDENTITY = 0;

        /*===========================================================================*\
         *  C1218 packets lenght definition
        \*===========================================================================*/
        public const Byte PORT1_APL_NUM_PACKETS = c1218.C1218_NUM_PACKETS;
        public const UInt16 PORT1_APL_PACKET_SIZE = c1218.C1218_PACKET_SIZE;
        public const UInt16 PORT1_APL_SIZE = PORT1_APL_NUM_PACKETS * PORT1_APL_PACKET_SIZE;

        /*
         ******************************************************************************
         * Enumerations and Structures and Typedefs                          
         ******************************************************************************
         */
        public struct c1218_requester_control_type
        {
            public Byte identity;
            public UInt16 user_id;
            public Byte[] user;
            public Byte[] password;
            public Byte nbr_retries;
        };

        /*
         ******************************************************************************
         * Global and Const Variable Defining Definitions / Initializations
         ******************************************************************************
         */

        /*
         ******************************************************************************
         * Static Variables and Const Variables With File Level Scope
         ******************************************************************************
         */
        static c1218.c1218_type port1_c1218;

        /*
         ******************************************************************************
         * Function Definitions
         ******************************************************************************
         */

        /** 
         ******************************************************************************
         * \fn bool APP_vInitialize(System.IO.Ports.SerialPort serial_port)
         * \brief Serial port module initialization
         *
         * I/O port, serial port and variables initialization
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public bool APP_vInitialize(System.IO.Ports.SerialPort serial_port)
        {
            bool configurated = false;

            HAL_vIo_initialize();

            if (HAL_vIo_configure(serial_port))
            {
                APP_vStruct_initialize(serial_port);
                configurated = true;
            }

            return configurated;
        }

        /**
         ******************************************************************************
         * \fn void HAL_vIo_initialize()
         * \brief 
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void HAL_vIo_initialize()
        {

        }

        /**
         ******************************************************************************
         * \fn bool HAL_vIo_configure(System.IO.Ports.SerialPort serial_port)
         * \brief 
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        bool HAL_vIo_configure(System.IO.Ports.SerialPort serial_port)
        {
            bool configurated = false;

            try
            {
                if (serial_port.IsOpen == false)
                {
                    serial_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(APP_vRx_int_handler);
                    serial_port.Parity = System.IO.Ports.Parity.None;
                    serial_port.Open();

                    configurated = true;
                }
                else
                {
                    configurated = true;
                }
            }
            catch (Exception ex)
            {
                configurated = false;
            }

            return configurated;
        }

        /**
         ******************************************************************************
         * \fn void APP_vStruct_initialize(System.IO.Ports.SerialPort serial_port)
         * \brief 
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vStruct_initialize(System.IO.Ports.SerialPort serial_port)
        {
            port1_c1218.dll.interrupt_context = true;
            port1_c1218 = new c1218.c1218_type();

            /* Services structure initialization */
            port1_c1218.service.identification = APP_vIdentification_service;
            port1_c1218.service.negotiate = APP_vNegotiate_service;
            port1_c1218.service.logon = APP_vLogon_service;
            port1_c1218.service.security = APP_vSecurity_service;
            port1_c1218.service.full_read = APP_vFull_read_service;
            port1_c1218.service.pread_offset = APP_vPread_offset_service;
            port1_c1218.service.full_write = APP_vFull_write_service;
            port1_c1218.service.pwrite_offset = APP_vPwrite_offset_service;
            port1_c1218.service.logoff = APP_vLogoff_service;
            port1_c1218.service.wait = APP_vWait_service;
            port1_c1218.service.terminate = APP_vTerminate_service;

            /* User functions structure initialization */
            port1_c1218.ufunction.resend_response = APP_vResend_response;
            port1_c1218.ufunction.terminate_logon_session = APP_vTerminate_logon_session;
            port1_c1218.ufunction.rx_abort = APP_vRx_abort;
            port1_c1218.ufunction.tx_abort = APP_vTx_abort;

            /* Control structure initialization */
            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;
            port1_c1218.control.user = new Byte[c1218.C1218_USER_LENGTH];
            port1_c1218.control.password = new Byte[c1218.C1218_PASS_LENGTH];
            port1_c1218.control.logon_timer = timer.ms_timer_id_type.PORT1_LOGON_TIMER;
            port1_c1218.control.waiting_ack_timer = timer.ms_timer_id_type.PORT1_ACK_TIMEOUT_TIMER;
            port1_c1218.control.response_timeout_timer = timer.ms_timer_id_type.PORT1_RESPONSE_TIMEOUT_TIMER;
            port1_c1218.control.max_response_timeout_timer = timer.ms_timer_id_type.PORT1_MAX_RESPONSE_TIMEOUT_TIMER;

            /* DLL structure initialization */
            port1_c1218.dll.rx_timer = timer.ms_timer_id_type.PORT1_RX_TIMER;
            port1_c1218.dll.tx_timer = timer.ms_timer_id_type.PORT1_TX_TIMER;

            /* C1218 structure initialization */
            C1218.APP_vStruct_initialize(ref port1_c1218);

            /* Hardware structure initialization */
            port1_c1218.hw.serial_port = serial_port;

            port1_c1218.dll.interrupt_context = false;
        }

        /**
         ******************************************************************************
         * \fn void APP_vOp_periodic_config()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vOp_periodic_config()
        {
            if ((port1_c1218.dll.tx_ongoing == false) && (port1_c1218.dll.rx_ongoing == false))
            {
                //HAL_vIo_configure();
                C1218.APP_vService_state_check(ref port1_c1218);
            }
        }

        /** 
         ******************************************************************************
         * \fn void APP_vOs_task()
         * \brief
         *
         * 
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vOs_task()
        {
            if (port1_c1218.dll.rx_eop == true)
            {
                if (port1_c1218.control.device_mode == c1218.c1218_device_mode.END_DEVICE)
                {
                    port1_c1218.dll.rx_eop = false;

                    if ((port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == PORT1_C1218_DEVICE_IDENTITY) && (port1_c1218.dll.rx_error == 0))
                    {
                        C1218.APP_vService_execute(ref port1_c1218);
                    }
                }
            }
        }

        /** 
         ******************************************************************************
         * \fn bool APP_bCatch_end_device_response()
         * \brief
         *
         * 
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public bool APP_bCatch_end_device_response()
        {
            bool rx_eop = false;

            port1_c1218.dll.rx_eop = false;
            C1218.APP_vSend_response(ref port1_c1218);

            TIMER.start_ms_timer((Byte)port1_c1218.control.max_response_timeout_timer, (20 * 1000) / constBri, TIMER.null_action);

            while ((TIMER.is_ms_timer_expired((Byte)port1_c1218.control.response_timeout_timer) == false) && (port1_c1218.dll.rx_eop == false))
            {
                //Application.DoEvents();

                if ((TIMER.is_ms_timer_expired((Byte)port1_c1218.control.max_response_timeout_timer) == true) ||
                     (TIMER.is_ms_timer_running((Byte)port1_c1218.control.max_response_timeout_timer) == false))
                {
                    break;
                }
            }

            rx_eop = port1_c1218.dll.rx_eop;
            port1_c1218.dll.rx_eop = false;

            return rx_eop;
        }

        /**
         ******************************************************************************
         * \fn void APP_vIdentification_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vIdentification_service()
        {
            port1_c1218.control.session_state = c1218.c1218_apl_state.ID_STATE;

            port1_c1218.dll.tx_data_length = 0;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.SERVICE_R_OK;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.STD;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.VER;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.REV;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.END_OF_LIST;

            C1218.APP_vSend_response(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn void APP_vNegotiate_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vNegotiate_service()
        {
            port1_c1218.control.session_state = c1218.c1218_apl_state.ID_STATE;

            port1_c1218.dll.tx_data_length = 0;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.SERVICE_R_OK;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = 0x00;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)c1218.C1218_PACKET_SIZE;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = PORT1_APL_NUM_PACKETS;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = 0x0B;

            C1218.APP_vSend_response(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn void APP_vLogon_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vLogon_service()
        {
            port1_c1218.control.session_state = c1218.c1218_apl_state.SESSION_STATE;

            TIMER.start_ms_timer((Byte)port1_c1218.control.logon_timer, c1218.C1218_LOGON_TIMEOUT, port1_c1218.ufunction.rx_abort);

            port1_c1218.control.user_id = (UInt16)(port1_c1218.data.rx_data[1] >> 8);
            port1_c1218.control.user_id |= (UInt16)port1_c1218.data.rx_data[2];
            Array.Copy(port1_c1218.data.rx_data, 3, port1_c1218.control.user, 0, c1218.C1218_USER_LENGTH);

            port1_c1218.dll.tx_data_length = 0;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.SERVICE_R_OK;
            C1218.APP_vSend_response(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn void APP_vSecurity_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vSecurity_service()
        {
            bool pass_ok = true;

            if (pass_ok == true)
            {
                port1_c1218.control.session_state = c1218.c1218_apl_state.SESSION_STATE;

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.C1218_OK;
                C1218.APP_vSend_response(ref port1_c1218);
            }
            else
            {
                Byte error_id = c1218.C1218_ERR;
                C1218.APP_vSend_error_response(ref port1_c1218, error_id);
            }
        }

        /**
         ******************************************************************************
         * \fn void APP_vFull_read_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vFull_read_service()
        {

        }

        /**
         ******************************************************************************
         * \fn void APP_vPread_offset_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vPread_offset_service()
        {

        }

        /**
         ******************************************************************************
         * \fn void APP_vFull_write_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vFull_write_service()
        {

        }

        /**
         ******************************************************************************
         * \fn void APP_vPread_offset_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vPwrite_offset_service()
        {

        }

        /**
         ******************************************************************************
         * \fn void OP_APP_vLogoff_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vLogoff_service()
        {
            TIMER.reset_ms_timer((Byte)port1_c1218.control.logon_timer);
            port1_c1218.control.session_state = c1218.c1218_apl_state.ID_STATE;

            port1_c1218.dll.tx_data_length = 0;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.C1218_OK;
            C1218.APP_vSend_response(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn void APP_vWait_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vWait_service()
        {

        }

        /**
         ******************************************************************************
         * \fn void APP_vTerminate_service()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vTerminate_service()
        {
            TIMER.reset_ms_timer((Byte)port1_c1218.control.logon_timer);
            port1_c1218.control.session_state = c1218.c1218_apl_state.BASE_STATE;

            port1_c1218.dll.tx_data_length = 0;
            port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.C1218_OK;
            C1218.APP_vSend_response(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn void APP_vResend_response()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vResend_response()
        {
            C1218.APP_vResend_response(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn void APP_vTerminate_service(void)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        void APP_vTerminate_logon_session()
        {

        }

        /**
         ******************************************************************************
         * \fn void APP_vRx_abort()
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public void APP_vRx_abort()
        {
            port1_c1218.dll.interrupt_context = true;

            TIMER.reset_ms_timer((Byte)port1_c1218.dll.rx_timer);
            port1_c1218.dll.rx_state = c1218.c1218_dll_rx_state.C1218_RX_IDLE;
            port1_c1218.dll.rx_ongoing = false;

            port1_c1218.service.identification = APP_vIdentification_service;
            port1_c1218.service.negotiate = APP_vNegotiate_service;
            port1_c1218.service.logon = APP_vLogon_service;
            port1_c1218.service.security = APP_vSecurity_service;
            port1_c1218.service.full_read = APP_vFull_read_service;
            port1_c1218.service.pread_offset = APP_vPread_offset_service;
            port1_c1218.service.full_write = APP_vFull_write_service;
            port1_c1218.service.pwrite_offset = APP_vPwrite_offset_service;
            port1_c1218.service.logoff = APP_vLogoff_service;
            port1_c1218.service.wait = APP_vWait_service;
            port1_c1218.service.terminate = APP_vTerminate_service;

            port1_c1218.ufunction.rx_abort = APP_vRx_abort;
            port1_c1218.ufunction.terminate_logon_session = APP_vTerminate_logon_session;

            //port1_c1218.hw.serial_port = ;

            port1_c1218.dll.interrupt_context = false;
        }

        /**
         ******************************************************************************
         * \fn void APP_vTx_abort()
         * \brief 
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public void APP_vTx_abort()
        {
            port1_c1218.dll.interrupt_context = true;

            TIMER.reset_ms_timer((Byte)port1_c1218.dll.tx_timer);
            port1_c1218.dll.tx_state = c1218.c1218_dll_tx_state.C1218_TX_IDLE;
            port1_c1218.dll.tx_ongoing = false;

            port1_c1218.service.identification = APP_vIdentification_service;
            port1_c1218.service.negotiate = APP_vNegotiate_service;
            port1_c1218.service.logon = APP_vLogon_service;
            port1_c1218.service.security = APP_vSecurity_service;
            port1_c1218.service.full_read = APP_vFull_read_service;
            port1_c1218.service.pread_offset = APP_vPread_offset_service;
            port1_c1218.service.full_write = APP_vFull_write_service;
            port1_c1218.service.pwrite_offset = APP_vPwrite_offset_service;
            port1_c1218.service.logoff = APP_vLogoff_service;
            port1_c1218.service.wait = APP_vWait_service;
            port1_c1218.service.terminate = APP_vTerminate_service;

            port1_c1218.ufunction.tx_abort = APP_vTx_abort;
            port1_c1218.ufunction.terminate_logon_session = APP_vTerminate_logon_session;

            //port1_c1218.hw.serial_port = ;

            port1_c1218.dll.interrupt_context = false;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bIdentification_service_request(c1218_requester_control_type control)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bIdentification_service_request(c1218_requester_control_type control)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.IDENTIFICATION;

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length >= 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_ISSS:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bLog_on_service_request(c1218_requester_control_type control)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bLog_on_service_request(c1218_requester_control_type control)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.LOGON;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((control.user_id & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((control.user_id & 0x00FF) >> 0);
                Array.Copy(control.user, 0, port1_c1218.data.tx_data, port1_c1218.dll.tx_data_length, c1218.C1218_USER_LENGTH);
                port1_c1218.dll.tx_data_length += c1218.C1218_USER_LENGTH;

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length == 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_IAR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_ISSS:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bSecurity_service_request(c1218_requester_control_type control)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bSecurity_service_request(c1218_requester_control_type control)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.SECURITY;
                Array.Copy(control.password, 0, port1_c1218.data.tx_data, port1_c1218.dll.tx_data_length, c1218.C1218_PASS_LENGTH);
                port1_c1218.dll.tx_data_length += c1218.C1218_PASS_LENGTH;

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length == 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_ISSS:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bLog_off_service_request(c1218_requester_control_type control)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bLog_off_service_request(c1218_requester_control_type control)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.LOGOFF;

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length == 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_ISSS:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bTerminate_service_request(c1218_requester_control_type control)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bTerminate_service_request(c1218_requester_control_type control)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.TERMINATE;

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length == 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bFull_write_service_request(c1218_requester_control_type control, UInt16 table_id, UInt16 count, Byte[] data)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bFull_write_service_request(c1218_requester_control_type control, UInt16 table_id, UInt16 count, Byte[] data)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.FULL_WRITE;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0x00FF) >> 0);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((count & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((count & 0x00FF) >> 0);
                Array.Copy(data, 0, port1_c1218.data.tx_data, port1_c1218.dll.tx_data_length, count);
                port1_c1218.dll.tx_data_length += count;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = CRC.calc_2s_complemet(data, count);

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length == 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_SNS:
                            break;

                        case c1218.C1218_ISC:
                            break;

                        case c1218.C1218_ONP:
                            break;

                        case c1218.C1218_IAR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_DNR:
                            break;

                        case c1218.C1218_DLK:
                            break;

                        case c1218.C1218_RNO:
                            break;

                        case c1218.C1218_ISSS:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bPwrite_offset_service_request(c1218_requester_control_type control, UInt16 table_id, UInt32 offset, UInt16 count, Byte[] data)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bPwrite_offset_service_request(c1218_requester_control_type control, UInt16 table_id, UInt32 offset, UInt16 count, Byte[] data)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.PWRITE_OFFSET;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0x00FF) >> 0);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((offset & 0x00FF0000) >> 16);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((offset & 0x0000FF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((offset & 0x000000FF) >> 0);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((count & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((count & 0x00FF) >> 0);
                Array.Copy(data, 0, port1_c1218.data.tx_data, port1_c1218.dll.tx_data_length, count);
                port1_c1218.dll.tx_data_length += count;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = CRC.calc_2s_complemet(data, count);

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length == 1))
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_SNS:
                            break;

                        case c1218.C1218_ISC:
                            break;

                        case c1218.C1218_ONP:
                            break;

                        case c1218.C1218_IAR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_DNR:
                            break;

                        case c1218.C1218_DLK:
                            break;

                        case c1218.C1218_RNO:
                            break;

                        case c1218.C1218_ISSS:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bFull_read_service_request(c1218_requester_control_type control, UInt16 table_id)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bFull_read_service_request(c1218_requester_control_type control, UInt16 table_id)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.FULL_READ;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0x00FF) >> 0);

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length >= 4))//1
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_SNS:
                            break;

                        case c1218.C1218_ISC:
                            //APP_bSecurity_service_request(control);
                            break;

                        case c1218.C1218_ONP:
                            break;

                        case c1218.C1218_IAR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_DNR:
                            break;

                        case c1218.C1218_DLK:
                            break;

                        case c1218.C1218_RNO:
                            break;

                        case c1218.C1218_ISSS:
                            //APP_bTerminate_service_request(control);
                            //APP_bIdentification_service_request(control);
                            //APP_bLog_on_service_request(control);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte APP_bPread_offset_service_request(c1218_requester_control_type control, UInt16 table_id, UInt32 offset, UInt16 count)
         * \brief
         *
         * \param void
         * \retval void
         ******************************************************************************
         */
        public Byte APP_bPread_offset_service_request(c1218_requester_control_type control, UInt16 table_id, UInt32 offset, UInt16 count)
        {
            Byte response_code = NULL_RESPONSE;
            Byte current_retries = 0;

            port1_c1218.control.device_mode = c1218.c1218_device_mode.REQUESTER;

            while ((current_retries < control.nbr_retries) && (response_code != c1218.C1218_OK))
            {
                port1_c1218.ufunction.rx_abort();
                port1_c1218.ufunction.tx_abort();

                port1_c1218.dll.tx_data_length = 0;
                port1_c1218.dll.tx_buffer[c1218.C1218_IDENTITY_INDEX] = control.identity;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = c1218.PREAD_OFFSET;
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((table_id & 0x00FF) >> 0);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((offset & 0x00FF0000) >> 16);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((offset & 0x0000FF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((offset & 0x000000FF) >> 0);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((count & 0xFF00) >> 8);
                port1_c1218.data.tx_data[port1_c1218.dll.tx_data_length++] = (Byte)((count & 0x00FF) >> 0);

                if ((APP_bCatch_end_device_response() == true) && (port1_c1218.dll.rx_buffer[c1218.C1218_IDENTITY_INDEX] == control.identity) && (port1_c1218.dll.rx_data_length >= 4))//4
                {
                    response_code = port1_c1218.data.rx_data[c1218.RESPONSE_CODE_INDEX];

                    switch (response_code)
                    {
                        case c1218.C1218_OK:
                            break;

                        case c1218.C1218_ERR:
                            break;

                        case c1218.C1218_SNS:
                            break;

                        case c1218.C1218_ISC:
                            break;

                        case c1218.C1218_ONP:
                            break;

                        case c1218.C1218_IAR:
                            break;

                        case c1218.C1218_BSY:
                            break;

                        case c1218.C1218_DNR:
                            break;

                        case c1218.C1218_DLK:
                            break;

                        case c1218.C1218_RNO:
                            break;

                        case c1218.C1218_ISSS:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    response_code = NULL_RESPONSE;
                }

                current_retries++;
            }

            port1_c1218.control.device_mode = c1218.c1218_device_mode.END_DEVICE;

            return response_code;
        }

        /**
         ******************************************************************************
         * \fn Byte[] APP_bGet_rx_data_length()
         * \brief 
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public UInt16 APP_bGet_rx_data_length()
        {
            return port1_c1218.dll.rx_data_offset;
        }

        /**
         ******************************************************************************
         * \fn Byte[] APP_bGet_tx_data_length()
         * \brief 
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public UInt16 APP_bGet_tx_data_length()
        {
            return port1_c1218.dll.tx_data_length;
        }

        /**
         ******************************************************************************
         * \fn Byte[] APP_bGet_rx_data()
         * \brief 
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public Byte[] APP_bGet_rx_data()
        {
            return port1_c1218.data.rx_data;
        }

        /**
         ******************************************************************************
         * \fn Byte[] APP_bGet_tx_data()
         * \brief 
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public Byte[] APP_bGet_tx_data()
        {
            return port1_c1218.data.tx_data;
        }

        /**
         ******************************************************************************
         * \fn static void APP_vTx_int_handler()
         * \brief Transmit byte complete interrupt service routine.
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        void APP_vTx_int_handler()
        {
            port1_c1218.dll.interrupt_context = true;

            //port1_c1218.hw.serial_port = ;
            port1_c1218.ufunction.tx_abort = APP_vTx_abort;

            C1218.APP_vTx_int_handler(ref port1_c1218);
        }

        /**
         ******************************************************************************
         * \fn static void APP_vRx_int_handler()
         * \brief Receive byte complete interrupt service routine.
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        void APP_vRx_int_handler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            port1_c1218.dll.interrupt_context = true;

            //port1_c1218.hw.serial_port = ;
            port1_c1218.ufunction.rx_abort = APP_vRx_abort;

            int nbr_bytes = port1_c1218.hw.serial_port.BytesToRead;
            byte[] buffer = new byte[nbr_bytes];

            port1_c1218.hw.serial_port.Read(buffer, 0, nbr_bytes);

            UInt16 i;
            for (i = 0; i < nbr_bytes; i++)
            {
                port1_c1218.dll.rx_byte = buffer[i];
                C1218.APP_vRx_int_handler(ref port1_c1218);
            }

            APP_vOs_task();
        }

        /**
       ******************************************************************************
       * \fn Byte APP_bProcedure_request(c1218_requester_control_type control, UInt16 procedure_id, Byte seq_nbr, UInt16 paramaters_len, Byte[] parameters)
       * \brief
       *
       * \param void
       * \retval void
       ******************************************************************************
       */
        public Byte APP_bProcedure_request(c1218_requester_control_type control, UInt16 procedure_id, Byte seq_nbr, UInt16 parameters_len, Byte[] parameters)
        {
            Byte response_code = NULL_RESPONSE;
            Byte[] data = new Byte[parameters_len + 3];

            data[0] = Convert.ToByte((procedure_id & 0x00FF) >> 0);
            data[1] = Convert.ToByte((procedure_id & 0xFF00) >> 8);
            data[2] = seq_nbr;
            Array.Copy(parameters, 0, data, 3, parameters_len);

            response_code = APP_bFull_write_service_request(control, 7, (UInt16)(parameters_len + 3), data);

            return response_code;
        }

       public void abort_rx()
        {
           port1_c1218.ufunction.rx_abort();
            
        }

        public void abort_tx()
       {
           port1_c1218.ufunction.tx_abort();
       }


    }
}
