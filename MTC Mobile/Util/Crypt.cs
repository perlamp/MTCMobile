using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MTC_Mobile.Util
{
    class Crypt
    {
        private static byte[] bKey = new byte[] { 0x02, 0x33, 0xf0, 0xcc, 0x46, 0x72, 0x81, 0x90 };

        private static byte[] bIV = new byte[] { 0x20, 0x33, 0x0f, 0xcc, 0x64, 0x27, 0x18, 0x09 };


        public string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            string hash = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

            return hash;
        }

        private string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            string text = reader.ReadToEnd();

            return text;
        }

        public Boolean Validate(string text, string hashed)
        {
            string decrypted = this.Decrypt(hashed);
            return decrypted.Equals(text);
        }

        public string EncryptDecrypt(string textEncrypt)
        {
            StringBuilder inSb = new StringBuilder(textEncrypt);
            StringBuilder outSb = new StringBuilder(textEncrypt.Length);
            int key = 160;
            char c;
            try
            {
                for (int i = 0; i < textEncrypt.Length; i++)
                {
                    c = inSb[i];
                    c = (char)(c ^ key);
                    outSb.Append(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return outSb.ToString();
        }
    }
}
