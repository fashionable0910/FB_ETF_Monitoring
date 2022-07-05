namespace FB
{
    class EtfInfo
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string e { get; set; }
        public string f { get; set; }
        public string g { get; set; }
        public string h { get; set; }
        public string i { get; set; }
        public string j { get; set; }
        public string k { get; set; }
    }
    class FbEtfResponseBody
    {
        public List<EtfInfo> msgArray { get; set; }
        public string refURL { get; set; }
        public string userDelay { get; set; }
        public string rtMessage { get; set; }
        public string rtCode { get; set; }
    }
}