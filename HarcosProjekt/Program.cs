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

            StreamReader r = new StreamReader("harcosok 1.csv");
            string sor;
            while (!r.EndOfStream)
            {
                sor = r.ReadLine();
                string [] st = sor.Split(';');
                Harcos h = new Harcos(st [0],Convert.ToInt32(st[1]));
                harcosok.Add(h);
            }
            foreach (Harcos item in harcosok)
            {
                Console.WriteLine(item);
            }
            

            Console.ReadKey();
        }
    }
}
