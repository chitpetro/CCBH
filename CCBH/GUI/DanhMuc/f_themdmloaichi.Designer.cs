namespace GUI.DanhMuc
{
    partial class f_themdmloaichi
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dmloaichiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaichiTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.chiphiCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForloaichi = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForchiphi = new DevExpress.XtraLayout.LayoutControlItem();
            this.congnoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemForcongno = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloaichiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaichiTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiphiCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaichi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForchiphi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.congnoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcongno)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.loaichiTextEdit);
            this.dataLayoutControl1.Controls.Add(this.chiphiCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.congnoCheckEdit);
            this.dataLayoutControl1.DataSource = this.dmloaichiBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(504, 96);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaichiBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(56, 12);
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(194, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // dmloaichiBindingSource
            // 
            this.dmloaichiBindingSource.DataSource = typeof(DAL.dmloaichi);
            // 
            // loaichiTextEdit
            // 
            this.loaichiTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaichiBindingSource, "loaichi", true));
            this.loaichiTextEdit.Location = new System.Drawing.Point(56, 36);
            this.loaichiTextEdit.Name = "loaichiTextEdit";
            this.loaichiTextEdit.Size = new System.Drawing.Size(436, 20);
            this.loaichiTextEdit.StyleController = this.dataLayoutControl1;
            this.loaichiTextEdit.TabIndex = 5;
            // 
            // chiphiCheckEdit
            // 
            this.chiphiCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaichiBindingSource, "chiphi", true));
            this.chiphiCheckEdit.Location = new System.Drawing.Point(56, 60);
            this.chiphiCheckEdit.Name = "chiphiCheckEdit";
            this.chiphiCheckEdit.Properties.Caption = "";
            this.chiphiCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chiphiCheckEdit.Size = new System.Drawing.Size(194, 19);
            this.chiphiCheckEdit.StyleController = this.dataLayoutControl1;
            this.chiphiCheckEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(504, 96);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForloaichi,
            this.emptySpaceItem1,
            this.ItemForchiphi,
            this.ItemForcongno});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(484, 76);
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(242, 24);
            this.ItemForid.Text = "ID";
            this.ItemForid.TextSize = new System.Drawing.Size(41, 13);
            // 
            // ItemForloaichi
            // 
            this.ItemForloaichi.Control = this.loaichiTextEdit;
            this.ItemForloaichi.Location = new System.Drawing.Point(0, 24);
            this.ItemForloaichi.Name = "ItemForloaichi";
            this.ItemForloaichi.Size = new System.Drawing.Size(484, 24);
            this.ItemForloaichi.Text = "Loại Chi";
            this.ItemForloaichi.TextSize = new System.Drawing.Size(41, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(242, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(242, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForchiphi
            // 
            this.ItemForchiphi.Control = this.chiphiCheckEdit;
            this.ItemForchiphi.Location = new System.Drawing.Point(0, 48);
            this.ItemForchiphi.Name = "ItemForchiphi";
            this.ItemForchiphi.Size = new System.Drawing.Size(242, 28);
            this.ItemForchiphi.Text = "Chi Phí";
            this.ItemForchiphi.TextSize = new System.Drawing.Size(41, 13);
            // 
            // congnoCheckEdit
            // 
            this.congnoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaichiBindingSource, "congno", true));
            this.congnoCheckEdit.Location = new System.Drawing.Point(298, 60);
            this.congnoCheckEdit.Name = "congnoCheckEdit";
            this.congnoCheckEdit.Properties.Caption = "";
            this.congnoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.congnoCheckEdit.Size = new System.Drawing.Size(194, 19);
            this.congnoCheckEdit.StyleController = this.dataLayoutControl1;
            this.congnoCheckEdit.TabIndex = 7;
            // 
            // ItemForcongno
            // 
            this.ItemForcongno.Control = this.congnoCheckEdit;
            this.ItemForcongno.Location = new System.Drawing.Point(242, 48);
            this.ItemForcongno.Name = "ItemForcongno";
            this.ItemForcongno.Size = new System.Drawing.Size(242, 28);
            this.ItemForcongno.Text = "Công Nợ";
            this.ItemForcongno.TextSize = new System.Drawing.Size(41, 13);
            // 
            // f_themdmloaichi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 143);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_themdmloaichi";
            this.Text = "Danh Mục Loại Chi";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloaichiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaichiTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiphiCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaichi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForchiphi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.congnoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcongno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource dmloaichiBindingSource;
        private DevExpress.XtraEditors.TextEdit loaichiTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloaichi;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.CheckEdit chiphiCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForchiphi;
        private DevExpress.XtraEditors.CheckEdit congnoCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcongno;
    }
}