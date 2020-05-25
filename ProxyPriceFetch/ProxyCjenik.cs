using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPriceFetch
{
    class ProxyCjenik : ICjenik
    {
        public ProxyCjenik(string korisnik, bool pg)
        {
            this.korisnik = korisnik;
            popustGotovina = pg;
        }
        public void IspisiCjenik()
        {
            Cjenik cjenik = new Cjenik(JeliKorisnik(korisnik)? Program.rabat :0, popustGotovina? Program.popust:0 );
            cjenik.IspisiCjenik();
            
        }
        bool JeliKorisnik(string kor)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Table<korisnici> kupci = dc.GetTable<korisnici>();
            var upit = from k in kupci
                       where kor.Equals(k.userID)
                       select new { };
            if (upit.Count() == 0)
            {
                Console.WriteLine("Neregistrirani korisnik");
                return false;
            }
            else
            {
                Console.WriteLine("Registrirani korisnik");
                return true;
            }
        }
        private bool popustGotovina = false;
        private string korisnik;
    }
}
