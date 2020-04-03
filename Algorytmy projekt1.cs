using System;
using System.Diagnostics;
using System.IO;

namespace Projekt1_Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {


            {
                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie proste - operacje");
                WyszukiwanieProsteOper();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie proste - operacje");
                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie proste - czas ");
                WyszukiwanieProsteCzas();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie proste - czas");

                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie proste Uśrednione  - operacje");
                WyszukiwanieProsteOperSr();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie proste Uśrednione - operacje");
                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie proste Uśrednione - czas");
                WyszukiwanieProsteCzasSr();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie proste Uśrednione - czas");


                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie binarne - operacje");
                WyszukiwanieBinarneOper();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie binarne - operacje");
                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie binarne - czas");
                WyszukiwanieBinarneCzas();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie binarne - czas");
                
                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie binarne Uśrednione - operacje");
                WyszukiwanieBinarneOperSr();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie binarne Uśrednione - operacje");
                
                Console.WriteLine($"{DateTime.Now} - Czas rozpoczęcia pomiaru - Wyszukiwanie binarne Uśrednione - czas");
                WyszukiwanieBinarneCzasSr();
                Console.WriteLine($"{DateTime.Now} - Koniec pomiaru - Wyszukiwanie binarne Uśrednione - czas");
                Console.ReadKey();
            }

            /*
             * Wyszukiwanie proste - operacje
            */
            static void WyszukiwanieProsteOper()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 1_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    long operacje = SimpleSearchCount(tabela, -1);
                    AddToFile("WyszukiwanieProsteOper", i, $"{operacje}");
                }
            }

            /*
             * Wyszukiwanie proste - czas
            */
            static void WyszukiwanieProsteCzas()
            {

                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 1_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    SimpleSearch(tabela, -1);
                    stoper.Stop();
                    long czasWykonania = stoper.ElapsedTicks;
                    AddToFile("WyszukiwanieProsteCzas", i, $"{czasWykonania}");
                }
            }

            /*
              * Wyszukiwanie proste Uśrednione - operacje
             */
            static void WyszukiwanieProsteOperSr()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 1_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    long operacje = SimpleSearch(tabela, i / 2);
                    AddToFile("WyszukiwanieProsteOperSr", i, $"{operacje}");
                }
            }

            /*
             * Wyszukiwanie proste Uśrednione - czas
            */
            static void WyszukiwanieProsteCzasSr()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 1_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    SimpleSearch(tabela, i / 2);
                    stoper.Stop();
                    long czasWykonania = stoper.ElapsedTicks;
                    AddToFile("WyszukiwanieProsteCzasSr", i, $"{czasWykonania}");
                }
            }

            /*
            * Wyszukiwanie binarne - operacje
           */
            static void WyszukiwanieBinarneOper()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 1_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    BinarySearch(tabela, -1, out long operacje);
                    AddToFile("WyszukiwanieBinarneOper", i, $"{operacje}");
                }
            }

            /*
             * Wyszukiwanie binarne - czas
            */
            static void WyszukiwanieBinarneCzas()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 1_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    BinarySearch(tabela, -1);
                    stoper.Stop();
                    long czasWykonania = stoper.ElapsedTicks;
                    AddToFile("WyszukiwanieBinarneCzas", i, $"{czasWykonania}");
                }
            }

            /*
              * Wyszukiwanie binarne Uśrednione - operacje
             */
            static void WyszukiwanieBinarneOperSr()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 5_000_000)
                {
                    long LicznikOperacji = 0;
                    long[] tabela = GenerateSortedTable(i);
                    foreach (var t in tabela)
                    {
                        BinarySearch(tabela, t, out long wynik);
                        LicznikOperacji += wynik;
                    }

                    AddToFile("WyszukiwanieBinarneOperSr", i, $"{LicznikOperacji / i}");
                }
            }

            /*
              * Wyszukiwanie binarne Uśrednione - czas
             */
            static void WyszukiwanieBinarneCzasSr()
            {
                for (long i = 2_000_000; i < Math.Pow(2, 28); i += 5_000_000)
                {
                    long[] tabela = GenerateSortedTable(i);
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    foreach (var t in tabela)
                    {
                        BinarySearch(tabela, t);
                    }
                    stoper.Stop();
                    long czasWykonania = stoper.ElapsedTicks;
                    AddToFile("WyszukiwanieBinarneCzasSr", i, $"{czasWykonania / i}");
                }
            }

        }


        // Generowanie posortowanej tablicy

        static long[] GenerateSortedTable(long wielkoscTablicy)
        {
            long[] tabela = new long[wielkoscTablicy];
            for (long i = 0; i < tabela.Length; i++)
            {

                tabela[i] = i;
            }

            return tabela;
        }


        // Wyszukiwanie proste

        static long SimpleSearch(long[] tablicaLiczb, long szukana)
        {
            for (long i = 0; i < tablicaLiczb.Length; i++)
            {
                if (tablicaLiczb[i] == szukana) return i;
            }

            return tablicaLiczb.Length;
        }


        // Wyszukiwanie proste ze zliczaniem

        static long SimpleSearchCount(long[] tablicaLiczb, long szukana)
        {
            long licznik = 0;
            for (long i = 0; i < tablicaLiczb.Length; i++)
            {

                if (tablicaLiczb[i] == szukana)
                {
                    licznik++;
                    return licznik;
                }

                else
                {
                    licznik++;
                }
            }
            return licznik;
        }




        // Wyszukiwanie binarne

        static long BinarySearch(long[] tablicaLiczb, long szukana)
        {
            long left = 0;
            long right = tablicaLiczb.Length - 1;
            long mid;
            while (left <= right)
            {
                mid = (right + left) / 2;
                if (tablicaLiczb[mid] == szukana) return mid;
                else if (tablicaLiczb[mid] < szukana) left = mid + 1;
                else right = mid - 1;
            }

            return -1;

        }


        // Wyszukiwanie binarne ze zliczaniem

        static long BinarySearch(long[] tablicaLiczb, long szukana, out long licznik)
        {
            licznik = 0;
            long left = 0;
            long right = tablicaLiczb.Length - 1;
            long mid;
            while (left <= right)
            {

                mid = (right + left) / 2;
                if (tablicaLiczb[mid] == szukana)
                {
                    licznik++;
                    return mid;
                }

                else if (tablicaLiczb[mid] < szukana)
                {
                    licznik++;
                    left = mid + 1;
                }

                else
                {
                    licznik++;
                    right = mid - 1;
                }
            }
            return -1;
        }

        /*
         * Zapis do pliku tekstowego
        */

        static void AddToFile(string type, long zapis, string wynik)
        {
            string path = @"dane.txt";

            if (!File.Exists(path))
            {
                //Tworzenie pliku
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"{type},{zapis},{wynik}");
                }
            }

            //Wypełnianie pliku danymi
            using (StreamWriter sw = File.AppendText(path))
            {

                sw.WriteLine($"{type},{zapis},{wynik}");
            }
        }


    }
}
