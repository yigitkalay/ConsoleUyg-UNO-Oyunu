using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class Kart
    {
        //Destenin hazırlanması

        public string[] renk = { "sarı", "kırmızı", "mavi" };
        public string[] kartlar = { "k1", "k2", "k3", "k4", "k5", "m1", "m2", "m3", "m4", "m5", "s1", "s2", "s3", "s4", "s5", "rd", "rd", "rd" };
        public string[] oyuncu1 = new string[6];
        public string[] oyuncu2 = new string[6];
        public string[] oyuncu3 = new string[6];

        Random rast = new Random();
        int a = 0;

         //Oyunculara kartların atanması

            public void kartdagit()
        {
            a = rast.Next(0, 18);
            for (int i = 0; i < 6; i++)
            {
                if (kartlar[a] != "yok")
                {
                    oyuncu1[i] = kartlar[a];
                    kartlar[a] = "yok";
                }

                else
                {
                    a = rast.Next(0, 18);
                    i -= 1;
                }
            }

            while (true)
            {
                a = rast.Next(0, 18);

                if (kartlar[a] != "yok")
                {
                    break;
                }
            }

            for (int i = 0; i < 6; i++)
            {

                if (kartlar[a] != "yok")
                {
                    oyuncu2[i] = kartlar[a];
                    kartlar[a] = "yok";
                }

                else
                {
                    a = rast.Next(0, 18);
                    if (i != 0)
                        i -= 1;
                }
            }

            while (true)
            {
                a = rast.Next(0, 18);

                if (kartlar[a] != "yok")
                {
                    break;
                }
            }

            for (int i = 0; i < 6; i++)
            {

                if (kartlar[a] != "yok")
                {
                    oyuncu3[i] = kartlar[a];
                    kartlar[a] = "yok";
                }

                else
                {
                    a = rast.Next(0, 18);
                    if (i != 0)
                        i -= 1;
                }
            }
        }      
    }
}
