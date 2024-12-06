using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutabakatOtomasyon.Eski_Fiyatlar
{
    public partial class HedefEskiFiyatlar : Form
    {
        public HedefEskiFiyatlar()
        {
            InitializeComponent();
        }

        private void HedefEskiFiyatlar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbMutabakatDataSet2.TblHedefEskiFiyatBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblHedefEskiFiyatBilgileriTableAdapter.Fill(this.dbMutabakatDataSet2.TblHedefEskiFiyatBilgileri);




            GridView gridView = gridControlHedefEskiFiyat.MainView as GridView;

            if (gridView != null)
            {
                gridView.Columns["EskiFiyat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView.Columns["EskiFiyat"].DisplayFormat.FormatString = "N2";

                gridView.Columns["YeniFiyat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView.Columns["YeniFiyat"].DisplayFormat.FormatString = "N2";
            }


        }

    }
}
