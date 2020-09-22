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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {

            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = db.TBLKATEGORI.Count().ToString();
            labelControl5.Text = db.TBLURUN.Sum(k => k.STOK).ToString();
            labelControl15.Text = (from u in db.TBLURUN  // EN FAZLA STOKLU ÜRÜN
                                   orderby u.STOK descending
                                   select u.AD).FirstOrDefault();
            labelControl13.Text = (from u in db.TBLURUN // EN AZ STOKLU ÜRÜN
                                   orderby u.STOK ascending
                                   select u.AD).FirstOrDefault();
            labelControl7.Text = "10"; //KRİTİK SEVİYE
            labelControl9.Text = (from u in db.TBLURUN  //en fazla fiyatlı ürün
                                  orderby u.SATISFIYAT descending
                                  select u.AD).FirstOrDefault();
            labelControl19.Text= (from u in db.TBLURUN  //en düşük fiyatlı ürün
                                  orderby u.SATISFIYAT ascending
                                  select u.AD).FirstOrDefault();
            labelControl29.Text = db.TBLURUN.Count(u => u.KATEGORI == 4).ToString(); //beyaz eşya sayısı
            labelControl25.Text = db.TBLURUN.Count(u => u.KATEGORI == 1).ToString(); //bilgisayar " "
            labelControl21.Text = db.TBLURUN.Count(u => u.KATEGORI == 3).ToString(); //küçük ev aleti " " 
            labelControl39.Text = (from u in db.TBLURUN
                                   select u.MARKA).Distinct().Count().ToString();
            labelControl33.Text = db.TBLURUNKABUL.Count().ToString();
            labelControl11.Text = db.MAKSKATEGORIURUN().FirstOrDefault();
            labelControl37.Text = (from u in db.TBLURUN  // EN FAZLA stoklu marka
                                  orderby u.STOK descending
                                  select u.MARKA).FirstOrDefault();

        }
    }
}
