using System;
using System.Collections;

namespace Proje3
{
    public class Yigin 
    {
        private object[] elemanlar;
        private int tepe; 

       
        public int ElemanSayisi
        {
            get { return tepe + 1; }
        }

        public Yigin()
        {
            elemanlar = new object[4];
            tepe = -1;
        }

        public Yigin(int baslangicKapasitesi)
        {
            if (baslangicKapasitesi < 1)
                baslangicKapasitesi = 4;

            elemanlar = new object[baslangicKapasitesi];
            tepe = -1;
        }

       
        private void KapasiteGerekiyorsaArtir()
        {
            if (tepe == elemanlar.Length - 1)
            {
                object[] yeniDizi = new object[elemanlar.Length * 2];
                for (int i = 0; i <= tepe; i++)
                {
                    yeniDizi[i] = elemanlar[i];
                }
                elemanlar = yeniDizi;
            }
        }

        public void Doldur(object eleman)
        {
            KapasiteGerekiyorsaArtir();
            tepe++;
            elemanlar[tepe] = eleman;
        }

        public object Cek()
        {
            if (tepe == -1)
            {
                throw new InvalidOperationException("Yığın boş, eleman çekilemez!");
            }

            object cikarilan = elemanlar[tepe];
            elemanlar[tepe] = null; 
            tepe--;
            return cikarilan;
        }

        public object Bak()
        {
            if (tepe == -1)
            {
                throw new InvalidOperationException("Yığın boş!");
            }

            return elemanlar[tepe];
        }

        public void Temizle()
        {
            elemanlar = new object[4];
            tepe = -1;
        }

        public object[] Diziye()
        {
            int sayi = ElemanSayisi;
            object[] sonuc = new object[sayi];

            for (int i = 0; i < sayi; i++)
            {
                sonuc[i] = elemanlar[tepe - i];
            }

            return sonuc;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = tepe; i >= 0; i--)
            {
                yield return elemanlar[i];
            }
        }
    }
}
