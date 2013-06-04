using System;
using System.Threading;

namespace CurrencyWebApp
{
    class Program
    {
        public static int Main(String[] args)
        {
            HttpServer httpServer;
            DataManager.getInstance().checkDB();
            if (args.GetLength(0) > 0)
            {
                httpServer = new MyHttpServer(Convert.ToInt16(args[0]));
            }
            else
            {
                httpServer = new MyHttpServer(8080);
            }
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
            return 0;
        }
    }
}
