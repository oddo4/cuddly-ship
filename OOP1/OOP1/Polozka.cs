using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Polozka
    {
        private string nazevPolozky;
        private string kodPolozky;
        private int cenaPolozky;
        private int pocetPolozky;

        public string NazevPolozky
        {
            get
            {
                return nazevPolozky;
            }
            set
            {
                nazevPolozky = value;
            }
        }

        public string KodPolozky
        {
            get
            {
                return kodPolozky;
            }
            set
            {
                kodPolozky = value;
            }
        }

        public int CenaPolozky
        {
            get
            {
                return cenaPolozky;
            }
            set
            {
                cenaPolozky = value;
            }
        }

        public int PocetPolozky
        {
            get
            {
                return pocetPolozky;
            }
            set
            {
                pocetPolozky = value;
            }
        }
    }
}
