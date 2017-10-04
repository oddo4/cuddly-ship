using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Automat
    {
        private int celkemPenezAtm;
        private int Penize;
        private int Vraceni;
        private int pocetZbozi;
        private List<Polozka> seznamZbozi = new List<Polozka>();

        public int NastavCelkemPenez()
        {
            celkemPenezAtm += Penize - Vraceni;
            Penize = 0;
            Vraceni = 0;
            return celkemPenezAtm;
        }

        public int ZiskejPenize(int penize)
        {
            Penize += penize;
            return Penize;
        }

        public int ZiskejVraceni(int cena)
        {
            Vraceni = Penize - cena;
            return Vraceni;
        }

        public List<Polozka> Zbozi(string nazev, int delka)
        {
            for (int i = 1; i < delka + 1; i++)
            {
                Polozka polozka = new Polozka();
                polozka.NazevPolozky = nazev + i;
                polozka.KodPolozky = "A" + i;
                polozka.CenaPolozky = 10 * i;
                polozka.PocetPolozky = i;

                seznamZbozi.Add(polozka);
                pocetZbozi++;
            }

            return seznamZbozi;
        }

        public List<Polozka> PridatZbozi(string nazev, int cena, int pocet)
        {
            pocetZbozi++;

            Polozka polozka = new Polozka();
            polozka.NazevPolozky = nazev;
            polozka.KodPolozky = "A"+ pocetZbozi;
            polozka.CenaPolozky = cena;
            polozka.PocetPolozky = pocet;

            seznamZbozi.Add(polozka);

            return seznamZbozi;
        }
    }
}
