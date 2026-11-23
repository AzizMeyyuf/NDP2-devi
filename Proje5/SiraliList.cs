using System;
using System.Collections;

namespace Proje5
{
    public class SiraliListe
    {
        private object[] anahtarlar;
        private object[] degerler;
        private int elemanSayisi;

        public int ElemanSayisi
        {
            get { return elemanSayisi; }
        }

        public object[] Anahtarlar
        {
            get
            {
                object[] sonuc = new object[elemanSayisi];
                for (int i = 0; i < elemanSayisi; i++)
                {
                    sonuc[i] = anahtarlar[i];
                }
                return sonuc;
            }
        }

        public object[] Degerler
        {
            get
            {
                object[] sonuc = new object[elemanSayisi];
                for (int i = 0; i < elemanSayisi; i++)
                {
                    sonuc[i] = degerler[i];
                }
                return sonuc;
            }
        }

        public SiraliListe()
        {
            anahtarlar = new object[4];
            degerler = new object[4];
            elemanSayisi = 0;
        }

        public SiraliListe(int baslangicKapasitesi)
        {
            if (baslangicKapasitesi < 1)
                baslangicKapasitesi = 4;

            anahtarlar = new object[baslangicKapasitesi];
            degerler = new object[baslangicKapasitesi];
            elemanSayisi = 0;
        }

        private void KapasiteGerekiyorsaArtir()
        {
            if (elemanSayisi == anahtarlar.Length)
            {
                object[] yeniAnahtarlar = new object[anahtarlar.Length * 2];
                object[] yeniDegerler = new object[degerler.Length * 2];

                for (int i = 0; i < elemanSayisi; i++)
                {
                    yeniAnahtarlar[i] = anahtarlar[i];
                    yeniDegerler[i] = degerler[i];
                }

                anahtarlar = yeniAnahtarlar;
                degerler = yeniDegerler;
            }
        }

        public void Ekle(object anahtar, object deger)
        {
            if (anahtar == null)
            {
                throw new ArgumentNullException("Anahtar boş (null) olamaz!");
            }

            IComparable yeniAnahtarKarsilastir = anahtar as IComparable;
            if (yeniAnahtarKarsilastir == null)
            {
                throw new ArgumentException("Anahtar sıralanabilir (IComparable) olmalıdır!");
            }

            int eklenecekIndeks = 0;
            while (eklenecekIndeks < elemanSayisi)
            {
                IComparable mevcutAnahtar = (IComparable)anahtarlar[eklenecekIndeks];
                int karsilastirma = mevcutAnahtar.CompareTo(anahtar);

                if (karsilastirma == 0)
                {
                    throw new InvalidOperationException("Bu anahtar zaten listede mevcut: " + anahtar);
                }

                if (karsilastirma > 0)
                {
                    break;
                }

                eklenecekIndeks++;
            }

            KapasiteGerekiyorsaArtir();

            for (int i = elemanSayisi; i > eklenecekIndeks; i--)
            {
                anahtarlar[i] = anahtarlar[i - 1];
                degerler[i] = degerler[i - 1];
            }

            anahtarlar[eklenecekIndeks] = anahtar;
            degerler[eklenecekIndeks] = deger;
            elemanSayisi++;
        }

        public void Sil(int indeks)
        {
            if (indeks < 0 || indeks >= elemanSayisi)
            {
                throw new IndexOutOfRangeException("Geçersiz indeks değeri!");
            }

            for (int i = indeks; i < elemanSayisi - 1; i++)
            {
                anahtarlar[i] = anahtarlar[i + 1];
                degerler[i] = degerler[i + 1];
            }

            anahtarlar[elemanSayisi - 1] = null;
            degerler[elemanSayisi - 1] = null;
            elemanSayisi--;
        }

        public bool Sil(object anahtar)
        {
            int bulunanIndeks = AnahtarIndeksiBul(anahtar);
            if (bulunanIndeks != -1)
            {
                Sil(bulunanIndeks);
                return true;
            }
            return false;
        }

        private int AnahtarIndeksiBul(object anahtar)
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                if (anahtarlar[i].Equals(anahtar))
                {
                    return i;
                }
            }
            return -1;
        }

        public int HashUret(object anahtar)
        {
            if (anahtar == null)
            {
                throw new ArgumentNullException("Anahtar boş olamaz!");
            }

            int hash = anahtar.GetHashCode();
            if (hash < 0)
            {
                hash = -hash;
            }

            return hash;
        }

        public void Temizle()
        {
            anahtarlar = new object[4];
            degerler = new object[4];
            elemanSayisi = 0;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                yield return $"[{anahtarlar[i]}: {degerler[i]}]";
            }
        }
    }
}
