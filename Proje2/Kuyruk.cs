using System;
using System.Collections;

namespace Proje2
{
    public class Kuyruk
    {
        private object[] elemanlar;
        private int on;          
        private int arka;       
        private int elemanSayisi; 

        public int ElemanSayisi
        {
            get { return elemanSayisi; }
        }

      
        public Kuyruk()
        {
            elemanlar = new object[4];
            on = 0;
            arka = -1;
            elemanSayisi = 0;
        }

        public Kuyruk(int baslangicKapasitesi)
        {
            if (baslangicKapasitesi < 1)
                baslangicKapasitesi = 4;

            elemanlar = new object[baslangicKapasitesi];
            on = 0;
            arka = -1;
            elemanSayisi = 0;
        }

        private void KapasiteGerekiyorsaArtir()
        {
            if (elemanSayisi == elemanlar.Length)
            {
                object[] yeniDizi = new object[elemanlar.Length * 2];
                for (int i = 0; i < elemanSayisi; i++)
                {
                    yeniDizi[i] = elemanlar[(on + i) % elemanlar.Length];
                }
                elemanlar = yeniDizi;
                on = 0;
                arka = elemanSayisi - 1;
            }
        }

        public void KuyrugaGir(object eleman)
        {
            KapasiteGerekiyorsaArtir();

            arka = (arka + 1) % elemanlar.Length;
            elemanlar[arka] = eleman;
            elemanSayisi++;
        }

        public object KuyruktanCik()
        {
            if (elemanSayisi == 0)
            {
                throw new InvalidOperationException("Kuyrukta hiç eleman yok!");
            }

            object cikarilan = elemanlar[on];
            elemanlar[on] = null; 
            on = (on + 1) % elemanlar.Length;
            elemanSayisi--;

            return cikarilan;
        }

        public object Bak()
        {
            if (elemanSayisi == 0)
            {
                throw new InvalidOperationException("Kuyruk boş!");
            }

            return elemanlar[on];
        }

        public void Temizle()
        {
            elemanlar = new object[4];
            on = 0;
            arka = -1;
            elemanSayisi = 0;
        }

        public object[] Diziye()
        {
            object[] sonucDizisi = new object[elemanSayisi];
            for (int i = 0; i < elemanSayisi; i++)
            {
                sonucDizisi[i] = elemanlar[(on + i) % elemanlar.Length];
            }
            return sonucDizisi;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                yield return elemanlar[(on + i) % elemanlar.Length];
            }
        }
    }
}
