using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cryptocurrency
{
    public static class MenuActions
    {
        static string filePath = Parameters.GetAllCurrencyPath();

        public static void SubmitAction(string action)
        {
            switch (action)
            {
                case "1":
                    DeleteFile();
                    break;

                case "2":
                    RefreshData();
                    break;

                case "3":
                    PrintItemMenu();
                    break;

                case "9":

                    break;

                default:
                    break;
            }
        }

        public static void DeleteFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("File has been deleted!");
            }
            else
            {
                Console.WriteLine("File doesn't exist!");
            }
                
        }

        public static void RefreshData()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            IFileParser parser = new FileParser();
            Console.WriteLine("Downloading data from API");
            Task<Result> apiData = Service.GetCurrencyList();
            apiData.Wait();
            Result result = apiData.Result;

            Console.WriteLine("Creating File (data.txt)...");
            result.data.ForEach(c => parser.Write(filePath, c.id + "," + c.name + "," + c.symbol + "," + c.website_slug));
            PrintMenuHeaders();
            parser.Read(filePath);
        }

        public static void PrintMenuHeaders()
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine(String.Format(" |{0,7}  | {1,40} | {2,10} |", "Index", "Coin", "Symbol"));
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public static void PrintData(Currency singleCurrency)
        {
            Console.WriteLine(String.Format(" | {0,7} | {1,40} | {2,10} |", singleCurrency.id.ToString(), singleCurrency.name, singleCurrency.symbol));
        }

        public static void PrintItemMenu()
        {
            Console.Clear();
            Console.Write("Enter a currency ID: ");
            //Int32.MaxValue.ToString();
            int currencyId;// = Convert.ToInt32(Console.ReadLine()); //add try
            if(!Int32.TryParse(Console.ReadLine(), out currencyId))
            {
                Console.WriteLine("Please enter a valid number between 0 and 4000");
            }
            else
            {
                try
                {
                    Task<CurrencyDetail> apiSingleCoin = Service.GetCurrencyDetail(currencyId);
            
                    apiSingleCoin.Wait();
                    if(apiSingleCoin.Result != null && apiSingleCoin.Result.data != null)
                    {
                        CurrencyDetail singleCoin = apiSingleCoin.Result;

                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Name", singleCoin.data.name));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Id", singleCoin.data.id));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Symbol", singleCoin.data.symbol));

                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Website Slug", singleCoin.data.website_slug));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Rank", singleCoin.data.rank));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Circulating Supply", singleCoin.data.circulating_supply));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Total Supply", singleCoin.data.total_supply));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Max Supply", singleCoin.data.max_supply));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Symbol", singleCoin.data.symbol));
                        Console.WriteLine(String.Format("{0,20} : {1,40}", "Last Updated", singleCoin.data.last_updated));
                    }
                    else
                    {
                        Console.WriteLine("No data");
                    }
                }
                catch(AggregateException ex)
                {
                    Console.WriteLine("Currency not found.");
                    //Console.WriteLine(ex.InnerExceptions[0].Message);
                }
            }

        }

    }
}
