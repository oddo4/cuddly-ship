using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lode
{
    class Program
    {
        static string[,] hracipole1 = new string[10, 10];
        static string[,] hracipole2 = new string[10, 10];
        static string[,] lodepole = new string[10, 10];
        static int[,] hrac1pole = new int[10, 10];
        static int[,] hrac2pole = new int[10, 10];
        static int[] ctrlode = new int[6];
        static int[] ctr2lode = new int[3];

        static string rada = "";
        static string horOzn = "";
        static int faultcode = 0;
        static int ctr = 0;
        static int poradi = 1;

        static void Main(string[] args)
        {
            bool urceni = true;
            bool pozice = true;
            bool smer = true;
            bool souboj = true;
            
            vytvorenipoli();

            /* URCENI START */
            while (urceni)
            {
                clearcons();
                nactenipole(lodepole, false);
                //testpole();

                if (faultcode != 0)
                {
                    Console.WriteLine(faultZprava(faultcode));
                    Console.ReadKey();

                    clearcons();
                    nactenipole(lodepole, false);
                }

                Console.WriteLine("Počet lodí: 2 místný - {0}/4, 3 místný - {1}/2, 4 místný - {2}/1", ctrlode[ctr], ctrlode[ctr + 1], ctrlode[ctr + 2]);

                Console.WriteLine("Vyber typ lodě (čisla od 1 do 3):");
                string vstupTypLode = Console.ReadLine(); // 1 = 2, 2 = 3, 3 = 4
                int typLode;

                if (int.TryParse(vstupTypLode, out typLode) && typLode >= 1 && typLode <= 3)
                {
                    if (pocetLodi(typLode))
                    {
                        pozice = true;

                        /* POZICE START */
                        while (pozice)
                        {
                            clearcons();
                            nactenipole(lodepole, false);

                            if (faultcode != 0)
                            {
                                Console.WriteLine(faultZprava(faultcode));
                                Console.ReadKey();

                                clearcons();
                                nactenipole(lodepole, false);
                            }

                            Console.WriteLine("Vyber počáteční pozici X a Y (čisla od 0 do 9):");
                            Console.Write("X: ");
                            string vstupPos1 = Console.ReadLine();
                            Console.Write("Y: ");
                            string vstupPos2 = Console.ReadLine();

                            if (int.TryParse(vstupPos1, out int y) && int.TryParse(vstupPos2, out int x) && y >= 0 && y <= 9 && x >= 0 && x <= 9)
                            {
                                smer = true;

                                /* SMER START */
                                while (smer)
                                {
                                    clearcons();
                                    nactenipole(lodepole, false);

                                    if (faultcode != 0)
                                    {
                                        Console.WriteLine(faultZprava(faultcode));
                                        Console.ReadKey();

                                        clearcons();
                                        nactenipole(lodepole, false);
                                    }

                                    Console.WriteLine("Vyber směr (1 = horizontalne, 2 = vertikalne):");
                                    string vstupSmer = Console.ReadLine();
                                    int smerLode;

                                    if (int.TryParse(vstupSmer, out smerLode) && smerLode >= 1 && smerLode <= 2)
                                    {
                                        if (poradi == 1)
                                        {
                                            urcenipole(x, y, typLode, smerLode, hrac1pole);
                                        }
                                        else if (poradi == 2)
                                        {
                                            urcenipole(x, y, typLode, smerLode, hrac2pole);
                                        }

                                        pozice = false;
                                        smer = false;
                                    }
                                    else
                                    {
                                        faultcode = 4;
                                    }
                                }
                                /* SMER END */
                            }
                            else
                            {
                                faultcode = 3;
                            }
                        }
                        /* POZICE END */
                    }
                    else
                    {
                        faultcode = 2;
                    }
                }
                else
                {
                    faultcode = 1;
                }

                if (ctrlode[ctr] == 1 && ctrlode[ctr + 1] == 1 && ctrlode[ctr + 2] == 1)
                {
                    if (poradi == 1)
                    {
                        clearcons();
                        nactenipole(lodepole, false);
                        Console.WriteLine("Umístění lodí {0}. hráče dokončeno!",poradi);
                        Console.WriteLine("Stiskněte libovolnou klávesu ...");
                        Console.ReadKey();

                        poradi += 1;
                        ctr += 3;
                        resetpole(lodepole, " * ");
                    }
                    else if (poradi == 2)
                    {
                        clearcons();
                        nactenipole(lodepole, false);
                        Console.WriteLine("Umístění lodí {0}. hráče dokončeno!",poradi);
                        Console.WriteLine("Stiskněte libovolnou klávesu ...");
                        Console.ReadKey();

                        poradi -= 1;
                        urceni = false;
                    }
                }
            }
            /* URCENI END */


            /* SOUBOJ START */
            while (souboj)
            {
                clearcons();
                Console.WriteLine("Hra v průběhu!");
                soubojpole(hracipole1, hracipole2);
                //testpole();

                if (faultcode != 0)
                {
                    Console.WriteLine(faultZprava(faultcode));
                    Console.ReadKey();

                    clearcons();
                    Console.WriteLine("Hra v průběhu!");
                    soubojpole(hracipole1, hracipole2);
                }

                Console.WriteLine("Hraje {0}. hráč", poradi);
                Console.WriteLine("Vyberte pozici X a Y (čisla od 0 do 9):");
                Console.Write("X: ");
                string vstupPos1 = Console.ReadLine();
                Console.Write("Y: ");
                string vstupPos2 = Console.ReadLine();

                if (int.TryParse(vstupPos1, out int y) && int.TryParse(vstupPos2, out int x) && y >= 0 && y <= 9 && x >= 0 && x <= 9)
                {
                    if (poradi == 1)
                    {
                        utokpole(x, y, hrac2pole, hracipole2);
                        poradi += 1;
                    }
                    else if (poradi == 2)
                    {
                        utokpole(x, y, hrac1pole, hracipole1);
                        poradi -= 1;
                    }
                    Console.ReadKey();
                }
                else
                {
                    faultcode = 3;
                }

                if (ctrlode[0] + ctrlode[1] + ctrlode[2] == 10 || ctrlode[3] + ctrlode[4] + ctrlode[5] == 10)
                {
                    souboj = false;
                }
            }
            /* SOUBOJ END */
        }

        static void vytvorenipoli()
        {
            for (int i = 0; i < hracipole1.GetLength(0); i++)
            {
                for (int j = 0; j < hracipole1.GetLength(1); j++)
                {
                    hracipole1[i, j] = " * ";
                    hracipole2[i, j] = " * ";
                    lodepole[i, j] = " * ";
                    hrac1pole[i, j] = 0;
                    hrac2pole[i, j] = 0;

                }
            }
        }

        static void resetpole(string[,] pole, string hodnota)
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = hodnota;
                }
            }
        }

        static void nactenipole(string[,] pole, bool souboj)
        {
            if (souboj == false)
            {
                Console.WriteLine("{0}. hráč umisťuje lodě", poradi);
            }
            
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        horOzn += " " + (j) + " ";
                    }

                    rada += pole[i, j];

                }

                if (i == 0)
                {
                    Console.WriteLine(" " + horOzn);
                }

                Console.Write(i);

                Console.WriteLine(rada);
                horOzn = "";
                rada = "";
            }
        }
        static void testpole()
        {
            for (int i = 0; i < hrac1pole.GetLength(0); i++)
            {
                for (int j = 0; j < hrac1pole.GetLength(1); j++)
                {
                    rada += " "+hrac1pole[i, j]+" ";
                }

                Console.WriteLine(" "+rada);
                rada = "";
            }
        }
        static void soubojpole(string[,] pole1, string[,] pole2)
        {
            string odsazeni = "     |      ";
            string rada2 = "";

            for (int i = 0; i < pole1.GetLength(0); i++)
            {
                for (int j = 0; j < pole1.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        horOzn += " " + (j) + " ";
                    }

                    rada += pole1[i, j];
                    rada2 += pole2[i, j];

                }

                if (i == 0)
                {
                    Console.WriteLine(" " + horOzn + odsazeni + " " + horOzn);
                }

                Console.WriteLine(i + rada + odsazeni + i + rada2);
                horOzn = "";
                rada = "";
                rada2 = "";
            }
            Console.WriteLine();
        }

        static void urcenipole(int X, int Y, int typ, int smer, int[,] pole)
        {
            int[,] pompole = new int[2, typ];
            bool stop = false;

            if (pole[X, Y] == 0)
            {
                switch (smer)
                {
                    case 1:
                        if (Y + typ > 9 && pole[X, Y - 1] == 0 || pole[X, Y + 1] == 1) // X, Y - k
                        {
                            for (int l = 0; l < typ + 1; l++)
                            {
                                if (pole[X, Y - l] != 0)
                                {
                                    faultcode = 5;
                                    stop = true;
                                }
                            }

                            if (stop == false)
                            {
                                for (int k = 0; k < typ + 1; k++)
                                {
                                    lodepole[X, Y - k] = " O ";
                                    pole[X, Y - k] = 2;

                                    if (X - 1 >= 0)
                                    {
                                        pole[X - 1, Y - k] = 1;
                                    }

                                    if (X + 1 <= 9)
                                    {
                                        pole[X + 1, Y - k] = 1;
                                    }

                                    if (k < 1 && Y + 1 <= 9)
                                    {
                                        pole[X, Y + 1] = 1;
                                    }
                                    else if (k > typ - 1 && Y - k - 1 >= 0)
                                    {
                                        pole[X, Y - k - 1] = 1;
                                    }
                                }

                                ctrlode[ctr + typ - 1] += 1;
                            }
                            
                        }
                        else if (pole[X, Y + 1] == 0 || pole[X, Y + 1] == 1) // X, Y + k
                        {
                            for (int l = 0; l < typ + 1; l++)
                            {
                                if (pole[X, Y + l] != 0)
                                {
                                    faultcode = 5;
                                    stop = true;
                                }
                            }

                            if (stop == false)
                            {
                                for (int k = 0; k < typ + 1; k++)
                                {
                                    lodepole[X, Y + k] = " O ";
                                    pole[X, Y + k] = 2;

                                    if (X - 1 >= 0)
                                    {
                                        pole[X - 1, Y + k] = 1;
                                    }

                                    if (X + 1 <= 9)
                                    {
                                        pole[X + 1, Y + k] = 1;
                                    }

                                    if (k < 1 && Y - 1 >= 0)
                                    {
                                        pole[X, Y - 1] = 1;
                                    }
                                    else if (k > typ - 1 && Y + k + 1 <= 9)
                                    {
                                        pole[X, Y + k + 1] = 1;
                                    }
                                }

                                ctrlode[ctr + typ - 1] += 1;
                            }
                        }
                        else
                        {
                            faultcode = 5;
                        }

                        break;
                    case 2:
                        if (X + typ > 9 && pole[X - 1, Y] == 0 || pole[X + 1, Y] == 1) // X - k, Y
                        {
                            for (int l = 0; l < typ + 1; l++)
                            {
                                if (pole[X - l, Y] != 0)
                                {
                                    faultcode = 5;
                                    stop = true;
                                }
                            }

                            if (stop == false)
                            {
                                for (int k = 0; k < typ + 1; k++)
                                {
                                    lodepole[X - k, Y] = " O ";
                                    pole[X - k, Y] = 2;

                                    if (Y + 1 <= 9)
                                    {
                                        pole[X - k, Y + 1] = 1;
                                    }

                                    if (Y - 1 >= 0)
                                    {
                                        pole[X - k, Y - 1] = 1;
                                    }

                                    if (k < 1 && X + 1 <= 9)
                                    {
                                        pole[X + 1, Y] = 1;
                                    }
                                    else if (k > typ - 1 && X - k - 1 >= 0)
                                    {
                                        pole[X - k - 1, Y] = 1;
                                    }
                                }

                                ctrlode[ctr + typ - 1] += 1;
                            }
                        }
                        else if (pole[X + 1, Y] == 0 || pole[X - 1, Y] == 1) // X - k, Y
                        {
                            for (int l = 0; l < typ + 1; l++)
                            {
                                if (pole[X + l, Y] != 0)
                                {
                                    faultcode = 5;
                                    stop = true;
                                }
                            }
                            if (stop == false)
                            {
                                for (int k = 0; k < typ + 1; k++)
                                {
                                    lodepole[X + k, Y] = " O ";
                                    pole[X + k, Y] = 2;

                                    if (Y + 1 <= 9)
                                    {
                                        pole[X + k, Y + 1] = 1;
                                    }

                                    if (Y - 1 >= 0)
                                    {
                                        pole[X + k, Y - 1] = 1;
                                    }

                                    if (k < 1 && X - 1 >= 0)
                                    {
                                        pole[X - 1, Y] = 1;
                                    }
                                    else if (k > typ - 1 && X + k + 1 <= 9)
                                    {
                                        pole[X + k + 1, Y] = 1;
                                    }
                                }

                                ctrlode[ctr + typ - 1] += 1;
                            }
                        }
                        else
                        {
                            faultcode = 5;
                        }

                        break;
                }
            }
            else
            {
                faultcode = 5;
            }
        }

        static void utokpole(int X, int Y, int[,] pole, string[,] hracipole)
        {
            if (pole[X, Y] != 3)
            {
                if (pole[X, Y] == 2)
                {
                    pole[X, Y] = 3;
                    hracipole[X, Y] = " X ";

                    if (X + 1 <= 9 && pole[X + 1, Y] == 2 || X - 1 >= 0 && pole[X - 1, Y] == 2)
                    {
                        Console.WriteLine("Zásah!");
                    }
                    else if (Y + 1 <= 9 && pole[X, Y + 1] == 2 || Y - 1 >= 0 && pole[X, Y - 1] == 2)
                    {
                        Console.WriteLine("Zásah!");
                    }
                    else
                    {
                        Console.WriteLine("Potopeno!");
                    }
                }
                else
                {
                    pole[X, Y] = 3;
                    hracipole[X, Y] = " # ";
                    Console.WriteLine("Vedle!");
                }
            }
            else
            {
                faultcode = 6;
            }
               

        }

        static bool pocetLodi(int typ)
        {
            switch (typ - 1)
            {
                case 0:
                    if (ctrlode[ctr + typ - 1] < 4)
                    {
                        return true;
                    }
                    break;
                case 1:
                    if (ctrlode[ctr + typ - 1] < 2)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (ctrlode[ctr + typ - 1] < 1)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        static string faultZprava(int code)
        {
            string zprava = "Neznámý fault!";

            switch (code)
            {
                case 1:
                    zprava = "Zadej číslo od 1 do 3!";
                    break;
                case 2:
                    zprava = "Tuto loď už nemůžete umístit!";
                    break;
                case 3:
                    zprava = "Zadej číslo od 0 do 9!";
                    break;
                case 4:
                    zprava = "Zadej číslo 1 nebo 2.";
                    break;
                case 5:
                    zprava = "Na tuto pozici nemůžeš umístit loď!";
                    break;
                case 6:
                    zprava = "Tuto pozici jste už sestřelili!";
                    break;
            }

            faultcode = 0;
            return zprava;
        }

        static void clearcons()
        {
            Console.Clear();
        }
    }
}
