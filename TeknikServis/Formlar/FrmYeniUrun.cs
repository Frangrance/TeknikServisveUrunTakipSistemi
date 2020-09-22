﻿using System;
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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                select new
                                {
                                    x.AD,
                                    x.ID
                                }).ToList();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
            TBLURUN t = new TBLURUN();

            t.AD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            t.STOK = short.Parse(txtStok.Text);
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtUrunAd_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = "";
            txtUrunAd.Focus();
        }
    }
}
