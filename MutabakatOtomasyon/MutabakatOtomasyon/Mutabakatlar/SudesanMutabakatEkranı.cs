using MutabakatOtomasyon.entity;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MutabakatOtomasyon.Mutabakatlar
{

    public partial class SudesanMutabakatEkranı : Form
    {
        public SudesanMutabakatEkranı()
        {
            InitializeComponent();
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
{
    // EPPlus lisans ayarı
    OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

    // Excel dosyasını seçmek için OpenFileDialog
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
        openFileDialog.Title = "Bir Excel Dosyası Seçin";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;

            // Excel dosyasını okuma
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // İlk sayfa

                // Yeni "Yükleme Tarihi" sütununu ekleyelim
                int newColumnIndex = worksheet.Dimension.End.Column + 1;
                worksheet.Cells[1, newColumnIndex].Value = "Yükleme Tarihi"; // Başlık

                // Sefer Tarihi sütunundaki verileri Yükleme Tarihi sütununa kopyalayalım
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var seferTarihi = worksheet.Cells[row, 1].Text.Trim(); // Sefer Tarihi, 1. sütun
                    worksheet.Cells[row, newColumnIndex].Value = seferTarihi; // Yükleme Tarihi, yeni sütun
                }

                // Teslim Noktası sütununun adını bulalım
                int teslimColumnIndex = -1;
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    if (worksheet.Cells[1, col].Text.Trim() == "Teslim Noktası")
                    {
                        teslimColumnIndex = col;
                        break;
                    }
                }

                if (teslimColumnIndex != -1)
                {
                    // Teslim Noktası sütununun sağında yeni sütunlar ekleyelim
                    worksheet.Cells[1, teslimColumnIndex + 1].Value = "BirinciTeslimatNoktasi";
                    worksheet.Cells[1, teslimColumnIndex + 2].Value = "İkinciTeslimatNoktasi";
                    worksheet.Cells[1, teslimColumnIndex + 3].Value = "UcuncuTeslimatNoktasi";
                    worksheet.Cells[1, teslimColumnIndex + 4].Value = "Uğrama"; // Yeni Uğrama sütunu

                    // Teslim Noktası sütunundaki verileri inceleyip ayıralım
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        // Teslim Noktası değerini alalım (örneğin; BİM NİLÜFER (9503);BİM İNEGÖL)
                        var teslimNoktasi = worksheet.Cells[row, teslimColumnIndex].Text.Trim();

                        // Teslim Noktası verisini ";" ile ayıralım
                        var teslimNoktasiList = teslimNoktasi.Split(';');

                        // Duruma göre teslimat noktalarını yerleştirelim
                        if (teslimNoktasiList.Length == 1)
                        {
                            worksheet.Cells[row, teslimColumnIndex + 1].Value = teslimNoktasiList[0].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 2].Value = null;
                            worksheet.Cells[row, teslimColumnIndex + 3].Value = null;
                            worksheet.Cells[row, teslimColumnIndex + 4].Value = "TEK YER";
                        }
                        else if (teslimNoktasiList.Length == 2)
                        {
                            worksheet.Cells[row, teslimColumnIndex + 1].Value = teslimNoktasiList[0].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 2].Value = teslimNoktasiList[1].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 3].Value = null;
                            worksheet.Cells[row, teslimColumnIndex + 4].Value = "İKİ YER";
                        }
                        else if (teslimNoktasiList.Length == 3)
                        {
                            worksheet.Cells[row, teslimColumnIndex + 1].Value = teslimNoktasiList[0].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 2].Value = teslimNoktasiList[1].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 3].Value = teslimNoktasiList[2].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 4].Value = "ÜÇ YER";
                        }
                        else
                        {
                            worksheet.Cells[row, teslimColumnIndex + 1].Value = teslimNoktasiList[0].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 2].Value = teslimNoktasiList[1].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 3].Value = teslimNoktasiList[2].Trim();
                            worksheet.Cells[row, teslimColumnIndex + 4].Value = "ÜÇ YER";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Teslim Noktası sütunu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Değişiklikleri kaydedelim
                package.Save();

                // Verileri gridControl'e yükleme
                DataTable dataTable = new DataTable();

                // Başlıkları (ilk satır) oku
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    string columnName = worksheet.Cells[1, col].Text.Trim();
                    if (!string.IsNullOrEmpty(columnName) && !dataTable.Columns.Contains(columnName))
                    {
                        dataTable.Columns.Add(columnName);
                    }
                }

                // Verileri (diğer satırları) oku
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int col = 1; col <= dataTable.Columns.Count; col++)
                    {
                        dataRow[col - 1] = worksheet.Cells[row, col].Text.Trim();
                    }
                    dataTable.Rows.Add(dataRow);
                }

                // gridControl'e veriyi yükle
                gridControlSudesan.DataSource = dataTable;

                // Burada, yüklenen veriye göre işlemi ekliyoruz
                var gridView = gridControlSudesan.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView != null)
                {
                    for (int rowHandle = 0; rowHandle < gridView.RowCount; rowHandle++)
                    {
                        string teslimNoktasi = gridView.GetRowCellValue(rowHandle, "Teslim Noktası")?.ToString();
                        string istenilenAracTipi = gridView.GetRowCellValue(rowHandle, "İstenilen Arac Tipi")?.ToString();

                        if (!string.IsNullOrEmpty(teslimNoktasi) && !string.IsNullOrEmpty(istenilenAracTipi))
                        {
                            using (var context = new DbMutabakatEntities3())
                            {
                                var adresler = teslimNoktasi.Split(';');  // ';' ile ayırıyoruz
                                decimal? maxSeferGeliri = null;

                                string aracTipiSutun = string.Empty;

                                if (istenilenAracTipi == "ÇEKİCİ")
                                {
                                    aracTipiSutun = "ÇEKİCİ";
                                }
                                else if (istenilenAracTipi == "ONTEKER")
                                {
                                    aracTipiSutun = "ONTEKER";
                                }

                                List<string> bulunamayanAdresler = new List<string>();

                                foreach (var adres in adresler)
                                {
                                    string temizlenmisAdres = adres.Trim();

                                    // Veritabanında adresi arıyoruz
                                    var depoData = context.SudesanFiyatListesi
                                        .Where(d => d.AdresAdi == temizlenmisAdres)
                                        .FirstOrDefault();

                                    if (depoData != null && !string.IsNullOrEmpty(aracTipiSutun))
                                    {
                                        var seferGeliriStr = depoData.GetType().GetProperty(aracTipiSutun)?.GetValue(depoData)?.ToString();

                                        if (decimal.TryParse(seferGeliriStr, out decimal seferGeliri))
                                        {
                                            // En büyük sefer gelirini alıyoruz
                                            if (maxSeferGeliri == null || seferGeliri > maxSeferGeliri)
                                            {
                                                maxSeferGeliri = seferGeliri;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bulunamayanAdresler.Add(temizlenmisAdres);
                                    }
                                }

                                // Sonucu grid'e yazalım
                                gridView.SetRowCellValue(rowHandle, "Navlun", maxSeferGeliri?.ToString() ?? "Yok");

                                // En büyük adresin sonucu bulunamayan adresler listesine ekleyelim
                                if (bulunamayanAdresler.Any())
                                {
                                    gridView.SetRowCellValue(rowHandle, "Bulunamayan Adresler", string.Join(", ", bulunamayanAdresler));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

        private void ShowAddressPopup(List<string> bulunamayanAdresler, DevExpress.XtraGrid.Views.Grid.GridView gridView, int rowHandle, string aracTipiSutun)
        {
            string adresler = string.Join(", ", bulunamayanAdresler);
            string message = $"Bu adres(ler) veritabanında bulunamadı: {adresler}. Lütfen kontrol edin.";

            // You can display a message box or create a custom popup window here
            MessageBox.Show(message, "Adres Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }





        private void BtnTemizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // gridControlSudesan üzerinde veri kaynağını temizleyin
            gridControlSudesan.DataSource = null;
        }

        private void BtnMutabakat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Görünür kalacak kolonların FieldName değerleri ve sıralaması
            string[] visibleFieldNames =
            {
        "Sefer Tarihi",
        "Yükleme Tarihi",
        "Sefer No",
        "TMSDespatchId",
        "İrsaliye No",
        "Yükleme Yeri",
        "Teslim Noktası",
        "BirinciTeslimatNoktasi",
        "İkinciTeslimatNoktasi",
        "UcuncuTeslimatNoktasi",
        "İstenilen Arac Tipi",
        "Uğrama",
        "Çalışma Tipi",
        "Plaka",
        "Navlun",
        "Uğrama Fiyat",
        "Bekleme",
        "Hammaliye",
        "Tutar"
    };

            // Manuel sıralama için VisibleIndex değerini ayarla
            for (int i = 0; i < visibleFieldNames.Length; i++)
            {
                var column = gridViewSudesan.Columns.ColumnByFieldName(visibleFieldNames[i]);
                if (column != null)
                {
                    column.Visible = true;
                    column.VisibleIndex = i;
                }
            }

            // Diğer sütunları gizle
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridViewSudesan.Columns)
            {
                if (!visibleFieldNames.Contains(column.FieldName))
                {
                    column.Visible = false;  // Görünürlüğü kapat
                }
            }

            // Sütun genişliklerini otomatik ayarla
            gridViewSudesan.OptionsView.ColumnAutoWidth = true;
            gridViewSudesan.BestFitColumns();
        }
    }
}



















