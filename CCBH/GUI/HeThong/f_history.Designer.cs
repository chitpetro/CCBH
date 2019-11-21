namespace GUI.HeThong
{
    partial class f_history
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_history));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnsearh = new DevExpress.XtraEditors.SimpleButton();
            this.denngay = new DevExpress.XtraEditors.DateEdit();
            this.tungay = new DevExpress.XtraEditors.DateEdit();
            this.thoigian = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sPLayHisResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhoatdong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnguoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthoigian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldonvi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collayma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLayHisResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gd);
            this.layoutControl1.Controls.Add(this.btnsearh);
            this.layoutControl1.Controls.Add(this.denngay);
            this.layoutControl1.Controls.Add(this.tungay);
            this.layoutControl1.Controls.Add(this.thoigian);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(713, 497);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gd
            // 
            this.gd.DataSource = this.sPLayHisResultBindingSource;
            this.gd.Location = new System.Drawing.Point(12, 38);
            this.gd.MainView = this.gv;
            this.gd.Name = "gd";
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gd.Size = new System.Drawing.Size(689, 447);
            this.gd.TabIndex = 8;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colma,
            this.colhoatdong,
            this.colnguoi,
            this.colmay,
            this.colthoigian,
            this.colid,
            this.coldonvi,
            this.collayma});
            this.gv.GridControl = this.gd;
            this.gv.Name = "gv";
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colthoigian, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_CustomDrawRowIndicator);
            // 
            // btnsearh
            // 
            this.btnsearh.ImageOptions.Image = global::GUI.Properties.Resources.lookup_reference_16x161;
            this.btnsearh.Location = new System.Drawing.Point(610, 12);
            this.btnsearh.Name = "btnsearh";
            this.btnsearh.Size = new System.Drawing.Size(91, 22);
            this.btnsearh.StyleController = this.layoutControl1;
            this.btnsearh.TabIndex = 7;
            this.btnsearh.Text = "Xem";
            // 
            // denngay
            // 
            this.denngay.EditValue = null;
            this.denngay.Location = new System.Drawing.Point(494, 12);
            this.denngay.Name = "denngay";
            this.denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.denngay.Size = new System.Drawing.Size(112, 20);
            this.denngay.StyleController = this.layoutControl1;
            this.denngay.TabIndex = 6;
            // 
            // tungay
            // 
            this.tungay.EditValue = null;
            this.tungay.Location = new System.Drawing.Point(293, 12);
            this.tungay.Name = "tungay";
            this.tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tungay.Size = new System.Drawing.Size(122, 20);
            this.tungay.StyleController = this.layoutControl1;
            this.tungay.TabIndex = 5;
            // 
            // thoigian
            // 
            this.thoigian.Location = new System.Drawing.Point(87, 12);
            this.thoigian.Name = "thoigian";
            this.thoigian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.thoigian.Properties.Items.AddRange(new object[] {
            "Tùy Ý",
            "Hôm Nay",
            "Tháng Nay",
            "Tháng 01",
            "Tháng 02",
            "Tháng 03",
            "Tháng 04",
            "Tháng 05",
            "Tháng 06",
            "Tháng 07",
            "Tháng 08",
            "Tháng 09",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12",
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4",
            "6 Tháng Đầu Năm",
            "6 Tháng Cuối Năm",
            "Cả Năm"});
            this.thoigian.Size = new System.Drawing.Size(127, 20);
            this.thoigian.StyleController = this.layoutControl1;
            this.thoigian.TabIndex = 4;
            this.thoigian.SelectedIndexChanged += new System.EventHandler(this.thoigian_SelectedIndexChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(713, 497);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.thoigian;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(206, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(206, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(206, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Chọn Thời Gian";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tungay;
            this.layoutControlItem2.Location = new System.Drawing.Point(206, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(201, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(201, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(201, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Từ Ngày";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.denngay;
            this.layoutControlItem3.Location = new System.Drawing.Point(407, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(191, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(191, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(191, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Đến Ngày";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnsearh;
            this.layoutControlItem4.Location = new System.Drawing.Point(598, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gd;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(693, 451);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // sPLayHisResultBindingSource
            // 
            this.sPLayHisResultBindingSource.DataSource = typeof(DAL.SP_LayHisResult);
            // 
            // colma
            // 
            this.colma.Caption = "Số Chứng Từ";
            this.colma.FieldName = "ma";
            this.colma.Name = "colma";
            this.colma.Visible = true;
            this.colma.VisibleIndex = 2;
            // 
            // colhoatdong
            // 
            this.colhoatdong.Caption = "Hoạt Động";
            this.colhoatdong.FieldName = "hoatdong";
            this.colhoatdong.Name = "colhoatdong";
            this.colhoatdong.Visible = true;
            this.colhoatdong.VisibleIndex = 1;
            // 
            // colnguoi
            // 
            this.colnguoi.Caption = "Tài Khoản";
            this.colnguoi.FieldName = "nguoi";
            this.colnguoi.Name = "colnguoi";
            this.colnguoi.Visible = true;
            this.colnguoi.VisibleIndex = 3;
            // 
            // colmay
            // 
            this.colmay.Caption = "Máy Trạm - IP";
            this.colmay.FieldName = "may";
            this.colmay.Name = "colmay";
            this.colmay.Visible = true;
            this.colmay.VisibleIndex = 4;
            // 
            // colthoigian
            // 
            this.colthoigian.Caption = "Thoài Gian";
            this.colthoigian.ColumnEdit = this.repositoryItemDateEdit1;
            this.colthoigian.FieldName = "thoigian";
            this.colthoigian.Name = "colthoigian";
            this.colthoigian.Visible = true;
            this.colthoigian.VisibleIndex = 5;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // coldonvi
            // 
            this.coldonvi.Caption = "Đơn Vị";
            this.coldonvi.FieldName = "donvi";
            this.coldonvi.Name = "coldonvi";
            this.coldonvi.Visible = true;
            this.coldonvi.VisibleIndex = 0;
            // 
            // collayma
            // 
            this.collayma.FieldName = "layma";
            this.collayma.Name = "collayma";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // f_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 497);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_history";
            this.Text = "f_history";
            this.Load += new System.EventHandler(this.f_history_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLayHisResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.SimpleButton btnsearh;
        private DevExpress.XtraEditors.DateEdit denngay;
        private DevExpress.XtraEditors.DateEdit tungay;
        private DevExpress.XtraEditors.ComboBoxEdit thoigian;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource sPLayHisResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colma;
        private DevExpress.XtraGrid.Columns.GridColumn colhoatdong;
        private DevExpress.XtraGrid.Columns.GridColumn colnguoi;
        private DevExpress.XtraGrid.Columns.GridColumn colmay;
        private DevExpress.XtraGrid.Columns.GridColumn colthoigian;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn coldonvi;
        private DevExpress.XtraGrid.Columns.GridColumn collayma;
    }
}