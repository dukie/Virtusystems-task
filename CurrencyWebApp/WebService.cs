using System;
using System.Web.Script.Serialization;

namespace CurrencyWebApp
{
    abstract class WebService
    {
        protected string postbody;
        protected string uri;
        protected JavaScriptSerializer js;
        protected Parser parser;
        public WebService(string postbody, string uri)
        {
            this.postbody = postbody;
            this.uri = uri;
            js = new JavaScriptSerializer();
        }

        public String invokeMethod()
        {
            switch (parser.parseUrlParams(uri).MethodName)
            {
                case "create":
                    return this.create();
                case "read":
                    return this.read();
                case "update":
                    return this.update();
                case "delete":
                    return this.delete();
                default:
                    throw new Exception("Unknown method");

            }
        }

        abstract public string create();
        abstract public string read();
        abstract public string update();
        abstract public string delete();
    }

 
}
