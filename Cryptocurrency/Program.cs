using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cryptocurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 - Welcome message
            Console.WriteLine("Welcome to the Cryptocurrency Console App!!!");
            //2 - Check is data locally
            string allDataPath = Parameters.GetAllCurrencyPath();
            IFileParser parser = new FileParser();
            if (!File.Exists(allDataPath))
            {
                //3 - If not exit download data from the API
                MenuActions.RefreshData();
            }

            MenuActions.PrintMenuHeaders();
            parser.Read(allDataPath);
            string menuOption = null;
            while (menuOption != "9")
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("The available actions are listed below:");
                Console.WriteLine("1 - Delete the data.txt");
                Console.WriteLine("2 - Refresh the data from the API");
                Console.WriteLine("3 - See the detail of a specific currency");
                Console.WriteLine("9 - Exit");

                menuOption = Console.ReadLine();
                MenuActions.SubmitAction(menuOption);
            }
            


            //result.data.ForEach(c => Console.WriteLine(String.Format(" | {0,7} | {1,40} | {2,10} |", c.id.ToString(), c.name, c.symbol)));



            //4 - Give the option to Refresh data from the API







            /*
                        Console.WriteLine("Enter a coin ID to see the detail");

                        int idConsult = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        //Add more options
                        //Check is it is a valid Id
                        if (result.data.Any(x => x.id == idConsult))
                        {
                            Task<CurrencyDetail> apiSingleCoin = Service.GetCurrencyDetail(idConsult);
                            apiSingleCoin.Wait();
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
                            Console.WriteLine("It is NOT a valid ID.");
                        }

                        //Console.WriteLine(id.ToString());
                        Console.ReadLine();
                        */
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
