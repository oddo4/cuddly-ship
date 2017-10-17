using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class EKniha : Kniha
    {
        private string uri;
        private int velikostMB;

        public int VelikostMB
        {
            get { return velikostMB; }
            set { velikostMB = value; }
        }

        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }

        public EKniha(string Nazev, Autor Autor, string Isbn, string Uri, int VelikostMB)
            : base(Nazev, Isbn, Autor)
        {
            uri = Uri;
            velikostMB = VelikostMB;
        }
        
    }
}
