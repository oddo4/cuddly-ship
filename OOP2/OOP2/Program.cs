using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Program
    {
        static List<Kniha> SeznamKnih = new List<Kniha>();
        static List<Autor> SeznamAutoru = new List<Autor>();

        static void Main(string[] args)
        {
            /*
            EKniha ekniha1 = new EKniha();
            ekniha1.Nazev = "Ekniha 1";
            ekniha1.Isbn = 0001;
            ekniha1.Uri = "asdasdsd";
            ekniha1.VelikostMB = 10;

            Autor autor1 = new Autor();
            autor1.Jmeno = "Jan";
            autor1.Prijmeni = "Novák";

            ekniha1.Autor = autor1;

            SeznamKnih.Add(ekniha1);

            TistenaKniha tkniha1 = new TistenaKniha();
            tkniha1.Nazev = "Tištěná kniha 1";
            tkniha1.Isbn = 0002;
            tkniha1.Hmotnost = 100;
            tkniha1.Kus = 10;
            tkniha1.Autor.Jmeno = "Honza";
            tkniha1.Autor.Prijmeni = "Starý";

            SeznamKnih.Add(tkniha1);
            */
            bool pridani = true;
            
            while (pridani)
            {
                vymazKonzoli();
                Console.WriteLine("Vyberte typ knihy (1 - E-Kniha, 2 - Tištěná Kniha): ");
                string vstupTyp = Console.ReadLine();
                Console.WriteLine("Napište název knihy: ");
                string vstupNazev = Console.ReadLine();
                Console.WriteLine("Napište jméno autora knihy: ");
                string vstupAutorJmeno = Console.ReadLine();
                Console.WriteLine("Napište příjmení autora knihy: ");
                string vstupAutorPrijmeni = Console.ReadLine();
                Autor autor = new Autor(vstupAutorJmeno, vstupAutorPrijmeni);

                if (pridaniAutora(autor))
                {
                    existujiciAutor(autor);
                }

                Console.WriteLine("Napište ISBN knihy: ");
                string vstupIsbn = Console.ReadLine();

                if (int.TryParse(vstupTyp, out int typ) && int.TryParse(vstupIsbn, out int isbn))
                {
                    switch (typ)
                    {
                        case 1:
                            Console.WriteLine("Napište URI knihy: ");
                            string vstupUri = Console.ReadLine();
                            Console.WriteLine("Napište velikost knihy v MB: ");
                            string vstupVelikost = Console.ReadLine();

                            int.TryParse(vstupVelikost, out int velikost);

                            EKniha ekniha = new EKniha(vstupNazev, autor, isbn, vstupUri, velikost);

                            SeznamKnih.Add(ekniha);
                            break;
                        case 2:
                            Console.WriteLine("Napište hmotnost knihy: ");
                            string vstupHmotnost = Console.ReadLine();
                            Console.WriteLine("Napište počet kusů knihy: ");
                            string vstupKus = Console.ReadLine();

                            int.TryParse(vstupHmotnost, out int hmotnost);
                            int.TryParse(vstupKus, out int kus);

                            TistenaKniha tkniha = new TistenaKniha(vstupNazev, autor, isbn, hmotnost, kus);

                            SeznamKnih.Add(tkniha);
                            break;
                    }
                }
                Console.WriteLine("Chcete přidat další knihu? (0 - konec, ostatní - přidání): ");
                string vstupKonecPridani = Console.ReadLine();

                if (int.TryParse(vstupKonecPridani, out int konecPridani))
                {
                    if (konecPridani == 0)
                    {
                        pridani = false;
                    }
                }
            }
            
            
            foreach (Kniha data in SeznamKnih)
            {
                Console.WriteLine("{0} | {1} {2}",data.Nazev,data.Autor.Jmeno,data.Autor.Prijmeni);
            }
            Console.WriteLine();
            foreach (Autor data in SeznamAutoru)
            {
                Console.WriteLine("{0} {1}",data.Jmeno,data.Prijmeni);
            }


        }

        static bool pridaniAutora(Autor autor)
        {
            foreach (Autor data in SeznamAutoru)
            {
                if (data.Jmeno == autor.Jmeno && data.Prijmeni == autor.Prijmeni)
                {
                    return true;
                }
            }

            SeznamAutoru.Add(autor);
            return false;
        }

        static void existujiciAutor(Autor autor)
        {
            Console.WriteLine("Napsal tento autor tyto knihy? (1 - Ano, 2 - Ne, 3 - Nevim)");

            foreach (Kniha data in SeznamKnih)
            {
                if (data.Autor.Jmeno == autor.Jmeno && data.Autor.Prijmeni == autor.Prijmeni)
                {
                    Console.WriteLine(data.Nazev);
                }
            }

            
        }

        static void vymazKonzoli()
        {
            Console.Clear();
        }
    }
}
