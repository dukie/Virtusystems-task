using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyWebApp
{
    class UrlParams
    {
        int start;
        string action;
        DateTime date;
        string code;
        int limit;
        string serviceName;
        string methodName;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }
    }
}
