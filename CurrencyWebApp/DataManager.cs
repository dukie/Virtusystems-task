using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyWebApp
{
    class DataManager
    {


        private static DataManager dm = null;
        private CurrencyDataModelContainer1 dmc;


        private DataManager()
        {
           dmc = new CurrencyDataModelContainer1();
        }


        static public DataManager getInstance()
        {
            if (dm == null)
            {
                dm = new DataManager();
            }
            return dm;
        }


        public CurrencyRef getCurrencyRefById(int id)
        {
            var qresult = from rs in dmc.CurrencyRefSet where rs.Id == id select rs;
            return qresult.FirstOrDefault<CurrencyRef>();
        }


        public CurrencyRef getCurrencyRefByCharCode(string code)
        {
            var qresult = from rs in dmc.CurrencyRefSet where rs.charcode == code select rs;
            return qresult.FirstOrDefault<CurrencyRef>();
        }


        public CurrencyRate getCurrencyRateById(int id)
        {
            var qresult = from rs in dmc.CurrencyRateSet where rs.Id == id select rs;
            return qresult.FirstOrDefault<CurrencyRate>();
        }

        public int addCurrencyRefNoCommit(CurrencyRef refrence)
        {
            dmc.AddToCurrencyRefSet(refrence);
            return refrence.Id;
        }


        public CurrencyRef creatCurrencyRef()
        {
            return dmc.CreateObject<CurrencyRef>();
        }


        public int addCurrencyRateNoCommit(CurrencyRate rate)
        {
            dmc.AddToCurrencyRateSet(rate);
            return rate.Id;
        }


        public CurrencyRate creatCurrencyRate()
        {
            return dmc.CreateObject<CurrencyRate>();
                        
        }


        public List<JSONCurrencyReference> getCurrencyRefs(int start, int limit)
        {
            return (from d in dmc.CurrencyRefSet orderby d.name select new JSONCurrencyReference { id = d.Id, code = d.code, name = d.name, nominal = d.nominal, numcode = d.numcode, charcode = d.charcode }).Skip(start).Take(limit).ToList();
        }


        public List<JSONCurrencyRate> getCurrencyRates(int start, int limit, DateTime datefilter)
        {
            return (from d in dmc.CurrencyRateSet orderby d.CurrencyRef.name descending where d.date == datefilter select new { id = d.Id, date = d.date, charcode = d.CurrencyRef.charcode, name = d.CurrencyRef.name, nominal = d.CurrencyRef.nominal, rate = d.rate }).Skip(start).Take(limit).AsEnumerable().Select(x => new JSONCurrencyRate() { date = x.date.ToString("o"), id = x.id, name = x.name, charcode = x.charcode, nominal = x.nominal, rate = x.rate }).ToList();
              
        }


        public void commit()
        {
            dmc.SaveChanges();
        }


        public int getCurrencyRefsCount()
        {
            return (from d in dmc.CurrencyRefSet select d).Count();
        }


        public int getCurrencyRatesCount()
        {
            return (from d in dmc.CurrencyRateSet orderby d.CurrencyRef.charcode select new { id = d.Id, date = d.date, name = d.CurrencyRef.charcode, nominal = d.CurrencyRef.nominal, rate = d.rate }).Count();
        }


        public void removeCurrencyRefById(int id)
        {
            CurrencyRef refr = this.getCurrencyRefById(id);
            dmc.DeleteObject(refr);
        }


        public void removeCurrencyRateById(int id)
        {
            CurrencyRate rate = this.getCurrencyRateById(id);
            dmc.DeleteObject(rate);
        }


        public void clearDB()
        {
            var rates = from d in dmc.CurrencyRateSet select d;
            foreach (var item in rates)
            {
                dm.removeCurrencyRateById(item.Id);
            }
            var refs = from d in dmc.CurrencyRefSet select d;
            foreach(var item in refs)
            {
                dm.removeCurrencyRefById(item.Id);
            }
            dm.commit();   
            
        }

        public void checkDB()
        {
            if(!dmc.DatabaseExists())
            {
                dmc.CreateDatabase();
            }
        }
       
        
    }
    
}
