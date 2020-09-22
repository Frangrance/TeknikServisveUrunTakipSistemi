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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.IL,
                                           x.ILCE
                                       }).ToList();

            labelControl12.Text = db.TBLCARI.Count().ToString(); //cari sayısı
            labelControl18.Text = db.TBLCARI.Select(x=>x.IL).Distinct().Count().ToString();
            labelControl16.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
            labelControl14.Text =(from u in db.TBLCARI  
                                  orderby u.IL descending
                                  select u.IL).FirstOrDefault();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI C = new TBLCARI();
            C.AD = txtAd.Text;
            C.SOYAD = txtSoyad.Text;
            C.IL = lookUpEdit2.EditValue.ToString();
            C.ILCE = lookUpEdit3.EditValue.ToString();
            C.BANKA = txtBanka.Text;
            C.ADRES = txtAdres.Text;
            C.VERGIDAIRESİ = txtVergiDairesi.Text;
            C.VERGINO = txtVergiNo.Text;
            C.TELEFON = txtTelefon.Text;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
