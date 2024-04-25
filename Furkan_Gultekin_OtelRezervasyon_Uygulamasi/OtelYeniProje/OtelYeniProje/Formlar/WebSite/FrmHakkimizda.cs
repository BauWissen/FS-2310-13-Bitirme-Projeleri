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

namespace OtelYeniProje.Formlar.WebSite
{
    public partial class FrmHakkimizda : Form
    {
        public FrmHakkimizda()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();
        Repository<TblHakkimda> repo = new Repository<TblHakkimda>();

        private void FrmHakkimizda_Load(object sender, EventArgs e)
        {
            var iletisim = repo.Find(x => x.ID == 1);
            TxtAciklama1.Text = iletisim.Hakkimda1;
            TxtAciklama2.Text = iletisim.Hakkimda2;
            TxtAciklama3.Text = iletisim.Hakkimda3;
            TxtAciklama4.Text = iletisim.Hakkimda4;
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var hakkimda = repo.Find(x => x.ID == 1);
            hakkimda.Hakkimda1 = TxtAciklama1.Text;
            hakkimda.Hakkimda2 = TxtAciklama2.Text;
            hakkimda.Hakkimda3 = TxtAciklama3.Text;
            hakkimda.Hakkimda4 = TxtAciklama4.Text;
            repo.TUpdate(hakkimda);
            XtraMessageBox.Show("İletişim başarılı bir şekilde güncellendi");
        }
    }
}
