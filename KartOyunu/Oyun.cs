using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class Oyun
    {
        public void Başlat()
        {
            //Oyunculara dağıtılmış olan kartların çağırılması
            
            Kart kart = new Kart();
            kart.kartdagit();

            int a = 0, b = 0, d1 = 0, d2 = 0;
            string cevap, cevapp = "", ortadasayi = "", ortadaharf = "", istrenk = "";

            //İlk turun gerçekleştirilmesi (ilk tura özel olarak hazırlanmış olup, ilk turun şartları sağlanmıştır.)

            Random rast = new Random();
            b = rast.Next(1, 4);
            Console.WriteLine("\nRengarenk Kart Oyununa Hoş Geldiniz...\n");
            Console.WriteLine("{0}.Oyuncu Oyuna İlk Olarak Başlıyor\n", b);
            int[] sira = new int[40] { 0, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3 };
            if (b == 2)
            {
                while (true)
                {
                    a = rast.Next(0, 6);
                    if (kart.oyuncu2[a] != "rd")
                    {
                        Console.WriteLine("{0}.Oyuncu {1} kartını attı.", b, kart.oyuncu2[a]);
                        ortadasayi = kart.oyuncu2[a].Substring(1);
                        ortadaharf = kart.oyuncu2[a].Substring(0, 1);
                        kart.oyuncu2[a] = "yok";
                        break;
                    }
                }
            }
            else if (b == 3)
            {
                while (true)
                {
                    a = rast.Next(0, 6);
                    if (kart.oyuncu3[a] != "rd")
                    {
                        Console.WriteLine("{0}.Oyuncu {1} kartını attı.", b, kart.oyuncu3[a]);
                        ortadasayi = kart.oyuncu3[a].Substring(1);
                        ortadaharf = kart.oyuncu3[a].Substring(0, 1);
                        kart.oyuncu3[a] = "yok";
                        break;
                    }
                }
            }

            else
            {
                a = rast.Next(0, 6);
                Console.WriteLine("Sıra sizin, işte kartlarınız:");
                
                for (int i = 0; i < 6; i++)
                {
                    if (kart.oyuncu1[i] == "yok")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(kart.oyuncu1[i] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (kart.oyuncu1[i].Substring(0, 1) == "s")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(kart.oyuncu1[i] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (kart.oyuncu1[i].Substring(0, 1) == "k")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(kart.oyuncu1[i] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (kart.oyuncu1[i].Substring(0, 1) == "m")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(kart.oyuncu1[i] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (kart.oyuncu1[i].Substring(0, 1) == "r")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(kart.oyuncu1[i] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine("\nAtmak istediğiniz kart hangisi: ");
                cevap = Console.ReadLine();

                int sabitle = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (cevap != "rd" && cevap != "yok" && cevap == kart.oyuncu1[j])
                        {
                            cevapp = cevap;
                            sabitle = j;
                        }
                    }

                    if (cevap != "rd" && cevap != "yok" && cevapp != "" && cevap != "PAS" && cevap != "pas")
                    {
                        Console.WriteLine("1.Oyuncu {0} kartını attı.", cevapp);
                        ortadasayi = kart.oyuncu1[sabitle].Substring(1);
                        ortadaharf = kart.oyuncu1[sabitle].Substring(0, 1);
                        kart.oyuncu1[sabitle] = "yok";
                        break;
                    }

                    else
                    {
                        if (cevap == "rd")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("İlk tur RENK DEĞİŞTİR kartını atamazsınız.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (cevap == "pas" || cevap == "PAS")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Atacak kartınız kalmayana dek PAS diyemezsiniz.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sahip olmadığınız bir kartı atamazsınız.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("Lütfen farklı bir kart seçin: ");
                        cevap = Console.ReadLine();
                    }
                }
            }

            //Oyuna ait tüm değişkenler, kontroller ve algoritmaların oluşturulup uygulanması

            int ok1 = 0, ok2 = 0, ok3 = 0;
            int ber1 = 0, ber2 = 0, ber3 = 0;
            int kontrol = 0;
            cevapp = "";
            for (int k = 1; k < 100; k++)
            {
                kontrol++;
                b++;

                //Elinde atacak kart kalmayan oyuncunun kazanması

                if (kontrol > 4)
                {

                    for (int j = 0; j < 6; j++)
                    {
                        if ("yok" == kart.oyuncu1[j])
                        {
                            ok1++;
                        }

                        if ("yok" == kart.oyuncu2[j])
                        {
                            ok2++;
                        }

                        if ("yok" == kart.oyuncu3[j])
                        {
                            ok3++;
                        }
                    }

                    if (ok1 == 6)
                    {
                        Console.Beep(3500, 1000);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nTebrikler Oyunu Siz Kazandınız.");
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        break;
                    }

                    else if (ok2 == 6)
                    {
                        Console.Beep(2500, 1000);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nElinde Hiç Kart Kalmadığından Oyunu 2.Oyuncu Kazandı.");
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        break;
                    }

                    else if (ok3 == 6)
                    {
                        Console.Beep(1500, 1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nElinde Hiç Kart Kalmadığından Oyunu 3.Oyuncu Kazandı.");
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        break;
                    }

                    else
                    {
                        ok1 = 0; ok2 = 0; ok3 = 0;
                    }

                    //OYUN BAŞLIYOR

                }

                //2.Oyuncu (Bilgisayar) için yapılan işlemler

                if (sira[b] == 2)
                {
                    d2 = 0;
                    int d22 = 0;
                    
                    for (int i = 0; i < 50; i++)
                    {
                        a = rast.Next(0, 6);
                        if ((ortadaharf == kart.oyuncu2[a].Substring(0, 1) || ortadasayi == kart.oyuncu2[a].Substring(1)) && kart.oyuncu2[a] != "yok")
                        {
                            d2 = 1;
                            d22 = 1;
                            Console.WriteLine("{0}.Oyuncu {1} kartını attı.", 2, kart.oyuncu2[a]);
                            if (kart.oyuncu2[a] != "rd")
                            {
                                ortadasayi = kart.oyuncu2[a].Substring(1);
                                ortadaharf = kart.oyuncu2[a].Substring(0, 1);
                            }

                            kart.oyuncu2[a] = "yok";
                            ber2 = 0;
                            break;
                        }
                    }

                    if (d22 == 0)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            a = rast.Next(0, 6);

                            if (kart.oyuncu2[a] == "rd")
                            {
                                string renk2 = kart.renk[rast.Next(0, 3)];
                                Console.WriteLine("{0}.Oyuncu {1} kartını attı.", 2, kart.oyuncu2[a]);
                                Console.WriteLine("Artık oyunun rengi {0}", renk2);
                                kart.oyuncu2[a] = "yok";
                                ortadaharf = renk2.Substring(0, 1);
                                ortadasayi = "0";
                                d2 = 1;
                                ber2 = 0;
                                break;
                            }
                        }
                    }

                    if (d2 == 0)
                    {
                        Console.WriteLine("2.Oyuncu PAS diyor.");
                        ber2 = 1;
                    }
                }

                //3.Oyuncu (Bilgisayar) için yapılan işlemler

                else if (sira[b] == 3)
                {
                    d1 = 0;
                    int d11 = 0;
                    
                    for (int i = 0; i < 50; i++)
                    {
                        a = rast.Next(0, 6);
                        if ((ortadaharf == kart.oyuncu3[a].Substring(0, 1) || ortadasayi == kart.oyuncu3[a].Substring(1)) && kart.oyuncu3[a] != "yok")
                        {
                            d1 = 1;
                            d11 = 1;
                            Console.WriteLine("{0}.Oyuncu {1} kartını attı.", 3, kart.oyuncu3[a]);
                            if (kart.oyuncu3[a] != "rd")
                            {
                                ortadasayi = kart.oyuncu3[a].Substring(1);
                                ortadaharf = kart.oyuncu3[a].Substring(0, 1);

                            }

                            ber3 = 0;
                            kart.oyuncu3[a] = "yok";
                            break;
                        }
                    }

                    if (d11 == 0)
                    {
                        for (int j = 0; j < 50; j++)
                        {
                            a = rast.Next(0, 6);

                            if (kart.oyuncu3[a] == "rd")
                            {
                                Random rast2 = new Random();
                                string renk3 = kart.renk[rast2.Next(0, 3)];
                                Console.WriteLine("{0}.Oyuncu {1} kartını attı.", 3, kart.oyuncu3[a]);
                                Console.WriteLine("Artık oyunun rengi {0}", renk3);
                                kart.oyuncu3[a] = "yok";
                                ortadaharf = renk3.Substring(0, 1);
                                ortadasayi = "0";
                                d1 = 1;
                                ber3 = 0;

                                break;  
                            }
                        }
                    }

                    
                    if (d1 == 0)
                    {
                        Console.WriteLine("3.Oyuncu PAS diyor.");
                        ber3 = 1;
                    }
                }

                //1.Oyuncu (Kullanıcı) için yapılan işlemler

                else
                {
                    int pas = 0;
                    int sabitle = 0;
                    a = rast.Next(0, 6);
                    Console.WriteLine("\nSıra sizin, işte kartlarınız:");
                    
                    for (int i = 0; i < 6; i++)
                    {
                        if (kart.oyuncu1[i]=="yok")
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(kart.oyuncu1[i] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (kart.oyuncu1[i].Substring(0,1) == "s")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(kart.oyuncu1[i] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (kart.oyuncu1[i].Substring(0,1) == "k")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(kart.oyuncu1[i] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (kart.oyuncu1[i].Substring(0,1) == "m")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(kart.oyuncu1[i] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (kart.oyuncu1[i].Substring(0,1) == "r")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(kart.oyuncu1[i] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    Console.WriteLine("\nAtmak istediğiniz kart hangisi: ");
                    cevap = Console.ReadLine();


                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (cevap == kart.oyuncu1[j])
                            {
                                cevapp = cevap;
                                sabitle = j;
                            }
                        }

                        if (((ortadaharf == kart.oyuncu1[sabitle].Substring(0, 1) || ortadasayi == kart.oyuncu1[sabitle].Substring(1)) && cevap != "yok" && cevapp != "") || ((cevap == "pas" || cevap == "PAS") && pas == 1))
                        {
                            if (pas == 1)
                            {
                                Console.WriteLine("1.Oyuncu PAS diyor.");
                                ber2 = 0;
                                cevapp = "";
                                pas = 0;
                                break;
                            }

                            else
                            {
                                Console.WriteLine("1.Oyuncu {0} kartını attı.", cevapp);
                                ortadasayi = kart.oyuncu1[sabitle].Substring(1);
                                ortadaharf = kart.oyuncu1[sabitle].Substring(0, 1);
                                kart.oyuncu1[sabitle] = "yok";
                                cevapp = "";
                                ber1 = 0;
                                break;
                            }
                        }

                        else if (cevapp == "rd")
                        {

                            Console.WriteLine("1.Oyuncu {0} kartını attı.", cevapp);
                            Console.WriteLine("Lütfen değiştirmek istediğiniz rengi seçin: ");
                            istrenk = Console.ReadLine();
                            int kntt = 1;
                            for (int j = 0; j < 3; j++)
                            {
                                kntt++;
                                if (istrenk == kart.renk[j])
                                {
                                    Console.WriteLine("Artık oyunun rengi {0}", istrenk);
                                    ortadaharf = istrenk.Substring(0, 1);
                                    ortadasayi = "0";
                                    ber1 = 0;
                                    break;
                                }

                                if (kntt == 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Lütfen seçmek istediğiniz rengin tam adını yazın:");
                                    Console.WriteLine("( sarı / kırmızı / mavi )");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Lütfen değiştirmek istediğiniz rengi seçin: ");
                                    istrenk = Console.ReadLine();
                                    if (istrenk == "sarı" || istrenk == "kırmızı" || istrenk == "mavi")
                                    {
                                        Console.WriteLine("Artık oyunun rengi {0}", istrenk);
                                        ortadaharf = istrenk.Substring(0, 1);
                                        ortadasayi = "0";
                                        ber1 = 0;
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Lütfen seçmek istediğiniz rengin tam adını yazın (Aşağıdaki gibi):");
                                        Console.WriteLine("( sarı / kırmızı / mavi )");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("Lütfen değiştirmek istediğiniz rengi seçin: ");
                                        istrenk = Console.ReadLine();
                                        Console.WriteLine("Artık oyunun rengi {0}", istrenk);
                                        ortadaharf = istrenk.Substring(0, 1);
                                        ortadasayi = "0";
                                        ber1 = 0;
                                        break;
                                    }
                                }
                            }

                            cevapp = "";
                            kart.oyuncu1[sabitle] = "yok";
                            break;
                        }

                        else
                        {
                            if ((ortadaharf != kart.oyuncu1[sabitle].Substring(0, 1) && ortadasayi != kart.oyuncu1[sabitle].Substring(1)))
                            {
                                
                                
                                int es = 0;
                                
                                for (int aa = 0; aa < 6; aa++)
                                {
                                    if ((ortadaharf == kart.oyuncu1[aa].Substring(0, 1) || ortadasayi == kart.oyuncu1[aa].Substring(1)))
                                    {
                                        Console.WriteLine("Yerdeki karta uygun kartı atmalısınız. Lütfen kontrol edin.");
                                        Console.WriteLine("Elinizde yerdeki karta uygun bir kart bulunmakta.");
                                        Console.WriteLine("Lütfen farklı bir kart seçin: ");
                                        cevap = Console.ReadLine();
                                        
                                        
                                        es = 0;
                                        ber1 = 0;
                                        break;
                                    }

                                    if ((ortadaharf != kart.oyuncu1[aa].Substring(0, 1) && ortadasayi != kart.oyuncu1[aa].Substring(1)) && kart.oyuncu1[aa] != "rd")
                                    {
                                        es++;
                                    }

                                    if (es == 6)
                                    {
                                        Console.WriteLine("Elinizde atacağınız uygun kart kalmadığından sıra diğer oyuncuya geçiyor.");
                                        Console.WriteLine("1.Oyuncu PAS diyor.");
                                        es = 0;
                                        
                                        pas = 1;
                                        ber1 = 1;
                                        i = 10;

                                        break;
                                    }
                                }
                                if (es == 5 || es == 4 || es == 3)
                                {
                                    Console.WriteLine("Yerdeki karta uygun kartı atmalısınız. Lütfen kontrol edin.");
                                    Console.WriteLine("Elinizdeki renk değiştir (rd) kartınızı kullanabilirsiniz");
                                    Console.WriteLine("Lütfen farklı bir kart seçin: ");
                                    cevap = Console.ReadLine();
                                    ber1 = 0;
                                }

                                es = 0;
                            }

                            else if (cevap == "yok" || cevapp == "")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Sahip olmadığınız bir kartı atamazsınız.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Lütfen farklı bir kart seçin");
                                cevap = Console.ReadLine();

                                continue;
                            }
                        }
                    }
                }

                //Oyunun berabere sonlanmasının sağlanması

                if (ber1 == 1 && ber2 == 1 && ber3 == 1)
                {
                    Console.Beep(2500, 1000);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\nBir turda üç oyuncu da PAS dediğinden:");
                    Console.WriteLine("\nOyun Berabere Sona Eriyor.");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                }
            }
        }
    }
}
