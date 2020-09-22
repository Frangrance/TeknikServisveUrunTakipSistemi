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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from d in db.TBLDEPARTMAN
                           select new
                           {
                               d.ID,
                               d.AD
                               //d.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl14.Text = db.TBLPERSONEL.Count().ToString();
            labelControl18.Text = db.MAKSDEPARTMAN().FirstOrDefault();
            labelControl16.Text = db.MINDEPARTMAN().FirstOrDefault();

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN d = new TBLDEPARTMAN();

            if (txtAd.Text.Length <= 50 && txtAd.Text != "" && richTextBox1.Text.Length >= 1)
            {
                d.AD = txtAd.Text;
                //d.ACIKLAMA = richTextBox1.Text;
                db.TBLDEPARTMAN.Add(d);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);

            deger.AD = txtAd.Text;
    
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        { //listele
            var degerler = from d in db.TBLDEPARTMAN
                           select new
                           {
                               d.ID,
                               d.AD
                               //d.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            //richTextBox1.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }
    }
}
