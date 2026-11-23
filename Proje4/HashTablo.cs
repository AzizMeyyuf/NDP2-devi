using System;
using System.Collections;

namespace Proje4
{
    public class HashDugumu
    {
        public object Anahtar;
        public object Deger;
        public HashDugumu Sonraki;

        public HashDugumu(object anahtar, object deger)
        {
            Anahtar = anahtar;
            Deger = deger;
            Sonraki = null;
        }
    }

    public class HashTablo
    {
        private HashDugumu[] tablolar;
        private int kapasite;
        private int elemanSayisi;

        public int ElemanSayisi
        {
            get { return elemanSayisi; }
        }

        public object[] Anahtarlar
        {
            get
            {
                object[] anahtarDizisi = new object[elemanSayisi];
                int sayac = 0;

                for (int i = 0; i < kapasite; i++)
                {
                    HashDugumu simdiki = tablolar[i];
                    while (simdiki != null)
                    {
                        anahtarDizisi[sayac] = simdiki.Anahtar;
                        sayac++;
                        simdiki = simdiki.Sonraki;
                    }
                }
                return anahtarDizisi;
            }
        }

        public object[] Degerler
        {
            get
            {
                object[] degerDizisi = new object[elemanSayisi];
                int sayac = 0;

                for (int i = 0; i < kapasite; i++)
                {
                    HashDugumu simdiki = tablolar[i];
                    while (simdiki != null)
                    {
                        degerDizisi[sayac] = simdiki.Deger;
                        sayac++;
                        simdiki = simdiki.Sonraki;
                    }
                }
                return degerDizisi;
            }
        }

        public HashTablo()
        {
            kapasite = 11;
            tablolar = new HashDugumu[kapasite];
            elemanSayisi = 0;
        }

        public HashTablo(int baslangicKapasitesi)
        {
            if (baslangicKapasitesi < 5)
                baslangicKapasitesi = 11;

            kapasite = baslangicKapasitesi;
            tablolar = new HashDugumu[kapasite];
            elemanSayisi = 0;
        }

        public int HashUret(object anahtar)
        {
            if (anahtar == null)
            {
                throw new ArgumentNullException("Anahtar boş (null) olamaz!");
            }

            int hashKodu = anahtar.GetHashCode();

            if (hashKodu < 0)
            {
                hashKodu = -hashKodu;
            }

            return hashKodu % kapasite;
        }

        public void Ekle(object anahtar, object deger)
        {
            int indeks = HashUret(anahtar);
            HashDugumu simdiki = tablolar[indeks];

            while (simdiki != null)
            {
                if (simdiki.Anahtar.Equals(anahtar))
                {
                    throw new InvalidOperationException("Bu anahtar zaten tabloda ekli: " + anahtar);
                }
                simdiki = simdiki.Sonraki;
            }

            HashDugumu yeniDugum = new HashDugumu(anahtar, deger);
            yeniDugum.Sonraki = tablolar[indeks];
            tablolar[indeks] = yeniDugum;
            elemanSayisi++;
        }

        public bool Sil(object anahtar)
        {
            int indeks = HashUret(anahtar);
            HashDugumu simdiki = tablolar[indeks];
            HashDugumu onceki = null;

            while (simdiki != null)
            {
                if (simdiki.Anahtar.Equals(anahtar))
                {
                    if (onceki == null)
                    {
                        tablolar[indeks] = simdiki.Sonraki;
                    }
                    else
                    {
                        onceki.Sonraki = simdiki.Sonraki;
                    }

                    elemanSayisi--;
                    return true;
                }

                onceki = simdiki;
                simdiki = simdiki.Sonraki;
            }

            return false; 
        }

        public void Temizle()
        {
            tablolar = new HashDugumu[kapasite];
            elemanSayisi = 0;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < kapasite; i++)
            {
                HashDugumu simdiki = tablolar[i];
                while (simdiki != null)
                {
                    yield return $"[{simdiki.Anahtar} -> {simdiki.Deger}]";
                    simdiki = simdiki.Sonraki;
                }
            }
        }
    }
}
