using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim_3.Ödv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçiniz (1: Vadesiz Hesap, 2: Vadeli Hesap):");
            int secim = int.Parse(Console.ReadLine());

            Hesap hesap;

            if (secim == 1)
            {
                hesap = new VadesizHesap();
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Başlangıç Bakiyesi: ");
                hesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                ((VadesizHesap)hesap).EkHesapLimiti = decimal.Parse(Console.ReadLine());
            }
            else if (secim == 2)
            {
                hesap = new VadeliHesap();
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Başlangıç Bakiyesi: ");
                hesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Vade Süresi (gün): ");
                ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı (%): ");
                ((VadeliHesap)hesap).FaizOrani = decimal.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nYapmak istediğiniz işlemi seçiniz:");
                Console.WriteLine("1. Para Yatır");
                Console.WriteLine("2. Para Çek");
                Console.WriteLine("3. Hesap Bilgilerini Yazdır");
                Console.WriteLine("4. Çıkış");

                int islem = int.Parse(Console.ReadLine());

                switch (islem)
                {
                    case 1:
                        Console.Write("Yatırmak istediğiniz tutar: ");
                        decimal yatirilanTutar = decimal.Parse(Console.ReadLine());
                        hesap.ParaYatir(yatirilanTutar);
                        break;
                    case 2:
                        Console.Write("Çekmek istediğiniz tutar: ");
                        decimal cekilenTutar = decimal.Parse(Console.ReadLine());
                        hesap.ParaCek(cekilenTutar);
                        break;
                    case 3:
                        hesap.BilgiYazdir();
                        break;
                    case 4:
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz işlem!");
                        break;
                }
            }
        }
    }

    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL hesaba yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL hesaptan çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap Numarası: {HesapNumarasi}");
            Console.WriteLine($"Hesap Sahibi: {HesapSahibi}");
            Console.WriteLine($"Bakiye: {Bakiye} TL");
        }
    }

    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye + EkHesapLimiti >= miktar)
            {
                decimal kullanilanLimit = 0;
                if (Bakiye < miktar)
                {
                    kullanilanLimit = miktar - Bakiye;
                    Bakiye = 0;
                }
                else
                {
                    Bakiye -= miktar;
                }

                EkHesapLimiti -= kullanilanLimit;
                Console.WriteLine($"{miktar} TL çekildi. Kalan bakiye: {Bakiye} TL, Kalan Ek Hesap Limiti: {EkHesapLimiti} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
        }
    }

    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public decimal FaizOrani { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (VadeSuresi > 0)
            {
                Console.WriteLine("Vade dolmadan para çekemezsiniz!");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} gün");
            Console.WriteLine($"Faiz Oranı: %{FaizOrani}");
        }

        public override void ParaYatir(decimal miktar)
        {
            base.ParaYatir(miktar);
            Console.WriteLine("Vadeli hesaba para yatırıldı.");
        }
    }
}