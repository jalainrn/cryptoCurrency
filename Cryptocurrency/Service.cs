using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency
{
    public static class Service
    {
        public static HttpClient HttpClient;

        public static async Task<Result> GetCurrencyList()
        {
            if (HttpClient == null)
                HttpClient = new HttpClient();

            var httpResponseMessage = await HttpClient.GetAsync("https://api.coinmarketcap.com/v2/listings");

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception("Unable to connect to CoinMarketCap.");

            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            var coins = JsonConvert.DeserializeObject<Result>(responseString);
            
            return coins;
        }

        public static async Task<CurrencyDetail> GetCurrencyDetail(int _id)
        {
            if (HttpClient == null)
                HttpClient = new HttpClient();

            var httpResponseMessage = await HttpClient.GetAsync("https://api.coinmarketcap.com/v2/ticker/" + _id.ToString());

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception("Unable to connect to CoinMarketCap.");

            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            //Console.WriteLine(responseString);
            //Console.Read();
            var coin = JsonConvert.DeserializeObject<CurrencyDetail>(responseString);


            return coin;
        }
    }
}
