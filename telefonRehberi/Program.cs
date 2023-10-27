using System;
using System.Collections.Generic;

namespace telefonRehberi
{
    class Program
    {
        static List<Rehber> rehberListesi = new List<Rehber>();

        static void Main(string[] args)
        {
            Rehber user1 = new Rehber("User1Name", "User1Surname", "10000000000");
            Rehber user2 = new Rehber("User2Name", "User2Surname", "20000000000");
            Rehber user3 = new Rehber("User3Name", "User3Surname", "30000000000");
            Rehber user4 = new Rehber("User4Name", "User4Surname", "40000000000");
            Rehber user5 = new Rehber("User5Name", "User5Surname", "50000000000");
            rehberListesi.Add(user1);
            rehberListesi.Add(user2);
            rehberListesi.Add(user3);
            rehberListesi.Add(user4);
            rehberListesi.Add(user5);

            Islem();
        }
        static void Islem()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi aşağıdaki menüden seçiniz...");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listeleme");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(6) Uygulamadan Çıkış");

            int islemSecim = Convert.ToInt32(Console.ReadLine());
            switch (islemSecim)
            {
                case 1:
                    Kaydet();
                    break;
                case 2:
                    Sil();
                    break;
                case 3:
                    Guncelle();
                    break;
                case 4:
                    Listele();
                    break;
                case 5:
                    Ara();
                    break;
                case 6: Cikis();
                    break;
            }
        }

        static void Kaydet()
        {
            string ad;
            string soyad;
            string telno;
            Console.Write("Lütfen isim giriniz             :");
            ad = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz          :");
            soyad = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz :");
            telno = Console.ReadLine();
            rehberListesi.Add(new Rehber(ad, soyad, telno));
            Islem();
        }

        static void Sil()
        {
            Console.Write("Lütfen silmek istediğiniz kişinin adını veya soyadını giriniz: ");
            string adSoyad = Console.ReadLine();

            Rehber silinecekKisi = rehberListesi.FirstOrDefault(kisi =>
                kisi.Ad.Equals(adSoyad, StringComparison.OrdinalIgnoreCase) || kisi.Soyad.Equals(adSoyad, StringComparison.OrdinalIgnoreCase)); 
            /* rehberListesi.FirstOrDefault, rehberListesi'nde koşulu sağlayan ilk öğeyi bulur. kisi.Ad.Equals(adSoyad, StringComparison.OrdinalIgnoreCase), kişinin "Ad" özelliği ile "adSoyad" dizesini karşılaştırır. StringComparison.OrdinalIgnoreCase kullanılarak büyük/küçük harf duyarsız bir karşılaştırma gerçekleştirir.*/

            if (silinecekKisi != null)
            {
                Console.Write($"{adSoyad} adlı kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n): ");
                string onay = Console.ReadLine();

                if (onay.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    rehberListesi.Remove(silinecekKisi);
                    Console.WriteLine($"{adSoyad} adlı kişi rehberden silindi.");
                }
                else
                {
                    Console.WriteLine($"{adSoyad} adlı kişi rehberden silinmedi.");
                    Islem();
                }
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("Yeniden denemek için      : (2)");

                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("Silmeyi sonlandırdınız.");
                }
                else if (secim == "2")
                {
                    Islem();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, işlem sonlandırıldı.");
                }
            }
            Islem();
        }

        static void Guncelle()
        {
            Console.Write("Lütfen güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string adSoyad = Console.ReadLine();

            Rehber guncellenecekKisi = rehberListesi.FirstOrDefault(kisi =>
                kisi.Ad.Equals(adSoyad, StringComparison.OrdinalIgnoreCase) || kisi.Soyad.Equals(adSoyad, StringComparison.OrdinalIgnoreCase));

            if (guncellenecekKisi != null)
            {
                Console.WriteLine($"Arama sonuçları:");
                Console.WriteLine($"Ad: {guncellenecekKisi.Ad}");
                Console.WriteLine($"Soyad: {guncellenecekKisi.Soyad}");
                Console.WriteLine($"Telefon Numarası: {guncellenecekKisi.TelNo}");

                Console.Write("Yeni ad giriniz: ");
                string yeniAd = Console.ReadLine();
                Console.Write("Yeni soyad giriniz: ");
                string yeniSoyad = Console.ReadLine();
                Console.Write("Yeni telefon numarası giriniz: ");
                string yeniTelNo = Console.ReadLine();

                guncellenecekKisi.Ad = yeniAd;
                guncellenecekKisi.Soyad = yeniSoyad;
                guncellenecekKisi.TelNo = yeniTelNo;

                Console.WriteLine("Kişi güncellendi.");
                Islem();
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine("Yeniden denemek için           : (2)");

                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("İşlemi sonlandırdınız.");
                    
                }
                else if (secim == "2")
                {
                    Guncelle();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, işlem sonlandırıldı.");
                    Islem();
                }
            }
        }


        static void Listele()
        {
            Console.WriteLine("Rehber Listesi:");
            foreach (var rehber in rehberListesi)
            {
                Console.WriteLine("İsim: {0}", rehber.Ad);
                Console.WriteLine("Soyisim: {0}", rehber.Soyad);
                Console.WriteLine("Telefon Numarası: {0}", rehber.TelNo);
            }
            Islem();
        }


        static void Ara()
        {
            Console.Write("Lütfen aramak istediğiniz kişinin telefon numarasını giriniz: ");
            string telno = Console.ReadLine();

            Rehber arananKisi = rehberListesi.FirstOrDefault(kisi =>
                kisi.TelNo.Equals(telno, StringComparison.OrdinalIgnoreCase));

            if (arananKisi != null)
            {
                Console.WriteLine($"Arama sonuçları:");
                Console.WriteLine($"Ad: {arananKisi.Ad}");
                Console.WriteLine($"Soyad: {arananKisi.Soyad}");
                Console.WriteLine($"Telefon Numarası: {arananKisi.TelNo}");
                Islem();
            }
            else {
                Console.WriteLine("Bu telefon numarasına sahip biri rehberinizde kayıtlı değil.");
                Islem();
            }
        }

        static void Cikis()
        {
            
            Console.WriteLine("Uygulamadan çıkmak istediğinize emin misiniz?");
            Console.WriteLine("Evet (1)");
            Console.WriteLine("Hayır (2)");
            string input = Console.ReadLine();

            if(input=="1")
            {

            }
            else if(input=="2") {
                Islem();
            }
            else
            {
                Console.WriteLine("Doğru bir giriş yapınız.");
                Islem() ;
            }
           


        }
    }

 
}
