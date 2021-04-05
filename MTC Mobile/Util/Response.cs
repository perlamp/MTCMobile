using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Util
{
    public class Response
    {
        private Boolean result = false;

        private string message = "";

        private Exception error;

        private string info = "";

        public Response() {}

        public Response(Boolean result)
        {
            this.result = result;
        }

        public Response(Boolean result, string message)
        {
            this.result = result;
            this.message = message;
        }

        public Response(Boolean result, string message, Exception error)
        {
            this.result = result;
            this.message = message;
            this.error = error;
        }

        public Boolean getResult()
        {
            return this.result;
        }

        public void setResult(Boolean result)
        {
            this.result = result;
        }

        public string getMessage()
        {
            return this.message;
        }

        public void setMessage(string message)
        {
            this.message = message;
        }

        public Exception getError()
        {
            return this.error;
        }

        public void setError(Exception error)
        {
            this.error = error;
        }

        public string getInfo()
        {
            return this.info;
        }

        public void setInfo(string info)
        {
            this.info = info;
        }
    }
}
