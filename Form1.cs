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
            DialogResult cevap = saveFileDialog1.ShowDialog();
            
            if(cevap == DialogResult.OK)//kullan�c� tamam dediyse
            {
                string secilenDosya = saveFileDialog1.FileName;

                //File s�n�f� dosya i�lemleri i�in kullan�l�r
                File.WriteAllText(secilenDosya, txtBelge.Text);
                dosyaAdi = secilenDosya;
                Text = $"[{dosyaAdi}]";
            }
        }
    }
}
