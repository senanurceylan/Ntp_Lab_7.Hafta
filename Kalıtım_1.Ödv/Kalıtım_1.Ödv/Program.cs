using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtım_1.Ödv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçiniz: 1- Yazılımcı, 2- Muhasebeci");
            int secim = int.Parse(Console.ReadLine());

            Calisan calisan;

            if (secim == 1)
            {
                calisan = new Yazilimci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = int.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();
                Console.Write("Yazılım Dili: ");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine();
            }
            else if (secim == 2)
            {
                calisan = new Muhasebeci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = int.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();
                Console.Write("Kullandığı Muhasebe Yazılımı: ");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Hatalı seçim yaptınız. Program sonlandırılıyor.");
                return;
            }

            // Çalışan bilgilerini yazdır
            Console.WriteLine("\nÇalışan Bilgileri:");
            calisan.BilgiYazdir();
        }
    }

    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Maas { get; set; }
        public string Pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Soyad: {Soyad}");
            Console.WriteLine($"Maaş: {Maas} TL");
            Console.WriteLine($"Pozisyon: {Pozisyon}");
        }
    }

    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Temel sınıfın BilgiYazdir metodunu çağır
            Console.WriteLine($"Yazılım Dili: {YazilimDili}");
        }
    }

    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Temel sınıfın BilgiYazdir metodunu çağır
            Console.WriteLine($"Kullandığı Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }
}