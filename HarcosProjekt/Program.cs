using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Harcos> harcosok = new List<Harcos>();

            Harcos harcos1 = new Harcos("Harcos1",1);
            Harcos harcos2 = new Harcos("Harcos2",2);
            Harcos harcos3 = new Harcos("Harcos3",3);
            harcosok.Add(harcos1);
            harcosok.Add(harcos2);
            harcosok.Add(harcos3);

            StreamReader r = new StreamReader("harcosok 1.csv",Encoding.Default);
            string sor;
            while (!r.EndOfStream)
            {
                sor = r.ReadLine();
                string [] st = sor.Split(';');
                Harcos h = new Harcos(st [0],Convert.ToInt32(st[1]));
                harcosok.Add(h);
            }
            /*foreach (Harcos item in harcosok)
            {
                Console.WriteLine(item);
            }*/
            char k;
            int szam;
            Console.WriteLine("Kérem a harcos nevét");
            string bekertNev = Console.ReadLine();
            Console.WriteLine("Kérem a harcos státusszablonját");
            int bekertStatusszablon = Convert.ToInt32(Console.ReadLine());
            Harcos bekertHarcos = new Harcos(bekertNev, bekertStatusszablon);
            do 
            {
                Console.WriteLine("   " + bekertHarcos + "\n");
                for (int i = 1; i < harcosok.Count; i++)
                {
                    Console.WriteLine("{0}. " + harcosok[i], i);
                }
                Console.WriteLine("Mit kíván tenni a harcossal?\na) Megküzdeni\tb) Gyógyulni\tc)Kilépni");
                k = Convert.ToChar(Console.ReadLine());
                do
                {
                    Console.WriteLine("Nem létező menüpontot adott meg, mit kíván tenni?");
                    k = Convert.ToChar(Console.ReadLine());
                }
                while (k!='a'||k!='b'||k!='c');

                if (k.Equals('a'))
                {

                    Console.WriteLine("Hanyadik harcossal szeretne küzdeni?");
                    szam = Convert.ToInt32(Console.ReadLine());
                    bekertHarcos.Megkuzd(harcosok[szam-1]);
                    Console.WriteLine("   "+bekertHarcos+"\n");
                    for (int i = 1; i < harcosok.Count; i++)
                    {
                        Console.WriteLine("{0}. " + harcosok[i], i);
                    }

                }
                else if (k.Equals('b'))
                {
                    bekertHarcos.Gyogyul();
                    Console.WriteLine("   " + bekertHarcos + "\n");
                    for (int i = 1; i < harcosok.Count; i++)
                    {
                        Console.WriteLine("{0}. " + harcosok[i], i);
                    }
                }
                else if (k.Equals('c'))
                {

                }
            }
            while ();

            








            Console.ReadKey();
        }
    }
}
