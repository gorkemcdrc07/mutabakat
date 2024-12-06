using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using MutabakatOtomasyon.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace MutabakatOtomasyon
{
    public partial class HedefMutabakatEkranı : Form
    {
        public HedefMutabakatEkranı()
        {
            InitializeComponent();
            BtnFiyatlar.Enabled = false;
            BtnUgrama.Enabled = false;
            BtnYuklemeUgrama.Enabled = false;
            BtnToplam.Enabled = false;
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Dosya gezgini açılıyor
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Dosyaları (*.xls;*.xlsx)|*.xls;*.xlsx";
            openFileDialog.Title = "Excel Dosyası Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın yolu
                string filePath = openFileDialog.FileName;

                // Excel dosyasını okuma
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Excel içeriğini DataSet olarak alıyoruz, ilk satır başlık olarak kabul edilir
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true // İlk satırı başlık olarak kabul et
                            }
                        });

                        DataTable dataTable = result.Tables[0]; // İlk sayfayı alıyoruz (ilk tablo)

                        // gridControlHedef'e veri ekleme
                        var dataList = new List<HedefMutabakat>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            var hedefMutabakat = new HedefMutabakat
                            {
                                SeferTarihi = row["Sefer Tarihi"] != DBNull.Value ?
                                    Convert.ToDateTime(row["Sefer Tarihi"]).ToString("dd.MM.yyyy") : "", // Sadece tarihi alıyoruz
                                TMSDespatchId = row["TMSDespatchId"]?.ToString(),
                                SeferNo = row["Sefer No"]?.ToString(),
                                HizmetAdi = row["Hizmet Adı"]?.ToString(),
                                ProjeAdi = row["Proje Adı"]?.ToString(),
                                MusteriAdi = row["Müşteri Adı"]?.ToString(),
                                CalismaTipi = row["Çalışma Tipi"]?.ToString(),
                                Plaka = row["Plaka"]?.ToString(),
                                IstenilenAracTipi = row["İstenilen Arac Tipi"]?.ToString(),
                                TalepEdilenAracTipi = row["Talep Edilen Arac Tipi"]?.ToString(),
                                VerilenAracTipi = row["Verilen Arac Tipi"]?.ToString(),
                                YuklemeNoktasi = row["Yükleme Noktası"]?.ToString(),
                                YuklemeIli = row["Yükleme İli"]?.ToString(),
                                TeslimIli = row["Teslim İli"]?.ToString(),
                                TeslimIlcesi = row["Teslim İlçesi"]?.ToString(),
                                TeslimNoktasi = row["Teslim Noktası"]?.ToString(),
                                MusteriSiparisNo = row["Müşteri Sipariş No"]?.ToString(),
                                IrsaliyeToplamKG = row["İrsaliye Toplam KG"]?.ToString(),
                                NavlunGeliriGirildiMi = row["Navlun Geliri Girildi Mi?"]?.ToString(),
                                NavlunGeliriOnaylandiMi = row["Navlun Geliri Onaylandı Mı?"]?.ToString(),
                            };

                            dataList.Add(hedefMutabakat);
                        }

                        // gridControlHedef'e veriyi bağlama
                        gridControlHedef.DataSource = dataList;
                    }
                }
            }
        }





        private void BtnTemizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // gridControlHedef üzerinde veri kaynağını temizleyin
            gridControlHedef.DataSource = null;
        }

        private void BtnMutabakat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnFiyatlar.Enabled = true;
            BtnUgrama.Enabled = false;
            BtnYuklemeUgrama.Enabled = false;
            BtnToplam.Enabled = false;
            // GridControl'un GridView'ini alıyoruz
            var gridView = gridControlHedef.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView != null)
            {
                // Gizlemek istediğimiz sütunları burada belirtiyoruz
                gridView.Columns["TalepEdilenAracTipi"].Visible = false;
                gridView.Columns["VerilenAracTipi"].Visible = false;
                gridView.Columns["TeslimIli"].Visible = false;
                gridView.Columns["TeslimIlcesi"].Visible = false;
                gridView.Columns["IrsaliyeToplamKG"].Visible = false;
                gridView.Columns["NavlunGeliriGirildiMi"].Visible = false;
                gridView.Columns["NavlunGeliriOnaylandiMi"].Visible = false;
            }
        }

        private void BtnFiyatlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnUgrama.Enabled = true;
            BtnYuklemeUgrama.Enabled = false;
            BtnToplam.Enabled = false;
            var gridView = gridControlHedef.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView != null)
            {
                for (int rowHandle = 0; rowHandle < gridView.RowCount; rowHandle++)
                {
                    string teslimNoktasi = gridView.GetRowCellValue(rowHandle, "TeslimNoktasi")?.ToString();
                    string istenilenAracTipi = gridView.GetRowCellValue(rowHandle, "IstenilenAracTipi")?.ToString();

                    if (!string.IsNullOrEmpty(teslimNoktasi) && !string.IsNullOrEmpty(istenilenAracTipi))
                    {
                        using (var context = new DbMutabakatEntities3())
                        {
                            var adresler = teslimNoktasi.Split(';');
                            List<string> bulunamayanAdresler = new List<string>();

                            string aracTipiSutun = string.Empty;

                            if (istenilenAracTipi == "ÇEKİCİ")
                            {
                                aracTipiSutun = "ÇEKİCİ";
                            }
                            else if (istenilenAracTipi == "KIRKAYAK")
                            {
                                aracTipiSutun = "KIRKAYAK";
                            }
                            else if (istenilenAracTipi == "ONTEKER")
                            {
                                aracTipiSutun = "ONTEKER";
                            }

                            decimal? maxSeferGeliri = null;

                            foreach (var adres in adresler)
                            {
                                string temizlenmisAdres = adres.Trim();
                                var depoData = context.HedefDepoOrhanlıDepo
                                    .Where(d => d.AdresAdi == temizlenmisAdres)
                                    .FirstOrDefault();

                                if (depoData != null && !string.IsNullOrEmpty(aracTipiSutun))
                                {
                                    var seferGeliriStr = depoData.GetType().GetProperty(aracTipiSutun)?.GetValue(depoData)?.ToString();

                                    if (decimal.TryParse(seferGeliriStr, out decimal seferGeliri))
                                    {
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

                            if (bulunamayanAdresler.Count > 0)
                            {
                                ShowAddressPopup(bulunamayanAdresler, gridView, rowHandle, aracTipiSutun);
                            }
                            else if (maxSeferGeliri.HasValue)
                            {
                                gridView.SetRowCellValue(rowHandle, "SeferGeliri", maxSeferGeliri.Value.ToString());
                            }
                        }
                    }
                }
            }
        }

        // Popup gösterme metodu, bulunamayan adresleri kaydettikten sonra SeferGeliri güncellemesi ekler
        private void ShowAddressPopup(List<string> bulunamayanAdresler, DevExpress.XtraGrid.Views.Grid.GridView gridView, int rowHandle, string aracTipiSutun)
        {
            var popupForm = new DevExpress.XtraEditors.XtraForm
            {
                Text = "Adres Ekle",
                Width = 800,
                Height = 500
            };

            var gridControlPopup = new DevExpress.XtraGrid.GridControl
            {
                Dock = DockStyle.Fill
            };

            var gridViewPopup = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControlPopup.MainView = gridViewPopup;
            popupForm.Controls.Add(gridControlPopup);

            // Adres bilgilerini hazırlama
            var adresData = new List<AdresData>();
            foreach (var adres in bulunamayanAdresler)
            {
                adresData.Add(new AdresData
                {
                    AdresAdi = adres,
                    Il = "",
                    CEKICI = "",
                    KIRKAYAK = "",
                    ONTEKER = ""
                });
            }

            // GridControl'e veri bağlama
            gridControlPopup.DataSource = adresData;

            // Kolon düzenlemeleri
            gridViewPopup.Columns["AdresAdi"].OptionsColumn.AllowEdit = false;
            gridViewPopup.Columns["Il"].OptionsColumn.AllowEdit = true;
            gridViewPopup.Columns["CEKICI"].OptionsColumn.AllowEdit = true;
            gridViewPopup.Columns["KIRKAYAK"].OptionsColumn.AllowEdit = true;
            gridViewPopup.Columns["ONTEKER"].OptionsColumn.AllowEdit = true;

            // "Tamam" butonu
            var btnTamam = new DevExpress.XtraEditors.SimpleButton
            {
                Text = "Tamam",
                Dock = DockStyle.Bottom
            };

            btnTamam.Click += (sender, e) =>
            {
                using (var context = new DbMutabakatEntities3())
                {
                    foreach (var adresDataRow in adresData)
                    {
                        var yeniAdres = new HedefDepoOrhanlıDepo
                        {
                            AdresAdi = adresDataRow.AdresAdi,
                            Il = adresDataRow.Il,
                            ÇEKİCİ = adresDataRow.CEKICI,
                            KIRKAYAK = adresDataRow.KIRKAYAK,
                            ONTEKER = adresDataRow.ONTEKER
                        };

                        context.HedefDepoOrhanlıDepo.Add(yeniAdres);
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Adresler başarıyla kaydedildi.");

                // Yeni eklenen adreslerle SeferGeliri değerini güncelleme
                using (var context = new DbMutabakatEntities3())
                {
                    decimal? maxSeferGeliri = null;

                    foreach (var adres in bulunamayanAdresler)
                    {
                        var depoData = context.HedefDepoOrhanlıDepo
                            .Where(d => d.AdresAdi == adres)
                            .FirstOrDefault();

                        if (depoData != null)
                        {
                            var seferGeliriStr = depoData.GetType().GetProperty(aracTipiSutun)?.GetValue(depoData)?.ToString();

                            if (decimal.TryParse(seferGeliriStr, out decimal seferGeliri))
                            {
                                if (maxSeferGeliri == null || seferGeliri > maxSeferGeliri)
                                {
                                    maxSeferGeliri = seferGeliri;
                                }
                            }
                        }
                    }

                    if (maxSeferGeliri.HasValue)
                    {
                        gridView.SetRowCellValue(rowHandle, "SeferGeliri", maxSeferGeliri.Value.ToString());
                    }
                }

                // Kullanıcıya bilgilendirme mesajı
                MessageBox.Show("Durum güncellendi. Lütfen excelinizi tekrar yükleyiniz.");

                popupForm.Close();
            };

            popupForm.Controls.Add(btnTamam);
            popupForm.ShowDialog();
        }







        private bool ugramaHesaplandi = false; // Bayrak ekledik

        private void BtnUgrama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (ugramaHesaplandi)
            {
                MessageBox.Show("Uğrama işlemi zaten hesaplandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // İşlemi tekrar yapma
            }

            BtnYuklemeUgrama.Enabled = true;
            // Tüm satırlar için döngü başlat
            for (int rowHandle = 0; rowHandle < gridViewHedef.RowCount; rowHandle++)
            {
                string teslimNoktasi = gridViewHedef.GetRowCellValue(rowHandle, "TeslimNoktasi")?.ToString();
                string istenilenAracTipi = gridViewHedef.GetRowCellValue(rowHandle, "IstenilenAracTipi")?.ToString();

                if (!string.IsNullOrEmpty(teslimNoktasi) && !string.IsNullOrEmpty(istenilenAracTipi))
                {
                    string[] noktalar = teslimNoktasi.Split(';');
                    int noktaSayisi = noktalar.Length;
                    decimal toplamUgrama = 0;
                    List<string> iller = new List<string>();
                    decimal enBuyukDeger = 0;
                    string baslangicNoktasi = "";

                    // Başlangıç noktasını belirle (en büyük değere sahip olan)
                    using (var context = new DbMutabakatEntities3())
                    {
                        foreach (string nokta in noktalar)
                        {
                            var depo = context.HedefDepoOrhanlıDepo.FirstOrDefault(d => d.AdresAdi == nokta.Trim());

                            if (depo != null)
                            {
                                decimal depoDeger = 0;

                                if (istenilenAracTipi == "ÇEKİCİ")
                                    decimal.TryParse(depo.ÇEKİCİ, out depoDeger);
                                else if (istenilenAracTipi == "KIRKAYAK")
                                    decimal.TryParse(depo.KIRKAYAK, out depoDeger);
                                else if (istenilenAracTipi == "ONTEKER")
                                    decimal.TryParse(depo.ONTEKER, out depoDeger);

                                if (depoDeger > enBuyukDeger)
                                {
                                    enBuyukDeger = depoDeger;
                                    baslangicNoktasi = nokta.Trim();
                                }

                                if (!iller.Contains(depo.Il))
                                    iller.Add(depo.Il);
                            }
                        }
                    }

                    // Başlangıç noktasından diğer noktalara uğrama hesapla
                    for (int i = 0; i < noktaSayisi - 1; i++)
                    {
                        string nokta1 = noktalar[i].Trim();
                        string nokta2 = noktalar[i + 1].Trim();

                        using (var context = new DbMutabakatEntities3())
                        {
                            var depo1 = context.HedefDepoOrhanlıDepo.FirstOrDefault(d => d.AdresAdi == nokta1);
                            var depo2 = context.HedefDepoOrhanlıDepo.FirstOrDefault(d => d.AdresAdi == nokta2);

                            if (depo1 != null && depo2 != null)
                            {
                                if (depo1.Il == depo2.Il)
                                {
                                    toplamUgrama += 820; // Aynı il için
                                }
                                else
                                {
                                    toplamUgrama += 1090; // Farklı iller için
                                }
                            }
                        }
                    }

                    // Toplam uğrama sonucunu hücreye yaz
                    gridViewHedef.SetRowCellValue(rowHandle, "Ugrama", toplamUgrama);
                }
                else
                {
                    // Eksik bilgi varsa uğrama 0
                    gridViewHedef.SetRowCellValue(rowHandle, "Ugrama", 0);
                }
            }

            // İşlem tamamlandı, bayrağı güncelle
            ugramaHesaplandi = true;
        }











        public class AdresData
        {
            public string AdresAdi { get; set; }
            public string Il { get; set; }
            public string CEKICI { get; set; }
            public string KIRKAYAK { get; set; }
            public string ONTEKER { get; set; }
        }

        private bool yuklemeUgramaHesaplandi = false; // Bayrak ekledik

        private void BtnYuklemeUgrama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnToplam.Enabled = true;
            if (yuklemeUgramaHesaplandi)
            {
                MessageBox.Show("Yükleme uğrama işlemi zaten hesaplandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // İşlemi tekrar yapma
            }

            // GridView'deki her bir satır için döngü
            for (int rowHandle = 0; rowHandle < gridViewHedef.RowCount; rowHandle++)
            {
                // YuklemeNoktasi sütunundaki değeri al
                string yuklemeNoktasi = gridViewHedef.GetRowCellValue(rowHandle, "YuklemeNoktasi")?.ToString();
                decimal mevcutUgrama = 0;

                // Ugrama sütunundaki mevcut değeri al
                if (decimal.TryParse(gridViewHedef.GetRowCellValue(rowHandle, "Ugrama")?.ToString(), out decimal ugrama))
                {
                    mevcutUgrama = ugrama;
                }

                // Eğer YuklemeNoktasi boş değilse işlem yap
                if (!string.IsNullOrEmpty(yuklemeNoktasi))
                {
                    // ";" sayısını belirle
                    int noktaSayisi = yuklemeNoktasi.Split(';').Length - 1;

                    // Nokta sayısına göre hesaplama yap
                    decimal eklenenDeger = noktaSayisi * 820;

                    // Mevcut Ugrama ile eklenen değeri topla
                    mevcutUgrama += eklenenDeger;

                    // Hesaplanan değeri Ugrama sütununa yaz
                    gridViewHedef.SetRowCellValue(rowHandle, "Ugrama", mevcutUgrama);
                }
                else
                {
                    // Eğer YuklemeNoktasi boşsa Ugrama sütununa 0 yaz
                    gridViewHedef.SetRowCellValue(rowHandle, "Ugrama", 0);
                }
            }

            // İşlem tamamlandı, bayrağı güncelle
            yuklemeUgramaHesaplandi = true;
        }


        private void BtnToplam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // GridView'e erişim
            var gridView = gridControlHedef.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null) return;

            // Satırları gezerek hesaplama
            for (int i = 0; i < gridView.RowCount; i++)
            {
                // SeferGeliri, BeklemeGeliri, RotaFarki, Hammaliye ve Ugrama sütunlarının değerlerini al
                decimal seferGeliri = Convert.ToDecimal(gridView.GetRowCellValue(i, "SeferGeliri") ?? 0);
                decimal beklemeGeliri = Convert.ToDecimal(gridView.GetRowCellValue(i, "BeklemeGeliri") ?? 0);
                decimal rotaFarki = Convert.ToDecimal(gridView.GetRowCellValue(i, "RotaFarki") ?? 0);
                decimal hammaliye = Convert.ToDecimal(gridView.GetRowCellValue(i, "Hammaliye") ?? 0);
                decimal ugrama = Convert.ToDecimal(gridView.GetRowCellValue(i, "Ugrama") ?? 0);

                // Toplam Gelir Hesabı
                decimal toplamGelir = seferGeliri + beklemeGeliri + rotaFarki + hammaliye + ugrama;

                // ToplamGelir sütununa yaz
                gridView.SetRowCellValue(i, "ToplamGelir", toplamGelir);
            }

            // Güncellemeyi grid üzerinde göstermek için
            gridView.RefreshData();
        }



        private void BtnCikti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ProgressBar'ı oluştur ve ayarla
            ProgressBar progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Maximum = gridViewHedef.RowCount; // Satır sayısına göre maksimum değeri ayarla
            progressBar.Minimum = 0;
            progressBar.Value = 0;

            // Kaydetme yeri sormak için SaveFileDialog oluştur
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Excel Çıktısı Kaydetme Konumu Seçin";

                // Dosya adını belirle (bugünün tarihiyle)
                string fileName = $"HEDEF MUTABAKAT ({DateTime.Now:dd-MM-yyyy}).xlsx";
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Seçilen sütunlar
                        List<string> targetColumns = new List<string>
                {
                    "SeferTarihi", "TMSDespatchId", "SeferNo", "HizmetAdi", "ProjeAdi",
                    "MusteriAdi", "CalismaTipi", "Plaka", "IstenilenAracTipi",
                    "YuklemeNoktasi", "YuklemeIli", "TeslimNoktasi", "SevkNumarasi","MusteriSiparisNo",
                    "SeferNumarasi", "SeferGeliri", "BeklemeGeliri",
                    "RotaFarki", "Hammaliye", "ToplamGelir"
                };

                        // Excel uygulaması oluştur
                        Excel.Application excelApp = new Excel.Application();
                        Excel.Workbook workbook = excelApp.Workbooks.Add();
                        Excel.Worksheet worksheet = workbook.Sheets[1];
                        worksheet.Name = "Çıktı";

                        // Başlıkları yaz
                        for (int i = 0; i < targetColumns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1] = targetColumns[i];
                        }

                        // İlk satırı stilize et (Daha koyu mavi arka plan, beyaz yazı)
                        Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, targetColumns.Count]];
                        headerRange.Interior.Color = System.Drawing.Color.FromArgb(0, 0, 139); // Koyu mavi (RGB: 0, 0, 139)
                        headerRange.Font.Color = System.Drawing.Color.White; // Beyaz yazı
                        headerRange.Font.Bold = true; // Kalın yazı

                        // Verileri yaz ve progress bar'ı güncelle
                        for (int rowHandle = 0; rowHandle < gridViewHedef.RowCount; rowHandle++)
                        {
                            for (int i = 0; i < targetColumns.Count; i++)
                            {
                                object cellValue = gridViewHedef.GetRowCellValue(rowHandle, targetColumns[i]);
                                worksheet.Cells[rowHandle + 2, i + 1] = cellValue?.ToString() ?? "";
                            }

                            // ProgressBar'ı güncelle
                            progressBar.Value = rowHandle + 1;
                            // UI'deki progress bar'ı güncellemek için Invoke kullanabilirsiniz
                            progressBar.Refresh();
                        }

                        // Sütun genişliklerini otomatik ayarla
                        worksheet.Columns.AutoFit();  // Bu satır sütunları içerdikleri en uzun metne göre genişletir

                        // Dolu hücrelere kenarlık ekle
                        Excel.Range dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[gridViewHedef.RowCount + 1, targetColumns.Count]];
                        dataRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // Alt kenarlık
                        dataRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // Sağ kenarlık
                        dataRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // Sol kenarlık
                        dataRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // Üst kenarlık
                        dataRange.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous; // İç yatay kenarlıklar
                        dataRange.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous; // İç dikey kenarlıklar

                        // Sütunlar için Türk Lirası formatını uygula (S, R, Q, P, O sütunları)
                        string[] currencyColumns = { "S", "R", "Q", "P", "O" };  // Para birimi formatı uygulanacak sütunlar
                        foreach (var columnLetter in currencyColumns)
                        {
                            Excel.Range columnRange = worksheet.Range[$"{columnLetter}2:{columnLetter}{gridViewHedef.RowCount + 1}"];
                            columnRange.NumberFormat = "₺ #,##0.00"; // Türk Lirası formatında
                        }

                        // Sütun T'nin son satırını bul ve toplamı ekle
                        int lastRow = gridViewHedef.RowCount + 1;  // Last data row
                        string columnLetterT = "T";  // Toplam için T sütunu

                        // "T" sütunundaki sayıları topla
                        Excel.Range sumCell = worksheet.Cells[lastRow + 1, targetColumns.IndexOf("ToplamGelir") + 1];  // Son satırın bir altındaki hücre
                        sumCell.Formula = $"=SUM({columnLetterT}2:{columnLetterT}{lastRow})";  // Toplamı T sütununa yaz

                        // Sarı arka plan ve koyu yazı rengi (daha koyu yazı)
                        sumCell.Interior.Color = System.Drawing.Color.Yellow;  // Arka plan rengini sarı yap
                        sumCell.Font.Color = System.Drawing.Color.Black; // Yazı rengini siyah yap

                        // Para birimi formatı (Türk Lirası)
                        sumCell.NumberFormat = "₺ #,##0.00"; // Türk Lirası formatında


                        // Excel dosyasını kaydet
                        workbook.SaveAs(saveFileDialog.FileName);
                        workbook.Close();
                        excelApp.Quit();

                        // Excel nesnelerini serbest bırak
                        Marshal.ReleaseComObject(worksheet);
                        Marshal.ReleaseComObject(workbook);
                        Marshal.ReleaseComObject(excelApp);

                        // ProgressBar'ı sıfırla
                        progressBar.Value = progressBar.Maximum;

                        // Kullanıcıya başarı mesajı göster
                        MessageBox.Show("Çıktı başarıyla Excel dosyasına kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Excel dosyasını otomatik aç
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Excel çıktısı alınırken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }







        public class HedefMutabakat
        {
            public string SeferTarihi { get; set; } // Sefer Tarihi
            public string TMSDespatchId { get; set; } // TMSDespatchId
            public string SeferNo { get; set; } // Sefer No
            public string HizmetAdi { get; set; } // Hizmet Adı
            public string ProjeAdi { get; set; } // Proje Adı
            public string MusteriAdi { get; set; } // Müşteri Adı
            public string CalismaTipi { get; set; } // Çalışma Tipi
            public string Plaka { get; set; } // Plaka
            public string IstenilenAracTipi { get; set; } // İstenilen Arac Tipi
            public string TalepEdilenAracTipi { get; set; } // Talep Edilen Arac Tipi
            public string VerilenAracTipi { get; set; } // Verilen Arac Tipi
            public string YuklemeNoktasi { get; set; } // Yükleme Noktası
            public string YuklemeIli { get; set; } // Yükleme İli
            public string TeslimIli { get; set; } // Teslim İli
            public string TeslimIlcesi { get; set; } // Teslim İlçesi
            public string TeslimNoktasi { get; set; } // Teslim Noktası
            public string MusteriSiparisNo { get; set; } // Müşteri Sipariş No
            public string IrsaliyeToplamKG { get; set; } // İrsaliye Toplam KG
            public string NavlunGeliriGirildiMi { get; set; } // Navlun Geliri Girildi Mi?
            public string NavlunGeliriOnaylandiMi { get; set; } // Navlun Geliri Onaylandı Mı?
            public string SevkNumarasi { get; set; } // Sevk Numarası
            public string SeferGeliri { get; set; } // Sefer Geliri
            public string BeklemeGeliri { get; set; } // Bekleme Geliri
            public string RotaFarki { get; set; } // Rota Farkı
            public string Hammaliye { get; set; } // Hammaliye
            public string ToplamGelir { get; set; } // Toplam Gelir
            public string Ugrama { get; set; }
            public string UgramaYerleri { get; set; }

        }
    }
}




