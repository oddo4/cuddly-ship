using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lode
{
    class Program
    {
        static string[,] hracipole = new string[10, 10];
        static string[,] lodepole = new string[10, 10];
        static int[,] hrac1pole = new int[10, 10];
        static int[] ctrlode = new int[3];

        static string rada = "";
        static string horOzn = "";
        static int errorcode = 0;

        static void Main(string[] args)
        {
            bool urceni = true;
            bool pozice = true;
            bool smer = true;
            bool souboj = true;
            
            vytvorenipole();

            /* URCENI START */
            while (urceni)
            {
                clearcons();
                nactenipole(lodepole);

                if (errorcode != 0)
                {
                    Console.WriteLine(errorZprava(errorcode));
                }

                Console.WriteLine("Počet lodí: 2 - {0}(4), 3 - {1}(2), 4 - {2}(1)", ctrlode[0], ctrlode[1], ctrlode[2]);

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
                            nactenipole(lodepole);

                            if (errorcode != 0)
                            {
                                Console.WriteLine(errorZprava(errorcode));
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
                                    nactenipole(lodepole);

                                    if (errorcode != 0)
                                    {
                                        Console.WriteLine(errorZprava(errorcode));
                                    }

                                    Console.WriteLine("Vyber směr (1 = horizontalne, 2 = vertikalne):");
                                    string vstupSmer = Console.ReadLine();
                                    int smerLode;

                                    if (int.TryParse(vstupSmer, out smerLode) && smerLode >= 1 && smerLode <= 2)
                                    {
                                        clearcons();
                                        urcenipole(x, y, typLode, smerLode);

                                        pozice = false;
                                        smer = false;
                                    }
                                    else
                                    {
                                        errorcode = 4;
                                    }
                                }
                                /* SMER END */
                            }
                            else
                            {
                                errorcode = 3;
                            }
                        }
                        /* POZICE END */
                    }
                    else
                    {
                        errorcode = 2;
                    }
                }
                else
                {
                    errorcode = 1;
                }

                if (ctrlode[0] == 1 && ctrlode[1] == 1 && ctrlode[2] == 1)
                {
                    urceni = false;
                }
            }
            /* URCENI END */

            Console.WriteLine("Začíná hra!");

            while (souboj)
            {
                clearcons();
                nactenipole(hracipole);

                if (errorcode != 0)
                {
                    Console.WriteLine(errorZprava(errorcode));
                }

                Console.WriteLine("Vyberte pozici X a Y (čisla od 0 do 9):");
                Console.Write("X: ");
                string vstupPos1 = Console.ReadLine();
                Console.Write("Y: ");
                string vstupPos2 = Console.ReadLine();

                if (int.TryParse(vstupPos1, out int y) && int.TryParse(vstupPos2, out int x) && y >= 0 && y <= 9 && x >= 0 && x <= 9)
                {

                }
                else
                {
                    errorcode = 3;
                }

                Console.ReadLine();
            }
        }

        static void vytvorenipole()
        {
            for (int i = 0; i < hracipole.GetLength(0); i++)
            {
                for (int j = 0; j < hracipole.GetLength(1); j++)
                {
                    hracipole[i, j] = " * ";
                    lodepole[i, j] = " * ";
                    hrac1pole[i, j] = 0;

                }
            }
        }

        static void nactenipole(string[,] pole)
        {
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

        static void urcenipole(int X, int Y, int typ, int smer)
        {
            int[,] pompole = new int[2, typ];

            if (limitpole[X, Y] == 0)
            {
                for (int k = 0; k < typ + 1; k++)
                {
                    switch (smer)
                    {
                        case 1:
                            if (Y + typ > 9 && limitpole[X, Y - k] == 0 || limitpole[X, Y + k] == 1)
                            {
                                lodepole[X, Y - k] = " O ";
                                limitpole[X, Y - k] = 2;

                                if (X - 1 >= 0)
                                {
                                    limitpole[X - 1, Y - k] = 1;
                                }

                                if (X + 1 <= 9)
                                {
                                    limitpole[X + 1, Y - k] = 1;
                                }

                                if (k < 1 && Y + 1 <= 9)
                                {
                                    limitpole[X, Y + 1] = 1;
                                }
                                else if (k > typ - 1 && Y - k - 1 >= 0)
                                {
                                    limitpole[X, Y - k - 1] = 1;
                                }
                            }
                            else if (limitpole[X, Y + k] == 0 || limitpole[X, Y + k] == 1)
                            {
                                lodepole[X, Y + k] = " O ";
                                limitpole[X, Y + k] = 2;

                                if (X - 1 >= 0)
                                {
                                    limitpole[X - 1, Y + k] = 1;
                                }

                                if (X + 1 <= 9)
                                {
                                    limitpole[X + 1, Y + k] = 1;
                                }

                                if (k < 1 && Y - 1 >= 0)
                                {
                                    limitpole[X, Y - 1] = 1;
                                }
                                else if (k > typ - 1 && Y + k + 1 <= 9)
                                {
                                    limitpole[X, Y + k + 1] = 1;
                                }
                            }
                            else
                            {
                                errorcode = 5;
                            }
                            break;
                        case 2:
                            if (X + typ > 9 && limitpole[X - k, Y] == 0 || limitpole[X + k, Y] == 1)
                            {
                                lodepole[X - k, Y] = " O ";
                                limitpole[X - k, Y] = 2;

                                if (Y + 1 <= 9)
                                {
                                    limitpole[X - k, Y + 1] = 1;
                                }

                                if (Y - 1 >= 0)
                                {
                                    limitpole[X - k, Y - 1] = 1;
                                }

                                if (k < 1 && X + 1 <= 9)
                                {
                                    limitpole[X + 1, Y] = 1;
                                }
                                else if (k > typ - 1 && X - k - 1 >= 0)
                                {
                                    limitpole[X - k - 1, Y] = 1;
                                }
                            }
                            else if (limitpole[X + k, Y] == 0 || limitpole[X - k, Y] == 1)
                            {
                                lodepole[X + k, Y] = " O ";
                                limitpole[X + k, Y] = 2;

                                if (Y + 1 <= 9)
                                {
                                    limitpole[X + k, Y + 1] = 1;
                                }

                                if (Y - 1 >= 0)
                                {
                                    limitpole[X + k, Y - 1] = 1;
                                }

                                if (k < 1 && X - 1 >= 0)
                                {
                                    limitpole[X - 1, Y] = 1;
                                }
                                else if (k > typ - 1 && X + k + 1 <= 9)
                                {
                                    limitpole[X + k + 1, Y] = 1;
                                }
                            }
                            else
                            {
                                errorcode = 5;
                            }
                            break;
                    }
                }

                ctrlode[typ - 1] += 1;
            }
            else
            {
                errorcode = 5;
            }
        }

        static void utokpole(int X, int Y)
        {

        }

        static bool pocetLodi(int typ)
        {
            switch (typ - 1)
            {
                case 0:
                    if (ctrlode[typ - 1] < 4)
                    {
                        return true;
                    }
                    break;
                case 1:
                    if (ctrlode[typ - 1] < 2)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (ctrlode[typ - 1] < 1)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        static string errorZprava(int code)
        {
            string zprava = "Neznámý error!";

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
            }

            errorcode = 0;
            return zprava;
        }

        static void clearcons()
        {
            Console.Clear();
        }
    }
}
