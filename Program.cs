namespace FB
{
    class Program
    {
        private static string url = "https://websys.fsit.com.tw/fubonetf/twse/fubonrealtime.aspx";
        static void Main(string[] args)
        {
            Console.WriteLine("Please input ETF codes you want to monitor split with cama: ");

            List<string> etfCodes = Console.ReadLine().Split(',').ToList<string>();
            ThreadCreator(etfCodes);
        }
        static void ThreadCreator(List<string> etfCodes)
        {
            try
            {

                FbEtfInfoProvider provider = new FbEtfInfoProvider(etfCodes, url);
                while (true)
                {
                    Thread updator = new Thread(new ThreadStart(provider.ETF_Info_Retriver));
                    updator.Start();
                    Thread.Sleep(15000);
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }

        }
    }
}