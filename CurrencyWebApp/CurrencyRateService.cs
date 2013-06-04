using System;
using System.Collections.Generic;


namespace CurrencyWebApp
{
    class CurrencyRateService : WebService
    {

        public CurrencyRateService(string postbody, string uri)
            : base(postbody,uri)
        {
            parser = new RateServiceParser();
        }

        override public string create()
        {
            var dr = js.Deserialize<JSONCreateRateObj>(postbody);
            foreach (JSONCurrencyRate dc in dr.data)
            {
                CurrencyRate rate = DataManager.getInstance().creatCurrencyRate();
                rate.date = DateTime.Parse(dc.date);
                rate.rate = dc.rate;
                rate.CurrencyRef = DataManager.getInstance().getCurrencyRefByCharCode(dc.charcode);
                dc.id = DataManager.getInstance().addCurrencyRateNoCommit(rate);
            }
            DataManager.getInstance().commit();
            dr.success = true;
            return js.Serialize(dr);
        }


        override public string read()
        {
            JSONCreateRateObj dr = new JSONCreateRateObj();
            UrlParams postparams = parser.parsePostBody(postbody);
            dr.data = DataManager.getInstance().getCurrencyRates(postparams.Start, postparams.Limit,postparams.Date.Date);
            dr.results = DataManager.getInstance().getCurrencyRatesCount();
            dr.success = true;
            return js.Serialize(dr);
        }
        

        override public string update()
        {
            JSONCreateRateObj dr = js.Deserialize<JSONCreateRateObj>(postbody);
            foreach (JSONCurrencyRate dc in dr.data)
            {
                CurrencyRate rate = DataManager.getInstance().getCurrencyRateById(dc.id);
                rate.date = DateTime.Parse(dc.date);
                rate.rate = dc.rate;
                dr.results++;
            }
            DataManager.getInstance().commit();
            dr.success = true;
            return js.Serialize(dr);
        }


        override public string delete()
        {
            JSONDeleteRefObj dr = js.Deserialize<JSONDeleteRefObj>(postbody);
            foreach (int id in dr.data)
            {
                DataManager.getInstance().removeCurrencyRateById(id);
            }
            DataManager.getInstance().commit();
            dr.success = true;
            return js.Serialize(dr);
        }
    }


    class JSONCurrencyRate
    {
        public int id;
        public string name;
        public string charcode;
        public decimal rate;
        public string date;
        public decimal nominal;
    }


    class JSONDeleteRateObj
    {
        List<int> pdata;
        Boolean psuccess;
        public List<int> data
        {
            get { return pdata; }
            set { pdata = value; }
        }
        public Boolean success
        {
            get { return psuccess; }
            set { psuccess = value; }
        }

    }


    class JSONCreateRateObj
    {
        List<JSONCurrencyRate> pdata;
        Boolean psuccess;
        int presults;

        public int results
        {
            get { return presults; }
            set { presults = value; }
        }
        public Boolean success
        {
            get { return psuccess; }
            set { psuccess = value; }
        }
        public List<JSONCurrencyRate> data
        {
            get { return pdata; }
            set { pdata = value; }
        }

    }
}
