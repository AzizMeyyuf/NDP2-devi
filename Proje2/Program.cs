using Proje2;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== PROJE 2: Kuyruk (Queue Alternatifi) Testi =====");

            Kuyruk kuyruk = new Kuyruk();

            // 1. Kuyruğa Eleman Ekleme (KuyrugaGir)
            Console.WriteLine("\n-- 1. KuyrugaGir Testi --");
            kuyruk.KuyrugaGir("Ali");
            kuyruk.KuyrugaGir("Ayşe");
            kuyruk.KuyrugaGir("Mehmet");
            kuyruk.KuyrugaGir("Fatma");
            kuyruk.KuyrugaGir("Zeynep"); // Kapasite artışını da test eder

            Console.WriteLine("Eleman sayısı: " + kuyruk.ElemanSayisi);
            Yazdir(kuyruk);

            // 2. Kuyruğun Başına Bakma (Bak)
            Console.WriteLine("\n-- 2. Bak (Peek) Testi --");
            Console.WriteLine("Kuyruğun başındaki eleman: " + kuyruk.Bak());
            Console.WriteLine("Eleman sayısı değişmedi: " + kuyruk.ElemanSayisi);

            // 3. Kuyruktan Eleman Çıkarma (KuyruktanCik)
            Console.WriteLine("\n-- 3. KuyruktanCik (Dequeue) Testi --");
            Console.WriteLine("Çıkarılan eleman: " + kuyruk.KuyruktanCik());
            Console.WriteLine("Çıkarılan eleman: " + kuyruk.KuyruktanCik());
            Console.WriteLine("Kalan eleman sayısı: " + kuyruk.ElemanSayisi);
            Yazdir(kuyruk);

            // 4. Diziye Aktarma Testi (Diziye)
            Console.WriteLine("\n-- 4. Diziye (ToArray) Testi --");
            object[] dizi = kuyruk.Diziye();
            Console.Write("Diziye aktarılan elemanlar: ");
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write(dizi[i] + " ");
            }
            Console.WriteLine();

            // 5. Temizleme Testi (Temizle)
            Console.WriteLine("\n-- 5. Temizle Testi --");
            kuyruk.Temizle();
            Console.WriteLine("Temizlendikten sonra Eleman Sayisi: " + kuyruk.ElemanSayisi);

            Console.WriteLine("\nTest başarıyla tamamlandı!");
        }

        static void Yazdir(Kuyruk kuyruk)
        {
            Console.Write("Kuyruk içeriği (foreach ile): ");
            foreach (object eleman in kuyruk)
            {
                Console.Write(eleman + " -> ");
            }
            Console.WriteLine("SON");
        }
    }
}
