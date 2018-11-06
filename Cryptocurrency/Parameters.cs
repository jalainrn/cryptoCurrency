using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency
{
    public static class Parameters
    {

        public static string GetAllCurrencyPath()
        {
            return "../../data.txt";
        }

        public static string GetSingleCurrencyPath(string currencyName)
        {
            return "../../" + currencyName + ".txt";
        }
    }
}
