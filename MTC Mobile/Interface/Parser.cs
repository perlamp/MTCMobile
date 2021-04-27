using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MTC_Mobile.Interface
{
    public class Parser
    {
        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> { { '0', "0000" }, { '1', "0001" }, { '2', "0010" }, { '3', "0011" }, { '4', "0100" }, { '5', "0101" }, { '6', "0110" }, { '7', "0111" }, { '8', "1000" }, { '9', "1001" }, { 'a', "1010" }, { 'b', "1011" }, { 'c', "1100" }, { 'd', "1101" }, { 'e', "1110" }, { 'f', "1111" } };

        public int hexToDecimal(string hexValues)
        {
            int dResult = 0;
            string[] hexValuesSplit = hexValues.Split(' ');
            foreach (String hex in hexValuesSplit)
            {
                // Convert the number expressed in base-16 to an integer.
                int value = Convert.ToInt32(hex, 16);
                dResult = value;
            }
            return dResult;
        }

        public string hexStringToDecimal(string hex)
        {
            hex = hex.Replace(" ", "");
            string hext = Convert.ToString(Convert.ToInt32(hex, 16), 10);
            return hext;
        }

        /// <summary>
        /// Convierte de hex a ASCII
        /// </summary>
        /// <param name="data_hex">dato en formato hex</param>
        /// <returns>dato en formato ASCCI</returns>
        public string hextostring(string data_hex)
        {
            string caracter = "";
            string[] hexValuesSplit = data_hex.Split(' ');
            foreach (String hex in hexValuesSplit)
            {
                byte[] raw = { Convert.ToByte(hex, 16) };
                string s = Encoding.ASCII.GetString(raw, 0, 1);
                caracter += s;
            }
            return caracter.Replace(" ", "");
        }

        public string hexadecimalToString(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hexString.Length; i += 3)
            {
                string hs = hexString.Substring(i, 2).Replace(" ", "0");
                if (hs != "00")
                    sb.Append(Convert.ToChar(Convert.ToUInt32(hs, 16)));
            }
            string out_string = sb.ToString();
            return out_string;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public string HexadecimalToBinary(string hex)
        {
            hex = hex.Replace(" ", "");
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                // This will crash for non-hex characters. You might want to handle that differently.
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            }
            return result.ToString();
        }

        public string[] epoch2string(Int64 epoch)
        {
            DateTime dt_date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
            //string str_compose = dt_date.ToString();
            DateTime dt = TimeZone.CurrentTimeZone.ToLocalTime(dt_date);
            string[] dates = new string[2];
            dates[0] = dt.ToString();      // Time Zone
            dates[1] = dt_date.ToString(); // GMT 
            return dates;
        }

        public long convertToInt48(string frame)
        {
            long value = 0;
            // get first 4 digits
            string str_int32 = frame.Substring(9, 2) + frame.Substring(6, 2) + frame.Substring(3, 2) + frame.Substring(0, 2);
            value = Convert.ToUInt32(str_int32, 16);
            string next_digit = frame.Substring(12, 2);
            value = value + Convert.ToInt16(next_digit, 16) * 4294967296;
            next_digit = frame.Substring(15, 2);
            value = value + Convert.ToInt16(next_digit, 16) * 1099511627776;
            return value;
        }

        public long convertToInt40(string frame)
        {
            long value = 0;
            // get first 4 digits
            string str_int32 = frame.Substring(9, 2) + frame.Substring(6, 2) + frame.Substring(3, 2) + frame.Substring(0, 2);
            value = Convert.ToUInt32(str_int32, 16);
            string next_digit = frame.Substring(12, 2);
            long sda = Convert.ToInt16(next_digit, 16) * 4294967296;
            value = value + Convert.ToInt16(next_digit, 16) * 4294967296;
            return value;
        }

        public string reverse_string(string frame)
        {
            int length = frame.Replace(" ", "").Length;
            string reversed = "";
            for (int a = 0; a < length; a = a + 2)
            {
                reversed = frame.Replace(" ", "").Substring(a, 2) + reversed;
            }
            return reversed;
        }

        /// <summary>
        /// change the secuence of array and convert to decimal value
        /// </summary>
        /// <param name="lsByte_str"></param>
        /// <returns></returns>
        public string get_little_endian_val(string lsByte_str)
        {
            string tmp_str = "";
            string[] byte_array = lsByte_str.Split(' ');
            foreach (string single_byte in byte_array)
            {
                tmp_str = single_byte + tmp_str;
            }
            string msByte_str = Convert.ToString(Convert.ToInt64(tmp_str, 16), 10);
            return msByte_str;
        }

        /// <summary>
        /// change the secuence of array 
        /// </summary>
        /// <param name="frame"></param>
        /// <returns>string in little endian</returns>
        public string get_little_endian(string frame)
        {
            string str_reverse = "";
            string[] byte_array = frame.Split(' ');
            foreach (string single_byte in byte_array)
            {
                str_reverse = single_byte + str_reverse;
            }

            str_reverse = alignFrame(str_reverse);
            return str_reverse;
        }

        /// <summary>
        /// aligns a recieved frame by adding a blank space to separate every byte on the string
        /// </summary>
        /// <param name="frame">frame to be modified</param>
        /// <returns>frame modified</returns>
        public string alignFrame(string frame)
        {
            try
            {
                string result = "";
                int y = 2;
                for (int i = 0; i < frame.Length; i += 2)
                {
                    string ressult = frame.Substring(i, y);
                    if (i == 0)
                    {
                        result = ressult;
                    }
                    else
                    {
                        result = result + " " + ressult;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error while aligning frame " + ex);
                return "";
            }
        }

        /// <summary>
        /// transforms a string to a byte array
        /// </summary>
        /// <param name="str">string to be parsed</param>
        /// <returns>resulting byte array</returns>
        public byte[] convertStringToByteArray(string str)
        {
            try
            {
                Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
                for (int i = 0; i <= 255; i++)
                    hexindex.Add(i.ToString("X2"), (byte)i);
                List<byte> hexres = new List<byte>();
                for (int i = 0; i < str.Length; i += 3)
                    hexres.Add(hexindex[str.Substring(i, 2)]);

                return hexres.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir a arreglo de bytes " + ex);
                return null;
            }
        }

        public decimal byteArrayToDecimal(byte[] bytes)
        {
            return bytes[0] + bytes[1]; //+ (arg2 << 16) + (arg3 << 24);
        }

        public string get_offset_time_zone(string frame)
        {
            string str_reverse = "";
            string[] byte_array = frame.Split(' ');
            foreach (string single_byte in byte_array)
            {
                str_reverse = single_byte + str_reverse;
            }
            string bitmap = this.HexadecimalToBinary(str_reverse);
            Int32 msByte_str = (1 + (~Convert.ToInt16(str_reverse, 16)));

            if (bitmap.Substring(0, 1).Equals("1"))
            {
                str_reverse = "-" + msByte_str.ToString();
            }
            else
            {
                str_reverse = msByte_str.ToString();
            }
            return str_reverse;
        }

        public string binaryToDecimal(string frame)
        {
            string str = Convert.ToInt32(frame, 2).ToString();
            return str;
        }

        public string getTier(string frame)
        {
            string tier = "";

            string value = binaryToDecimal(frame);

            switch (value)
            {
                case "0":
                    tier = "A";
                    break;
                case "1":
                    tier = "B";
                    break;
                case "2":
                    tier = "C";
                    break;
                case "3":
                    tier = "D";
                    break;
            }

            return tier;
        }

        /// <summary>
        /// Convierte de Litte Endian to Big Endian
        /// </summary>
        /// <param name="frame">dato en formato litte Endian</param>
        /// <returns></returns>
        public string litte_endian_to_big_endian(string frame)
        {
            string litte_endian = "";
            string aux = frame.Replace(" ", "");
            long decValue = Convert.ToInt64(aux, 16);
            byte[] bytes = BitConverter.GetBytes(decValue);
            string a = (BitConverter.ToString(bytes));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            string b = (BitConverter.ToString(bytes));
            // Call method to send byte stream across machine boundaries.
            // Receive byte stream from beyond machine boundaries.
            string c = (BitConverter.ToString(bytes));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            litte_endian = (BitConverter.ToString(bytes));

            if (litte_endian.Length > frame.Length)
            {
                litte_endian = litte_endian.Substring(0, frame.Length);
            }
            litte_endian = litte_endian.Replace("-", " ");
            litte_endian = litte_endian.Replace(" ", "");
            return litte_endian;
        }


        public string litte_endian_to_big_endianConfig(string frame)
        {
            string litte_endian = "";
            string aux = frame.Replace(" ", "");
            long decValue = Convert.ToInt64(aux, 16);
            byte[] bytes = BitConverter.GetBytes(decValue);
            string a = (BitConverter.ToString(bytes));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            string b = (BitConverter.ToString(bytes));
            // Call method to send byte stream across machine boundaries.
            // Receive byte stream from beyond machine boundaries.
            string c = (BitConverter.ToString(bytes));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            litte_endian = (BitConverter.ToString(bytes));

            if (litte_endian.Length > frame.Length)
            {
                litte_endian = litte_endian.Substring(0, frame.Length + 1);
            }
            litte_endian = litte_endian.Replace("-", " ");
            litte_endian = litte_endian.Replace(" ", "");
            return litte_endian;
        }

        public string hexToInt64String(string frame)
        {
            string num = "";
            string aux = frame.Replace("-", "");
            aux = aux.Replace(" ", "");
            Int64 decValue = Convert.ToInt64(aux, 16);
            num = decValue.ToString();
            return num;
        }

        public string[] hexToBinaryArray(string num_to_convert)
        {
            string valBinario = "";
            string aux = num_to_convert.Replace("-", "");
            aux = num_to_convert.Replace(" ", "");
            valBinario = Convert.ToString(Convert.ToInt64(aux, 16), 2);
            string aux_2 = valBinario.PadLeft(8, '0');
            string[] binaryArray = new string[aux_2.Length];
            binaryArray = aux_2.Select(c => c.ToString()).ToArray();
            return binaryArray;
        }

        public int getValueBytes(string interval)
        {
            int value = 0;
            switch (interval)
            {
                case "4":
                    value = 4;
                    break;
                case "8":
                    value = 1;
                    break;
                case "9":
                    value = 5;
                    break;
                case "10":
                    value = 6;
                    break;
                case "16":
                    value = 2;
                    break;
                case "24":
                    value = 3;
                    break;
                case "32":
                    value = 4;
                    break;
                case "40":
                    value = 5;
                    break;
                case "48":
                    value = 6;
                    break;
                case "64":
                    value = 8;
                    break;
            }
            return value;
        }

        public string[] hexToBitmapArray(string num)
        {
            int nbr_bytes = (num.Length + 1) / 3;
            int array_size = nbr_bytes * 8;
            int count = 0;
            string[] bit_array = new string[array_size];
            // extrae byte por byte de num
            for (int a = 0; a < nbr_bytes; a++)
            {
                string value = num.Substring(a * 3, 2);
                string bitmap = Convert.ToString(Convert.ToInt64(value, 16), 2).PadLeft(8, '0');
                for (int b = bitmap.Length - 1; b > -1; b--)
                {
                    bit_array[count] = bitmap.Substring(b, 1);
                    count++;
                }
            }
            return bit_array;
        }

        /// <summary>
        /// function that transforms a recieved hex array intoits corresponding binary values
        /// recieves a string array and returns the resulting binary string (the string may need to be trnsformed into a char array to be inverted).
        /// </summary>
        /// <param name="recievedArray"></param>
        /// <returns></returns>
        /// 
        public string binarizeArray(string[] recievedArray)
        {
            string binResponse = "";
            string temp = "";
            for (int i = 0; i < recievedArray.Length; i++)
            {
                temp = Convert.ToString(HexadecimalToBinary(recievedArray[i].ToUpper()));
                temp = Reverse(temp);
                binResponse += temp;
            }
            return binResponse;
        }

        /// <summary>
        /// invert a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// When a hex little endian string is recieved, the string will previosly be transformed into an string array 
        /// the this function is called to inver the little endian hex bytes.
        /// the function will recieve a string array as a parameter to be inverted and will return the resulting inverted string array.
        /// </summary>
        /// <param name="recievedArray"></param>
        /// <returns></returns>
        public string[] invertArray(string[] recievedArray)
        {
            string[] temp = new string[recievedArray.Length];
            int count = 0;
            for (int i = recievedArray.Length - 1; i >= 0; i--)
            {
                temp[count] = recievedArray[i];
                count++;
            }
            return temp;
        }

        /// <summary>
        /// recieves a given array concats all values into a single string
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        public string arrayToString(string[] stringArray)
        {
            string temp = "";
            for (int i = 0; i < stringArray.Length; i++)
            {
                temp += stringArray[i];
            }
            return temp;
        }

        public string invertFrameHexadecimal(string frame)
        {
            string newHex = "";
            try
            {
                frame = frame.Replace(" ", "").ToUpper();

                for (int i = 0; i < frame.Length; i += 2)
                {
                    if (i.Equals(0))
                    {
                        newHex = frame.Substring(i, 2);
                    }
                    else
                    {
                        newHex = frame.Substring(i, 2) + " " + newHex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newHex;
        }

        /// <summary>
        /// deletes a given char into a string
        /// </summary>
        /// <param name="data">string to be parsed</param>
        /// <param name="letter">char to be removed</param>
        /// <returns></returns>
        public string clearCharInString(string data, char letter)
        {//recibe frame y elimina char de un tipo
            string newstring = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (!data[i].Equals(letter))
                    newstring += data[i].ToString();
            }
            return newstring;
        }

        public int hexToDecimalFile(string frame)
        {
            int decimal_ = 0;
            string b = "";
            frame = frame.Replace(" ", "").ToUpper();
            try
            {
                for (int i = frame.Length - 2; i >= 0; i -= 2)
                {
                    string a = frame.Substring(i, 2);
                    b += a;
                }

                int valDecimal = 0;
                int count = 0;
                for (int i = b.Length - 1; i >= 0; i--)
                {
                    valDecimal = Convert.ToInt32(b.Substring(i, 1), 16);
                    valDecimal = Convert.ToInt32(valDecimal * (Math.Pow(16, count)));
                    decimal_ = decimal_ + Convert.ToInt32(valDecimal);
                    count++;
                }
            }
            catch
            {
                throw;
            }
            return decimal_;
        }

        public string stringToHex(string hexstring)
        {
            var sb = new StringBuilder();
            foreach (char t in hexstring)
                sb.Append(Convert.ToInt32(t).ToString("x") + " ");
            return sb.ToString();
        }

        public string numberBytesST0(string bin)
        {
            string resultado = "";
            int data = Convert.ToInt32(bin, 2);
            switch (data)
            {
                case 0:
                    {
                        resultado = "8";
                    }
                    break;
                case 1:
                    {
                        resultado = "4";
                    }
                    break;
                case 2:
                    {
                        resultado = "12";
                    }
                    break;
                case 3:
                    {
                        resultado = "6";
                    }
                    break;
                case 4:
                    {
                        resultado = "4";
                    }
                    break;
                case 5:
                    {
                        resultado = "6";
                    }
                    break;
                case 6:
                    {
                        resultado = "4";
                    }
                    break;
                case 7:
                    {
                        resultado = "3";
                    }
                    break;
                case 8:
                    {
                        resultado = "4";
                    }
                    break;
                case 9:
                    {//9
                        resultado = "5";
                    }
                    break;
                case 10:
                    {//10
                        resultado = "6";
                    }
                    break;
                case 11:
                    {
                        resultado = "8";
                    }
                    break;
                case 12:
                    {
                        resultado = "8";
                    }
                    break;
                case 13:
                    {
                        resultado = "21";
                    }
                    break;
            }
            return resultado;
        }

        public string numberBytesST00TFormat(string bin)
        {
            string resultado = "";
            int data = Convert.ToInt32(bin, 2);
            switch (data)
            {
                case 0:
                    {
                        resultado = "0";
                    }
                    break;
                case 1:
                    {
                        resultado = "7";
                    }
                    break;
                case 2:
                    {
                        resultado = "7";
                    }
                    break;
                case 3:
                    {
                        resultado = "4";
                    }
                    break;
                case 4:
                    {
                        resultado = "4";
                    }
                    break;
            }
            return resultado;
        }

        public string getDayOfWeek(string frame)
        {
            string dayOfWeek = "";
            string strTemp = "";

            if (frame.Length > 1)
            {
                strTemp = this.binaryToDecimal(frame.Substring(5, 3));
            }
            else
            {
                strTemp = frame;
            }


            switch (strTemp)
            {
                case "0":
                    dayOfWeek = "Sunday";
                    break;
                case "1":
                    dayOfWeek = "Monday";
                    break;
                case "2":
                    dayOfWeek = "Tuesday";
                    break;
                case "3":
                    dayOfWeek = "Wednesday";
                    break;
                case "4":
                    dayOfWeek = "Thursday";
                    break;
                case "5":
                    dayOfWeek = "Friday";
                    break;
                case "6":
                    dayOfWeek = "Saturday";
                    break;
            }
            return dayOfWeek;
        }

        public string getMonth(string index)
        {
            string month = "";
            switch (index)
            {
                case "0":
                    month = "Period in minutes";
                    break;
                case "1":
                    month = "January";
                    break;
                case "2":
                    month = "February";
                    break;
                case "3":
                    month = "March";
                    break;
                case "4":
                    month = "April";
                    break;
                case "5":
                    month = "May";
                    break;
                case "6":
                    month = "June";
                    break;
                case "7":
                    month = "July";
                    break;
                case "8":
                    month = "August";
                    break;
                case "9":
                    month = "September";
                    break;
                case "10":
                    month = "October";
                    break;
                case "11":
                    month = "November";
                    break;
                case "12":
                    month = "December";
                    break;
                case "13":
                    month = "Monthly";
                    break;
                case "14":
                    month = "Weekly";
                    break;
                case "15":
                    month = "Period in days";
                    break;
            }
            return month;
        }

        public string getCalendarControl(string index)
        {
            string valueCalendarAction = "";

            switch (Convert.ToInt16(index))
            {
                case 0:

                    valueCalendarAction = "No Action";
                    break;
                case 1:
                    valueCalendarAction = "Daylight Saving Time On";
                    break;
                case 2:
                    valueCalendarAction = "Daylight Saving Time Off";
                    break;
                case 3:
                    valueCalendarAction = "Season 0";
                    break;
                case 4:
                    valueCalendarAction = "Season 1";
                    break;
                case 5:
                    valueCalendarAction = "Season 2";
                    break;
                case 6:
                    valueCalendarAction = "Season 3";
                    break;
                case 7:
                    valueCalendarAction = "Season 4";
                    break;
                case 8:
                    valueCalendarAction = "Season 5";
                    break;
                case 9:
                    valueCalendarAction = "Season 6";
                    break;
                case 10:
                    valueCalendarAction = "Season 7";
                    break;
                case 11:
                    valueCalendarAction = "Season 8";
                    break;
                case 12:
                    valueCalendarAction = "Season 9";
                    break;
                case 13:
                    valueCalendarAction = "Season 10";
                    break;
                case 14:
                    valueCalendarAction = "Season 11";
                    break;
                case 15:
                    valueCalendarAction = "Season 12";
                    break;
                case 16:
                    valueCalendarAction = "Season 13";
                    break;
                case 17:
                    valueCalendarAction = "Season 14";
                    break;
                case 18:
                    valueCalendarAction = "Reserved";
                    break;
                case 19:
                    valueCalendarAction = "Special Schedule 0";
                    break;
                case 20:
                    valueCalendarAction = "Special Schedule 1";
                    break;
                case 21:
                    valueCalendarAction = "Special Schedule 2";
                    break;
                case 22:
                    valueCalendarAction = "Special Schedule 3";
                    break;
                case 23:
                    valueCalendarAction = "Special Schedule 4";
                    break;
                case 24:
                    valueCalendarAction = "Special Schedule 5";
                    break;
                case 25:
                    valueCalendarAction = "Special Schedule 6";
                    break;
                case 26:
                    valueCalendarAction = "Special Schedule 7";
                    break;
                case 27:
                    valueCalendarAction = "Special Schedule 8";
                    break;
                case 28:
                    valueCalendarAction = "Special Schedule 9";
                    break;
                case 29:
                    valueCalendarAction = "Special Schedule 10";
                    break;
                case 30:
                    valueCalendarAction = "Special Schedule 11";
                    break;
            }
            return valueCalendarAction;
        }

        public string getOffset(string index)
        {
            string offset = "";

            switch (index)
            {
                case "0":
                    offset = "No offset";
                    break;
                case "1":
                    offset = "Monday";
                    break;
                case "2":
                    offset = "Postpone to the first WEEKDAY";
                    break;
            }
            return offset;
        }

        public string autocompleteBytes(string frame, int size)
        {
            string data = "";

            string aux = "";
            for (int i = frame.Length; i < size; i++)
            {
                aux += "0";
            }
            data = aux + frame;
            if (frame.Length > 2)
            {
                data = alignFrame(data.Replace(" ", ""));
            }
            return data;
        }

        public string autocompleteBytes(string frame, int size, string val, int interval)
        {
            string data = "";
            string aux = "";
            for (int i = frame.Length; i < size; i += interval)
            {
                aux += val;
            }
            if (val.Equals("20") || val.Equals("30"))
            {
                data = frame + aux;
            }
            else
            {
                data = aux + frame;
            }
            data = alignFrame(data.Replace(" ", ""));
            return data;
        }

        public byte[] hexadecimalToBytesArray(string input)
        {
            var result = new byte[(input.Length + 1) / 3];
            int aux = 0;

            for (int i = 0; i < (input.Length + 1) / 3; i++)
            {
                result[i] = (byte)Convert.ToUInt32(input.Substring(aux, 2), 16);
                aux += 3;
            }
            return result;
        }

        public string decimalToHexadecimal(string value)
        {
            string bin = Convert.ToString(Convert.ToInt32(value, 10), 16).ToUpper();
            if (bin.Length.Equals(1))
            {
                bin = "0" + bin;
            }
            return bin;
        }

        public byte[] hexadecimalToBytes(string input)
        {
            var result = new byte[(input.Length + 1) / 3];
            int aux = 0;

            for (int i = 0; i < (input.Length + 1) / 3; i++)
            {
                result[i] = (byte)Convert.ToUInt32(input.Substring(aux, 2), 16);
                aux += 3;
            }
            return result;
        }

        public string hexadecimalToASCII(String hexString)
        {
            try
            {
                string ascii = "";
                hexString = clearCharInString(hexString, ' ');
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = "";
                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;
                }
                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return string.Empty;
        }

        public IDictionary<string, string[]> ParseTableData(string table, string data)
        {
            table = table.Replace("-", "");

            Type t = this.GetType();
            MethodInfo m = t.GetMethod("parse" + table);

            IDictionary<string, string[]> dict = new Dictionary<string, string[]>();

            try
            {
                dict = (IDictionary<string, string[]>)m.Invoke(this, new object[] { data });
               
            }
            catch (Exception ex)
            {

            }
            return dict;
        }

        public IDictionary<string, string[]> parseMT1(string stringData)
        {
            IDictionary<string, string[]> dict = new Dictionary<string, string[]>();
            string[] arrData = stringData.Split(' ');

            string[] arrFP = new string[8];
            for (var i = 0; i < 8; i++)
            {
                arrFP[i] = arrData[i];
            }
            string strFP = string.Join(" ", arrFP);
            string[] dataFP = new string[] { strFP, this.hextostring(strFP) };
            dict.Add("FW_PART_NUMBER", dataFP);

            return dict;
        }

        public IDictionary<string, string[]> parseST1(string stringData)
        {
            IDictionary<string, string[]> dict = new Dictionary<string, string[]>();
            string[] arrData = stringData.Split(' ');

            int j = 0;
            string[] arrM = new string[4];
            for (var i = 0; i <= 3; i++)
            {
                arrM[j] = arrData[i];
                j++;
            }
            string strM = string.Join(" ", arrM);
            string[] dataM = new string[] { strM, this.hextostring(strM) };
            dict.Add("MANUFACTURER", dataM);

            j = 0;
            string[] arrEM = new string[8];
            for (var i = 4; i <= 11; i++)
            {
                arrEM[j] = arrData[i];
                j++;
            }
            string strEM = string.Join(" ", arrEM);
            string[] dataEM = new string[] { strEM, this.hextostring(strEM) };
            dict.Add("ED_MODEL", dataEM);

            string strHVN = arrData[12];
            string[] dataHVN = new string[] { strHVN, this.hexToDecimal(strHVN).ToString() };
            dict.Add("HW_VERSION_NUMBER", dataHVN);

            string strHRN = arrData[13];
            string[] dataHRN = new string[] { strHRN, this.hexToDecimal(strHRN).ToString() };
            dict.Add("HW_REVISION_NUMBER", dataHRN);

            string strFVN = arrData[14];
            string[] dataFVN = new string[] { strFVN, this.hexToDecimal(strFVN).ToString() };
            dict.Add("FW_VERSION_NUMBER", dataFVN);

            string strFRN = arrData[15];
            string[] dataFRN = new string[] { strFRN, this.hexToDecimal(strFRN).ToString() };
            dict.Add("FW_REVISION_NUMBER", dataFRN);

            j = 0;
            string[] arrMSN = new string[16];
            for (var i = 16; i <= 31; i++)
            {
                arrMSN[j] = arrData[i];
                j++;
            }
            string strMSN = string.Join(" ", arrMSN);
            string[] dataMSN = new string[] { strMSN, this.hextostring(strMSN) };
            dict.Add("MFG_SERIAL_NUMBER", dataMSN);

            return dict;
        }

        public IDictionary<string, string[]> parseST6(string stringData)
        {
            IDictionary<string, string[]> dict = new Dictionary<string, string[]>();
            string[] arrData = stringData.Split(' ');
            
            int j = 0;
            string[] arrON = new string[20];
            for (var i = 0; i <= 19 ; i++)
            {
                arrON[j] = arrData[i];
                j++;
            }
            string strON = string.Join(" ", arrON);
            string[] dataON = new string[] { strON, this.hextostring(strON) };
            dict.Add("OWNER_NAME", dataON);
            
            j = 0;
            string[] arrUD = new string[20];
            for (var i = 20; i <= 39; i++)
            {
                arrUD[j] = arrData[i];
                j++;
            }
            string strUD = string.Join(" ", arrUD);
            string[] dataUD = new string[] { strUD, this.hextostring(strUD) };
            dict.Add("UTILITY_DIV", dataUD);
            
            j = 0;
            string[] arrSPI = new string[20];
            for (var i = 40; i <= 59; i++)
            {
                arrSPI[j] = arrData[i];
                j++;
            }
            string strSPI = string.Join(" ", arrSPI);
            string[] dataSPI = new string[] { strSPI, this.hextostring(strSPI) };
            dict.Add("SERVICE_POINT_ID", dataSPI);

            j = 0;
            string[] arrEA = new string[20];
            for (var i = 60; i <= 79; i++)
            {
                arrEA[j] = arrData[i];
                j++;
            }
            string strEA = string.Join(" ", arrEA);
            string[] dataEA = new string[] { strEA, this.hextostring(strEA) };
            dict.Add("ELEC_ADDR", dataEA);

            j = 0;
            string[] arrDI = new string[20];
            for (var i = 80; i <= 99; i++)
            {
                arrDI[j] = arrData[i];
                j++;
            }
            string strDI = string.Join(" ", arrDI);
            string[] dataDI = new string[] { strDI, this.hextostring(strDI) };
            dict.Add("DEVICE_ID", dataDI);

            j = 0;
            string[] arrUSN = new string[20];
            for (var i = 100; i <= 119; i++)
            {
                arrUSN[j] = arrData[i];
                j++;
            }
            string strUSN = string.Join(" ", arrUSN);
            string[] dataUSN = new string[] { strUSN, this.hextostring(strUSN) };
            dict.Add("UTIL_SER_NO", dataUSN);

            j = 0;
            string[] arrCI = new string[20];
            for (var i = 120; i <= 139; i++)
            {
                arrCI[j] = arrData[i];
                j++;
            }
            string strCI = string.Join(" ", arrCI);
            string[] dataCI = new string[] { strCI, this.hextostring(strCI) };
            dict.Add("CUSTOMER_ID", dataCI);

            j = 0;
            string[] arrC1 = new string[10];
            for (var i = 140; i <= 149; i++)
            {
                arrC1[j] = arrData[i];
                j++;
            }
            string strC1 = string.Join(" ", arrC1);
            string[] dataC1 = new string[] { strC1, this.hexToDecimal(strC1).ToString() };
            dict.Add("COORDINATE_1", dataC1);

            j = 0;
            string[] arrC2 = new string[10];
            for (var i = 150; i <= 159; i++)
            {
                arrC2[j] = arrData[i];
                j++;
            }
            string strC2 = string.Join(" ", arrC2);
            string[] dataC2 = new string[] { strC2, this.hexToDecimal(strC2).ToString() };
            dict.Add("COORDINATE_2", dataC2);

            j = 0;
            string[] arrC3 = new string[10];
            for (var i = 160; i <= 169; i++)
            {
                arrC3[j] = arrData[i];
                j++;
            }
            string strC3 = string.Join(" ", arrC3);
            string[] dataC3 = new string[] { strC3, this.hexToDecimal(strC3).ToString() };
            dict.Add("COORDINATE_3", dataC3);

            j = 0;
            string[] arrTI = new string[8];
            for (var i = 170; i <= 177; i++)
            {
                arrTI[j] = arrData[i];
                j++;
            }
            string strTI = string.Join(" ", arrTI);
            string[] dataTI = new string[] { strTI, this.hextostring(strTI) };
            dict.Add("TARIFF_ID", dataTI);

            j = 0;
            string[] arrE1SV = new string[4];
            for (var i = 178; i <= 181; i++)
            {
                arrE1SV[j] = arrData[i];
                j++;
            }
            string strE1SV = string.Join(" ", arrE1SV);
            string[] dataE1SV = new string[] { strE1SV, this.hextostring(strE1SV) };
            dict.Add("EX1_SW_VENDOR", dataE1SV);

            string strE1SVN = arrData[182];
            string[] dataE1SVN = new string[] { strE1SVN, this.hexToDecimal(strE1SVN).ToString() };
            dict.Add("EX1_SW_VENDOR_NUMBER", dataE1SVN);

            string strE1SRN = arrData[183];
            string[] dataE1SRN = new string[] { strE1SRN, this.hexToDecimal(strE1SRN).ToString() };
            dict.Add("EX1_SW_REVISION_NUMBER", dataE1SRN);

            j = 0;
            string[] arrE2SV = new string[4];
            for (var i = 184; i <= 187; i++)
            {
                arrE2SV[j] = arrData[i];
                j++;
            }
            string strE2SV = string.Join(" ", arrE2SV);
            string[] dataE2SV = new string[] { strE2SV, this.hextostring(strE2SV) };
            dict.Add("EX2_SW_VENDOR", dataE2SV);

            string strE2SVN = arrData[188];
            string[] dataE2SVN = new string[] { strE2SVN, this.hexToDecimal(strE2SVN).ToString() };
            dict.Add("EX2_SW_VENDOR_NUMBER", dataE2SVN);

            string strE2SRN = arrData[189];
            string[] dataE2SRN = new string[] { strE2SRN, this.hexToDecimal(strE2SRN).ToString() };
            dict.Add("EX2_SW_REVISION_NUMBER", dataE2SRN);

            j = 0;
            string[] arrPN = new string[10];
            for (var i = 190; i <= 199; i++)
            {
                arrPN[j] = arrData[i];
                j++;
            }
            string strPN = string.Join(" ", arrPN);
            string[] dataPN = new string[] { strPN, this.hextostring(strPN) };
            dict.Add("PROGRAMMER_NAME", dataPN);

            j = 0;
            string[] arrMI = new string[30];
            for (var i = 200; i <= 229; i++)
            {
                arrMI[j] = arrData[i];
                j++;
            }
            string strMI = string.Join(" ", arrMI);
            string[] dataMI = new string[] { strMI, this.hextostring(strMI) };
            dict.Add("MISC_ID", dataMI);

            return dict;
        }
    }
}
