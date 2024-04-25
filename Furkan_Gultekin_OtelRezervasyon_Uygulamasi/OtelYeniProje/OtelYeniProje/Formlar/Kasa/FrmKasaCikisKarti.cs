using DevExpress.XtraEditors;
using OtelYeniProje.Entity;
using OtelYeniProje.Repositories;
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
    public partial class FrmKasaCikisKarti : Form
    {
        public FrmKasaCikisKarti()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();
        Repository<TblKasaCikisHareketi> repo = new Repository<TblKasaCikisHareketi>();
        TblKasaCikisHareketi t = new TblKasaCikisHareketi();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.Aciklama = TxtAciklama.Text;
            t.Tarih = DateTime.Parse(dateEdit1.Text);
            t.Tutar = decimal.Parse(TxtToplam.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Çıkış hareketi sisteme kaydedildi");
        }
    }
}
