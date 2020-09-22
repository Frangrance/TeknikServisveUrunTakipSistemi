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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from f in db.TBLFATURABILGI
                           select new
                           {
                               f.ID,
                               f.SERI,
                               f.SIRANO,
                               f.TARIH,
                               f.SAAT,
                               f.VERGIDAIRE,
                               CARI = f.TBLCARI.AD + " " + f.TBLCARI.SOYAD,
                               PERSONEL = f.TBLPERSONEL.AD + " " + f.TBLPERSONEL.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();


            lookUpEdit1.Properties.DataSource = (from c in db.TBLCARI
                                                 select new
                                                 {
                                                     c.ID,
                                                    AD= c.AD+" "+c.SOYAD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from p in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     p.ID,
                                                     AD = p.AD + " " + p.SOYAD
                                                 }).ToList();


        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from f in db.TBLFATURABILGI
                           select new
                           {
                               f.ID,
                               f.SERI,
                               f.SIRANO,
                               f.TARIH,
                               f.SAAT,
                               f.VERGIDAIRE,
                               CARI = f.TBLCARI.AD + " " + f.TBLCARI.SOYAD,
                               PERSONEL = f.TBLPERSONEL.AD + " " + f.TBLPERSONEL.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI f = new TBLFATURABILGI();
            f.SERI = txtSeri.Text;
            f.SIRANO = txtSıraNo.Text;
            f.TARIH = Convert.ToDateTime(txtTarih.Text);
            f.SAAT = (txtSaat.Text);
            f.VERGIDAIRE = txtVergiDairesi.Text;
            f.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            f.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TBLFATURABILGI.Add(f);
            db.SaveChanges();
            MessageBox.Show("Fatura Sisteme Kaydedildi.", "Kalem Girişi Yapabilirsiniz.");
        }
        
        private void gridView1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
