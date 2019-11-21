namespace GUI.DanhMuc
{
    partial class f_loaixuat
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
            this.dmloaixuatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaixuatTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.doanhthuCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForloaixuat = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemFordoanhthu = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.noiboCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemFornoibo = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloaixuatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaixuatTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doanhthuCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaixuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordoanhthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiboCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFornoibo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.loaixuatTextEdit);
            this.dataLayoutControl1.Controls.Add(this.doanhthuCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.noiboCheckEdit);
            this.dataLayoutControl1.DataSource = this.dmloaixuatBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(418, 98);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaixuatBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(67, 9);
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(131, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // dmloaixuatBindingSource
            // 
            this.dmloaixuatBindingSource.DataSource = typeof(DAL.dmloaixuat);
            // 
            // loaixuatTextEdit
            // 
            this.loaixuatTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaixuatBindingSource, "loaixuat", true));
            this.loaixuatTextEdit.Location = new System.Drawing.Point(67, 33);
            this.loaixuatTextEdit.Name = "loaixuatTextEdit";
            this.loaixuatTextEdit.Size = new System.Drawing.Size(322, 20);
            this.loaixuatTextEdit.StyleController = this.dataLayoutControl1;
            this.loaixuatTextEdit.TabIndex = 5;
            // 
            // doanhthuCheckEdit
            // 
            this.doanhthuCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaixuatBindingSource, "doanhthu", true));
            this.doanhthuCheckEdit.Location = new System.Drawing.Point(67, 57);
            this.doanhthuCheckEdit.Name = "doanhthuCheckEdit";
            this.doanhthuCheckEdit.Properties.Caption = "";
            this.doanhthuCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.doanhthuCheckEdit.Size = new System.Drawing.Size(131, 19);
            this.doanhthuCheckEdit.StyleController = this.dataLayoutControl1;
            this.doanhthuCheckEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(401, 101);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForloaixuat,
            this.emptySpaceItem2,
            this.ItemFordoanhthu,
            this.emptySpaceItem1,
            this.ItemFornoibo});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(381, 81);
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(190, 24);
            this.ItemForid.Text = "ID";
            this.ItemForid.TextSize = new System.Drawing.Size(52, 13);
            // 
            // ItemForloaixuat
            // 
            this.ItemForloaixuat.Control = this.loaixuatTextEdit;
            this.ItemForloaixuat.Location = new System.Drawing.Point(0, 24);
            this.ItemForloaixuat.Name = "ItemForloaixuat";
            this.ItemForloaixuat.Size = new System.Drawing.Size(381, 24);
            this.ItemForloaixuat.Text = "Loại Xuất";
            this.ItemForloaixuat.TextSize = new System.Drawing.Size(52, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(190, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(191, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemFordoanhthu
            // 
            this.ItemFordoanhthu.Control = this.doanhthuCheckEdit;
            this.ItemFordoanhthu.Location = new System.Drawing.Point(0, 48);
            this.ItemFordoanhthu.MinSize = new System.Drawing.Size(78, 23);
            this.ItemFordoanhthu.Name = "ItemFordoanhthu";
            this.ItemFordoanhthu.Size = new System.Drawing.Size(190, 23);
            this.ItemFordoanhthu.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemFordoanhthu.Text = "Doanh Thu";
            this.ItemFordoanhthu.TextSize = new System.Drawing.Size(52, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 71);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(381, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // noiboCheckEdit
            // 
            this.noiboCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloaixuatBindingSource, "noibo", true));
            this.noiboCheckEdit.Location = new System.Drawing.Point(257, 57);
            this.noiboCheckEdit.Name = "noiboCheckEdit";
            this.noiboCheckEdit.Properties.Caption = "";
            this.noiboCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.noiboCheckEdit.Size = new System.Drawing.Size(132, 19);
            this.noiboCheckEdit.StyleController = this.dataLayoutControl1;
            this.noiboCheckEdit.TabIndex = 7;
            // 
            // ItemFornoibo
            // 
            this.ItemFornoibo.Control = this.noiboCheckEdit;
            this.ItemFornoibo.Location = new System.Drawing.Point(190, 48);
            this.ItemFornoibo.Name = "ItemFornoibo";
            this.ItemFornoibo.Size = new System.Drawing.Size(191, 23);
            this.ItemFornoibo.Text = "Nội Bộ";
            this.ItemFornoibo.TextSize = new System.Drawing.Size(52, 13);
            // 
            // f_loaixuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 145);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_loaixuat";
            this.Text = "Loại Xuất";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloaixuatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaixuatTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doanhthuCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaixuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordoanhthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiboCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFornoibo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource dmloaixuatBindingSource;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.TextEdit loaixuatTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloaixuat;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.CheckEdit doanhthuCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemFordoanhthu;
        private DevExpress.XtraEditors.CheckEdit noiboCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemFornoibo;
    }
}