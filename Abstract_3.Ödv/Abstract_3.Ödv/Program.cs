using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_3.Ödv
{
    // IYayinci arayüzü
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void AbonelereBildirimGonder(string mesaj);
    }

    // IAbone arayüzü
    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    // Yayinci sınıfı
    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();

        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
            Console.WriteLine("Yeni abone eklendi.");
        }

        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
            Console.WriteLine("Bir abone çıkarıldı.");
        }

        public void AbonelereBildirimGonder(string mesaj)
        {
            Console.WriteLine("\nYayıncı yeni bir bildirim gönderiyor: " + mesaj);
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    // Abone sınıfı
    public class Abone : IAbone
    {
        private string isim;

        public Abone(string isim)
        {
            this.isim = isim;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{isim} bildirim aldı: {mesaj}");
        }
    }

    // Test için Program sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            // Yayıncıyı oluştur
            Yayinci yayinci = new Yayinci();

            // Aboneleri oluştur ve ekle
            IAbone abone1 = new Abone("Abone 1");
            IAbone abone2 = new Abone("Abone 2");
            IAbone abone3 = new Abone("Abone 3");

            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            // Yayıncı bir değişiklik yapıyor
            yayinci.AbonelereBildirimGonder("Yeni makale yayımlandı!");

            // Bir abone çıkarılıyor
            yayinci.AboneCikar(abone2);

            // Yayıncı bir başka değişiklik yapıyor
            yayinci.AbonelereBildirimGonder("Yeni video yüklendi!");

            // Programı bekletmek için
            Console.ReadLine();
        }
    }
}