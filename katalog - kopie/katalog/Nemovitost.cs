using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katalog
{
    class Nemovitost
    {
        public List<Rodina> seznamRodin = new List<Rodina>();
        public static int pocetRodin;
        private string typNemovistosti;
        private int plochaNemovistosti;
        

        public int PlochaNemovistosti
        {
            get { return plochaNemovistosti; }
            set { plochaNemovistosti = value; }
        }

        public string TypNemovistosti
        {
            get { return typNemovistosti; }
            set { typNemovistosti = value; }
        }

        public void PridatRodinu(Rodina rodina)
        {
            seznamRodin.Add(rodina);
            pocetRodin += 1;
        }
    }
}
