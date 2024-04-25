using OtelYeniProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.AnaForm
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            //Misafir Listesi
            gridControl3.DataSource = (from x in db.TblMisafir
                                       select new
                                       {
                                           x.AdSoyad
                                       }).ToList();

            //Mesaj Listesi
            gridControl4.DataSource = (from x in db.TblMesaj
                                       select new
                                       {
                                           x.Gonderen,
                                           x.Konu
                                       }).ToList();

            //Bugün Gelecekler Listesi
            gridControl2.DataSource = (from x in db.TblRezervasyon
                                       select new
                                       {
                                           x.TblMisafir.AdSoyad,
                                           x.Durum
                                       }).Where(y => y.Durum == 16).ToList();
            gridView2.Columns["Durum"].Visible = false;

            //ürün stok listesi
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunAd,
                                           x.Toplam
                                       }).ToList();

            //Ürün-Stok Grafiği
            var urunler = db.TblUrun.ToList();
            foreach(var x in urunler)
            {
                chartControl1.Series["Urun-Stok"].Points.AddPoint(x.UrunAd, double.Parse(x.Toplam.ToString()));
            }

            //Oda Doluluk Grafiği
            var durumlar = db.OdaDurum();
            foreach(var x in durumlar)
            {
                chartControl2.Series["Durumlar"].Points.AddPoint(x.DurumAd, double.Parse(x.Sayı.ToString()));
            }
        }
    }
}
