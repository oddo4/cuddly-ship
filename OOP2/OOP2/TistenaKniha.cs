using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class TistenaKniha : Kniha
    {
        private int hmotnost;
        private int kus;

        public int Kus
        {
            get { return kus; }
            set { kus = value; }
        }

        public int Hmotnost
        {
            get { return hmotnost; }
            set { hmotnost = value; }
        }

        public TistenaKniha(string Nazev, Autor Autor, int Isbn, int Hmotnost, int Kus)
            : base(Nazev, Isbn, Autor)
        {
            hmotnost = Hmotnost;
            kus = Kus;
        }
    }
}
