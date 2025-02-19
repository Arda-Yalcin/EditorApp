using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorApp
{
    public partial class FrmBul : Form
    {
        TextBox txtBelge;
        public FrmBul(TextBox txtBelge)//Yapıcı metot
        {
            this.txtBelge = txtBelge;

            InitializeComponent();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            int bulunanIndex = txtBelge.Text.IndexOf(txtAranan.Text);

            if(bulunanIndex == -1)
            {
                MessageBox.Show("Aradığınız metin bulunamadı");
                return;
            }
            else
            {
                //Textbox içinde bir yeri seçili hale getirir
                txtBelge.SelectionStart = bulunanIndex;
                txtBelge.SelectionLength = txtAranan.Text.Length;
                txtBelge.Focus();
            }
        }
    }
}
