using System;

namespace CurrencyWebApp
{
    class WebServiceFactory
    {
        static private WebServiceFactory ws = null;
        private WebServiceFactory()
        {

        }

        static public WebServiceFactory getInstance()
        {
            if(ws == null){
                ws = new WebServiceFactory();
            }
            return ws;
        }

        public string invokeService(String uri, string postbody)
        {
            string servicestr = uri.Split('/')[1];
            if (servicestr == "currencyref") return new CurrencyRefService(postbody,uri).invokeMethod();
            if (servicestr == "currencyrates") return new CurrencyRateService(postbody,uri).invokeMethod();
            if (servicestr == "cbr") return new CbrService(postbody,uri).invokeMethod();
            throw new Exception("Wrong Service");

        }
    }
}
