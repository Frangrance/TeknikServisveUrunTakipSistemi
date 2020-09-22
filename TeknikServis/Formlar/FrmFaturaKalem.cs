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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = txtÜrün.Text;
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.TUTAR = decimal.Parse(txtTutar.Text);
            t.FATURAID = int.Parse(txtFaturaID.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Faturaya Kalem Girişi Başarıyla Gerçekleştirildi.");
        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var degerler = from f in db.TBLFATURADETAY
                           select new
                           {
                               f.FATURADETAYID,
                               f.URUN,
                               f.ADET,
                               f.FIYAT,
                               f.TUTAR,
                               f.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from f in db.TBLFATURADETAY
                           select new
                           {
                               f.FATURADETAYID,
                               f.URUN,
                               f.ADET,
                               f.FIYAT,
                               f.TUTAR,
                               f.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
