using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katalog
{
    class Rodina
    {
        public List<Osoba> seznamOsob = new List<Osoba>();
        public int pocetOsob;
        private string jmenoRodiny;

        public string JmenoRodiny
        {
            get { return jmenoRodiny; }
            set { jmenoRodiny = value; }
        }

        public void PridatOsobu(Osoba osoba)
        {
            seznamOsob.Add(osoba);
            pocetOsob++;
        }
    }
}
