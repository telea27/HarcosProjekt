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
            Console.WriteLine(harcos1);
            Console.WriteLine(harcos2);
            Console.WriteLine(harcos3);



            Console.ReadKey();
        }
    }
}
