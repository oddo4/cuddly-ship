using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katalog
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Rodina rodina1 = new Rodina();

            Osoba osoba1 = new Osoba();
            osoba1.Jmeno = "Jan";
            osoba1.Prijmeni = "Novák";
            osoba1.DatumNarozeni = "10";
            osoba1.Pohlavi = "M";

            Osoba osoba2 = new Osoba();
            osoba2.Jmeno = "Jan2";
            osoba2.Prijmeni = "Novák2";
            osoba2.DatumNarozeni = "100";
            osoba2.Pohlavi = "Ž";

            rodina1.PridatOsobu(osoba1);
            rodina1.PridatOsobu(osoba2);

            foreach (Osoba data in rodina1.seznamOsob)
            {
                Console.WriteLine(data.Jmeno);
            }
            */

            bool dumPridatCykl = true;
            bool rodinaPridatCykl = true;
            bool osobaPridatCykl = true;
            bool dumZmenaCykl = true;
            bool rodinaZmenaCykl = true;
            bool osobaZmenaCykl = true;
            int ctr1 = 1;
            int ctr2 = 1;

            while (dumPridatCykl)
            {
                Console.WriteLine("Nová nemovitost");

                Nemovitost dum1 = new Nemovitost();

                Console.Write("Zadejte typ domu: ");
                string vstupTyp = Console.ReadLine();

                Console.Write("Zadejte plochu domu (v m2): ");
                string vstupPlocha = Console.ReadLine();
                int plocha = int.Parse(vstupPlocha);

                dum1.TypNemovistosti = vstupTyp;
                dum1.PlochaNemovistosti = plocha;

                while (rodinaPridatCykl)
                {
                    clearcons();
                    Console.WriteLine("Typ domu: {0}" + Environment.NewLine + "Plocha domu: {1}m2" + Environment.NewLine + "Počet rodin: {2}", dum1.TypNemovistosti, dum1.PlochaNemovistosti, dum1.pocetRodin);

                    Console.WriteLine("Nová rodina {0}", ctr1);
                    Rodina novaRodina = new Rodina();

                    Console.Write("Zadejte jméno rodiny: ");
                    string vstupJmenoRodiny = Console.ReadLine();

                    novaRodina.JmenoRodiny = vstupJmenoRodiny;

                    clearcons();
                    Console.WriteLine("Typ domu: {0}" + Environment.NewLine + "Plocha domu: {1}m2" + Environment.NewLine + "Počet rodin: {2}", dum1.TypNemovistosti, dum1.PlochaNemovistosti, dum1.pocetRodin);

                    Console.WriteLine("Nová rodina '{0}'", novaRodina.JmenoRodiny);

                    osobaPridatCykl = true;

                    while (osobaPridatCykl)
                    {
                        Console.WriteLine("Nová osoba {0}", ctr2);
                        Osoba novaOsoba = new Osoba();

                        Console.Write("Zadejte jméno: ");
                        string vstupJmeno = Console.ReadLine();

                        if (vstupJmeno == "0") // 0 = dalsi rodina
                        {
                            ctr2 = 1;
                            dum1.PridatRodinu(novaRodina);
                            osobaPridatCykl = false;
                        }
                        else if (vstupJmeno == "00") // 00 = konec pridavani
                        {
                            ctr1 = 1;
                            ctr2 = 1;
                            dum1.PridatRodinu(novaRodina);
                            osobaPridatCykl = false;
                            rodinaPridatCykl = false;
                            dumPridatCykl = false;
                        }
                        else
                        {
                            Console.Write("Zadejte příjmení: ");
                            string vstupPrijmeni = Console.ReadLine();

                            Console.Write("Zadejte datum narození (Např. 26.10.1999): ");
                            string vstupDatumNarozeni = Console.ReadLine();

                            Console.Write("Zadejte pohlaví: ");
                            string vstupPohlavi = Console.ReadLine();

                            novaOsoba.Jmeno = vstupJmeno;
                            novaOsoba.Prijmeni = vstupPrijmeni;
                            novaOsoba.DatumNarozeni = vstupDatumNarozeni;
                            novaOsoba.Pohlavi = vstupPohlavi;

                            novaRodina.PridatOsobu(novaOsoba);
                            ctr2++;
                        }
                    }

                    foreach (Osoba data in novaRodina.seznamOsob)
                    {
                        Console.WriteLine(data.Jmeno);
                    }

                    ctr1++;
                    Console.ReadKey();
                }

                clearcons();
                Console.WriteLine("Změna údajů");
                Console.ReadKey();

                while (dumZmenaCykl)
                {
                    foreach (Rodina data in dum1.seznamRodin)
                    {

                    }
                    while (rodinaZmenaCykl)
                    {
                        while (osobaZmenaCykl)
                        {

                        }
                    }
                }
            }
        }



        static void clearcons()
        {
            Console.Clear();
        }
    }
}
