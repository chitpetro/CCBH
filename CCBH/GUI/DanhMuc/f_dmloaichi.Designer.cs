namespace GUI.DanhMuc
{
    partial class f_dmloaichi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dmloaichi));
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaichi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dmloaichiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaichi1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloaichiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnthem
            // 
            this.btnthem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.Image")));
            this.btnthem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.LargeImage")));
            // 
            // btnsua
            // 
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.LargeImage")));
            // 
            // btnxoa
            // 
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.LargeImage")));
            // 
            // btnprint
            // 
            this.btnprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.Image")));
            this.btnprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.LargeImage")));
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.Image")));
            this.btnxls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.LargeImage")));
            // 
            // btnreload
            // 
            this.btnreload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.Image")));
            this.btnreload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.LargeImage")));
            // 
            // btnsaochep
            // 
            this.btnsaochep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsaochep.ImageOptions.Image")));
            this.btnsaochep.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsaochep.ImageOptions.LargeImage")));
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Size = new System.Drawing.Size(519, 304);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(519, 304);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(499, 284);
            // 
            // gd
            // 
            this.gd.DataSource = this.dmloaichiBindingSource;
            this.gd.Size = new System.Drawing.Size(495, 280);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.colloaichi1,
            this.gridColumn1});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsPrint.RtfReportHeader = resources.GetString("gv.OptionsPrint.RtfReportHeader");
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colloaichi
            // 
            this.colloaichi.FieldName = "loaichi";
            this.colloaichi.Name = "colloaichi";
            this.colloaichi.Visible = true;
            this.colloaichi.VisibleIndex = 1;
            // 
            // dmloaichiBindingSource
            // 
            this.dmloaichiBindingSource.DataSource = typeof(DAL.dmloaichi);
            // 
            // colid1
            // 
            this.colid1.Caption = "ID";
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            this.colid1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colid1.Visible = true;
            this.colid1.VisibleIndex = 0;
            this.colid1.Width = 115;
            // 
            // colloaichi1
            // 
            this.colloaichi1.Caption = "loại Chi";
            this.colloaichi1.FieldName = "loaichi";
            this.colloaichi1.Name = "colloaichi1";
            this.colloaichi1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colloaichi1.Visible = true;
            this.colloaichi1.VisibleIndex = 1;
            this.colloaichi1.Width = 267;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Chi Phí";
            this.gridColumn1.FieldName = "chiphi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 67;
            // 
            // f_dmloaichi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 364);
            this.Name = "f_dmloaichi";
            this.Text = "Danh Mục Loại Chi";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloaichiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colloaichi;
        private System.Windows.Forms.BindingSource dmloaichiBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn colloaichi1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}