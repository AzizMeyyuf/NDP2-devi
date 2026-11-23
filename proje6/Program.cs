using Proje6;

namespace proje6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== PROJE 6: Generik Liste<T> (List<T> Alternatifi) Testi =====");

            // 1. String türü ile Genel Test (Aşırı yüklenmiş metotların tam testi)
            Console.WriteLine("\n--- 1. String Türü ile Test (Liste<string>) ---");
            Liste<string> sehirler = new Liste<string>();

            // Sona Ekleme (Ekle 1. Aşırı Yükleme - Add)
            sehirler.Ekle("İstanbul");
            sehirler.Ekle("Ankara");
            sehirler.Ekle("İzmir");
            sehirler.Ekle("Bursa");
            Console.WriteLine("Şehirler eklendi. Eleman Sayısı: " + sehirler.ElemanSayisi);
            YazdirString(sehirler);

            // Araya Ekleme (Ekle 2. Aşırı Yükleme - Insert)
            Console.WriteLine("\n-- Araya Ekleme (İndeks 1'e 'Antalya' ekle) --");
            sehirler.Ekle(1, "Antalya");
            YazdirString(sehirler);

            // Endeksleyici Testi
            Console.WriteLine("\n-- Endeksleyici Testi --");
            Console.WriteLine("sehirler[0]: " + sehirler[0]);
            sehirler[2] = "Eskişehir";
            Console.WriteLine("sehirler[2] = 'Eskişehir' yapıldı.");
            YazdirString(sehirler);

            // Bul ve VarMi Testi
            Console.WriteLine("\n-- Bul ve VarMi Testi --");
            Console.WriteLine("'Antalya' var mı? " + sehirler.VarMi("Antalya"));
            Console.WriteLine("'Antalya' indeksi: " + sehirler.Bul("Antalya"));
            Console.WriteLine("'Trabzon' var mı? " + sehirler.VarMi("Trabzon"));

            // Aşırı Yüklenmiş Silme Metotları
            Console.WriteLine("\n-- Silme Testleri (Overloaded Sil) --");
            Console.WriteLine("İndeks 1'deki eleman siliniyor (RemoveAt yerine)...");
            sehirler.Sil(1); // Sil(int indeks) çağrılır
            YazdirString(sehirler);

            Console.WriteLine("'Bursa' değeri siliniyor (Remove yerine)...");
            sehirler.Sil("Bursa"); // Sil(T eleman) çağrılır
            YazdirString(sehirler);

            // Sıralama (Bubble Sort)
            Console.WriteLine("\n-- Sirala Testi --");
            sehirler.Sirala();
            YazdirString(sehirler);

            // Terse Çevirme
            Console.WriteLine("\n-- TerCevir Testi --");
            sehirler.TerCevir();
            YazdirString(sehirler);

            // Temizle
            Console.WriteLine("\n-- Temizle Testi --");
            sehirler.Temizle();
            Console.WriteLine("Temizlendikten sonra Eleman Sayisi: " + sehirler.ElemanSayisi);


            // 2. Sayısal Tür ile Test (Liste<int>)
            Console.WriteLine("\n\n--- 2. Sayısal Tür ile Test (Liste<int>) ---");
            Liste<int> sayilar = new Liste<int>();
            sayilar.Ekle(45);
            sayilar.Ekle(12);
            sayilar.Ekle(89);
            sayilar.Ekle(23);
            sayilar.Ekle(67);

            Console.Write("Sayılar listesi: ");
            YazdirInt(sayilar);

            Console.WriteLine("Sayılar sıralanıyor...");
            sayilar.Sirala();
            YazdirInt(sayilar);

            Console.WriteLine("Sayılar ters çevriliyor...");
            sayilar.TerCevir();
            YazdirInt(sayilar);

            Console.WriteLine("İndeks 0 siliniyor...");
            sayilar.Sil(0);
            YazdirInt(sayilar);

            Console.WriteLine("\nTest başarıyla tamamlandı!");
        }

        static void YazdirString(Liste<string> liste)
        {
            Console.Write("Liste içeriği (foreach ile): ");
            foreach (string eleman in liste)
            {
                Console.Write(eleman + " ");
            }
            Console.WriteLine();
        }

        static void YazdirInt(Liste<int> liste)
        {
            foreach (int eleman in liste)
            {
                Console.Write(eleman + " ");
            }
            Console.WriteLine();
        }
    }
}
