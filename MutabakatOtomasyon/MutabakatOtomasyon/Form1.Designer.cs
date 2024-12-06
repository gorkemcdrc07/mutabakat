namespace MutabakatOtomasyon
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BtnHedefMutabakatEkrani = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BtnHedefFiyatListesi = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BtnSudesanMutabakatEkrani = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BtnSudesanFiyatListesi = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1266, 150);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "MUTABAKAT";
            // 
            // accordionControl1
            // 
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2});
            this.accordionControl1.Location = new System.Drawing.Point(0, 148);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.accordionControl1.Size = new System.Drawing.Size(260, 362);
            this.accordionControl1.TabIndex = 1;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Appearance.Default.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.accordionControlElement1.Appearance.Default.Options.UseFont = true;
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.BtnHedefMutabakatEkrani,
            this.BtnHedefFiyatListesi});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "HEDEF";
            // 
            // BtnHedefMutabakatEkrani
            // 
            this.BtnHedefMutabakatEkrani.Name = "BtnHedefMutabakatEkrani";
            this.BtnHedefMutabakatEkrani.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.BtnHedefMutabakatEkrani.Text = "Mutabakat Ekranı";
            this.BtnHedefMutabakatEkrani.Click += new System.EventHandler(this.BtnHedefMutabakatEkrani_Click);
            // 
            // BtnHedefFiyatListesi
            // 
            this.BtnHedefFiyatListesi.Name = "BtnHedefFiyatListesi";
            this.BtnHedefFiyatListesi.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.BtnHedefFiyatListesi.Text = "Fiyat Listesi";
            this.BtnHedefFiyatListesi.Click += new System.EventHandler(this.BtnHedefFiyatListesi_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.BtnSudesanMutabakatEkrani,
            this.BtnSudesanFiyatListesi});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "SUDESAN";
            // 
            // BtnSudesanMutabakatEkrani
            // 
            this.BtnSudesanMutabakatEkrani.Name = "BtnSudesanMutabakatEkrani";
            this.BtnSudesanMutabakatEkrani.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.BtnSudesanMutabakatEkrani.Text = "Mutabakat Ekranı";
            this.BtnSudesanMutabakatEkrani.Click += new System.EventHandler(this.BtnSudesanMutabakatEkrani_Click);
            // 
            // BtnSudesanFiyatListesi
            // 
            this.BtnSudesanFiyatListesi.Name = "BtnSudesanFiyatListesi";
            this.BtnSudesanFiyatListesi.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.BtnSudesanFiyatListesi.Text = "Fiyat Listesi";
            this.BtnSudesanFiyatListesi.Click += new System.EventHandler(this.BtnSudesanFiyatListesi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 510);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BtnHedefMutabakatEkrani;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BtnHedefFiyatListesi;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BtnSudesanMutabakatEkrani;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BtnSudesanFiyatListesi;
    }
}

