using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Business
{
    class ReadFile
    {
        /*Interface.Parser parser = new Interface.Parser();
        Interface.Meter deviceInterface = new Interface.Meter();

        public int[,] table_dir = new int[300, 3];
        string[] file_read = new string[0];
        byte[] tbl_byte_array;
        // string path;
        int[] table = { 1, 6, 7, 11, 13, 20, 21, 22, 23, 24, 25, 26, 27, 41, 42, 43, 44, 51, 53, 54, 61, 62, 71, 73, 75 };
        string pathDirectoryReadings = "C:\\PLive\\mm\\data\\readings\\";
        string pathDirectoryPrograms = "C:\\PLive\\mm\\data\\programs\\";
        string pathDirectoryPassword = "C:\\PLive\\mm\\password\\";
        string pathDirectoryMaster = "C:\\PLive\\mm\\master\\";
        string pathDirectoryConfigPort = "C:\\PLive\\mm\\data\\Port\\";
        string pathDirectoryIdSocket = "C:\\PLive\\mm\\data\\Socket\\";
        string pathDirectoryConfigElements = "C:\\PLive\\mm\\data\\ConfigElements\\";
        string pathDirectoryControlConfigElements = "C:\\PLive\\mm\\data\\ConfigElements\\FilesConfig\\";

        /// <summary>
        /// Selected password access to the meter
        /// </summary>
        /// <param name="user">Rol User Logged</param>
        /// <returns>password for access to meter</returns>
        public byte[] selectSecurity(string user, byte identity)
        {
            DeviceInterface.mm100 deviceInterface = new DeviceInterface.mm100();
            SecurityHandler.SecurityHandler_DB db = new SecurityHandler.SecurityHandler_DB();
            byte[] result = new byte[29];// = false;
            string[] dataRow = new string[2];
            try
            {
                List<String> lstUser = db.selectSingleUser(user);
                List<String[]> lsPasswords = db.queryUserPasswords(int.Parse(lstUser[0]));

                foreach (string[] tmp in lsPasswords)
                {
                    if (lstUser[6].Equals(tmp[2]))
                    {
                        dataRow[0] = tmp[4];
                        dataRow[1] = tmp[3];
                        break;
                    }
                    else if (lstUser[6].Equals("4") || lstUser[6].Equals("8"))
                    {
                        dataRow[0] = tmp[4];
                        dataRow[1] = tmp[3];
                        break;
                    }
                }

                for (int i = 1; i > -1; i--)
                {
                    if (!dataRow[i].Equals(""))
                    {
                        if (deviceInterface.validatePassword(parser.hexadecimalToBytesArray(parser.autocompleteBytes(parser.StringToHexadecimal(dataRow[i]).Replace(" ", ""), 40, "20", 2).ToUpper()), Program.gblPort.PortName, identity))
                        {
                            result = parser.hexadecimalToBytesArray(parser.autocompleteBytes(parser.StringToHexadecimal(dataRow[i]).Replace(" ", ""), 40, "20", 2).ToUpper());
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
           
        }*/
    }
}
