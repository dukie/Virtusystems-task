using System;

namespace CurrencyWebApp
{
    class CbrService : WebService
    {
        DailyInfo di;

        public CbrService(string postbody, string uri)
            : base(postbody,uri)
        {
            di = new DailyInfo();
            parser = new CbrServiceParser();
        }


        override public string create()
        {

            DataManager.getInstance().clearDB();
            var refDataSetTable = di.EnumValutes(false).Tables[0];

            for (int i = 0; i < refDataSetTable.Rows.Count; i++)
            {
                CurrencyRef cr = DataManager.getInstance().creatCurrencyRef();
                cr.code = ((String)refDataSetTable.Rows[i].ItemArray.GetValue(0)).Trim();
                cr.name = ((String)refDataSetTable.Rows[i].ItemArray.GetValue(1)).Trim();
                cr.nominal = ((Decimal)refDataSetTable.Rows[i].ItemArray.GetValue(3));
                cr.numcode = ((Int32)refDataSetTable.Rows[i].ItemArray.GetValue(5));
                cr.charcode = ((String)refDataSetTable.Rows[i].ItemArray.GetValue(6));
                DataManager.getInstance().addCurrencyRefNoCommit(cr);
            }
            DataManager.getInstance().commit();

            return "Success";
        }


        override public string read()
        {
            UrlParams par = parser.parsePostBody(postbody);
            JSONRateObj obj = new JSONRateObj();
            try
            {
                var items = di.GetCursOnDate(par.Date).Tables[0];
                              
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    if ((String)items.Rows[i].ItemArray.GetValue(4) == par.Code)
                    {
                        obj.name = items.Rows[i].ItemArray.GetValue(0).ToString().Trim();
                        obj.nominal = (Decimal)items.Rows[i].ItemArray.GetValue(1);
                        obj.rate = (Decimal)items.Rows[i].ItemArray.GetValue(2);
                        obj.numcode = (int)items.Rows[i].ItemArray.GetValue(3);
                        obj.charcode = (String)items.Rows[i].ItemArray.GetValue(4);
                        obj.date = par.Date.ToShortDateString();
                        break;
                    }

                }
                
            }
            catch (Exception e)
            {
                obj.date = par.Date.ToShortDateString();
                obj.charcode = par.Code;
                obj.name = "";
                obj.nominal = 1;
                obj.rate = 0;
                obj.numcode = 0;

            }
            return js.Serialize(obj);
            
        }


        override public string update()
        {
            return "Cbr update";
        }


        override public string delete()
        {
            return "cbr delete";
        }
    }


    class JSONRateObj
    {
        public int numcode;
        public string charcode;
        public decimal rate;
        public string name;
        public decimal nominal;
        public string date;
    }
}
