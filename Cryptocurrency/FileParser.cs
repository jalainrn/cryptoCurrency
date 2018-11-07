using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency
{
    public class FileParser : IFileParser
    {
        public void Read(string path)
        {
            List<Currency> currencies = new List<Currency>();
            Currency singleCurrency = new Currency();
            StreamReader readers = new StreamReader(path);
            int count = 0;
            while (!readers.EndOfStream && count <= 50)
            {
                var line = readers.ReadLine();
                var values = line.Split(',');

                singleCurrency.id = Int32.Parse(values[0]);
                singleCurrency.name = values[1];
                singleCurrency.symbol = values[2];
                singleCurrency.website_slug = values[3];

                MenuActions.PrintData(singleCurrency);

                currencies.Add(singleCurrency);
                count++;
            }

            readers.Close();
            readers.Dispose();
        }

        public void Write(string path, string toCopy)
        {
            StreamWriter writer = new StreamWriter(path, true, Encoding.ASCII);
            writer.WriteLine(toCopy);
            writer.Close();
            writer.Dispose();

        }

        public void Reformat(string fromPath, string toPath)
        {
            StreamReader reader = new StreamReader(fromPath);
            string lineToCopy;
            for (int i = 0; i < 298; i++)
            {
                lineToCopy = reader.ReadLine();
                Console.WriteLine(lineToCopy);
                Write(toPath, lineToCopy);
            }
        }
    }
}
