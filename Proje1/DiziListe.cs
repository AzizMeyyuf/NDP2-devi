 using System;
using System.Collections;

namespace Proje1
{
    public class DiziListe 
    {
        private object[] elemanlar;
        private int elemanSayisi;

        public int ElemanSayisi
        {
            get { return elemanSayisi; }
        }

        public int Kapasite
        {
            get { return elemanlar.Length; }
        }

        public DiziListe()
        {
            elemanlar = new object[4];
            elemanSayisi = 0;
        }

        public DiziListe(int baslangicKapasitesi)
        {
            if (baslangicKapasitesi < 1)
                baslangicKapasitesi = 4;

            elemanlar = new object[baslangicKapasitesi];
            elemanSayisi = 0;
        }

        private void KapasiteGerekiyorsaArtir()
        {
            if (elemanSayisi == elemanlar.Length)
            {
                object[] yeniDizi = new object[elemanlar.Length * 2];
                for (int i = 0; i < elemanSayisi; i++)
                {
                    yeniDizi[i] = elemanlar[i];
                }
                elemanlar = yeniDizi;
            }
        }

        public void SonaEkle(object eleman)
        {
            KapasiteGerekiyorsaArtir();
            elemanlar[elemanSayisi] = eleman;
            elemanSayisi++;
        }

        public void ArayaEkle(int indeks, object eleman)
        {
            if (indeks < 0 || indeks > elemanSayisi)
            {
                throw new IndexOutOfRangeException("Geçersiz indeks değeri!");
            }
            if (elemanSayisi == elemanlar.Length)
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

            elemanlar[elemanSayisi - 1] = null;
            elemanSayisi--;
        }

        public bool Sil(object eleman)
        {
            int bulunanIndeks = Bul(eleman);
            if (bulunanIndeks != -1)
            {
                Sil(bulunanIndeks);
                return true;
            }
            return false;
        }

        public bool VarMi(object eleman)
        {
            return Bul(eleman) != -1;
        }

        public int Bul(object eleman)
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                if (elemanlar[i] == null && eleman == null)
                    return i;

                if (elemanlar[i] != null && elemanlar[i].Equals(eleman))
                    return i;
            }
            return -1;
        }

        public void Temizle()
        {
            elemanlar = new object[4];
            elemanSayisi = 0;
        }

        public void Sirala()
        {
            if (elemanSayisi <= 1)
                return;

            for (int i = 0; i < elemanSayisi - 1; i++)
            {
                bool takasYapildi = false;

                for (int j = 0; j < elemanSayisi - 1 - i; j++)
                {
                    object a = elemanlar[j];
                    object b = elemanlar[j + 1];

                    if (a == null || b == null)
                        continue;

                    
                    if (!a.Equals(b) && a is IComparable compA)
                    {
                        if (compA.CompareTo(b) > 0)
                        {
                            object gecici = elemanlar[j];
                            elemanlar[j] = elemanlar[j + 1];
                            elemanlar[j + 1] = gecici;
                            takasYapildi = true;
                        }
                    }
                }

                if (!takasYapildi)
                    break;
            }
        }

        public void TerCevir()
        {
            int baslangic = 0;
            int bitis = elemanSayisi - 1;

            while (baslangic < bitis)
            {
                object gecici = elemanlar[baslangic];
                elemanlar[baslangic] = elemanlar[bitis];
                elemanlar[bitis] = gecici;

                baslangic++;
                bitis--;
            }
        }

        public object this[int indeks]
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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                yield return elemanlar[i];
            }
        }
    }
}