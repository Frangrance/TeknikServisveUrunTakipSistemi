using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities(); 
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               CARI = x.TBLCARI.AD +" "+ x.TBLCARI.SOYAD,
                               PERSONEL =  x.TBLPERSONEL.AD +" "+x.TBLPERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIH,
                               x.URUNSERINO,
                               x.DURUMDETAY
                           };
            gridControl1.DataSource = degerler.ToList();

            labelControl3.Text = db.TBLURUNKABUL.Count(x=>x.URUNDURUM==true).ToString();
            labelControl5.Text = db.TBLURUNKABUL.Count(x=>x.URUNDURUM==false).ToString();
            labelControl12.Text= db.TBLURUN.Count().ToString();
            labelControl7.Text = db.TBLURUNKABUL.Count(x=>x.DURUMDETAY == "Parça Bekliyor").ToString();
            labelControl14.Text = db.TBLURUNKABUL.Count(x => x.DURUMDETAY == "Mesaj Bekliyor").ToString();
            labelControl10.Text = db.TBLURUNKABUL.Count(x => x.DURUMDETAY == "Ürün Kaydoldu").ToString();


            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-3799O65Q;Initial Catalog=DBTEKNIKSERVIS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT DURUMDETAY, COUNT(*) FROM TBLURUNKABUL GROUP BY DURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), Convert.ToInt32(dr[1]));
            }
            baglanti.Close();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("SERINO").ToString();

            fr.Show();
        }
    }
}
