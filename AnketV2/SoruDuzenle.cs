using DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketV2
{
    public partial class SoruDuzenle : Form
    {
        public Soru GelenSoru { get; set; }

        public SoruDuzenle()
        {
            InitializeComponent();
        }

        private void SoruDuzenle_Load(object sender, EventArgs e)
        {
            textBox3.Text = GelenSoru.SoruCumlesi;
        }

        private void btn_kaydet_click(object sender, EventArgs e)
        { 
            AnketContext db = new AnketContext();
            var duzenlenecek = db.Sorular.Find(GelenSoru.SoruID);
            duzenlenecek.SoruCumlesi = textBox3.Text;
            db.Entry(duzenlenecek).State = EntityState.Modified;
            db.SaveChanges();

            Form1 f =(Form1) Application.OpenForms["Form1"];
            f.SorulariYenile();
            f.CevaplariYenile();
            this.Close();
        }
    }
}
