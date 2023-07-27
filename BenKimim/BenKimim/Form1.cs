using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;



// Sorulmuş sorunun tekrar sorulması

namespace BenKimim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sorular = SorulariDoldur();
            kisiler = KisileriDoldur();
            secilmisSoruNumarasi = getRandomQuestion(sorular);
        }
        public static Dictionary<int, String> sorular;
        public static Dictionary<string, List<int>> kisiler;
        public static int secilmisSoruNumarasi;
        public DialogResult secilmiCevap;
        public List<int> sorulmusSoru = new List<int>();
        public static Dictionary<int, string> SorulariDoldur()
        {
            Dictionary<int, String> sorularListesi = new Dictionary<int, string>();
            sorularListesi.Add(1, "Kadın mı?");
            sorularListesi.Add(2, "Türk mü?");
            sorularListesi.Add(3, "Gerçek hayatta yaşadı mı?");
            sorularListesi.Add(4, "Şarkıcı mı?");
            sorularListesi.Add(5, "Sunucu mu?");
            sorularListesi.Add(6, "Ezel dizisinde oynadı mı?");
            sorularListesi.Add(7, "Sarışın mı?");
            sorularListesi.Add(8, "Boyu 180 cm den yüksek mi?");
            sorularListesi.Add(9, "50 yaşından büyük mü?");
            sorularListesi.Add(10, "Saçı uzun mu?");
            sorularListesi.Add(11, "Dövmesi var mı?");
            sorularListesi.Add(12, "Esmer mi?");
            sorularListesi.Add(13, "Erkek mi?");
            sorularListesi.Add(14, "Aşırı zengin mi?");
            sorularListesi.Add(15, "Sosyal medyayı aktif kullanır mı?");
            sorularListesi.Add(16, "Ünlü bir dansı var mı?");
            sorularListesi.Add(17, "Şuan hayatta mı?");
            sorularListesi.Add(18, "Evlendi mi?");
            sorularListesi.Add(19, "Gözleri mavi mi?");
            sorularListesi.Add(20, "Oyuncu mu?");
            sorularListesi.Add(21, "Estetiği var mı?");
            sorularListesi.Add(22, "Çocuğu var mı?");
            sorularListesi.Add(23, "Giyim tarzı klasik mi?");
            sorularListesi.Add(24, "Kanalı var mı?");
            sorularListesi.Add(25, "Müslüman mı?");
            return sorularListesi;
        }

        public static Dictionary<string, List<int>> KisileriDoldur()
        {
            Dictionary<string, List<int>> kisilerListesi = new Dictionary<string, List<int>>();
            kisilerListesi.Add("Mustafa Sandal", new List<int> { 2, 3, 4, 9, 11, 13, 16, 17, 18, 22, 23, 25 });
            kisilerListesi.Add("Demet Aklın", new List<int> { 1, 2, 3, 4, 10, 11, 15, 17, 18, 21, 22, 23, 25 });
            kisilerListesi.Add("Cansu Dere", new List<int> { 1, 2, 3, 6, 10, 17, 20, 23, 25 });
            kisilerListesi.Add("Hürrem Sultan", new List<int> { 1, 3, 10, 14, 18, 19, 22 });
            kisilerListesi.Add("Can Bonomo", new List<int> { 2, 3, 4, 11, 13, 17, 18, 22 });
            kisilerListesi.Add("Thanos", new List<int> { 8, 9, 13, 22 });
            kisilerListesi.Add("İsmail YK", new List<int> { 2, 3, 4, 10, 13, 25 });
            kisilerListesi.Add("Barney Stinson", new List<int> { 7, 8, 13, 17, 18, 19, 22, 23 });
            kisilerListesi.Add("Ariana Grande", new List<int> { 1, 3, 4, 10, 11, 12, 14, 15, 20, 21 });
            kisilerListesi.Add("Acun Ilıcalı", new List<int> { 2, 3, 5, 8, 9, 13, 14, 17, 18, 22, 24, 25 });
            kisilerListesi.Add("Rihanna", new List<int> { 1, 3, 4, 10, 11, 12, 14 });
            kisilerListesi.Add("Robert Downey JR", new List<int> { 3, 9, 11, 13, 14, 17, 18, 20, 22, 23, });
            kisilerListesi.Add("Kemal Can Parlak", new List<int> { 2, 3, 10, 13, 15, 25 });
            kisilerListesi.Add("Binnur Kaya", new List<int> { 1, 2, 3, 10, 20, 25 });
            kisilerListesi.Add("Michael Jackson", new List<int> { 3, 4, 9, 10, 12, 13, 14, 16, 17, 18, 21, 22 });
            kisilerListesi.Add("Müge Anlı", new List<int> { 1, 2, 3, 5, 7, 10, 11, 17, 18, 22, 23, 25 });
            kisilerListesi.Add("Tuncel Kurtiz", new List<int> { 2, 3, 6, 9, 13, 17, 18, 20, 22, 23, 25 });
            kisilerListesi.Add("Aydın Doğan", new List<int> { 2, 3, 9, 13, 14, 17, 18, 22, 23, 24, 25 });

            return kisilerListesi;
        }

        public bool isNumberExists(List<int> liste)
        {
            foreach (int soruId in liste)
            {
                if (soruId == secilmisSoruNumarasi)
                {
                    return true;
                }
            }
            return false;
        }

        public Dictionary<int, string> sorularıGuncelle()
        {
            Dictionary<int, string> availableQuestions = new Dictionary<int, string>();
            foreach (var item in kisiler)
            {
                foreach (var listeElemani in item.Value)
                {
                    if (!availableQuestions.ContainsKey(listeElemani))
                    {
                        availableQuestions.Add(listeElemani, sorular[listeElemani]);
                    }
                }
            }
            return availableQuestions;
        }

        public int getRandomQuestion(Dictionary<int, String> sorular)
        {
            
            List<int> degerListesi = new List<int>(sorular.Keys);
            Random rnd = new Random();
            int RSayi = rnd.Next(1,degerListesi.Count);
            int secilmisSoruNumarasi;
            if (!sorulmusSoru.Contains(RSayi))
            {
                Random ran = new Random();
                RSayi = ran.Next(1,degerListesi.Count);
                secilmisSoruNumarasi = degerListesi[RSayi];
            }
            else
            {
                Random rdn = new Random();
                RSayi = rdn.Next(1,degerListesi.Count);
                secilmisSoruNumarasi = degerListesi[RSayi];
            }
            
           // soruKontrol(degerListesi, RSayi);
            return secilmisSoruNumarasi;
        }

        public void islemler()
        {
            while (kisiler.Count != 1)
            {
                secilmisSoruNumarasi = getRandomQuestion(sorular);

                DialogResult secilmiCevap = MessageBox.Show(sorular[secilmisSoruNumarasi], "Soru", MessageBoxButtons.YesNo);
                if (secilmiCevap == DialogResult.Yes)
                {
                    //evet gelirse soruyu içermeyen kişileri sil
                    foreach (var entry in kisiler)
                    {
                        if (!isNumberExists(entry.Value))
                        {
                            kisiler.Remove(entry.Key);
                        }
                    }

                    sorular = sorularıGuncelle();
                    //Sorularbilir soruları güncelle (kalan kişilerin soruları üzerinden yeni bir sorularbilir sorular listesi oluştur)
                }
                else
                {
                    //hayır gelirse soruyu içeren kişileri sil
                    foreach (var entry in kisiler)
                    {
                        if (isNumberExists(entry.Value))
                        {
                            kisiler.Remove(entry.Key);
                        }
                    }

                    sorular = sorularıGuncelle();
                    //Sorularbilir soruları güncelle (kalan kişilerin soruları üzerinden yeni bir sorularbilir sorular listesi oluştur)

                }
                if (kisiler.Count==0)
                {
                    MessageBox.Show("Yanlış cevap verdiniz.");
                }

            }
            MessageBox.Show("Seçtiğiniz kişi: " + kisiler.First().Key);
            
        }

        private void btn_Baslat_Click(object sender, EventArgs e)
        {
            sorular = SorulariDoldur();
            kisiler = KisileriDoldur();
            islemler();
        }
    }
}
