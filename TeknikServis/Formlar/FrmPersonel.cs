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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from p in db.TBLPERSONEL
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               p.TELEFON                       
                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
    
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL p = new TBLPERSONEL();
            p.ID = short.Parse(txtID.Text);
            p.AD = txtAd.Text;
            p.SOYAD = txtSoyad.Text;
            p.TELEFON = txtTelefon.Text;
            p.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedildi.");
        }    

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            deger.AD = txtAd.Text;
            deger.SOYAD = txtSoyad.Text;
            deger.TELEFON = txtTelefon.Text;
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from p in db.TBLPERSONEL
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();     
        }
    }
}