using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelYeniProje.Entity;
namespace OtelYeniProje.Formlar.Rezervasyon
{
    public partial class FrmTumRezervasyonlar : Form
    {
        public FrmTumRezervasyonlar()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();

        private void FrmTumRezervasyonlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblRezervasyon
                                       select new
                                       {
                                           x.RezervasyonID,
                                           x.TblMisafir.AdSoyad,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Kisi,
                                           x.TblOda.OdaNo,
                                           x.Telefon,
                                           x.TblDurum.DurumAd
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmRezervasyonKarti fr = new FrmRezervasyonKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("RezervasyonID").ToString());
            fr.Show();
        }
    }
}
