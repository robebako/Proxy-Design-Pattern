using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPriceFetch
{
    class Cjenik : ICjenik
    {
        public Cjenik(decimal rab, decimal pop)
        {
            rabat = rab;
            popust = pop;
        }
        public void IspisiCjenik()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Table<artikli> proizvodi = dc.GetTable<artikli>();
            var upit = from p in proizvodi
                       select new
                       {
                           nazivArtikla = p.nazivProizvoda,
                           cijena = p.jedinicnaCijena
                       };
            foreach (var v in upit)
            {
                Console.WriteLine("Naziv artikla :{0}\t\tCijena:{1:0.00}", v.nazivArtikla, v.cijena * (1 - rabat) * (1 - popust));
            }
        }
        private readonly decimal popust;
        private readonly decimal rabat;
    }
}
