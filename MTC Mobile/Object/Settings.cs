using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Util
{
    class Settings
    {
        private int id;

        private string storagePath;

        private int? userId;

        private static byte[] logon = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };

        private static byte[] security = new byte[] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };

        private static string port = "COM0";

        public Settings(){}

        public Settings(string storagePath)
        {
            this.storagePath = storagePath;
        }

        public Settings(int id, string storagePath)
        {
            this.id = id;
            this.storagePath = storagePath;
        }

        public Settings(int id, string storagePath, int? userId)
        {
            this.id = id;
            this.storagePath = storagePath;
            this.userId = userId;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getStoragePath()
        {
            return this.storagePath;
        }

        public void setStoragePath(string storagePath)
        {
            this.storagePath = storagePath;
        }

        public int? getUserId()
        {
            return this.userId;
        }

        public void setUserId(int? userId)
        {
            this.userId = userId;
        }

        public byte[] getLogon()
        {
            return logon;
        }

        public byte[] getSecurity()
        {
            return security;
        }

        public string getPort()
        {
            return port;
        }
    }
}
