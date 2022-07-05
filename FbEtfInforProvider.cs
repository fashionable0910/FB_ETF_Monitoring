using System.Text.Json;

namespace FB
{
    class FbEtfInfoProvider
    {
        private List<string> etfCodes { get; set; }
        private string url { get; set; }
        public FbEtfInfoProvider(List<string> etfCodes, string url)
        {
            this.etfCodes = etfCodes;
            this.url = url;
        }
        public async void ETF_Info_Retriver()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (responseBody != null)
                    {
                        FbEtfResponseBody etfResponseBody = JsonSerializer.Deserialize<FbEtfResponseBody>(responseBody);
                        foreach (EtfInfo info in etfResponseBody.msgArray)
                        {
                            if (etfCodes?.Count > 0 && etfCodes.Contains(info.a))
                            {
                                ShowEtfInfo(info);
                            }
                            else if ((etfCodes == null || etfCodes?.Count == 0))
                            {
                                ShowEtfInfo(info);
                            }
                        }
                    }
                    else{
                        throw new Exception("There are some connectivity issues. Please check!");
                    }
                }

            }
        }
        public void ShowEtfInfo(EtfInfo info)
        {
            Console.WriteLine(
                                        String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}"
                                        , info.a
                                        , info.b
                                        , info.c
                                        , info.d
                                        , info.e
                                        , info.f
                                        , info.g
                                        , info.h
                                        , info.i
                                        , info.j
                                        , info.k
                                        ,DateTime.Now.ToString("hh:mm:ss")
                                        )
                                        );
        }
    }
}