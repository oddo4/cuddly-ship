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
        static int[,] limitpole = new int[10, 10];
        static string rada = "";
        static string horOzn = "";

        static void Main(string[] args)
        {
            bool urceni = true;
            bool pozice = true;
            bool smer = true;
            bool souboj = true;
            int ctrlode = 0;

            vytvorenipole();

            while (urceni)
            {

                Console.WriteLine("Vyber typ lodě (čisla od 1 do 3):");
                string vstupTypLode = Console.ReadLine(); // 1 = 2, 2 = 3, 3 = 4
                int typLode;

                if (int.TryParse(vstupTypLode, out typLode) && typLode >= 1 && typLode <= 3)
                {
                    pozice = true;

                    while (pozice)
                    {

                        //clearcons();
                        //vytvorenipole();

                        Console.WriteLine("Vyber počáteční pozici X a Y (čisla od 0 do 9):");
                        string vstupPos1 = Console.ReadLine();
                        string vstupPos2 = Console.ReadLine();

                        //int x, y;

                        if (int.TryParse(vstupPos1, out int y) && int.TryParse(vstupPos2, out int x) && y >= 0 && y <= 9 && x >= 0 && x <= 9)
                        {
                            smer = true;

                            while (smer)
                            {
                                Console.WriteLine("Vyber směr (1 = horizontalne, 2 = vertikalne):");
                                string vstupSmer = Console.ReadLine();
                                int smerLode;

                                if (int.TryParse(vstupSmer, out smerLode) && smerLode >= 1 && smerLode <= 2)
                                {
                                    clearcons();
                                    urcenipole(x, y, typLode, smerLode);
                                    //testpole();

                                    pozice = false;
                                    smer = false;
                                }
                                else
                                {
                                    Console.WriteLine("Zadej číslo 1 nebo 2.");
                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("Zadej číslo od 0 do 9.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Zadej číslo od 1 do 3!");
                }

            }

        }

        static void vytvorenipole()
        {
            for (int i = 0; i < hracipole.GetLength(0); i++)
            {
                for (int j = 0; j < hracipole.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        horOzn += " " + (j) + " ";
                    }

                    hracipole[i, j] = " * ";
                    lodepole[i, j] = " * ";
                    limitpole[i, j] = 0;

                    rada += hracipole[i, j];

                }

                if (i == 0)
                {
                    Console.WriteLine(" " + horOzn);
                }

                Console.Write(i);

                Console.WriteLine(rada);
                rada = "";
            }
        }

        /*static void testpole()
        {
            for (int i = 0; i < limitpole.GetLength(0); i++)
            {
                for (int j = 0; j < limitpole.GetLength(1); j++)
                {

                    rada += " " + limitpole[i, j] + " ";

                }

                Console.WriteLine(" " + rada);
                rada = "";
            }
        }*/



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
                            if (Y + typ > 9 && limitpole[X, Y - k] == 0)
                            {
                                lodepole[X, Y - k] = " O ";
                                limitpole[X, Y - k] = 1;
                                limitpole[X - 1, Y - k] = 1;
                                limitpole[X + 1, Y - k] = 1;

                                if (k < 1)
                                {
                                    limitpole[X, Y + 1] = 1;
                                }
                                else if (k > typ - 1)
                                {
                                    limitpole[X, Y - k - 1] = 1;
                                }
                            }
                            else if (limitpole[X, Y + k] == 0)
                            {
                                lodepole[X, Y + k] = " O ";
                                limitpole[X, Y + k] = 1;
                                limitpole[X - 1, Y + k] = 1;
                                limitpole[X + 1, Y + k] = 1;

                                if (k < 1)
                                {
                                    limitpole[X, Y - 1] = 1;
                                }
                                else if (k > typ - 1)
                                {
                                    limitpole[X, Y + k + 1] = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tato pozice je již vybraná.");
                            }
                            break;
                        case 2:
                            if (X + typ > 9 && limitpole[X - k, Y] == 0)
                            {
                                lodepole[X - k, Y] = " O ";
                                limitpole[X - k, Y] = 1;
                                limitpole[X - k, Y + 1] = 1;
                                limitpole[X - k, Y - 1] = 1;

                                if (k < 1)
                                {
                                    limitpole[X + 1, Y] = 1;
                                }
                                else if (k > typ - 1)
                                {
                                    limitpole[X - k - 1, Y] = 1;
                                }
                            }
                            else if (limitpole[X + k, Y] == 0)
                            {
                                lodepole[X + k, Y] = " O ";
                                limitpole[X + k, Y] = 1;
                                limitpole[X + k, Y + 1] = 1;
                                limitpole[X + k, Y - 1] = 1;

                                if (k < 1)
                                {
                                    limitpole[X - 1, Y] = 1;
                                }
                                else if (k > typ - 1)
                                {
                                    limitpole[X + k + 1, Y] = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tato pozice je již vybraná.");
                            }
                            break;
                    }
                }

                /*for (int l = 0; l < (typ+1)*2+2; l++)
                {
                    if (l < 1)
                    {
                        limit
                    }
                }*/

            }
            else
            {
                Console.WriteLine("Tato pozice je již vybraná.");
            }

            for (int i = 0; i < lodepole.GetLength(0); i++)
            {
                for (int j = 0; j < lodepole.GetLength(1); j++)
                {
                    rada += lodepole[i, j];
                }
                if (i == 0)
                {
                    Console.WriteLine(" " + horOzn);
                }

                Console.Write(i);

                Console.WriteLine(rada);
                rada = "";
            }
        }

        static void clearcons()
        {
            Console.Clear();
        }


    }
}
