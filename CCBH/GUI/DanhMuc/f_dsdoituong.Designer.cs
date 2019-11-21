namespace GUI.DanhMuc
{
    partial class f_dsdoituong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dsdoituong));
            this.doituongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiachi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmsthue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldienthoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colemail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltaikhoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnganhang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmadv = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doituongBindingSource)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(759, 304);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(759, 304);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(739, 284);
            // 
            // gd
            // 
            this.gd.DataSource = this.doituongBindingSource;
            this.gd.Size = new System.Drawing.Size(735, 280);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colten,
            this.colnhom,
            this.colloai,
            this.coldiachi,
            this.colmsthue,
            this.coldienthoai,
            this.colemail,
            this.colfax,
            this.coldd,
            this.coltaikhoan,
            this.colnganhang,
            this.colmanv,
            this.colmadv});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsPrint.RtfReportHeader = resources.GetString("gv.OptionsPrint.RtfReportHeader");
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // doituongBindingSource
            // 
            this.doituongBindingSource.DataSource = typeof(DAL.doituong);
            // 
            // colid
            // 
            this.colid.Caption = "Mã Đối Tượng";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            this.colid.Width = 87;
            // 
            // colten
            // 
            this.colten.Caption = "Tên Đối Tượng";
            this.colten.FieldName = "tendt";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 1;
            this.colten.Width = 91;
            // 
            // colnhom
            // 
            this.colnhom.Caption = "Nhóm Đối Tượng";
            this.colnhom.FieldName = "nhom";
            this.colnhom.Name = "colnhom";
            this.colnhom.Visible = true;
            this.colnhom.VisibleIndex = 2;
            this.colnhom.Width = 55;
            // 
            // colloai
            // 
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // coldiachi
            // 
            this.coldiachi.Caption = "Địa Chỉ";
            this.coldiachi.FieldName = "diachi";
            this.coldiachi.Name = "coldiachi";
            this.coldiachi.Visible = true;
            this.coldiachi.VisibleIndex = 3;
            this.coldiachi.Width = 55;
            // 
            // colmsthue
            // 
            this.colmsthue.Caption = "Mã Số Thuế";
            this.colmsthue.FieldName = "msthue";
            this.colmsthue.Name = "colmsthue";
            this.colmsthue.Visible = true;
            this.colmsthue.VisibleIndex = 4;
            this.colmsthue.Width = 76;
            // 
            // coldienthoai
            // 
            this.coldienthoai.Caption = "Điện Thoại";
            this.coldienthoai.FieldName = "dienthoai";
            this.coldienthoai.Name = "coldienthoai";
            this.coldienthoai.Visible = true;
            this.coldienthoai.VisibleIndex = 6;
            this.coldienthoai.Width = 51;
            // 
            // colemail
            // 
            this.colemail.Caption = "E mail";
            this.colemail.FieldName = "email";
            this.colemail.Name = "colemail";
            this.colemail.Visible = true;
            this.colemail.VisibleIndex = 5;
            this.colemail.Width = 51;
            // 
            // colfax
            // 
            this.colfax.Caption = "Fax";
            this.colfax.FieldName = "fax";
            this.colfax.Name = "colfax";
            this.colfax.Visible = true;
            this.colfax.VisibleIndex = 7;
            this.colfax.Width = 51;
            // 
            // coldd
            // 
            this.coldd.Caption = "Di Động";
            this.coldd.FieldName = "dd";
            this.coldd.Name = "coldd";
            this.coldd.Visible = true;
            this.coldd.VisibleIndex = 8;
            this.coldd.Width = 51;
            // 
            // coltaikhoan
            // 
            this.coltaikhoan.Caption = "Số Tài Khoản";
            this.coltaikhoan.FieldName = "taikhoan";
            this.coltaikhoan.Name = "coltaikhoan";
            this.coltaikhoan.Visible = true;
            this.coltaikhoan.VisibleIndex = 9;
            this.coltaikhoan.Width = 51;
            // 
            // colnganhang
            // 
            this.colnganhang.Caption = "Ngân Hàng";
            this.colnganhang.FieldName = "nganhang";
            this.colnganhang.Name = "colnganhang";
            this.colnganhang.Visible = true;
            this.colnganhang.VisibleIndex = 10;
            this.colnganhang.Width = 69;
            // 
            // colmanv
            // 
            this.colmanv.FieldName = "manv";
            this.colmanv.Name = "colmanv";
            // 
            // colmadv
            // 
            this.colmadv.FieldName = "madv";
            this.colmadv.Name = "colmadv";
            // 
            // f_dsdoituong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 364);
            this.Name = "f_dsdoituong";
            this.Text = "Danh Sách Đối Tượng";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doituongBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource doituongBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colnhom;
        private DevExpress.XtraGrid.Columns.GridColumn colloai;
        private DevExpress.XtraGrid.Columns.GridColumn coldiachi;
        private DevExpress.XtraGrid.Columns.GridColumn colmsthue;
        private DevExpress.XtraGrid.Columns.GridColumn coldienthoai;
        private DevExpress.XtraGrid.Columns.GridColumn colemail;
        private DevExpress.XtraGrid.Columns.GridColumn colfax;
        private DevExpress.XtraGrid.Columns.GridColumn coldd;
        private DevExpress.XtraGrid.Columns.GridColumn coltaikhoan;
        private DevExpress.XtraGrid.Columns.GridColumn colnganhang;
        private DevExpress.XtraGrid.Columns.GridColumn colmanv;
        private DevExpress.XtraGrid.Columns.GridColumn colmadv;
    }
}