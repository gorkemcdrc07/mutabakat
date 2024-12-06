namespace MutabakatOtomasyon
{
    partial class HedefFiyatListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HedefFiyatListesi));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnEskalasyon = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.BtnEskiFiyat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControlHedefFiyat = new DevExpress.XtraGrid.GridControl();
            this.hedefDepoOrhanlıDepoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbMutabakatDataSet = new MutabakatOtomasyon.DbMutabakatDataSet();
            this.gridViewHedefFiyat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hedefDepoOrhanlıDepoTableAdapter = new MutabakatOtomasyon.DbMutabakatDataSetTableAdapters.HedefDepoOrhanlıDepoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHedefFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hedefDepoOrhanlıDepoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMutabakatDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHedefFiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BtnEskalasyon,
            this.barButtonItem1,
            this.BtnEskiFiyat});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1245, 150);
            // 
            // BtnEskalasyon
            // 
            this.BtnEskalasyon.Caption = "Eskalasyon Hesapla";
            this.BtnEskalasyon.Id = 1;
            this.BtnEskalasyon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnEskalasyon.ImageOptions.SvgImage")));
            this.BtnEskalasyon.Name = "BtnEskalasyon";
            this.BtnEskalasyon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEskalasyon_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Eski Fiyat Bilgileri";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // BtnEskiFiyat
            // 
            this.BtnEskiFiyat.Caption = "Eski Fiyat Bilgileri";
            this.BtnEskiFiyat.Id = 3;
            this.BtnEskiFiyat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnEskiFiyat.ImageOptions.SvgImage")));
            this.BtnEskiFiyat.Name = "BtnEskiFiyat";
            this.BtnEskiFiyat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEskiFiyat_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "HEDEF";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnEskalasyon);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "İŞLEMLER";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnEskiFiyat);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // gridControlHedefFiyat
            // 
            this.gridControlHedefFiyat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlHedefFiyat.DataSource = this.hedefDepoOrhanlıDepoBindingSource;
            this.gridControlHedefFiyat.Location = new System.Drawing.Point(0, 156);
            this.gridControlHedefFiyat.MainView = this.gridViewHedefFiyat;
            this.gridControlHedefFiyat.MenuManager = this.ribbonControl1;
            this.gridControlHedefFiyat.Name = "gridControlHedefFiyat";
            this.gridControlHedefFiyat.Size = new System.Drawing.Size(1245, 341);
            this.gridControlHedefFiyat.TabIndex = 1;
            this.gridControlHedefFiyat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHedefFiyat});
            // 
            // hedefDepoOrhanlıDepoBindingSource
            // 
            this.hedefDepoOrhanlıDepoBindingSource.DataMember = "HedefDepoOrhanlıDepo";
            this.hedefDepoOrhanlıDepoBindingSource.DataSource = this.dbMutabakatDataSet;
            // 
            // dbMutabakatDataSet
            // 
            this.dbMutabakatDataSet.DataSetName = "DbMutabakatDataSet";
            this.dbMutabakatDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridViewHedefFiyat
            // 
            this.gridViewHedefFiyat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridViewHedefFiyat.GridControl = this.gridControlHedefFiyat;
            this.gridViewHedefFiyat.Name = "gridViewHedefFiyat";
            this.gridViewHedefFiyat.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Adres Adi";
            this.gridColumn1.FieldName = "AdresAdi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "İl";
            this.gridColumn2.FieldName = "Il";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ÇEKİCİ";
            this.gridColumn3.FieldName = "ÇEKİCİ";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "KIRKAYAK";
            this.gridColumn4.FieldName = "KIRKAYAK";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ONTEKER";
            this.gridColumn5.FieldName = "ONTEKER";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // hedefDepoOrhanlıDepoTableAdapter
            // 
            this.hedefDepoOrhanlıDepoTableAdapter.ClearBeforeFill = true;
            // 
            // HedefFiyatListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 499);
            this.Controls.Add(this.gridControlHedefFiyat);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "HedefFiyatListesi";
            this.Text = "HedefFiyatListesi";
            this.Load += new System.EventHandler(this.HedefFiyatListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHedefFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hedefDepoOrhanlıDepoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMutabakatDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHedefFiyat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControlHedefFiyat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHedefFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DbMutabakatDataSet dbMutabakatDataSet;
        private System.Windows.Forms.BindingSource hedefDepoOrhanlıDepoBindingSource;
        private DbMutabakatDataSetTableAdapters.HedefDepoOrhanlıDepoTableAdapter hedefDepoOrhanlıDepoTableAdapter;
        private DevExpress.XtraBars.BarButtonItem BtnEskalasyon;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem BtnEskiFiyat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}