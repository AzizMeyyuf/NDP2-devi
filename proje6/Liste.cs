using System;
using System.Collections;
using System.Collections.Generic;

namespace Proje6
{
    public class Liste<T> 
    {
        private T[] elemanlar;
        private int elemanSayisi;

        public int ElemanSayisi
        {
            get { return elemanSayisi; }
        }

        public int Kapasite
        {
            get { return elemanlar.Length; }
        }

        public Liste()
        {
            elemanlar = new T[4];
            elemanSayisi = 0;
        }

        public Liste(int baslangicKapasitesi)
        {
            if (baslangicKapasitesi < 1)
                baslangicKapasitesi = 4;

            elemanlar = new T[baslangicKapasitesi];
            elemanSayisi = 0;
        }

        private void KapasiteGerekiyorsaArtir()
        {
            if (elemanSayisi == elemanlar.Length)
            {
                T[] yeniDizi = new T[elemanlar.Length * 2];
                for (int i = 0; i < elemanSayisi; i++)
                {
                    yeniDizi[i] = elemanlar[i];
                }
                elemanlar = yeniDizi;
            }
        }

        public void Ekle(T eleman)
        {
            KapasiteGerekiyorsaArtir();
            elemanlar[elemanSayisi] = eleman;
            elemanSayisi++;
        }

        public void Ekle(int indeks, T eleman)
        {
            if (indeks < 0 || indeks > elemanSayisi)
            {
                throw new IndexOutOfRangeException("Geçersiz indeks değeri!");
            }

            KapasiteGerekiyorsaArtir();

            for (int i = elemanSayisi; i > indeks; i--)
            {
                elemanlar[i] = elemanlar[i - 1];
            }

            elemanlar[indeks] = eleman;
            elemanSayisi++;
        }

        public void Sil(int indeks)
        {
            if (indeks < 0 || indeks >= elemanSayisi)
            {
                throw new IndexOutOfRangeException("Silinecek indeks aralık dışında!");
            }

            for (int i = indeks; i < elemanSayisi - 1; i++)
            {
                elemanlar[i] = elemanlar[i + 1];
            }

            elemanlar[elemanSayisi - 1] = default(T);
            elemanSayisi--;
        }

        public bool Sil(T eleman)
        {
            int bulunanIndeks = Bul(eleman);
            if (bulunanIndeks != -1)
            {
                Sil(bulunanIndeks);
                return true;
            }
            return false;
        }

        public bool VarMi(T eleman)
        {
            return Bul(eleman) != -1;
        }

        public int Bul(T eleman)
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                if (EqualityComparer<T>.Default.Equals(elemanlar[i], eleman))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Temizle()
        {
            elemanlar = new T[4];
            elemanSayisi = 0;
        }

        public void Sirala()
        {
            for (int i = 0; i < elemanSayisi - 1; i++)
            {
                for (int j = 0; j < elemanSayisi - i - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(elemanlar[j], elemanlar[j + 1]) > 0)
                    {
                        T gecici = elemanlar[j];
                        elemanlar[j] = elemanlar[j + 1];
                        elemanlar[j + 1] = gecici;
                    }
                }
            }
        }

        public void TerCevir()
        {
            int baslangic = 0;
            int bitis = elemanSayisi - 1;

            while (baslangic < bitis)
            {
                T gecici = elemanlar[baslangic];
                elemanlar[baslangic] = elemanlar[bitis];
                elemanlar[bitis] = gecici;

                baslangic++;
                bitis--;
            }
        }

        public T this[int indeks]
        {
            get
            {
                if (indeks < 0 || indeks >= elemanSayisi)
                    throw new IndexOutOfRangeException("Geçersiz indeks!");
                return elemanlar[indeks];
            }
            set
            {
                if (indeks < 0 || indeks >= elemanSayisi)
                    throw new IndexOutOfRangeException("Geçersiz indeks!");
                elemanlar[indeks] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                yield return elemanlar[i];
            }
        }


       
    }
}
