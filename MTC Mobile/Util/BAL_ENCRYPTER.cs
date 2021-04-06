using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Util
{
    class BAL_ENCRYPTER
    {
        #region Varables definition
        #endregion
        /// <summary>
        /// encrypts or decrypts a recieved string
        /// </summary>
        /// <param name="textEncrypt">string to parse</param>
        /// <returns>parsed string</returns>
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
