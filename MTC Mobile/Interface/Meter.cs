using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using MTC_Mobile.Util;

namespace MTC_Mobile.Interface
{
    public class Meter
    {
        ProtocolC1218.port PORT1 = new ProtocolC1218.port();
        ProtocolC1218.timer TIMER = new ProtocolC1218.timer();
        ProtocolC1218.util UTIL = new ProtocolC1218.util();
        ProtocolC1218.port.c1218_requester_control_type control = new ProtocolC1218.port.c1218_requester_control_type();

        Parser parser = new Parser();

        public static SerialPort serialPort1;

        public Meter()
        {
            TIMER.initialize();
        }

        public Boolean testConnection()
        {
            Settings settings = new Settings();
            Boolean testCon = configurePort(settings.getPort());
            serialPort1.Close();

            return testCon;
        }

        private UInt16 tableId(string strTableId)
        {
            string[] strTbl = strTableId.Split('-');
            int intId = System.Convert.ToInt32(strTbl[1]);
            if (strTbl[0].Equals("MT"))
            {
                intId += 2048;
            }
            UInt16 hexId = (UInt16)System.Convert.ToInt16(intId);

            return hexId;
        }

        public string readTable(string table)
        {
            string data = "";
            Settings settings = new Settings();
            try
            {
                Byte response_code;
                if (configurePort(settings.getPort()))
                {
                    //TIMER.initialize();
                    control.user_id = 0;
                    control.user = new Byte[ProtocolC1218.c1218.C1218_USER_LENGTH];
                    control.password = settings.getSecurity();
                    control.identity = 0;
                    control.nbr_retries = 2;

                    /// finaliza la sesion
                    response_code = PORT1.APP_bTerminate_service_request(control);

                    /// Logon
                    response_code = PORT1.APP_bLog_on_service_request(control);
                    if (response_code == ProtocolC1218.c1218.C1218_OK)
                    {
                        /// Security
                        response_code = PORT1.APP_bSecurity_service_request(control);
                        if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                        {
                            UInt16 hexId = tableId(table);
                            response_code = PORT1.APP_bFull_read_service_request(control, hexId);
                            //response_code = PORT1.APP_bPread_offset_service_request(control, hexId,
                            if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                            {
                                data = UTIL.ByteBuffer_to_StringHex(PORT1.APP_bGet_rx_data(), PORT1.APP_bGet_rx_data_length());
                                data = data.Substring(9, data.Length - 13);
                            }
                            PORT1.APP_bLog_off_service_request(control);
                            PORT1.APP_bTerminate_service_request(control);
                        }
                    }
                    PORT1.APP_vRx_abort();
                    PORT1.APP_vTx_abort();
                    serialPort1.Close();
                }
            }
            catch (Exception)
            {
                serialPort1.Close();
                throw;
            }

            return data;
        }

        private bool configurePort(string portName)
        {
            bool configurated = false;
            serialPort1 = new SerialPort();
            serialPort1.PortName = portName;
            serialPort1.BaudRate = 9600;

            if (PORT1.APP_vInitialize(serialPort1))
            {
                configurated = true;
            }

            return configurated;
        }

    }
}
