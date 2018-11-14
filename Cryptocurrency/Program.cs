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
            else
            {
                MenuActions.PrintMenuHeaders();
                parser.Read(allDataPath);
            }

            //Print Menu
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
        }
    }
}
