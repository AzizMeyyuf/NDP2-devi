using Proje3;

namespace proje3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== PROJE 3: Yigin (Stack Alternatifi) Testi =====");

            Yigin yigin = new Yigin();

            // 1. Doldur Testi
            Console.WriteLine("\n-- 1. Doldur (Push) Testi --");
            yigin.Doldur(10);
            yigin.Doldur(20);
            yigin.Doldur(30);
            yigin.Doldur(40);
            yigin.Doldur(50); // Kapasite artışını tetikler

            Console.WriteLine("Eleman sayısı: " + yigin.ElemanSayisi);
            Yazdir(yigin);

            // 2. Bak Testi
            Console.WriteLine("\n-- 2. Bak (Peek) Testi --");
            Console.WriteLine("Yığının tepesindeki eleman: " + yigin.Bak());
            Console.WriteLine("Eleman sayısı değişmedi: " + yigin.ElemanSayisi);

            // 3. Cek Testi
            Console.WriteLine("\n-- 3. Cek (Pop) Testi --");
            Console.WriteLine("Çekilen eleman: " + yigin.Cek());
            Console.WriteLine("Çekilen eleman: " + yigin.Cek());
            Console.WriteLine("Kalan eleman sayısı: " + yigin.ElemanSayisi);
            Yazdir(yigin);

            // 4. Diziye Testi
            Console.WriteLine("\n-- 4. Diziye (ToArray) Testi --");
            object[] dizi = yigin.Diziye();
            Console.Write("Diziye aktarılan elemanlar: ");
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write(dizi[i] + " ");
            }
            Console.WriteLine();

            // 5. Temizle Testi
            Console.WriteLine("\n-- 5. Temizle Testi --");
            yigin.Temizle();
            Console.WriteLine("Temizlendikten sonra Eleman Sayisi: " + yigin.ElemanSayisi);

            Console.WriteLine("\nTest başarıyla tamamlandı!");
        }

        static void Yazdir(Yigin yigin)
        {
            Console.Write("Yığın içeriği (Tepeden tabana): ");
            foreach (object eleman in yigin)
            {
                Console.Write(eleman + " ");
            }
            Console.WriteLine();
        }
    }
}
