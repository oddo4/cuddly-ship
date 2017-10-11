using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Kniha
    {
        private string nazev;
        private int isbn;
        private Autor autor;

        public Kniha(string Nazev, int Isbn, Autor Autor)
        {
            nazev = Nazev;
            isbn = Isbn;
            autor = Autor;
        }

        public Autor Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Nazev
        {
            get { return nazev; }
            set { nazev = value; }
        }

    }
}
