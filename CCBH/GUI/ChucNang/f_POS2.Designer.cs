using System;
using System.Windows.Forms;

namespace GUI.ChucNang
{
    partial class f_POS2
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
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_POS2));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblteniddt = new DevExpress.XtraEditors.LabelControl();
            this.txtphone = new DevExpress.XtraEditors.TextEdit();
            this.txtiddt = new DevExpress.XtraEditors.TextEdit();
            this.txttong = new DevExpress.XtraEditors.SpinEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtusd = new DevExpress.XtraEditors.SpinEdit();
            this.txtbath = new DevExpress.XtraEditors.SpinEdit();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.pxuatctBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkeypx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidsp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.coldongia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnguyente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthanhtien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sluidsp = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.dmsanphamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lobath = new DevExpress.XtraLayout.LayoutControlItem();
            this.lousd = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.playvideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.spn2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtiddt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxuatctBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluidsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmsanphamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lousd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playvideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lblteniddt);
            this.layoutControl1.Controls.Add(this.txtphone);
            this.layoutControl1.Controls.Add(this.txtiddt);
            this.layoutControl1.Controls.Add(this.txttong);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(923, 120);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblteniddt
            // 
            this.lblteniddt.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblteniddt.Appearance.Options.UseFont = true;
            this.lblteniddt.Location = new System.Drawing.Point(215, 42);
            this.lblteniddt.Name = "lblteniddt";
            this.lblteniddt.Size = new System.Drawing.Size(251, 26);
            this.lblteniddt.StyleController = this.layoutControl1;
            this.lblteniddt.TabIndex = 7;
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(57, 72);
            this.txtphone.Name = "txtphone";
            this.txtphone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.Properties.Appearance.Options.UseFont = true;
            this.txtphone.Properties.ReadOnly = true;
            this.txtphone.Size = new System.Drawing.Size(409, 26);
            this.txtphone.StyleController = this.layoutControl1;
            this.txtphone.TabIndex = 6;
            // 
            // txtiddt
            // 
            this.txtiddt.Location = new System.Drawing.Point(57, 42);
            this.txtiddt.Name = "txtiddt";
            this.txtiddt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtiddt.Properties.Appearance.Options.UseFont = true;
            this.txtiddt.Properties.ReadOnly = true;
            this.txtiddt.Size = new System.Drawing.Size(154, 26);
            this.txtiddt.StyleController = this.layoutControl1;
            this.txtiddt.TabIndex = 5;
            this.txtiddt.EditValueChanged += new System.EventHandler(this.txtiddt_EditValueChanged);
            // 
            // txttong
            // 
            this.txttong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txttong.Location = new System.Drawing.Point(494, 42);
            this.txttong.Name = "txttong";
            this.txttong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttong.Properties.Appearance.Options.UseFont = true;
            this.txttong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txttong.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txttong.Properties.Mask.EditMask = "n2";
            this.txttong.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txttong.Properties.ReadOnly = true;
            this.txttong.Size = new System.Drawing.Size(388, 54);
            this.txttong.StyleController = this.layoutControl1;
            this.txttong.TabIndex = 4;
            this.txttong.EditValueChanged += new System.EventHandler(this.txttong_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(906, 122);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(470, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(416, 102);
            this.layoutControlGroup3.Text = "Total (Kip)";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txttong;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(54, 58);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(392, 60);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(470, 102);
            this.layoutControlGroup4.Text = "Customer";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtiddt;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(191, 30);
            this.layoutControlItem2.Text = "ID";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtphone;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(446, 30);
            this.layoutControlItem3.Text = "Phone";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(30, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lblteniddt;
            this.layoutControlItem4.Location = new System.Drawing.Point(191, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(255, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtusd);
            this.layoutControl2.Controls.Add(this.txtbath);
            this.layoutControl2.Controls.Add(this.gd);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.layoutControl2.Location = new System.Drawing.Point(469, 120);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(454, 380);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtusd
            // 
            this.txtusd.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtusd.Location = new System.Drawing.Point(37, 348);
            this.txtusd.Name = "txtusd";
            this.txtusd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtusd.Properties.Appearance.Options.UseFont = true;
            this.txtusd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtusd.Properties.Mask.EditMask = "n2";
            this.txtusd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtusd.Properties.ReadOnly = true;
            this.txtusd.Size = new System.Drawing.Size(405, 26);
            this.txtusd.StyleController = this.layoutControl2;
            this.txtusd.TabIndex = 6;
            // 
            // txtbath
            // 
            this.txtbath.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtbath.Location = new System.Drawing.Point(37, 324);
            this.txtbath.Name = "txtbath";
            this.txtbath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtbath.Properties.Appearance.Options.UseFont = true;
            this.txtbath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtbath.Properties.Mask.EditMask = "n2";
            this.txtbath.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtbath.Properties.ReadOnly = true;
            this.txtbath.Size = new System.Drawing.Size(405, 26);
            this.txtbath.StyleController = this.layoutControl2;
            this.txtbath.TabIndex = 5;
            // 
            // gd
            // 
            this.gd.DataSource = this.pxuatctBindingSource;
            this.gd.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gd.Location = new System.Drawing.Point(12, 12);
            this.gd.MainView = this.gv;
            this.gd.Name = "gd";
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.sluidsp,
            this.spn,
            this.spn2});
            this.gd.Size = new System.Drawing.Size(430, 308);
            this.gd.TabIndex = 4;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // pxuatctBindingSource
            // 
            this.pxuatctBindingSource.DataSource = typeof(DAL.pxuatct);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colkey,
            this.colkeypx,
            this.colidsp,
            this.colsoluong,
            this.coldongia,
            this.colnguyente,
            this.colthanhtien,
            this.colghichu,
            this.colstt,
            this.gridColumn1,
            this.gridColumn2});
            this.gv.GridControl = this.gd;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_CustomDrawRowIndicator);
            this.gv.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gv_InitNewRow);
            // 
            // colkey
            // 
            this.colkey.FieldName = "key";
            this.colkey.Name = "colkey";
            // 
            // colkeypx
            // 
            this.colkeypx.FieldName = "keypx";
            this.colkeypx.Name = "colkeypx";
            // 
            // colidsp
            // 
            this.colidsp.FieldName = "idsp";
            this.colidsp.Name = "colidsp";
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Amount";
            this.colsoluong.ColumnEdit = this.spn2;
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soluong", "{0:n2}")});
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 1;
            this.colsoluong.Width = 91;
            // 
            // spn
            // 
            this.spn.AutoHeight = false;
            this.spn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spn.Mask.EditMask = "n0";
            this.spn.Mask.UseMaskAsDisplayFormat = true;
            this.spn.Name = "spn";
            // 
            // coldongia
            // 
            this.coldongia.Caption = "Price";
            this.coldongia.ColumnEdit = this.spn;
            this.coldongia.FieldName = "dongia";
            this.coldongia.Name = "coldongia";
            this.coldongia.Visible = true;
            this.coldongia.VisibleIndex = 2;
            this.coldongia.Width = 91;
            // 
            // colnguyente
            // 
            this.colnguyente.FieldName = "nguyente";
            this.colnguyente.Name = "colnguyente";
            // 
            // colthanhtien
            // 
            this.colthanhtien.Caption = "Total";
            this.colthanhtien.ColumnEdit = this.spn;
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", "{0:n0}")});
            this.colthanhtien.Visible = true;
            this.colthanhtien.VisibleIndex = 4;
            this.colthanhtien.Width = 91;
            // 
            // colghichu
            // 
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            // 
            // colstt
            // 
            this.colstt.FieldName = "stt";
            this.colstt.Name = "colstt";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Item";
            this.gridColumn1.ColumnEdit = this.sluidsp;
            this.gridColumn1.FieldName = "idsp";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 139;
            // 
            // sluidsp
            // 
            this.sluidsp.AutoHeight = false;
            this.sluidsp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluidsp.DataSource = this.dmsanphamBindingSource;
            this.sluidsp.DisplayMember = "tensp";
            this.sluidsp.Name = "sluidsp";
            this.sluidsp.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.sluidsp.ValueMember = "id";
            // 
            // dmsanphamBindingSource
            // 
            this.dmsanphamBindingSource.DataSource = typeof(DAL.dmsanpham);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Discount";
            this.gridColumn2.ColumnEdit = this.spn;
            this.gridColumn2.FieldName = "chietkhau";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "chietkhau", "{0:n0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.lobath,
            this.lousd});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(454, 380);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gd;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(434, 312);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // lobath
            // 
            this.lobath.Control = this.txtbath;
            this.lobath.Location = new System.Drawing.Point(0, 312);
            this.lobath.MinSize = new System.Drawing.Size(79, 24);
            this.lobath.Name = "lobath";
            this.lobath.Size = new System.Drawing.Size(434, 24);
            this.lobath.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lobath.Text = "Bath";
            this.lobath.TextSize = new System.Drawing.Size(22, 13);
            // 
            // lousd
            // 
            this.lousd.Control = this.txtusd;
            this.lousd.Location = new System.Drawing.Point(0, 336);
            this.lousd.MinSize = new System.Drawing.Size(79, 24);
            this.lousd.Name = "lousd";
            this.lousd.Size = new System.Drawing.Size(434, 24);
            this.lousd.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lousd.Text = "USD";
            this.lousd.TextSize = new System.Drawing.Size(22, 13);
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.playvideo);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(0, 120);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(469, 380);
            this.layoutControl3.TabIndex = 2;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // playvideo
            // 
            this.playvideo.Enabled = true;
            this.playvideo.Location = new System.Drawing.Point(12, 12);
            this.playvideo.Name = "playvideo";
            this.playvideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("playvideo.OcxState")));
            this.playvideo.Size = new System.Drawing.Size(445, 356);
            this.playvideo.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(469, 380);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.playvideo;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(449, 360);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // spn2
            // 
            this.spn2.AutoHeight = false;
            this.spn2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spn2.Mask.EditMask = "n2";
            this.spn2.Mask.UseMaskAsDisplayFormat = true;
            this.spn2.Name = "spn2";
            // 
            // f_POS2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 500);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl3);
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_POS2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.f_POS2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtiddt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtusd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxuatctBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluidsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmsanphamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lousd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playvideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.LabelControl lblteniddt;
        private DevExpress.XtraEditors.TextEdit txtphone;
        private DevExpress.XtraEditors.TextEdit txtiddt;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private AxWMPLib.AxWindowsMediaPlayer playvideo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource pxuatctBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colkeypx;
        private DevExpress.XtraGrid.Columns.GridColumn colidsp;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn coldongia;
        private DevExpress.XtraGrid.Columns.GridColumn colnguyente;
        private DevExpress.XtraGrid.Columns.GridColumn colthanhtien;
        private DevExpress.XtraGrid.Columns.GridColumn colghichu;
        private DevExpress.XtraGrid.Columns.GridColumn colstt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit sluidsp;
        private System.Windows.Forms.BindingSource dmsanphamBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.SpinEdit txttong;
        private DevExpress.XtraEditors.SpinEdit txtusd;
        private DevExpress.XtraEditors.SpinEdit txtbath;
        private DevExpress.XtraLayout.LayoutControlItem lobath;
        private DevExpress.XtraLayout.LayoutControlItem lousd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spn2;
    }
}