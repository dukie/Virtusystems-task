using System;
using System.Text.RegularExpressions;

namespace CurrencyWebApp
{
    abstract class Parser
    {
        protected UrlParams result;

        public Parser()
        {
            result = new UrlParams();
        }
        

        public UrlParams parseUrlParams(string input)
        {
            string pattern = @"^/(currencyref|currencyrates|cbr)/(create|read|update|delete)$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            GroupCollection matches = rgx.Match(input).Groups;
            if (matches.Count > 0)
            {
                result.ServiceName = matches[1].ToString();
                result.MethodName = matches[2].ToString();
            }
            return result;
        }


        public abstract UrlParams parsePostBody(string input);


    }



    class RefServiceParser : Parser
    {

        public RefServiceParser()
            : base()
        {
        }


        override public UrlParams parsePostBody(string input)
        {
             string pattern = @"^start=([0-9]*)&limit=([0-9]*)$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.GroupCollection matches = rgx.Match(input).Groups;
            if (matches.Count > 0)
            {
                result.Start = int.Parse(matches[1].ToString());
                result.Limit = int.Parse(matches[2].ToString());

            }
            return result;
        }

    }


    class RateServiceParser : Parser
    {

        public RateServiceParser()
            : base()
        {
        }


        override public UrlParams parsePostBody(string input)
        {
            string pattern = @"^start=([0-9]*)&limit=([0-9]*)&date=([0-9\-T\:]*)$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.GroupCollection matches = rgx.Match(input).Groups;
            if (matches.Count > 0)
            {
                result.Start = int.Parse(matches[1].ToString());
                result.Limit = int.Parse(matches[2].ToString());
                result.Date = DateTime.Parse(matches[3].ToString());


            }
            return result;
        }

    }


    class CbrServiceParser : Parser
    {

        public CbrServiceParser()
            : base()
        {
        }


        override public UrlParams parsePostBody(string input)
        {
            string pattern = @"^action=(getRate)&code=([A-Z]*)&date=([0-9\-T\:]*)$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.GroupCollection matches = rgx.Match(input).Groups;
            if (matches.Count > 0)
            {
                result.Action = matches[1].ToString();
                result.Code = matches[2].ToString();
                result.Date = DateTime.Parse(matches[3].ToString());


            }
            return result;
        }

    }

}
