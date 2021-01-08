using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Oyunuma Hoş Geldiniz...

            Oyun oyun = new Oyun();
            oyun.Başlat();


            Console.ReadKey();
        }
    }
}
