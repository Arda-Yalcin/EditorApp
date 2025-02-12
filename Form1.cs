namespace EditorApp
{
    public partial class Form1 : Form
    {
        string dosyaAdi;//edit�rdeki dosyan�n ad�

        public Form1()
        {
            InitializeComponent();

            YeniBelge();//uygulama ilk�al��t���nda yeni belge olu�tursun
        }

        void YeniBelge()
        {
            txtBelge.Text = "";//metin kutusunu temizler
            dosyaAdi = "";
            Text = "[Yeni Belge]";
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
            //e�er dosya zaten kay�tl� ise diyalog g�sterme
            //
            if(!string.IsNullOrEmpty(dosyaAdi))//dosyaAdi!=""
            {
                File.WriteAllText(dosyaAdi, txtBelge.Text);
                return;
            }

            saveFileDialog1.Filter = "Metin Dosyalar�|*.txt|T�m Dosyalar|*.*";
            saveFileDialog1.DefaultExt = "*.txt";
            DialogResult cevap = saveFileDialog1.ShowDialog();

            if (cevap == DialogResult.OK)//kullan�c� tamam dediyse
            {
                string secilenDosya = saveFileDialog1.FileName;

                //File s�n�f� dosya i�lemleri i�in kullan�l�r
                File.WriteAllText(secilenDosya, txtBelge.Text);
                dosyaAdi = secilenDosya;
                Text = $"[{dosyaAdi}]";
            }
        }

        private void tsbAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new ();
            dialog.Filter = "Metin Dosyalar�|*.txt|T�m Dosyalar|*.*";
            dialog.DefaultExt = "*.txt";

            DialogResult cevap = dialog.ShowDialog();//g�ster ve bekle
            if(cevap == DialogResult.OK)//gelen cevap ne?
            {
                string secilenDosya = dialog.FileName;
                string icerik = File.ReadAllText(secilenDosya);
                txtBelge.Text = icerik;
                dosyaAdi = secilenDosya;
                Text = $"[{dosyaAdi}]";

            }

        }
    }
}
