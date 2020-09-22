using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities DB = new DBTEKNIKSERVISEntities();
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = richTextBox1.Text;
            t.SERINO = txtSeriNo.Text;
            t.TARIH = DateTime.Parse(txtTarih.Text);
            DB.TBLURUNTAKIP.Add(t);
            DB.SaveChanges();
            MessageBox.Show("Ürün arıza detayları güncellendi.");

            TBLURUNKABUL tb = new TBLURUNKABUL();

            int urunid = int.Parse(id.ToString());
            var deger = DB.TBLURUNKABUL.Find(urunid);
            deger.DURUMDETAY = comboBox1.Text;
            DB.SaveChanges();

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string id,serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
            txtSeriNo.Text = serino;
        }
    }
}
