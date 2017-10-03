using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Osoba
    {
        private string rc;
        private string jmeno;
        private string prijmeni;
        private bool alive = true;

        private int ct = 0;

        public string Rc
        {
            get
            {
                return rc;
            }
            set
            {
                ct++;
                rc = value;
            }
        }

        public bool IsAlive()
        {
            return alive;
        }

        public string getRc()
        {
            return "rodne cislo";
        }

        public int getVek()
        {
            return 17;
        }


    }
}
