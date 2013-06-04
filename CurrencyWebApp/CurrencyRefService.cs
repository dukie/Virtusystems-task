using System;
using System.Collections.Generic;


namespace CurrencyWebApp
{
    class CurrencyRefService : WebService
    {
        
        public CurrencyRefService(string postbody,string uri)
            : base(postbody,uri)
        {
            parser = new RefServiceParser();
        }


        override public string create()
        {
            var dr = js.Deserialize<JSONCreateRefObj>(postbody);
            foreach (JSONCurrencyReference dc in dr.data)
            {
                CurrencyRef refr = DataManager.getInstance().creatCurrencyRef();
                refr.nominal = dc.nominal;
                refr.name = dc.name;
                refr.numcode = dc.numcode;
                refr.code = dc.code;
                refr.charcode = dc.charcode;
                dc.id = DataManager.getInstance().addCurrencyRefNoCommit(refr);
            }
            DataManager.getInstance().commit();
            dr.success = true;
            return js.Serialize(dr);
        }


        override public string read()
        {
            JSONCreateRefObj dr = new JSONCreateRefObj();
            UrlParams postparams = parser.parsePostBody(postbody);
            dr.data = DataManager.getInstance().getCurrencyRefs(postparams.Start, postparams.Limit);
            dr.results = DataManager.getInstance().getCurrencyRefsCount();
            dr.success = true;
            return js.Serialize(dr);
        }


        override public string update()
        {
            JSONCreateRefObj dr = js.Deserialize<JSONCreateRefObj>(postbody);
            foreach (JSONCurrencyReference dc in dr.data)
            {
                CurrencyRef refr = DataManager.getInstance().getCurrencyRefById(dc.id);
                refr.nominal = dc.nominal;
                refr.name = dc.name;
                refr.numcode = dc.numcode;
                refr.code = dc.code;
                refr.charcode = dc.charcode;
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
                DataManager.getInstance().removeCurrencyRefById(id);       
            }
            DataManager.getInstance().commit();
            dr.success = true;
            return js.Serialize(dr);
        }
    }

    class JSONCurrencyReference
    {
        public int id;
        public string name;
        public string charcode;
        public string code;
        public int numcode;
        public decimal nominal;
    }

    class JSONDeleteRefObj
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

    class JSONCreateRefObj
    {
        List<JSONCurrencyReference> pdata;
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
        public List<JSONCurrencyReference> data
        {
            get { return pdata; }
            set { pdata = value; }
        }

    }
    
}
