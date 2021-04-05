using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using MTC_Mobile.Dao;
using System.IO;
using MTC_Mobile.Object;
using MTC_Mobile.Interface;

namespace MTC_Mobile.Util
{
    class Report
    {
        private XmlDocument xmlDoc = new XmlDocument();

        public Report() { }

        public Response createXML(Dictionary<String, List<String[]>>  tablesData, string readingName)
        {
            Response response = new Response();

            IDao<Settings> settingsDao = new SettingsDao();
            Settings settings = settingsDao.GetById(1);
            string path = settings.getStoragePath();
            int userId = settings.getId();

            IDao<User> userDao = new UserDao();
            string username = userDao.GetById(userId).getUsername();
            string userFolder = path + "\\" + username;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + " " + readingName;

            string fullName = path + "\\" + fileName + ".xml";

            try
            {

                //(1) the xml declaration is recommended, but not mandatory
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDoc.DocumentElement;
                xmlDoc.InsertBefore(xmlDeclaration, root);

                //(2) string.Empty makes cleaner code
                XmlElement decadesNode = xmlDoc.CreateElement("decades");
                xmlDoc.AppendChild(decadesNode);

                foreach (KeyValuePair<String, List<String[]>> entry in tablesData)
                {
                    //(2) string.Empty makes cleaner code
                    XmlElement decadeNode = xmlDoc.CreateElement("decade");
                    decadeNode.SetAttribute("id", entry.Key);
                    decadesNode.AppendChild(decadeNode);

                    foreach (String[] table in entry.Value)
                    {
                        XmlElement tableNode = xmlDoc.CreateElement("table");
                        tableNode.SetAttribute("id", table[0]);
                        decadeNode.AppendChild(tableNode);

                        XmlElement dataNode = xmlDoc.CreateElement("data");
                        XmlText textNode = xmlDoc.CreateTextNode(table[1]);
                        dataNode.AppendChild(textNode);
                        tableNode.AppendChild(dataNode);
                    }
                }


                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                xmlDoc.Save(fullName);

                response.setResult(File.Exists(fullName));
            }
            catch (Exception ex)
            {
                response.setError(ex);
            }

            return response;
        }

        public Response createEDF(Dictionary<String, List<String[]>> tablesData, string readingName)
        {
            Response response = new Response();


            IDao<Settings> settingsDao = new SettingsDao();
            Settings settings = settingsDao.GetById(1);
            string path = settings.getStoragePath();
            int userId = settings.getId();

            IDao<User> userDao = new UserDao();
            string username = userDao.GetById(userId).getUsername();
            //string userFolder = path + "\\" + username;
            string userFolder = path;

            string meterSN = "";
            Parser parser = new Parser();
            List<String[]> mtTables = tablesData["0"];
            foreach (String[] table in mtTables)
            {
                if (table[0].Equals("ST-6"))
                {
                    IDictionary<string, string[]> dict = parser.ParseTableData("ST-6", table[1]);
                    meterSN = dict["DEVICE_ID"][1];
                }
            }

            string writeDate = DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");
            string pathFile = userFolder + "\\" + meterSN + "-" + writeDate + ".edf";


            string Header = createHeaderFile(tablesData, parser).ToUpper();
            string HeaderEnd = parser.stringToHex("HEADEREND");
            HeaderEnd = completeRegister(HeaderEnd.Replace(" ", ""), 256).ToUpper();

            int numTables = 0;
            int[] table_number_dir = new int[0];
            int[] table_len_dir = new int[0];
            int[] table_offset_dir = new int[0];
            string[] table_frames = new string[0];
            int index = 0;
            foreach (KeyValuePair<String, List<String[]>> entry in tablesData)
            {
                numTables += entry.Value.Count;
                Array.Resize(ref table_number_dir, numTables);
                Array.Resize(ref table_len_dir, numTables);
                Array.Resize(ref table_offset_dir, numTables);
                Array.Resize(ref table_frames, numTables);
                foreach (String[] table in entry.Value)
                {
                    string tableName = table[0];
                    string data = table[1];


                    string[] strTbl = tableName.Split('-');
                    int intId = System.Convert.ToInt32(strTbl[1]);
                    if (strTbl[0].Equals("MT"))
                    {
                        intId += 2048;
                    }
                    table_number_dir[index] = intId;


                    int table_len = (data.Length + 1) / 3;
                    table_len_dir[index] = table_len;

                    table_frames[index] = data;

                    index++;
                }
            }

            string complete_table_frame = string.Join(" ", table_frames);

            if (numTables > 0)
            {
                // recalcula offset de todas las tablas en table_dir
                int table_offset = 256 + numTables * 12 + 4;
                for (int a = 0; a < numTables; a++)
                {
                    table_offset_dir[a] = table_offset;
                    table_offset = table_offset + table_len_dir[a];
                }

                // ajusta frame de directorio antes de escibir
                string complete_table_dir = little_endian(numTables, 4);
                for (int a = 0; a < numTables; a++)
                {
                    complete_table_dir = complete_table_dir + " " + little_endian(table_number_dir[a], 4);
                    complete_table_dir = complete_table_dir + " " + little_endian(table_len_dir[a], 4);
                    complete_table_dir = complete_table_dir + " " + little_endian(table_offset_dir[a], 4);
                }
                complete_table_dir = complete_table_dir.ToUpper();
                string[] dir_hexValues = complete_table_dir.Split(' ');
                byte[] dir_byteValues = new byte[dir_hexValues.Length];
                int cont = 0;
                foreach (String my_hex in dir_hexValues)
                {
                    dir_byteValues[cont] = Convert.ToByte(my_hex, 16);
                    cont++;
                }
                // ajusta frame de tablas antes de escribir
                complete_table_frame = complete_table_frame.ToUpper();
                string[] frame_hexValues = complete_table_frame.Split(' ');
                byte[] frame_byteValues = new byte[frame_hexValues.Length];
                cont = 0;
                foreach (String my_hex in frame_hexValues)
                {
                    frame_byteValues[cont] = Convert.ToByte(my_hex, 16);
                    cont++;
                }


                // ajusta header antes de escribir
                complete_table_frame = Header.ToUpper();
                string[] frame_hexValuesHeader = complete_table_frame.Split(' ');
                byte[] frame_byteValuesHeader = new byte[frame_hexValuesHeader.Length];
                cont = 0;
                foreach (String my_hex in frame_hexValuesHeader)
                {
                    frame_byteValuesHeader[cont] = Convert.ToByte(my_hex, 16);
                    cont++;
                }

                // ajusta endheader antes de escribir
                complete_table_frame = HeaderEnd.ToUpper();
                string[] frame_hexValuesendHeader = complete_table_frame.Split(' ');
                byte[] frame_byteValuesendHeader = new byte[frame_hexValuesendHeader.Length];
                cont = 0;
                foreach (String my_hex in frame_hexValuesendHeader)
                {
                    frame_byteValuesendHeader[cont] = Convert.ToByte(my_hex, 16);
                    cont++;
                }

                try
                {
                    // escribe archivo nuevo
                    using (System.IO.BinaryWriter my_file = new System.IO.BinaryWriter(System.IO.File.Open(pathFile, System.IO.FileMode.Create)))
                    {
                        //escribe encabezado
                        foreach (byte i in frame_byteValuesHeader)
                        {
                            my_file.Write(i);
                        }
                        // escribe frame de directorio
                        foreach (byte i in dir_byteValues)
                        {
                            my_file.Write(i);
                        }
                        // escribe frame de tablas
                        foreach (byte i in frame_byteValues)
                        {
                            my_file.Write(i);
                        }

                        //escribir final del encabezado
                        foreach (byte i in frame_byteValuesendHeader)
                        {
                            my_file.Write(i);
                        }
                    }
                    response.setResult(true);
                }
                catch (Exception ex)
                {
                    response.setError(ex);
                }
            }

            return response;
        }


        private string createHeaderFile(Dictionary<String, List<String[]>> tablesData, Parser parser)
        {
            string header = "";
            string recordId = "";
            string meterModel = "";
            string meterSN = "";
            string meterUtility = "";
            string readerTime = "";
            string readNameSoftware = "";
            string readerId = "FE 08";
            string registerDataFlag = "01";
            string lpDataFlag = "01";
            string eventDataFlag = "01";
            string diagDataFlag = "01";
            string actionDataFlag = "01";
            try
            {
                //FIXED
                recordId = parser.stringToHex("HEADER");


                List<String[]> mtTables = tablesData["0"];
                IDictionary<string, string[]> dicTbl1 = new Dictionary<string, string[]>();
                IDictionary<string, string[]> dicTbl6 = new Dictionary<string, string[]>();
                foreach (String[] table in mtTables)
                {
                    if (table[0].Equals("ST-1"))
                    {
                        dicTbl1 = parser.ParseTableData("ST-1", table[1]);
                    }
                    
                    if (table[0].Equals("ST-6"))
                    {
                        dicTbl6 = parser.ParseTableData("ST-6", table[1]);
                    }
                }

                //ST-1: ED_MODEL
                meterModel = dicTbl1["ED_MODEL"][0];
                meterModel = completeRegister(meterModel.Replace(" ", ""), 8);

                //ST-1: MFG_SERIAL_NUMBER
                meterSN = dicTbl1["MFG_SERIAL_NUMBER"][0];
                meterSN = completeRegister(meterSN.Replace(" ", ""), 16);

                //ST-6: DEVICE_ID
                meterUtility = dicTbl6["DEVICE_ID"][0];
                meterUtility = completeRegister(meterUtility.Replace(" ", ""), 20);

                string writeDate = DateTime.Now.ToString("MMddyyHHmm");
                readerTime = parser.stringToHex(writeDate);

                //FIXED
                readNameSoftware = parser.stringToHex("MTC");
                readNameSoftware = completeRegister(readNameSoftware.Replace(" ", ""), 10);
                
                header = recordId + meterModel + meterSN + meterUtility + readerTime + readNameSoftware + readerId + registerDataFlag + lpDataFlag + eventDataFlag + diagDataFlag + actionDataFlag;
                header = completeRegister(header.Replace(" ", ""), 256);
            }
            catch (Exception)
            {
                throw;
            }
            return header;
        }

        /// <summary>
        /// Autocompleta los registros que no cuentan con su respectiva longitud
        /// </summary>
        /// <param name="data">dato a autocompletar</param>
        /// <param name="length">longitud del dato</param>
        /// <returns>longitud del dato acompletada</returns>
        public string completeRegister(string data, int length)
        {
            string completeData = "";
            length = length * 2;
            for (int i = data.Length; i < length; i += 2)
            {
                completeData += "20";
            }
            completeData = aling_frame_to_Write(data + completeData);
            return completeData;
        }

        public string aling_frame_to_Write(string frame)
        {
            string result = "";
            int y = 2;
            try
            {
                for (int i = 0; i < frame.Length; i += 2)
                {
                    string byte_ = frame.Substring(i, y);
                    if (i == 0)
                        result = byte_;
                    else
                        result = result + " " + byte_;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        private string little_endian(long value, int nbr_bytes)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            string retval = "";
            foreach (byte b in bytes)
            {
                if (retval.Length > 0)
                    retval = retval + " ";
                retval = retval + b.ToString("X2");
            }
            retval = retval.Substring(0, nbr_bytes * 2 + (nbr_bytes - 1));
            return retval;
        }
    }
}
