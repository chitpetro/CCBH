namespace GUI.ChucNang
{
    partial class f_dsthutienbanhang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dsthutienbanhang));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.pttBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaythu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltygia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.collink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltienthu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltientra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pttBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gd);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(687, 415);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gd
            // 
            this.gd.DataSource = this.pttBindingSource;
            this.gd.Location = new System.Drawing.Point(12, 12);
            this.gd.MainView = this.gv;
            this.gd.Name = "gd";
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.spn});
            this.gd.Size = new System.Drawing.Size(663, 391);
            this.gd.TabIndex = 4;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // pttBindingSource
            // 
            this.pttBindingSource.DataSource = typeof(DAL.ptt);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colkey,
            this.colid,
            this.colngaythu,
            this.colidnv,
            this.coliddt,
            this.colso,
            this.coliddv,
            this.coltiente,
            this.coltygia,
            this.collink,
            this.coltienthu,
            this.coltientra,
            this.coltt});
            this.gv.GridControl = this.gd;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.collink, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gv.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gv_RowClick);
            this.gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_CustomDrawRowIndicator);
            this.gv.Click += new System.EventHandler(this.gv_Click);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colkey
            // 
            this.colkey.FieldName = "key";
            this.colkey.Name = "colkey";
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colngaythu
            // 
            this.colngaythu.Caption = "Ngày Thu Tiền";
            this.colngaythu.FieldName = "ngaythu";
            this.colngaythu.Name = "colngaythu";
            this.colngaythu.Visible = true;
            this.colngaythu.VisibleIndex = 1;
            this.colngaythu.Width = 71;
            // 
            // colidnv
            // 
            this.colidnv.Caption = "Mã Nhân Viên";
            this.colidnv.FieldName = "idnv";
            this.colidnv.Name = "colidnv";
            this.colidnv.Visible = true;
            this.colidnv.VisibleIndex = 7;
            this.colidnv.Width = 64;
            // 
            // coliddt
            // 
            this.coliddt.Caption = "Đối Tượng";
            this.coliddt.FieldName = "iddt";
            this.coliddt.Name = "coliddt";
            this.coliddt.Width = 71;
            // 
            // colso
            // 
            this.colso.FieldName = "so";
            this.colso.Name = "colso";
            // 
            // coliddv
            // 
            this.coliddv.Caption = "Đơn Vị";
            this.coliddv.FieldName = "iddv";
            this.coliddv.Name = "coliddv";
            this.coliddv.Visible = true;
            this.coliddv.VisibleIndex = 0;
            this.coliddv.Width = 71;
            // 
            // coltiente
            // 
            this.coltiente.Caption = "Tiền Tệ";
            this.coltiente.FieldName = "tiente";
            this.coltiente.Name = "coltiente";
            this.coltiente.Visible = true;
            this.coltiente.VisibleIndex = 2;
            this.coltiente.Width = 71;
            // 
            // coltygia
            // 
            this.coltygia.Caption = "Tỷ Giá";
            this.coltygia.ColumnEdit = this.spn;
            this.coltygia.FieldName = "tygia";
            this.coltygia.Name = "coltygia";
            this.coltygia.Visible = true;
            this.coltygia.VisibleIndex = 3;
            this.coltygia.Width = 71;
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
            // collink
            // 
            this.collink.FieldName = "link";
            this.collink.Name = "collink";
            // 
            // coltienthu
            // 
            this.coltienthu.Caption = "Tiền Nhận";
            this.coltienthu.ColumnEdit = this.spn;
            this.coltienthu.FieldName = "tienthu";
            this.coltienthu.Name = "coltienthu";
            this.coltienthu.Visible = true;
            this.coltienthu.VisibleIndex = 4;
            this.coltienthu.Width = 71;
            // 
            // coltientra
            // 
            this.coltientra.Caption = "Tiền Thối";
            this.coltientra.ColumnEdit = this.spn;
            this.coltientra.FieldName = "tientra";
            this.coltientra.Name = "coltientra";
            this.coltientra.Visible = true;
            this.coltientra.VisibleIndex = 5;
            this.coltientra.Width = 71;
            // 
            // coltt
            // 
            this.coltt.Caption = "Thành Tiền (KIP)";
            this.coltt.ColumnEdit = this.spn;
            this.coltt.FieldName = "thanhtientt";
            this.coltt.Name = "coltt";
            this.coltt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtientt", "{0:n2}")});
            this.coltt.Visible = true;
            this.coltt.VisibleIndex = 6;
            this.coltt.Width = 84;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(687, 415);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(667, 395);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // f_dsthutienbanhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 415);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_dsthutienbanhang";
            this.Text = "Danh Sách Phiếu Thu Tiền Bán Hàng";
            this.Load += new System.EventHandler(this.f_dsthutienbanhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pttBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource pttBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colngaythu;
        private DevExpress.XtraGrid.Columns.GridColumn colidnv;
        private DevExpress.XtraGrid.Columns.GridColumn coliddt;
        private DevExpress.XtraGrid.Columns.GridColumn colso;
        private DevExpress.XtraGrid.Columns.GridColumn coliddv;
        private DevExpress.XtraGrid.Columns.GridColumn coltiente;
        private DevExpress.XtraGrid.Columns.GridColumn coltygia;
        private DevExpress.XtraGrid.Columns.GridColumn collink;
        private DevExpress.XtraGrid.Columns.GridColumn coltienthu;
        private DevExpress.XtraGrid.Columns.GridColumn coltientra;
        private DevExpress.XtraGrid.Columns.GridColumn coltt;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spn;
    }
}