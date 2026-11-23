using Proje1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== PROJE 1: DiziListe (ArrayList Alternatifi) Testi =====");

            DiziListe liste = new DiziListe();

            Console.WriteLine("\n-- 1. Sona Ekleme Testi --");
            liste.SonaEkle(40);
            liste.SonaEkle(10);
            liste.SonaEkle(30);
            liste.SonaEkle(20);
           // liste.SonaEkle("Aziz");
            Console.WriteLine("Elemanlar eklendi. Eleman Sayisi: " + liste.ElemanSayisi);
            Yazdir(liste);

            Console.WriteLine("\n-- 2. Araya Ekleme Testi (İndeks 1'e 50 ekle) --");
            liste.ArayaEkle(1, 50);
            Yazdir(liste);


            Console.WriteLine("\n-- 3. Endeksleyici Testi --");
            Console.WriteLine("liste[0]: " + liste[0]);
            Console.WriteLine("liste[2]: " + liste[2]);
            liste[2] = 99;
            Console.WriteLine("liste[2] = 99 yapıldı.");
            Yazdir(liste);

            Console.WriteLine("\n-- 4. Bul ve VarMi Testi --");
            Console.WriteLine("50 var mi? " + liste.VarMi(50));
            Console.WriteLine("50'nin indeksi: " + liste.Bul(50));
            Console.WriteLine("100 var mi? " + liste.VarMi(100));
            Console.WriteLine("100'un indeksi: " + liste.Bul(100));

            Console.WriteLine("\n-- 5. Silme Testleri --");
            Console.WriteLine("İndeks 1'deki eleman siliniyor...");
            liste.Sil(1);
            Yazdir(liste);

            Console.WriteLine("Degeri 99 olan eleman siliniyor...");
            liste.Sil((object)99);
            Yazdir(liste);


            Console.WriteLine("\n-- 6. Siralama Testi (Sirala) --");
            liste.Sirala();
            Yazdir(liste);


            Console.WriteLine("\n-- 7. Terse Cevirme Testi (TerCevir) --");
            liste.TerCevir();
            Yazdir(liste);


            Console.WriteLine("\n-- 8. Temizle Testi --");
            liste.Temizle();
            Console.WriteLine("Temizlendikten sonra Eleman Sayisi: " + liste.ElemanSayisi);

            Console.WriteLine("\nTest tamamlandı. Çıkmak için bir tuşa basınız...");
        }

        static void Yazdir(DiziListe liste)
        {
            Console.Write("Liste içeriği (foreach ile): ");
            foreach (object o in liste)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }
    }
}
