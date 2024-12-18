using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_1.Ödv
{
    public abstract class Hesap
    {
        // Hesap numarası
        public string HesapNo { get; set; }

        // Hesap bakiyesi
        public decimal Bakiye { get; set; }

        // Para yatırma işlemi
        public abstract void ParaYatir(decimal miktar);

        // Para çekme işlemi
        public abstract void ParaCek(decimal miktar);
    }

    // IBankaHesabi Arayüzü
    public interface IBankaHesabi
    {
        // Hesap açılış tarihi
        DateTime HesapAcilisTarihi { get; set; }

        // Hesap özeti görüntüleme
        void HesapOzeti();
    }

    // Birikim Hesabı Sınıfı
    public class BirikimHesabi : Hesap, IBankaHesabi
    {
        // Faiz oranı
        public decimal FaizOrani { get; set; }

        // Hesap açılış tarihi
        public DateTime HesapAcilisTarihi { get; set; }

        // Faizli para yatırma işlemi
        public override void ParaYatir(decimal miktar)
        {
            // Faiz hesaplaması
            Bakiye += miktar + (miktar * FaizOrani / 100);
        }

        // Para çekme işlemi
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        // Hesap özeti görüntüleme
        public void HesapOzeti()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Bakiye: {Bakiye:C}, Faiz Oranı: {FaizOrani}%");
            Console.WriteLine($"Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
        }
    }

    // Vadesiz Hesap Sınıfı
    public class VadesizHesap : Hesap, IBankaHesabi
    {
        // İşlem ücreti
        public decimal IslemUcreti { get; set; }

        // Hesap açılış tarihi
        public DateTime HesapAcilisTarihi { get; set; }

        // Para yatırma işlemi
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
        }

        // Para çekme işlemi
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar + IslemUcreti)
            {
                Bakiye -= (miktar + IslemUcreti);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        // Hesap özeti görüntüleme
        public void HesapOzeti()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Bakiye: {Bakiye:C}");
            Console.WriteLine($"İşlem Ücreti: {IslemUcreti:C}");
            Console.WriteLine($"Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
        }
    }

    // Program Sınıfı (Test için)
    class Program
    {
        static void Main()
        {
            // Birikim Hesabı oluşturuluyor
            BirikimHesabi birikimHesabi = new BirikimHesabi
            {
                HesapNo = "12345",
                Bakiye = 1000,
                FaizOrani = 5,  // %5 faiz oranı
                HesapAcilisTarihi = DateTime.Now
            };

            Console.WriteLine("Birikim Hesabı İşlem:");
            birikimHesabi.ParaYatir(500);  // 500 yatırıldı, faiz uygulanacak
            birikimHesabi.HesapOzeti();    // Hesap özeti yazdırılacak

            Console.WriteLine("\n------------------------------\n");

            // Vadesiz Hesap oluşturuluyor
            VadesizHesap vadesizHesap = new VadesizHesap
            {
                HesapNo = "67890",
                Bakiye = 2000,
                IslemUcreti = 10,  // 10 TL işlem ücreti
                HesapAcilisTarihi = DateTime.Now
            };

            Console.WriteLine("Vadesiz Hesap İşlem:");
            vadesizHesap.ParaCek(500);  // 500 çekilecek, 10 TL işlem ücreti eklenecek
            vadesizHesap.HesapOzeti();  // Hesap özeti yazdırılacak
        }
    }
}