using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            


        }
        Formlar.FrmUrunListesi fr3;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {    
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmUrunListesi();
                fr3.MdiParent = this;
                fr3.Show();
            }     
        }

        private void btnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniUrun fr = new Formlar.FrmYeniUrun();
            //fr.MdiParent = this;
            fr.Show();
        }
        Formlar.FrmKategori fr2;
        private void btnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmKategori();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            fr.Show();
        }

        private void BtnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmIstatistik fr = new Formlar.FrmIstatistik();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnMarkaİst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmMarkalar fr = new Formlar.FrmMarkalar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //CARİ LİSTESİ

            Formlar.FrmCariListesi fr = new Formlar.FrmCariListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariIller fr = new Formlar.FrmCariIller();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartman fr = new Formlar.FrmDepartman();
            fr.MdiParent = this;
            fr.Show();
        }
        Formlar.FrmAnaSayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {
           
            if (fr == null || fr.IsDisposed)
            {

                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void BtnPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonel fr = new Formlar.FrmPersonel();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKurlar fr = new Formlar.FrmKurlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void BtnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaListesi fr = new Formlar.FrmArizaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatis fr = new Formlar.FrmUrunSatis();
            fr.Show();
        }

        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmSatislar fr = new Formlar.FrmSatislar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunKaydi fr = new Formlar.FrmArizaliUrunKaydi();

            fr.Show();
        }

        private void btnArizaliAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaDetaylar fr = new Formlar.FrmArizaDetaylar();

            fr.Show();
        }

        private void BtnArizaliDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrünDetay fr = new Formlar.FrmArizaliUrünDetay();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnQRCodeOluştur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRCode fr = new Formlar.FrmQRCode();
            fr.Show();
        }

        private void BtnYeniFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaListesi fr = new Formlar.FrmFaturaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnFaturayaKalemGiris_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalem fr = new Formlar.FrmFaturaKalem();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnDetaylıFaturaSorgulama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalemleri fr = new Formlar.FrmFaturaKalemleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRapor fr = new Formlar.FrmRapor();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
                fr = new Formlar.FrmAnaSayfa();
            fr.MdiParent = this;
            fr.Show();
        }
        Formlar.FrmGelenKutusu fr5;
        private void BtnMailKutusu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
                fr5 = new Formlar.FrmGelenKutusu();
            fr5.MdiParent = this;
            fr5.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}