using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Autor
    {
        private string jmeno;
        private string prijmeni;

        public string Prijmeni
        {
            get { return prijmeni; }
            set { prijmeni = value; }
        }

        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; }
        }

        public Autor(string Jmeno, string Prijmeni)
        {
            jmeno = Jmeno;
            prijmeni = Prijmeni;
        }



    }
}
