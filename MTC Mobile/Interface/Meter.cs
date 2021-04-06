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
        public List<string> TablesProcedure = new List<string>();
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

        public bool runProcedure(string portName, byte[] Security, byte procedureId, byte identity)
        {
            Byte response_code;
            bool status = false;

            try
            {
                if (configurePort(portName))
                {
                    //TIMER.initialize();
                    control.user_id = 0;
                    control.user = new Byte[ProtocolC1218.c1218.C1218_USER_LENGTH];
                    control.password = Security; //Security;
                    control.identity = identity;
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
                            switch (procedureId)
                            {
                                //// cold start
                                case 0:
                                    byte[] data0 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 0, 0, 0, data0);
                                    break;

                                //// warm start
                                case 1:
                                    byte[] data1 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 1, 0, 0, data1);
                                    break;

                                //// reset passwords
                                case 3:
                                    //EE 00 20 00 00 09 40 00 07 00 03 03 08 00 F5 38 B3
                                    byte[] data3 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 3 + 0x0800, 0, 0, data3);
                                    break;
                                //// start test mode
                                case 5:
                                    byte[] data5 = { 2 };
                                    response_code = PORT1.APP_bProcedure_request(control, 6, 0, 1, data5);
                                    break;

                                //// end test mode
                                case 6:
                                    byte[] data6 = { 1 };
                                    response_code = PORT1.APP_bProcedure_request(control, 6, 0, 1, data6);
                                    break;

                                //// clear standard status flags
                                case 7:
                                    byte[] data7 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 7, 0, 0, data7);
                                    break;

                                //// clear manufacturer status flags
                                case 8:
                                    byte[] data8 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 8, 0, 0, data8);
                                    break;

                                //// Enable KWh Pulse Output Mode
                                case 37:
                                    byte[] data37 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 37 + 0x0800, 0, 0, data37);
                                    break;

                                //// Enable KVARh Pulse Output Mode
                                case 38:
                                    byte[] data38 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 38 + 0x0800, 0, 0, data38);
                                    break;

                                //// clear history log data
                                case 50:
                                    byte[] data50 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 50 + 0x0800, 0, 0, data50);
                                    break;

                                //// clear event log data
                                case 51:
                                    byte[] data51 = { 0 };
                                    response_code = PORT1.APP_bProcedure_request(control, 51 + 0x0800, 0, 0, data51);
                                    break;

                                //// demand
                                case 101:
                                    byte[] data = { 1 };
                                    response_code = PORT1.APP_bProcedure_request(control, 9, 0, 1, data);
                                    break;
                            }

                            if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                            {
                                readTablesSTMT();
                                status = true;
                                /// finaliza la sesion
                                PORT1.APP_bLog_off_service_request(control);
                                PORT1.APP_bTerminate_service_request(control);
                            }
                        }
                    }
                    PORT1.APP_vRx_abort();
                    PORT1.APP_vTx_abort();
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                serialPort1.Close();
                throw ex;
            }

            return status;
        }

        private void readTablesSTMT()
        {
            Byte response_code;
            try
            {
                TablesProcedure.Add("Table ST-08");
                response_code = PORT1.APP_bFull_read_service_request(control, 8 /*Table ST-08*/);
                if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                {
                    string data = UTIL.ByteBuffer_to_StringHex(PORT1.APP_bGet_rx_data(), PORT1.APP_bGet_rx_data_length());
                    TablesProcedure.Add(data.Substring(9, data.Length - 13));
                }
                else
                {
                    TablesProcedure.Add("");
                }

                TablesProcedure.Add("Table MT-105");
                response_code = PORT1.APP_bFull_read_service_request(control, 105 + 0x0800 /*Table MT-105*/);
                if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                {
                    string data = UTIL.ByteBuffer_to_StringHex(PORT1.APP_bGet_rx_data(), PORT1.APP_bGet_rx_data_length());
                    TablesProcedure.Add(data.Substring(9, data.Length - 13));
                    //TablesProcedure.Add(UTIL.ByteBuffer_to_StringHex(PORT1.APP_bGet_rx_data(), PORT1.APP_bGet_rx_data_length()));
                }
                else
                {
                    TablesProcedure.Add("");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool relayProcedure(string portName, string status, byte[] Security, byte identity)
        {
            byte response_code;
            bool ejecuted = false;
            try
            {
                if (configurePort(portName))
                {
                    control.user_id = 0;
                    control.user = new Byte[ProtocolC1218.c1218.C1218_USER_LENGTH];
                    control.password = Security;
                    control.identity = identity;
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
                            if (status.Equals("Open"))
                            {
                                byte[] data = { 0 };
                                response_code = PORT1.APP_bProcedure_request(control, 105 + 0x0800, 0, 1, data);
                                if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                                {
                                    readTablesSTMT();
                                    ejecuted = true;
                                }
                            }
                            else if (status.Equals("Close"))
                            {
                                byte[] data = { 1 };
                                response_code = PORT1.APP_bProcedure_request(control, 105 + 0x0800, 0, 1, data);
                                if (response_code.Equals(ProtocolC1218.c1218.C1218_OK))
                                {
                                    readTablesSTMT();
                                    ejecuted = true;
                                }
                            }
                            /// finaliza la sesion
                            PORT1.APP_bLog_off_service_request(control);
                            PORT1.APP_bTerminate_service_request(control);
                        }
                    }
                    PORT1.APP_vRx_abort();
                    PORT1.APP_vTx_abort();
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                throw ex;
            }

            return ejecuted;
        }


    }
}
