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
        }

    }
}
