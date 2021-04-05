using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;

namespace MTC_Mobile
{
    static class Program
    {
        public static string sPortName = "COM0";
        
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