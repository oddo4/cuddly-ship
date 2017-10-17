using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katalog
{
    class Osoba
    {
        private string jmeno;
        private string prijmeni;
        private string pohlavi;
        private string datumNarozeni;

        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; }
        }
        public string Prijmeni
        {
            get { return prijmeni; }
            set { prijmeni = value; }
        }
        public string Pohlavi
        {
            get { return pohlavi; }
            set { pohlavi = value; }
        }
        public string DatumNarozeni
        {
            get { return datumNarozeni; }
            set { datumNarozeni = value; }
        }

        public Osoba()
        {

        }

    }
}
