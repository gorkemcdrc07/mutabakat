namespace MutabakatOtomasyon.Eski_Fiyatlar
{
    partial class HedefEskiFiyatlar
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
            this.gridControlHedefEskiFiyat = new DevExpress.XtraGrid.GridControl();
            this.gridViewHedefEskiFiyat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbMutabakatDataSet2 = new MutabakatOtomasyon.DbMutabakatDataSet2();
            this.tblHedefEskiFiyatBilgileriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblHedefEskiFiyatBilgileriTableAdapter = new MutabakatOtomasyon.DbMutabakatDataSet2TableAdapters.TblHedefEskiFiyatBilgileriTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHedefEskiFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHedefEskiFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMutabakatDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHedefEskiFiyatBilgileriBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlHedefEskiFiyat
            // 
            this.gridControlHedefEskiFiyat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlHedefEskiFiyat.DataSource = this.tblHedefEskiFiyatBilgileriBindingSource;
            this.gridControlHedefEskiFiyat.Location = new System.Drawing.Point(0, 0);
            this.gridControlHedefEskiFiyat.MainView = this.gridViewHedefEskiFiyat;
            this.gridControlHedefEskiFiyat.Name = "gridControlHedefEskiFiyat";
            this.gridControlHedefEskiFiyat.Size = new System.Drawing.Size(703, 450);
            this.gridControlHedefEskiFiyat.TabIndex = 0;
            this.gridControlHedefEskiFiyat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHedefEskiFiyat});
            // 
            // gridViewHedefEskiFiyat
            // 
            this.gridViewHedefEskiFiyat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewHedefEskiFiyat.GridControl = this.gridControlHedefEskiFiyat;
            this.gridViewHedefEskiFiyat.Name = "gridViewHedefEskiFiyat";
            this.gridViewHedefEskiFiyat.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tarih";
            this.gridColumn1.FieldName = "Tarih";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Eski Fiyat";
            this.gridColumn2.FieldName = "EskiFiyat";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Yeni Fiyat";
            this.gridColumn3.FieldName = "YeniFiyat";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // dbMutabakatDataSet2
            // 
            this.dbMutabakatDataSet2.DataSetName = "DbMutabakatDataSet2";
            this.dbMutabakatDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblHedefEskiFiyatBilgileriBindingSource
            // 
            this.tblHedefEskiFiyatBilgileriBindingSource.DataMember = "TblHedefEskiFiyatBilgileri";
            this.tblHedefEskiFiyatBilgileriBindingSource.DataSource = this.dbMutabakatDataSet2;
            // 
            // tblHedefEskiFiyatBilgileriTableAdapter
            // 
            this.tblHedefEskiFiyatBilgileriTableAdapter.ClearBeforeFill = true;
            // 
            // HedefEskiFiyatlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.gridControlHedefEskiFiyat);
            this.Name = "HedefEskiFiyatlar";
            this.Text = "HedefEskiFiyatlar";
            this.Load += new System.EventHandler(this.HedefEskiFiyatlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHedefEskiFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHedefEskiFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMutabakatDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHedefEskiFiyatBilgileriBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        public DevExpress.XtraGrid.GridControl gridControlHedefEskiFiyat;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewHedefEskiFiyat;
        private DbMutabakatDataSet2 dbMutabakatDataSet2;
        private System.Windows.Forms.BindingSource tblHedefEskiFiyatBilgileriBindingSource;
        private DbMutabakatDataSet2TableAdapters.TblHedefEskiFiyatBilgileriTableAdapter tblHedefEskiFiyatBilgileriTableAdapter;
    }
}