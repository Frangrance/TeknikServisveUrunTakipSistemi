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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            TBLURUNKABUL u = new TBLURUNKABUL();
            u.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            u.GELISTARIH = DateTime.Parse(txtTarih.Text);
            u.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            u.URUNSERINO = txtSeriNo.Text;
            u.DURUMDETAY = "Ürün Kaydoldu";
            db.TBLURUNKABUL.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Girişi Yapıldı.");
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
