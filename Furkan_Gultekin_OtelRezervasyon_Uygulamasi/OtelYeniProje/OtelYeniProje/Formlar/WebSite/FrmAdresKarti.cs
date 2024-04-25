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
    public partial class FrmAdresKarti : Form
    {
        public FrmAdresKarti()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();
        Repository<Tbliletisim> repo = new Repository<Tbliletisim>();

        private void FrmAdresKarti_Load(object sender, EventArgs e)
        {
            var iletisim = repo.Find(x => x.ID == 1);
            TxtTelefon.Text = iletisim.Telefon;
            TxtMail.Text = iletisim.Mail;
            TxtKoordinat.Text = iletisim.Koordinat;
            TxtAdres.Text = iletisim.Adres;
            TxtAciklama.Text = iletisim.Aciklama;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var iletisim = repo.Find(x => x.ID == 1);
            iletisim.Mail = TxtMail.Text;
            iletisim.Telefon = TxtTelefon.Text;
            iletisim.Aciklama = TxtAciklama.Text;
            iletisim.Koordinat = TxtKoordinat.Text;
            iletisim.Adres = TxtAdres.Text;
            repo.TUpdate(iletisim);
            XtraMessageBox.Show("İletişim başarılı bir şekilde güncellendi");
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
