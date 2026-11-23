namespace Proje4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== PROJE 4: HashTablo (HashTable Alternatifi) Testi =====");

            HashTablo tablo = new HashTablo();

            // 1. Ekleme ve HashUret Testi
            Console.WriteLine("\n-- 1. Ekle ve HashUret Testi --");
            tablo.Ekle("101", "Ahmet");
            tablo.Ekle("102", "Mehmet");
            tablo.Ekle("103", "Ayşe");
            tablo.Ekle("205", "Fatma");

            Console.WriteLine("'101' anahtarı için üretilen hash indisi: " + tablo.HashUret("101"));
            Console.WriteLine("'102' anahtarı için üretilen hash indisi: " + tablo.HashUret("102"));
            Console.WriteLine("Eleman Sayisi: " + tablo.ElemanSayisi);
            Yazdir(tablo);

            // 2. Anahtarlar ve Degerler Özellikleri Testi
            Console.WriteLine("\n-- 2. Anahtarlar ve Degerler Özellikleri --");
            Console.Write("Anahtarlar: ");
            foreach (object k in tablo.Anahtarlar)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();

            Console.Write("Değerler: ");
            foreach (object v in tablo.Degerler)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();

            // 3. Silme Testi
            Console.WriteLine("\n-- 3. Sil (Remove) Testi --");
            Console.WriteLine("'102' siliniyor...");
            tablo.Sil("102");
            Console.WriteLine("Kalan eleman sayısı: " + tablo.ElemanSayisi);
            Yazdir(tablo);

            // 4. Temizle Testi
            Console.WriteLine("\n-- 4. Temizle Testi --");
            tablo.Temizle();
            Console.WriteLine("Temizlendikten sonra Eleman Sayisi: " + tablo.ElemanSayisi);

            Console.WriteLine("\nTest başarıyla tamamlandı!");
        }

        static void Yazdir(HashTablo tablo)
        {
            Console.WriteLine("HashTablo içeriği (foreach ile):");
            foreach (object eleman in tablo)
            {
                Console.WriteLine("  " + eleman);
            }
        }
    }
}
