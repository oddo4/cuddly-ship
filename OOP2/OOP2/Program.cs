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

            bool app = true;
            bool hlavniMenu = true;
            bool vypsaniKnih = false;
            bool vypsaniAutoru = false;
            bool pridani = false;
            bool upraveni = false;
            bool uprava = false;

            while (app)
            {
                while (hlavniMenu)
                {
                    vymazKonzoli();
                    Console.WriteLine("1) Seznam Knih" + Environment.NewLine + "2) Seznam autorů" + Environment.NewLine + "3) Pridani knihy" + Environment.NewLine + "4) Upraveni knih" + Environment.NewLine + "5) Konec");
                    string vstupMenu = Console.ReadLine();

                    if (int.TryParse(vstupMenu, out int menu))
                    {
                        switch (menu)
                        {
                            case 1:
                                vypsaniKnih = true;
                                hlavniMenu = false;
                                break;
                            case 2:
                                vypsaniAutoru = true;
                                hlavniMenu = false;
                                break;
                            case 3:
                                pridani = true;
                                hlavniMenu = false;
                                break;
                            case 4:
                                upraveni = true;
                                hlavniMenu = false;
                                break;
                            case 5:
                                app = false;
                                hlavniMenu = false;
                                break;
                        }
                    }
                }

                while (vypsaniKnih)
                {
                    if (SeznamKnih.Count > 0)
                    {
                        foreach (Kniha data in SeznamKnih)
                        {
                            Console.WriteLine("{0} | {1} {2}", data.Nazev, data.Autor.Jmeno, data.Autor.Prijmeni);
                        }
                    }
                    else
                    {
                        Console.WriteLine("V seznamu nejsou žádné knihy!");
                    }

                    vypsaniKnih = false;
                    hlavniMenu = true;
                    Console.ReadKey();
                }

                while (vypsaniAutoru)
                {
                    if (SeznamAutoru.Count > 0)
                    {
                        for (int i = 0; i < SeznamAutoru.Count; i++)
                        {
                            Console.WriteLine("{0}| {1} {2}", i, SeznamAutoru[i].Jmeno, SeznamAutoru[i].Prijmeni);
                        }

                        Console.WriteLine("Vyberte podle indexu nalevo autora: ");
                        string vstupVyber = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("V seznamu nejsou žádní autoři!");
                    }

                    vypsaniAutoru = false;
                    hlavniMenu = true;
                    Console.ReadKey();
                }

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

                    if (int.TryParse(vstupTyp, out int typ))
                    {
                        switch (typ)
                        {
                            case 1:
                                Console.WriteLine("Napište URI knihy: ");
                                string vstupUri = Console.ReadLine();
                                Console.WriteLine("Napište velikost knihy v MB: ");
                                string vstupVelikost = Console.ReadLine();

                                int.TryParse(vstupVelikost, out int velikost);

                                EKniha ekniha = new EKniha(vstupNazev, autor, vstupIsbn, vstupUri, velikost);

                                if (existujiciKniha(vstupIsbn))
                                {

                                }

                                SeznamKnih.Add(ekniha);
                                break;
                            case 2:
                                Console.WriteLine("Napište hmotnost knihy: ");
                                string vstupHmotnost = Console.ReadLine();
                                Console.WriteLine("Napište počet kusů knihy: ");
                                string vstupKus = Console.ReadLine();

                                int.TryParse(vstupHmotnost, out int hmotnost);
                                int.TryParse(vstupKus, out int kus);

                                TistenaKniha tkniha = new TistenaKniha(vstupNazev, autor, vstupIsbn, hmotnost, kus);

                                SeznamKnih.Add(tkniha);
                                break;
                        }
                    }
                    Console.WriteLine("Kniha byla přidána");
                    Console.ReadKey();

                    pridani = false;
                    hlavniMenu = true;
                }

                while (upraveni)
                {
                    for (int i = 0; i < SeznamKnih.Count; i++)
                    {
                        Console.WriteLine("{0}| {1} | {2} {3}", i, SeznamKnih[i].Nazev, SeznamKnih[i].Autor.Jmeno, SeznamKnih[i].Autor.Prijmeni);
                    }

                    Console.WriteLine("Vyberte podle indexu nalevo knihu: ");
                    string vstupVyber = Console.ReadLine();

                    if (int.TryParse(vstupVyber, out int iKniha))
                    {
                        vymazKonzoli();
                        uprava = true;

                        while (uprava)
                        {
                            Console.WriteLine("{0} | {1} {2} | {3}", SeznamKnih[iKniha].Nazev, SeznamKnih[iKniha].Autor.Jmeno, SeznamKnih[iKniha].Autor.Prijmeni, SeznamKnih[iKniha].Isbn);
                            Console.WriteLine("Upravit: " + Environment.NewLine + " 1) Název knihy" + Environment.NewLine + " 2) Autora" + Environment.NewLine + " 3) ISBN" + Environment.NewLine + " 4) Zpět do hlavního menu");

                            string vstupUpravit = Console.ReadLine();

                            if (int.TryParse(vstupUpravit, out int upravit))
                            {
                                switch (upravit)
                                {
                                    case 1:
                                        Console.WriteLine("Zadejte nový název knihy: ");
                                        string vstupNazev = Console.ReadLine();

                                        SeznamKnih[iKniha].Nazev = vstupNazev;
                                        Console.WriteLine("Úspěšně uloženo");
                                        break;
                                    case 2:
                                        Console.WriteLine("Zadejte nové jméno autora: ");
                                        string vstupJmeno = Console.ReadLine();
                                        Console.WriteLine("Zadejte nové příjmení autora: ");
                                        string vstupPrijmeni = Console.ReadLine();

                                        SeznamKnih[iKniha].Autor.Jmeno = vstupJmeno;
                                        SeznamKnih[iKniha].Autor.Prijmeni = vstupPrijmeni;

                                        Console.WriteLine("Úspěšně uloženo");
                                        break;
                                    case 3:
                                        Console.WriteLine("Zadejte nové ISBN: ");
                                        string vstupIsbn = Console.ReadLine();

                                        SeznamKnih[iKniha].Isbn = vstupIsbn;

                                        Console.WriteLine("Úspěšně uloženo");
                                        break;
                                    case 4:
                                        uprava = false;
                                        break;
                                }
                            }
                        }
                    }



                    upraveni = false;
                    hlavniMenu = true;
                    Console.ReadKey();
                }

                /*
                foreach (Kniha data in SeznamKnih)
                {
                    Console.WriteLine("{0} | {1} {2}", data.Nazev, data.Autor.Jmeno, data.Autor.Prijmeni);
                }
                Console.WriteLine();
                foreach (Autor data in SeznamAutoru)
                {
                    Console.WriteLine("{0} {1}", data.Jmeno, data.Prijmeni);
                }
                */
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

            string vstupExist = Console.ReadLine();

            if (int.TryParse(vstupExist, out int exist))
            {
                switch(exist)
                {
                    case 1:
                        break;
                    case 2:
                        SeznamAutoru.Add(autor);
                        break;
                    case 3:
                        SeznamAutoru.Add(autor);
                        break;
                }
            }

            
        }

        static bool existujiciKniha(string isbn)
        {
            foreach (Kniha data in SeznamKnih)
            {
                if (data.Isbn == isbn)
                {
                    Console.WriteLine();
                }
            }

            return false;
        }

        static void vymazKonzoli()
        {
            Console.Clear();
        }
    }
}
