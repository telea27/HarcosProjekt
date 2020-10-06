using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Globalization;

namespace HarcosProjekt
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Harcos> harcosok = new List<Harcos>();

            Harcos harcos1 = new Harcos("Pipibaba", 1);
            Harcos harcos2 = new Harcos("Küratorp", 2);
            Harcos harcos3 = new Harcos("Kvudrulf", 3);
            harcosok.Add(harcos1);
            harcosok.Add(harcos2);
            harcosok.Add(harcos3);

            StreamReader r = new StreamReader("harcosok 1.csv", Encoding.Default);
            string sor;
            while (!r.EndOfStream)
            {
                sor = r.ReadLine();
                string[] st = sor.Split(';');
                Harcos h = new Harcos(st[0], Convert.ToInt32(st[1]));
                harcosok.Add(h);
            }
            /*foreach (Harcos item in harcosok)
            {
                Console.WriteLine(item);
            }*/
            char k;
            string szam;
            int szamlalo = 0;
            Random rnd = new Random();
            Console.WriteLine("Kérem a harcos nevét");
            string bekertNev = Console.ReadLine();
            Console.WriteLine("Kérem a harcos státusszablonját");
            int bekertStatusszablon = Convert.ToInt32(Console.ReadLine());
            Harcos bekertHarcos = new Harcos(bekertNev, bekertStatusszablon);
            do
            {
                szamlalo++;
                Console.WriteLine(szamlalo + ". kör!");
                Console.WriteLine("   " + bekertHarcos + "\n");
                for (int i = 0; i < harcosok.Count; i++)
                {
                    Console.WriteLine("{0}. " + harcosok[i], i + 1);
                }

                do
                {
                    Console.WriteLine("Mit kíván tenni a harcossal?\na) Megküzdeni\tb) Gyógyulni\tc)Kilépni");
                    k = Convert.ToChar(Console.ReadLine());
                }
                while (k != 'a' && k != 'b' && k != 'c');

                if (k.Equals('a'))
                {
                    string[] szamocskak = new string[harcosok.Count];
                    for (int i = 0; i < harcosok.Count; i++)
                    {
                        szamocskak[i] = Convert.ToString(i);
                    }

                    bool l;
                    do
                    {
                        Console.WriteLine("Hanyadik harcossal szeretne küzdeni?");
                        szam = Console.ReadLine();
                        l = false;
                        if (szam.All(char.IsNumber))
                        {
                            l = true;
                        }
                    }
                    while (!szamocskak.Contains(szam) && !l);

                    bekertHarcos.Megkuzd(harcosok[Convert.ToInt32(szam) - 1]);
                }
                else if (k.Equals('b'))
                {
                    bekertHarcos.Gyogyul();
                }
                if (szamlalo % 3 == 0)
                {
                    int harcosSzama = rnd.Next(0, harcosok.Count);
                    bekertHarcos.Megkuzd(harcosok[harcosSzama]);
                    Console.WriteLine("Megtámadott {0}!!!!!!!!!!!!",harcosok[harcosSzama].Nev);

                    for (int i = 0; i < harcosok.Count; i++)
                    {
                        harcosok[i].Gyogyul();
                    }

                }
                Console.Clear();
            }
            while (!k.Equals('c'));










            Console.ReadKey();
        }
    }
}
