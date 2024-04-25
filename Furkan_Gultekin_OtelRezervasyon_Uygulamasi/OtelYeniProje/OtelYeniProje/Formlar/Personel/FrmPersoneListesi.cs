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

namespace OtelYeniProje.Formlar.Personel
{
    public partial class FrmPersoneListesi : Form
    {
        public FrmPersoneListesi()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();

        private void FrmPersoneListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblPersonel
                            select new
                            {
                                x.PersonelID,
                                x.AdSoyad,
                                x.TC,
                                x.Telefon,
                                x.Mail,
                                x.TblDepartman.DepartmanAd,
                                x.TblGorev.GorevAd,
                                x.TblDurum.DurumAd
                            }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmPersonelKarti fr = new FrmPersonelKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("PersonelID").ToString());
            fr.Show();
        }
    }
}
