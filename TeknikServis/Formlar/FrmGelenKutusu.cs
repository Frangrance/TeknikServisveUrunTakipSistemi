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
    public partial class FrmGelenKutusu : Form
    {
        public FrmGelenKutusu()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmGelenKutusu_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLILETISIM
                                      select new
                                      {
                                        
                                          x.ADSOYAD,
                                          x.KONU,
                                          x.MAIL,
                                          x.MESAJ
                                      }).ToList();
        }
    }
}
