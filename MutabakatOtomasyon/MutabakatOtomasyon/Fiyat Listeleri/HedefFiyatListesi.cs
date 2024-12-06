using DevExpress.XtraEditors;
using MutabakatOtomasyon.entity;
using MutabakatOtomasyon.Eski_Fiyatlar;
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
    public partial class HedefFiyatListesi : Form
    {
        public HedefFiyatListesi()
        {
            InitializeComponent();
        }

        private void HedefFiyatListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbMutabakatDataSet.HedefDepoOrhanlıDepo' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.hedefDepoOrhanlıDepoTableAdapter.Fill(this.dbMutabakatDataSet.HedefDepoOrhanlıDepo);

        }



        // The event handler for BtnEskalasyon_ItemClick in this form
        private void BtnEskalasyon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kullanıcıdan eski fiyatı al
            string eskiFiyatStr = XtraInputBox.Show("Eski fiyatı giriniz:", "Eski Fiyat", "");
            if (string.IsNullOrEmpty(eskiFiyatStr)) return; // Eğer boşsa işlem yapma

            // Kullanıcıdan yeni fiyatı al
            string yeniFiyatStr = XtraInputBox.Show("Yeni fiyatı giriniz:", "Yeni Fiyat", "");
            if (string.IsNullOrEmpty(yeniFiyatStr)) return; // Eğer boşsa işlem yapma

            try
            {
                // Fiyatları decimal türüne çevir
                decimal eskiFiyat = Convert.ToDecimal(eskiFiyatStr);
                decimal yeniFiyat = Convert.ToDecimal(yeniFiyatStr);

                // Eskalasyon oranını hesapla: (Yeni Fiyat / Eski Fiyat) - 1
                decimal eskanOrani = ((yeniFiyat / eskiFiyat) - 1) * 100;

                // Hesaplanan eskalasyon oranını 2'ye böl
                decimal eskanOraniYarisi = eskanOrani / 2;

                // Sonucu yüzde olarak göster
                XtraMessageBox.Show($"Eskalasyon Oranı: {eskanOraniYarisi:F2}%", "Hesaplama Sonucu");

                // DbMutabakatEntities1'deki verilerle işlem yap
                // DbMutabakatEntities1'deki HedefEskiFiyatBilgileri sınıfını kullanın
                using (var context = new DbMutabakatEntities3())
                {
                    // Eski fiyat ve yeni fiyatı string'e dönüştür
                    var newRecord = new MutabakatOtomasyon.entity.TblHedefEskiFiyatBilgileri
                    {
                        EskiFiyat = eskiFiyat.ToString(), // decimal değeri string'e çeviriyoruz
                        YeniFiyat = yeniFiyat.ToString(), // decimal değeri string'e çeviriyoruz
                        Tarih = DateTime.Now
                    };

                    context.TblHedefEskiFiyatBilgileri.Add(newRecord);
                    context.SaveChanges();



                    // ÇEKİCİ, KIRKAYAK ve ONTEKER sütunlarındaki verileri al
                    var data = context.HedefDepoOrhanlıDepo.ToList();

                    foreach (var row in data)
                    {
                        // ÇEKİCİ, KIRKAYAK, ONTEKER sütunlarındaki her hücreyi güncelle
                        if (!string.IsNullOrEmpty(row.ÇEKİCİ))
                        {
                            decimal cekiciValue = Convert.ToDecimal(row.ÇEKİCİ);
                            // Hesaplama ve tam sayıya yuvarlama
                            row.ÇEKİCİ = Math.Round(((cekiciValue * (eskanOraniYarisi / 100)) + cekiciValue), 0).ToString();  // Tam sayıya yuvarla
                        }

                        if (!string.IsNullOrEmpty(row.KIRKAYAK))
                        {
                            decimal kirkayakValue = Convert.ToDecimal(row.KIRKAYAK);
                            // Hesaplama ve tam sayıya yuvarlama
                            row.KIRKAYAK = Math.Round(((kirkayakValue * (eskanOraniYarisi / 100)) + kirkayakValue), 0).ToString();  // Tam sayıya yuvarla
                        }

                        if (!string.IsNullOrEmpty(row.ONTEKER))
                        {
                            decimal ontekerValue = Convert.ToDecimal(row.ONTEKER);
                            // Hesaplama ve tam sayıya yuvarlama
                            row.ONTEKER = Math.Round(((ontekerValue * (eskanOraniYarisi / 100)) + ontekerValue), 0).ToString();  // Tam sayıya yuvarla
                        }
                    }

                    // Değişiklikleri kaydet
                    context.SaveChanges();
                }

                XtraMessageBox.Show("Eskalasyon oranı ile sütunlar güncellendi.", "Başarılı");
            }
            catch (Exception ex)
            {
                // Hata mesajı göster
                XtraMessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Veritabanı sınıfı ile çakışmaması için ismi değiştirebilirsiniz
        







        private void BtnEskiFiyat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HedefEskiFiyatlar hedefEskiFiyatlar = new HedefEskiFiyatlar();
            hedefEskiFiyatlar.Show();
        }
    }
}
