using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_2.Ödv
{
    public abstract class Urun
    {
        // Ürün adı
        public string Ad { get; set; }

        // Ürün fiyatı
        public decimal Fiyat { get; set; }

        // Ödeme hesaplama metodu (soyut)
        public abstract decimal HesaplaOdeme();

        // Ürün bilgilerini yazdıran metot
        public abstract void BilgiYazdir();
    }

    // Kitap sınıfı (Urun sınıfından türemektedir)
    public class Kitap : Urun
    {
        // Kitapla ilgili özel özellikler (örneğin yazar adı)
        public string Yazar { get; set; }

        // Ödeme hesaplaması (kitaplar için %10 vergi)
        public override decimal HesaplaOdeme()
        {
            decimal vergi = Fiyat * 0.10m; // %10 vergi
            return Fiyat + vergi;
        }

        // Kitap bilgilerini yazdıran metot
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Kitap Adı: {Ad}");
            Console.WriteLine($"Yazar: {Yazar}");
            Console.WriteLine($"Fiyat: {Fiyat:C}");
            Console.WriteLine($"Ödenecek Tutar (Vergi dahil): {HesaplaOdeme():C}\n");
        }
    }

    // Elektronik sınıfı (Urun sınıfından türemektedir)
    public class Elektronik : Urun
    {
        // Elektronik ürünle ilgili özellikler (örneğin garanti süresi)
        public int GarantiSuresi { get; set; }

        // Ödeme hesaplaması (elektronik ürünler için %25 vergi)
        public override decimal HesaplaOdeme()
        {
            decimal vergi = Fiyat * 0.25m; // %25 vergi
            return Fiyat + vergi;
        }

        // Elektronik ürün bilgilerini yazdıran metot
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad}");
            Console.WriteLine($"Garanti Süresi: {GarantiSuresi} yıl");
            Console.WriteLine($"Fiyat: {Fiyat:C}");
            Console.WriteLine($"Ödenecek Tutar (Vergi dahil): {HesaplaOdeme():C}\n");
        }
    }

    // Program sınıfı
    class Program
    {
        static void Main()
        {
            // Ürünlerin saklanacağı bir liste oluşturuyoruz
            List<Urun> urunler = new List<Urun>();

            // Kitap oluşturuluyor ve listeye ekleniyor
            Kitap kitap1 = new Kitap
            {
                Ad = "C# Programlama",
                Fiyat = 100m,
                Yazar = "Ahmet Yılmaz"
            };
            urunler.Add(kitap1);

            // Elektronik ürün oluşturuluyor ve listeye ekleniyor
            Elektronik elektronik1 = new Elektronik
            {
                Ad = "Laptop",
                Fiyat = 3000m,
                GarantiSuresi = 2
            };
            urunler.Add(elektronik1);

            // Ürün bilgilerini ve ödeme hesaplamalarını ekrana yazdırıyoruz
            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
            }
        }
    }
}