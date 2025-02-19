using System.Text.Json;

namespace EditorApp
{
    public partial class Form1 : Form
    {
        string dosyaAdi;//editördeki dosyanýn adý
        Ayarlar ayarlar = new Ayarlar();

        public Form1()
        {
            InitializeComponent();

            AyarlariYukle();//kayýtlý ayar var ise yükler

            YeniBelge();//uygulama ilkçalýþtýðýnda yeni belge oluþtursun
        }

        void AyarlariYukle()
        {
            if (File.Exists("ayarlar.txt"))
            {
                string jsonMetni = File.ReadAllText("ayarlar.txt");
                //tam tersine serileþtirme yap
                //metni sýnýfa dönüþtür

                ayarlar = JsonSerializer.Deserialize<Ayarlar>(jsonMetni);
                Color yaziRengi = Color.FromArgb(ayarlar.YaziRengi);
                yaziRengi = Color.FromArgb(255, yaziRengi);
                
                Color arkaRengi = Color.FromArgb(ayarlar.ArkaplanRengi);
                arkaRengi = Color.FromArgb(255, arkaRengi);

                txtBelge.ForeColor = yaziRengi;
                txtBelge.BackColor = arkaRengi;
                
                toolStrip1.BackColor = txtBelge.BackColor;
                toolStrip1.ForeColor = txtBelge.ForeColor;
                menuStrip1.BackColor = txtBelge.BackColor;
                menuStrip1.ForeColor = txtBelge.ForeColor;
            }
        }

        void AyarlariKaydet()
        {
            //Serileþtirme sýnýfýn verisini metne dönüþtürmektir
            //Json serileþtirmeyi kullan
            string jsonMetni = JsonSerializer.Serialize(ayarlar);

            File.WriteAllText("ayarlar.txt", jsonMetni);
        }

        void YeniBelge()
        {
            txtBelge.Text = "";//metin kutusunu temizler
            dosyaAdi = "";
            Text = "[Yeni Belge]";
        }
        void Kaydet()
        {
            //eðer dosya zaten kayýtlý ise diyalog gösterme
            //
            if (!string.IsNullOrEmpty(dosyaAdi))//dosyaAdi!=""
            {
                File.WriteAllText(dosyaAdi, txtBelge.Text);
                return;
            }

            saveFileDialog1.Filter = "Metin Dosyalarý|*.txt|Tüm Dosyalar|*.*";
            saveFileDialog1.DefaultExt = "*.txt";
            DialogResult cevap = saveFileDialog1.ShowDialog();

            if (cevap == DialogResult.OK)//kullanýcý tamam dediyse
            {
                string secilenDosya = saveFileDialog1.FileName;

                //File sýnýfý dosya iþlemleri için kullanýlýr
                File.WriteAllText(secilenDosya, txtBelge.Text);
                dosyaAdi = secilenDosya;
                Text = $"[{dosyaAdi}]";
            }
        }

        private void miYeni_Click(object sender, EventArgs e)
        {
            YeniBelge();
        }

        private void tsbYeni_Click(object sender, EventArgs e)
        {
            YeniBelge();
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void tsbAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Metin Dosyalarý|*.txt|Tüm Dosyalar|*.*";
            dialog.DefaultExt = "*.txt";

            DialogResult cevap = dialog.ShowDialog();//göster ve bekle
            if (cevap == DialogResult.OK)//gelen cevap ne?
            {
                string secilenDosya = dialog.FileName;
                string icerik = File.ReadAllText(secilenDosya);
                txtBelge.Text = icerik;
                dosyaAdi = secilenDosya;
                Text = $"[{dosyaAdi}]";

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox diayalog penceresi
            //MessageBox.Show("Form kapanýyor.....");
            //MessageBox.Show("Form Kapanýyor....", "Dikkat");
            //MessageBox.Show("Form Kapanýyor....", "Dikkat", MessageBoxButtons.YesNoCancel);
            //MessageBox.Show("Form Kapanýyor....", "Dikkat", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            var cevap = MessageBox.Show("Kayýt edilmemiþ deðiþiklikleri kayýt etmek ister misiniz?",
                "Dikkat", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                Kaydet();
            }
            else if (cevap == DialogResult.Cancel)
            {
                e.Cancel = true;//kapatma iþlemini iptal et
            }
            //Hayýr seçeneðini yazmaya gerek yok!!!!
        }

        private void miKes_Click(object sender, EventArgs e)
        {
            txtBelge.Cut();
        }

        private void miKopyala_Click(object sender, EventArgs e)
        {
            txtBelge.Copy();
        }

        private void miYapistir_Click(object sender, EventArgs e)
        {
            txtBelge.Paste();
        }

        private void tsbBul_Click(object sender, EventArgs e)
        {
            FrmBul form = new FrmBul(txtBelge);//Formun nesnesini oluþtur
            form.Show();//formu göster
            //form.ShowDialog();//formu diyalog olarak göster
        }

        private void miYaziTipi_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            DialogResult cevap = dialog.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                txtBelge.Font = dialog.Font;
            }
        }

        private void miYaziRengi_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            DialogResult cevap = dialog.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                txtBelge.ForeColor = dialog.Color;
                ayarlar.YaziRengi = txtBelge.ForeColor.ToArgb();
                AyarlariKaydet();
            }
        }

        private void miKoyuTema_Click(object sender, EventArgs e)
        {
            txtBelge.BackColor = Color.Black;
            txtBelge.ForeColor = Color.Orange;
            toolStrip1.BackColor = Color.Black;
            toolStrip1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.Gray;
            menuStrip1.ForeColor = Color.White;
            ayarlar.ArkaplanRengi = Color.Black.ToArgb();
            ayarlar.YaziRengi = Color.Orange.ToArgb();
            AyarlariKaydet();
        }

        private void miAcikTema_Click(object sender, EventArgs e)
        {
            txtBelge.BackColor = Color.White;
            txtBelge.ForeColor = Color.Black;
            toolStrip1.BackColor = SystemColors.ButtonFace;
            toolStrip1.ForeColor = Color.Black;
            menuStrip1.BackColor = SystemColors.ButtonFace;
            menuStrip1.ForeColor = Color.Black;
            ayarlar.ArkaplanRengi = Color.White.ToArgb();
            ayarlar.YaziRengi = Color.Black.ToArgb();
            AyarlariKaydet();
        }
    }
}
