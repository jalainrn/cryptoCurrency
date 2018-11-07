using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency
{
    public class Currency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string website_slug { get; set; }
    }

    public class Result
    {
        public List<Currency> data { get; set; }
    }


    public class CurrencyDetail
    {
        public Data data { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string website_slug { get; set; }
        public int rank { get; set; }
        public float? circulating_supply { get; set; }
        public float? total_supply { get; set; }
        public float? max_supply { get; set; }
        public Quotes quotes { get; set; }
        public int? last_updated { get; set; }
    }

    public class Quotes
    {
        public USD USD { get; set; }
    }

    public class USD
    {
        public float? price { get; set; }
        public float? volume_24h { get; set; }
        public long? market_cap { get; set; }
        public float? percent_change_1h { get; set; }
        public float? percent_change_24h { get; set; }
        public float? percent_change_7d { get; set; }
    }

    public class Metadata
    {
        public int? timestamp { get; set; }
        public object error { get; set; }
    }

}
