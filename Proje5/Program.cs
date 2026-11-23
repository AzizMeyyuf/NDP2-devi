namespace Proje5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== PROJE 5: SiraliListe (SortedList Alternatifi) Testi =====");

            SiraliListe siraliListe = new SiraliListe();

            // 1. Karışık Sırada Ekleme Testi (Otomatik sıralandığını göreceğiz)
            Console.WriteLine("\n-- 1. Ekle Testi (Karışık anahtarlar ile ekleme) --");
            siraliListe.Ekle(30, "Otuz");
            siraliListe.Ekle(10, "On");
            siraliListe.Ekle(50, "Elli");
            siraliListe.Ekle(20, "Yirmi");
            siraliListe.Ekle(40, "Kirk");

            Console.WriteLine("Eleman Sayisi: " + siraliListe.ElemanSayisi);
            Yazdir(siraliListe);

            // 2. HashUret Testi
            Console.WriteLine("\n-- 2. HashUret Testi --");
            Console.WriteLine("30 anahtarı için Hash: " + siraliListe.HashUret(30));
            Console.WriteLine("10 anahtarı için Hash: " + siraliListe.HashUret(10));

            // 3. Anahtarlar ve Degerler Dizileri
            Console.WriteLine("\n-- 3. Anahtarlar ve Degerler Özellikleri --");
            Console.Write("Anahtarlar: ");
            foreach (object k in siraliListe.Anahtarlar)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();

            Console.Write("Değerler: ");
            foreach (object v in siraliListe.Degerler)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();

            // 4. Silme Testleri (Overloaded: Indeks ve Anahtar)
            Console.WriteLine("\n-- 4. Silme Testleri (Aşırı yüklenmiş Sil) --");
            Console.WriteLine("İndeks 0 siliniyor (En küçük eleman)...");
            siraliListe.Sil(0); // RemoveAt
            Yazdir(siraliListe);

            Console.WriteLine("Anahtarı 40 olan eleman siliniyor...");
            siraliListe.Sil((object)40); // Remove
            Yazdir(siraliListe);

            // 5. Temizle Testi
            Console.WriteLine("\n-- 5. Temizle Testi --");
            siraliListe.Temizle();
            Console.WriteLine("Temizlendikten sonra Eleman Sayisi: " + siraliListe.ElemanSayisi);

            Console.WriteLine("\nTest başarıyla tamamlandı!");
        }

        static void Yazdir(SiraliListe liste)
        {
            Console.Write("Sıralı Liste içeriği (foreach ile): ");
            foreach (object o in liste)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }
    }
}
