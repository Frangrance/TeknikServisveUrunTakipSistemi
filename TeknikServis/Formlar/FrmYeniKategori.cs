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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != " " && txtAd.Text.Length <= 30)
            {
                TBLKATEGORI t = new TBLKATEGORI();

                t.AD = txtAd.Text;
                db.TBLKATEGORI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Lütfen karakter sayısını 1 ila 30 arası seçiniz.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
