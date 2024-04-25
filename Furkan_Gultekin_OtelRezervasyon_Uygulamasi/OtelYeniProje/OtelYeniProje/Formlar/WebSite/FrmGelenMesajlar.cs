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

namespace OtelYeniProje.Formlar.WebSite
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMesaj2
                                       select new
                                       {
                                           x.MesajID,
                                           x.Gonderen,
                                           x.Konu,
                                           x.Tarih,
                                           x.Alici
                                       }).Where(y => y.Alici == "Admin").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMesajKarti fr = new FrmMesajKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("MesajID").ToString());
            fr.Show();
        }
    }
}
