using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPriceFetch
{
    class Program
    {
        public static decimal rabat = 0.2M;
        public static decimal popust = 0.05M;

        static void Main(string[] args)
        {
            string korisnik = Console.ReadLine();
            ICjenik cjenik = new ProxyCjenik(korisnik, true);
            cjenik.IspisiCjenik();
        }
    }
}
