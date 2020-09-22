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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        void metot1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORİ = u.TBLKATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //Listeleme ToList Add Remove
            //var degerler = db.TBLURUN.ToList();
            metot1();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN T = new TBLURUN();
            T.AD = txtUrunAdi.Text;
            T.MARKA = txtMarka.Text;
            T.ALISFIYAT = decimal.Parse(txtAlisFiyati.Text);
            T.SATISFIYAT = decimal.Parse(txtSatisFiyati.Text);
            T.STOK = short.Parse(txtStok.Text);
            T.DURUM = false;
            T.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());

            db.TBLURUN.Add(T);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
             
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //LİSTELEME BUTON
            metot1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtAlisFiyati.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            txtSatisFiyati.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            //lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //SİLME
            int id = int.Parse(txtID.Text);
            var deger = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLURUN.Find(id);

            deger.AD = txtUrunAdi.Text;
            deger.STOK = short.Parse(txtStok.Text);
            deger.MARKA = txtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(txtAlisFiyati.Text);
            deger.SATISFIYAT = decimal.Parse(txtSatisFiyati.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {//TEMİZLE butonu
            txtID.Text = "";
            txtUrunAdi.Text = "";
            txtMarka.Text = "";
            txtAlisFiyati.Text = "";
            txtSatisFiyati.Text = "";
            txtStok.Text = "";
        }
    }
}
