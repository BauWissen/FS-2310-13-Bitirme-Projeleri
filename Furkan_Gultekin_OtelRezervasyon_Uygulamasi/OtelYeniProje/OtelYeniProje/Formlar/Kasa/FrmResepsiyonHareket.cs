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

namespace OtelYeniProje.Formlar.Kasa
{
    public partial class FrmResepsiyonHareket : Form
    {
        public FrmResepsiyonHareket()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();

        private void FrmResepsiyonHareket_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblKasaHareketi
                                       select new
                                       {
                                           x.Misafir,
                                           x.Tarih,
                                           x.Tutar
                                       }).ToList();
        }
    }
}
