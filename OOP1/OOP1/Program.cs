using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Automat automat = new Automat();

            List<Polozka> seznam = automat.Zbozi("Polozka", 10);

            for (int i = 0; i < seznam.Count; i++)
            {
                Console.WriteLine(seznam[i].NazevPolozky + "|" + seznam[i].KodPolozky + "|" +seznam[i].CenaPolozky + "Kč");
            }
            */

            /*
            List<Polozka> seznamZbozi = new List<Polozka>();

            for (int i = 0; i < 10; i++)
            {
                Polozka polozka = new Polozka();
                polozka.NazevPolozky = "Nazev" + i;
                polozka.KodPolozky = "A" + i;
                polozka.CenaPolozky = 10;

                seznamZbozi.Add(polozka);
            }

            Console.WriteLine(seznamZbozi[2].KodPolozky);
            */

            bool vkladani = true;
            bool vyber = true;
            int celkem = 0;
            int cena = 0;
            int vraceni = 0;
            int index = 0;

            Automat automat = new Automat();

            List<Polozka> seznam = automat.Zbozi("Polozka", 10);

            while (true)
            {
                while (vkladani)
                {
                    clearcons();
                    zobrazeni(automat, seznam);
                    Console.WriteLine("Vloženo: {0}Kč", celkem);

                    string pocetPenez = Console.ReadLine();
                    int Penez = int.Parse(pocetPenez);

                    if (Penez == 0)
                    {
                        vkladani = false;
                        vyber = true;
                    }
                    else
                    {
                        celkem = automat.ZiskejPenize(Penez);
                    }
                }

                while (vyber)
                {
                    clearcons();
                    zobrazeni(automat, seznam);
                    Console.WriteLine("Vloženo: {0}Kč", celkem);

                    string kod = Console.ReadLine();

                    if (kod != "0")
                    {
                        for (int i = 0; i < seznam.Count; i++)
                        {
                            if (seznam[i].KodPolozky == kod && seznam[i].PocetPolozky > 0)
                            {
                                index = i;
                                cena = seznam[i].CenaPolozky;
                                vyber = false;
                            }
                            else if (seznam[i].PocetPolozky == 0)
                            {
                                Console.WriteLine("Nedostupná položka.");
                                Console.ReadKey();
                            }
                        }              
                    }
                    else
                    {
                        Console.WriteLine("Ahoj");
                        Console.ReadKey();
                    }                        
                }

                if (vkladani == false && vyber == false)
                {
                    if (celkem < cena)
                    {
                        vkladani = true;
                        vyber = true;
                        celkem = 0;
                        automat.NastavCelkemPenez();

                        Console.WriteLine("Nedostatek peněz.");
                        Console.ReadKey();
                    }
                    else if (celkem == cena)
                    {
                        vkladani = true;
                        vyber = true;
                        celkem = 0;
                        automat.NastavCelkemPenez();
                        snizeniPoctu(seznam, index);

                        Console.WriteLine("Nakoupeno.");
                        Console.ReadKey();
                    }
                    else if (celkem > cena)
                    {
                        vkladani = true;
                        vyber = true;
                        vraceni = automat.ZiskejVraceni(cena);
                        celkem = 0;
                        automat.NastavCelkemPenez();
                        snizeniPoctu(seznam, index);

                        Console.WriteLine("Vráceno: {0}Kč", vraceni);
                        Console.ReadKey();
                    }
                }
            }
        }

        static void zobrazeni(Automat automat, List<Polozka> seznam)
        {
            Console.WriteLine("Celkem v automatu: {0}Kč", automat.NastavCelkemPenez());

            for (int i = 0; i < seznam.Count; i++)
            {
                Console.WriteLine(seznam[i].NazevPolozky + " | " + seznam[i].KodPolozky + " | " + seznam[i].CenaPolozky + "Kč | "+seznam[i].PocetPolozky + "x");
            }

            Console.WriteLine("________________________");
        }

        static void snizeniPoctu(List<Polozka> seznam, int index)
        {
            for (int i = 0; i < seznam.Count; i++)
            {
                if (i == index)
                {
                    seznam[i].PocetPolozky -= 1;
                }
            }
        }
    
        static void clearcons()
        {
            Console.Clear();
        }
    }
}
