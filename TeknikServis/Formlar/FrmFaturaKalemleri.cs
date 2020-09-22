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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmFaturaKalemleri_Load(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
          
            var degerler = (from f in db.TBLFATURADETAY
                            select new
                            {
                                f.FATURADETAYID,
                                f.URUN,
                                f.ADET,
                                f.FIYAT,
                                f.TUTAR,
                                f.FATURAID
                            }).Where(x=>x.FATURAID==id);
            gridControl1.DataSource = degerler.ToList();
            }
        }
}
