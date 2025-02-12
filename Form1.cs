namespace EditorApp
{
    public partial class Form1 : Form
    {
        string dosyaAdi;//editördeki dosyanýn adý

        public Form1()
        {
            InitializeComponent();

            YeniBelge();//uygulama ilkçalýþtýðýnda yeni belge oluþtursun
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
    }
}
