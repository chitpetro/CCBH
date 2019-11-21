namespace GUI.ChucNang
{
    partial class f_dspchi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dspchi));
            this.sPLayDSPChiResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaychi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidloaichi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaichi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphongban = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltendt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiengiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltendonvi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltygia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnguyente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthanhtien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLayDSPChiResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Size = new System.Drawing.Size(1057, 437);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            this.layoutControl1.Controls.SetChildIndex(this.thoigian, 0);
            this.layoutControl1.Controls.SetChildIndex(this.tungay, 0);
            this.layoutControl1.Controls.SetChildIndex(this.denngay, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnsearh, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnsearchall, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnxls, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnin, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(1057, 437);
            // 
            // gd
            // 
            this.gd.DataSource = this.sPLayDSPChiResultBindingSource;
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.spn});
            this.gd.Size = new System.Drawing.Size(1033, 345);
            this.gd.TabIndex = 8;
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colkey,
            this.colid,
            this.colngaychi,
            this.colidloaichi,
            this.colloaichi,
            this.colidnv,
            this.coltenidnv,
            this.colphongban,
            this.coliddt,
            this.coltendt,
            this.coldiengiai,
            this.colso,
            this.coliddv,
            this.coltendonvi,
            this.coltiente,
            this.coltygia,
            this.colnguyente,
            this.colthanhtien,
            this.colghichu,
            this.colstt});
            this.gv.GroupCount = 1;
            this.gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", this.colthanhtien, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nguyente", this.colnguyente, "{0:n2}")});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsPrint.RtfReportHeader = resources.GetString("gv.OptionsPrint.RtfReportHeader");
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colid, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(1037, 349);
            // 
            // btnin
            // 
            this.btnin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnin.ImageOptions.Image")));
            this.btnin.TabIndex = 7;
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.Image")));
            this.btnxls.TabIndex = 6;
            // 
            // btnsearchall
            // 
            this.btnsearchall.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearchall.ImageOptions.Image")));
            this.btnsearchall.TabIndex = 5;
            // 
            // btnsearh
            // 
            this.btnsearh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearh.ImageOptions.Image")));
            this.btnsearh.TabIndex = 4;
            // 
            // denngay
            // 
            this.denngay.EditValue = new System.DateTime(2019, 7, 31, 0, 0, 0, 0);
            this.denngay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.denngay.TabIndex = 3;
            // 
            // tungay
            // 
            this.tungay.EditValue = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            this.tungay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tungay.TabIndex = 2;
            // 
            // thoigian
            // 
            this.thoigian.EditValue = "Tháng Này";
            this.thoigian.TabIndex = 0;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(85, 68);
            // 
            // sPLayDSPChiResultBindingSource
            // 
            this.sPLayDSPChiResultBindingSource.DataSource = typeof(DAL.SP_LayDSPChiResult);
            // 
            // colkey
            // 
            this.colkey.FieldName = "key";
            this.colkey.Name = "colkey";
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colngaychi
            // 
            this.colngaychi.Caption = "Ngày Chi";
            this.colngaychi.FieldName = "ngaychi";
            this.colngaychi.Name = "colngaychi";
            this.colngaychi.Visible = true;
            this.colngaychi.VisibleIndex = 1;
            this.colngaychi.Width = 108;
            // 
            // colidloaichi
            // 
            this.colidloaichi.FieldName = "idloaichi";
            this.colidloaichi.Name = "colidloaichi";
            // 
            // colloaichi
            // 
            this.colloaichi.Caption = "Loại Chi";
            this.colloaichi.FieldName = "loaichi";
            this.colloaichi.Name = "colloaichi";
            this.colloaichi.Visible = true;
            this.colloaichi.VisibleIndex = 2;
            this.colloaichi.Width = 94;
            // 
            // colidnv
            // 
            this.colidnv.FieldName = "idnv";
            this.colidnv.Name = "colidnv";
            // 
            // coltenidnv
            // 
            this.coltenidnv.Caption = "Người Lập";
            this.coltenidnv.FieldName = "tenidnv";
            this.coltenidnv.Name = "coltenidnv";
            this.coltenidnv.Visible = true;
            this.coltenidnv.VisibleIndex = 3;
            this.coltenidnv.Width = 83;
            // 
            // colphongban
            // 
            this.colphongban.Caption = "Phòng Ban";
            this.colphongban.FieldName = "phongban";
            this.colphongban.Name = "colphongban";
            this.colphongban.Visible = true;
            this.colphongban.VisibleIndex = 4;
            this.colphongban.Width = 68;
            // 
            // coliddt
            // 
            this.coliddt.Caption = "Mã Đối Tượng";
            this.coliddt.FieldName = "iddt";
            this.coliddt.Name = "coliddt";
            this.coliddt.Visible = true;
            this.coliddt.VisibleIndex = 5;
            this.coliddt.Width = 68;
            // 
            // coltendt
            // 
            this.coltendt.Caption = "Tên Đối Tượng";
            this.coltendt.FieldName = "tendt";
            this.coltendt.Name = "coltendt";
            this.coltendt.Visible = true;
            this.coltendt.VisibleIndex = 6;
            this.coltendt.Width = 68;
            // 
            // coldiengiai
            // 
            this.coldiengiai.Caption = "Diễn Giải";
            this.coldiengiai.FieldName = "diengiai";
            this.coldiengiai.Name = "coldiengiai";
            this.coldiengiai.Visible = true;
            this.coldiengiai.VisibleIndex = 0;
            this.coldiengiai.Width = 125;
            // 
            // colso
            // 
            this.colso.FieldName = "so";
            this.colso.Name = "colso";
            // 
            // coliddv
            // 
            this.coliddv.FieldName = "iddv";
            this.coliddv.Name = "coliddv";
            // 
            // coltendonvi
            // 
            this.coltendonvi.Caption = "Đơn Vị";
            this.coltendonvi.FieldName = "tendonvi";
            this.coltendonvi.Name = "coltendonvi";
            this.coltendonvi.Visible = true;
            this.coltendonvi.VisibleIndex = 12;
            this.coltendonvi.Width = 97;
            // 
            // coltiente
            // 
            this.coltiente.Caption = "Tiền Tệ";
            this.coltiente.FieldName = "tiente";
            this.coltiente.Name = "coltiente";
            this.coltiente.Visible = true;
            this.coltiente.VisibleIndex = 7;
            this.coltiente.Width = 57;
            // 
            // coltygia
            // 
            this.coltygia.Caption = "Tỷ Giá";
            this.coltygia.ColumnEdit = this.spn;
            this.coltygia.FieldName = "tygia";
            this.coltygia.Name = "coltygia";
            this.coltygia.Visible = true;
            this.coltygia.VisibleIndex = 8;
            this.coltygia.Width = 50;
            // 
            // colnguyente
            // 
            this.colnguyente.Caption = "Nguyên tệ";
            this.colnguyente.ColumnEdit = this.spn;
            this.colnguyente.FieldName = "nguyente";
            this.colnguyente.Name = "colnguyente";
            this.colnguyente.Visible = true;
            this.colnguyente.VisibleIndex = 9;
            this.colnguyente.Width = 74;
            // 
            // colthanhtien
            // 
            this.colthanhtien.Caption = "Thành Tiền";
            this.colthanhtien.ColumnEdit = this.spn;
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", "{0:n2}")});
            this.colthanhtien.Visible = true;
            this.colthanhtien.VisibleIndex = 10;
            this.colthanhtien.Width = 74;
            // 
            // colghichu
            // 
            this.colghichu.Caption = "Ghi Chú";
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            this.colghichu.Visible = true;
            this.colghichu.VisibleIndex = 11;
            this.colghichu.Width = 74;
            // 
            // colstt
            // 
            this.colstt.FieldName = "stt";
            this.colstt.Name = "colstt";
            // 
            // spn
            // 
            this.spn.AutoHeight = false;
            this.spn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spn.Mask.EditMask = "n2";
            this.spn.Mask.UseMaskAsDisplayFormat = true;
            this.spn.Name = "spn";
            // 
            // f_dspchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 437);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "f_dspchi";
            this.Text = "Danh Sách Phiếu Chi";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLayDSPChiResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sPLayDSPChiResultBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spn;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colngaychi;
        private DevExpress.XtraGrid.Columns.GridColumn colidloaichi;
        private DevExpress.XtraGrid.Columns.GridColumn colloaichi;
        private DevExpress.XtraGrid.Columns.GridColumn colidnv;
        private DevExpress.XtraGrid.Columns.GridColumn coltenidnv;
        private DevExpress.XtraGrid.Columns.GridColumn colphongban;
        private DevExpress.XtraGrid.Columns.GridColumn coliddt;
        private DevExpress.XtraGrid.Columns.GridColumn coltendt;
        private DevExpress.XtraGrid.Columns.GridColumn coldiengiai;
        private DevExpress.XtraGrid.Columns.GridColumn colso;
        private DevExpress.XtraGrid.Columns.GridColumn coliddv;
        private DevExpress.XtraGrid.Columns.GridColumn coltendonvi;
        private DevExpress.XtraGrid.Columns.GridColumn coltiente;
        private DevExpress.XtraGrid.Columns.GridColumn coltygia;
        private DevExpress.XtraGrid.Columns.GridColumn colnguyente;
        private DevExpress.XtraGrid.Columns.GridColumn colthanhtien;
        private DevExpress.XtraGrid.Columns.GridColumn colghichu;
        private DevExpress.XtraGrid.Columns.GridColumn colstt;
    }
}