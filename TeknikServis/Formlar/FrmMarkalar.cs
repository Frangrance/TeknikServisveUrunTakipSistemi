using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });

            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl7.Text = (from u in db.TBLURUN  //en fazla fiyatlı ürün
                                  orderby u.SATISFIYAT descending
                                  select u.MARKA).FirstOrDefault();
            labelControl5.Text = db.MAKSKATEGORIURUN().FirstOrDefault();
            

            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-3799O65Q;Initial Catalog=DBTEKNIKSERVIS;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA, COUNT(*) FROM TBLURUN GROUP BY MARKA",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), Convert.ToInt32(dr[1]));
            }
            baglanti.Close();
        }
    }
}
