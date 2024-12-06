using MutabakatOtomasyon.Fiyat_Listeleri;
using MutabakatOtomasyon.Mutabakatlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutabakatOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnHedefMutabakatEkrani_Click(object sender, EventArgs e)
        {
            HedefMutabakatEkranı hedefMutabakatEkranı = new HedefMutabakatEkranı();
            hedefMutabakatEkranı.Show();
        }


        private void BtnHedefFiyatListesi_Click(object sender, EventArgs e)
        {
            HedefFiyatListesi hedefFiyatListesi = new HedefFiyatListesi();
            hedefFiyatListesi.Show();
        }

        private void BtnSudesanMutabakatEkrani_Click(object sender, EventArgs e)
        {
            SudesanMutabakatEkranı sudesanMutabakatEkranı = new SudesanMutabakatEkranı();
            sudesanMutabakatEkranı.Show();
        }

        private void BtnSudesanFiyatListesi_Click(object sender, EventArgs e)
        {
            SudesanFiyatListesi sudesanFiyatListesi = new SudesanFiyatListesi();
            sudesanFiyatListesi.Show();
        }
    }
}
