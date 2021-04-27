using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;

namespace MTC_Mobile
{
    static class Program
    {
        public static SerialPort gblPort = new SerialPort();
        public static string sPortName = "COM0";
        public static byte[] Security;
        public static string loggedUser = "";
        public static string strSetDateTime = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {

            Application.Run(new Home());

        }
    }
}