using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ProtocolC1218
{
    public class util
    {
        /** 
       ******************************************************************************
       * \fn byte[] string_to_byte_array(string str)
       * \brief 
       *
       * 
       * \param void
       * \retval void
       ******************************************************************************
       */
        public byte[] StringHex_to_ByteBuffer(string StringHex)
        {
            StringHex = aling_frame(StringHex, 2);

            Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
            for (int i = 0; i <= 255; i++)
                hexindex.Add(i.ToString("X2"), (byte)i);

            List<byte> hexres = new List<byte>();
            for (int i = 0; i < StringHex.Length; i += 3)
                hexres.Add(hexindex[StringHex.Substring(i, 2)]);

            return hexres.ToArray();
        }

        /** 
        ******************************************************************************
        * \fn public string ByteBuffer_to_StringHex(Byte[] buffer, UInt16 buffer_len)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public string ByteBuffer_to_StringHex(Byte[] buffer, UInt16 buffer_len)
        {
            string buffer_strg = "";
            int i;

            for (i = 0; i < buffer_len; i++)
            {
                buffer_strg += StringDec_to_StringHex(buffer[i].ToString());
                buffer_strg += " ";
            }

            return buffer_strg;
        }

        /** 
        ******************************************************************************
        * \fn String StringDec_to_StringHex(String StringDec)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public String StringDec_to_StringHex(String StringDec)
        {
            string bin = Convert.ToString(Convert.ToInt32(StringDec, 10), 16).ToUpper();
            if (bin.Length.Equals(1))
            {
                bin = "0" + bin;
            }

            return bin;
        }

        /** 
        ******************************************************************************
        * \fn string string_to_binary(string data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public string string_to_binary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));

            }
            return sb.ToString();
        }

        /** 
        ******************************************************************************
        * \fn string aling_frame(string frame)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public string aling_frame(string frame, byte nbr_chars)
        {
            int i = 0;
            string result = "";
            string new_frame = "";
            string character;

            for (i = 0; i < frame.Length; i++)
            {
                character = frame.Substring(i, 1);

                if (character != " ")
                {
                    new_frame += character;
                }
            }

            frame = new_frame;
            if (frame.Length % nbr_chars == 0)
            {
                for (i = 0; i < frame.Length; i += nbr_chars)
                {
                    string ressult = frame.Substring(i, nbr_chars);

                    if (i == 0)
                    {
                        result = ressult;
                    }
                    else
                    {
                        result = result + " " + ressult;
                    }
                }
            }

            return result;
        }

        /** 
        ******************************************************************************
        * \fn public UInt16 get_frame_length(string frame)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public UInt16 get_frame_length(string frame)
        {
            Byte[] data_hex;
            UInt16 length;

            data_hex = this.StringHex_to_ByteBuffer(frame);
            length = Convert.ToUInt16(data_hex.Length);

            return length;
        }

        /** 
        ******************************************************************************
        * \fn public Byte StringHex_to_Byte(string hex_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public Byte StringHex_to_Byte(string hex_data)
        {
            Byte[] byteArray_data;
            Byte byte_data = 0;
            uint i;
            string fill = "";
            string backup = "";

            if (hex_data.Length <= 2)
            {
                for (i = 0; i < (2 - hex_data.Length); i++)
                {
                    fill += "0";
                }
                backup = hex_data;
                hex_data = fill + backup;
                byteArray_data = StringHex_to_ByteBuffer(hex_data);
                byte_data = byteArray_data[0];
            }

            return byte_data;
        }

        /** 
        ******************************************************************************
        * \fn public String Byte_to_StringHex(Byte byte_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public String Byte_to_StringHex(Byte byte_data)
        {
            int i;
            String StringHex;

            StringHex = StringDec_to_StringHex(byte_data.ToString());

            for (i = StringHex.Length; i < 2; i++)
            {
                StringHex = "0" + StringHex;
            }

            return StringHex;
        }

        /** 
        ******************************************************************************
        * \fn public Byte StringDec_to_Byte(string dec_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public Byte StringDec_to_Byte(string dec_data)
        {
            UInt64 num;
            Byte byte_data = 0;

            num = Convert.ToUInt64(dec_data);

            if (num <= 0xFF)
            {
                byte_data = Convert.ToByte(num);
            }

            return byte_data;
        }

        /** 
        ******************************************************************************
        * \fn public String Byte_to_StringHex(Byte byte_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public String Byte_to_StringDec(Byte byte_data)
        {
            String StringDec;

            StringDec = byte_data.ToString();

            return StringDec;
        }

        /* 
        ******************************************************************************
        * \fn public UInt16 StringHex_to_UInt16(string hex_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex_data"></param>
        /// <returns></returns>
        public UInt16 StringHex_to_UInt16(string hex_data)
        {
            Byte[] byteArray_data;
            UInt16 byte_data = 0;
            uint i;
            string fill = "";
            string backup = "";

            if (hex_data.Length <= 4)
            {
                for (i = 0; i < (4 - hex_data.Length); i++)
                {
                    fill += "0";
                }
                backup = hex_data;
                hex_data = fill + backup;
                byteArray_data = StringHex_to_ByteBuffer(hex_data);
                byte_data = Convert.ToUInt16(byteArray_data[0] << 8);
                byte_data |= Convert.ToUInt16(byteArray_data[1]);
            }

            return byte_data;
        }

        /** 
      ******************************************************************************
      * \fn public String UInt16_to_StringHex(UInt16 UInt16_data)
      * \brief 
      *
      * 
      * \param void
      * \retval void
      ******************************************************************************
      */
        public String UInt16_to_StringHex(UInt16 UInt16_data)
        {
            int i;
            String StringHex;

            StringHex = StringDec_to_StringHex(UInt16_data.ToString());

            for (i = StringHex.Length; i < 4; i++)
            {
                StringHex = "0" + StringHex;
            }

            return StringHex;
        }

        /** 
        ******************************************************************************
        * \fn public UInt16 StringDec_to_UInt16(string dec_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public UInt16 StringDec_to_UInt16(string dec_data)
        {
            UInt64 num;
            UInt16 byte_data = 0;

            num = Convert.ToUInt64(dec_data);

            if (num <= 0xFFFF)
            {
                byte_data = Convert.ToUInt16(num);
            }

            return byte_data;
        }

        /** 
        ******************************************************************************
        * \fn public String UInt16_to_StringDec(UInt16 byte_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public String UInt16_to_StringDec(UInt16 UInt16_data)
        {
            String StringDec;

            StringDec = UInt16_data.ToString();

            return StringDec;
        }

        /** 
       ******************************************************************************
       * \fn public UInt32 StringHex_to_UInt32(string hex_data)
       * \brief 
       *
       * 
       * \param void
       * \retval void
       ******************************************************************************
       */
        public UInt32 StringHex_to_UInt32(string hex_data)
        {
            Byte[] byteArray_data;
            UInt32 byte_data = 0;
            uint i;
            string fill = "";
            string backup = "";

            if (hex_data.Length <= 8)
            {
                for (i = 0; i < (8 - hex_data.Length); i++)
                {
                    fill += "0";
                }
                backup = hex_data;
                hex_data = fill + backup;

                byteArray_data = StringHex_to_ByteBuffer(hex_data);
                byte_data = Convert.ToUInt16(byteArray_data[0] << 24);
                byte_data |= Convert.ToUInt16(byteArray_data[1] << 16);
                byte_data |= Convert.ToUInt16(byteArray_data[2] << 8);
                byte_data |= Convert.ToUInt16(byteArray_data[3]);
            }

            return byte_data;
        }

        /** 
       ******************************************************************************
       * \fn public String UInt32_to_StringHex(UInt32 UInt32_data)
       * \brief 
       *
       * 
       * \param void
       * \retval void
       ******************************************************************************
       */
        public String UInt32_to_StringHex(UInt32 UInt32_data)
        {
            int i;
            String StringHex;

            StringHex = StringDec_to_StringHex(UInt32_data.ToString());

            for (i = StringHex.Length; i < 8; i++)
            {
                StringHex = "0" + StringHex;
            }

            return StringHex;
        }

        /** 
       ******************************************************************************
       * \fn public UInt32 StringDec_to_UInt32(string dec_data)
       * \brief 
       *
       * 
       * \param void
       * \retval void
       ******************************************************************************
       */
        public UInt32 StringDec_to_UInt32(string dec_data)
        {
            UInt64 num;
            UInt32 byte_data = 0;

            num = Convert.ToUInt64(dec_data);

            if (num <= 0xFFFFFFFF)
            {
                byte_data = Convert.ToUInt32(num);
            }

            return byte_data;
        }

        /** 
        ******************************************************************************
        * \fn public String UInt32_to_StringDec(UInt16 byte_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public String UInt32_to_StringDec(UInt32 UInt32_data)
        {
            String StringDec;

            StringDec = UInt32_data.ToString();

            return StringDec;
        }

        /** 
        ******************************************************************************
        * \fn public UInt64 StringHex_to_Uint64(string hex_data)
        * \brief 
        *
        * 
        * \param void
        * \retval void
        ******************************************************************************
        */
        public UInt64 StringHex_to_Uint64(string hex_data)
        {
            Byte[] byteArray_data;
            UInt64 byte_data = 0;
            uint i;
            string fill = "";
            string backup = "";

            if (hex_data.Length <= 64)
            {
                for (i = 0; i < (64 - hex_data.Length); i++)
                {
                    fill += "0";
                }
                backup = hex_data;
                hex_data = fill + backup;
                byteArray_data = StringHex_to_ByteBuffer(hex_data);
                byte_data = Convert.ToUInt16(byteArray_data[0] << 56);
                byte_data |= Convert.ToUInt16(byteArray_data[1] << 48);
                byte_data |= Convert.ToUInt16(byteArray_data[2] << 40);
                byte_data |= Convert.ToUInt16(byteArray_data[3] << 32);
                byte_data |= Convert.ToUInt16(byteArray_data[4] << 24);
                byte_data |= Convert.ToUInt16(byteArray_data[5] << 16);
                byte_data |= Convert.ToUInt16(byteArray_data[6] << 8);
                byte_data |= Convert.ToUInt16(byteArray_data[7]);
            }

            return byte_data;
        }

        public String StringHexArray_to_StringDecArray(String StringHexArray)
        {
            Byte i, j;
            string Hex_Byte;
            string Dec_Byte;
            string StringDecArray = "";
            string fill = "";
            string backup = "";

            for (i = 0; i < ((StringHexArray.Length + 1) / 3); i++)
            {
                Hex_Byte = StringHexArray.Substring(i * 3, 2);
                Dec_Byte = Byte_to_StringDec(StringHex_to_Byte(Hex_Byte));

                fill = "";
                for (j = 0; j < (3 - Dec_Byte.Length); j++)
                {
                    fill += "0";
                }

                backup = Dec_Byte;
                Dec_Byte = fill + backup;

                StringDecArray += Dec_Byte;
            }

            StringDecArray = aling_frame(StringDecArray, 3);

            return StringDecArray;
        }


        public String StringDecArray_to_StringHexArray(String StringDecArray)
        {
            Byte i, j;
            string Hex_Byte;
            string Dec_Byte;
            string StringHexArray = "";
            string fill = "";
            string backup = "";

            for (i = 0; i < ((StringDecArray.Length + 1) / 4); i++)
            {
                Dec_Byte = StringDecArray.Substring(i * 4, 3);
                Hex_Byte = Byte_to_StringHex(StringDec_to_Byte(Dec_Byte));

                fill = "";
                for (j = 0; j < (2 - Hex_Byte.Length); j++)
                {
                    fill += "0";
                }
                backup = Hex_Byte;
                Hex_Byte = fill + backup;

                StringHexArray += Hex_Byte;
            }

            StringHexArray = aling_frame(StringHexArray, 2);

            return StringHexArray;
        }

        public String StringHexArray_to_StringASCIIArray(String StringHexArray)
        {
            Byte i;
            string Hex_Byte;
            string ASCII_Byte;
            string StringASCIIArray = "";

            for (i = 0; i < ((StringHexArray.Length + 1) / 3); i++)
            {
                Hex_Byte = StringHexArray.Substring(i * 3, 2);
                ASCII_Byte = StringHex_to_StringASCII(Hex_Byte);

                StringASCIIArray += ASCII_Byte;
            }

            return StringASCIIArray;
        }

        public String StringASCIIArray_to_StringHexArray(String StringASCIIArray)
        {
            Byte i, j;
            string Hex_Byte;
            string ASCII_Byte;
            string StringHexArray = "";
            string fill = "";
            string backup = "";

            for (i = 0; i < (StringASCIIArray.Length); i++)
            {
                ASCII_Byte = StringASCIIArray.Substring(i, 1);
                Hex_Byte = StringASCII_to_StringHex(ASCII_Byte);

                fill = "";
                for (j = 0; j < (2 - Hex_Byte.Length); j++)
                {
                    fill += "0";
                }

                backup = Hex_Byte;
                Hex_Byte = fill + backup;

                StringHexArray += Hex_Byte;
            }

            StringHexArray = aling_frame(StringHexArray, 2);

            return StringHexArray;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UInt16_data"></param>
        /// <returns></returns>
        public String int_to_StringHex(int data)
        {
            int i;
            String StringHex;

            StringHex = StringDec_to_StringHex(data.ToString());

            for (i = StringHex.Length; i < 6; i++)
            {
                StringHex = "0" + StringHex;
            }

            return StringHex;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iteration"></param>
        /// <returns></returns>
        public String getOffset(int iteration)
        {
            String offset = "";

            int int_offset = iteration * 5000;


            offset = int_to_StringHex(int_offset);

            return offset;
        }

        public String StringHex_to_StringASCII(String StringHex)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < StringHex.Length; i += 2)
            {
                String str = StringHex.Substring(i, 2);
                output.Append((char)Convert.ToInt16(str, 16));
            }
            return output.ToString();
        }

        public String StringASCII_to_StringHex(String asciiValue)
        {
            char[] chars = asciiValue.ToCharArray();
            String hex = "";
            byte m;

            for (int i = 0; i < chars.Length; i++)
            {
                m = Convert.ToByte(chars[i]);
                hex = StringDec_to_StringHex(m.ToString());
            }
            return hex;
        }
    }
}
