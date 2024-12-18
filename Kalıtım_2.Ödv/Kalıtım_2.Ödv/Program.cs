using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtım_2.Ödv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçiniz: 1- Memeli, 2- Kuş");
            int secim = int.Parse(Console.ReadLine());

            Hayvan hayvan;

            if (secim == 1)
            {
                hayvan = new memeli();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = Console.ReadLine();
                Console.Write("Tüy Rengi: ");
                ((memeli)hayvan).TuyRengi = Console.ReadLine();
            }
            else if (secim == 2)
            {
                hayvan = new kus();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = Console.ReadLine();
                Console.Write("Kanat Genişliği: ");
                ((kus)hayvan).KanatGenisligi = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Hatalı seçim yaptınız. Program sonlandırılıyor.");
                return;
            }

            Console.WriteLine("\nHayvan Bilgileri ve Ses Çıkarma Durumu:");
            hayvan.SesCikar();
        }

    }
    
    class Hayvan
    {
        public string Ad {get;set;}
        public string Tur { get; set; }
        public string Yas { get; set; }
        public void SesCikar()
        {
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Tur: {Tur}");
            Console.WriteLine($"Yas: {Yas} TL");
           
        }

    }
    class memeli : Hayvan
    {
    public string TuyRengi { get; set; }
        public void SesCikar()
        {
            base.SesCikar();
            Console.WriteLine($"Tüy Rengi: {TuyRengi}");
        Console.WriteLine($"MÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖ");
    }
    }




    class kus : Hayvan
    {
    public string KanatGenisligi { get; set; }
        public override void SesCikar()
        {
            base.SesCikar();
            Console.WriteLine($"Kanat Genişliği: {KanatGenisligi}");
            Console.WriteLine($"Ses: GAK GAKKKKKKKKKKKKKKKKKKK");
        }
    }
}
