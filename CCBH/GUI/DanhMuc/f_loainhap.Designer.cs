namespace GUI.DanhMuc
{
    partial class f_loainhap
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
            this.dmloainhapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loainhapTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.congnoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForloainhap = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForcongno = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloainhapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loainhapTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.congnoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloainhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcongno)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AutoRetrieveFields = true;
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.loainhapTextEdit);
            this.dataLayoutControl1.Controls.Add(this.congnoCheckEdit);
            this.dataLayoutControl1.DataSource = this.dmloainhapBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(418, 90);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(62, 12);
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(136, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // dmloainhapBindingSource
            // 
            this.dmloainhapBindingSource.DataSource = typeof(DAL.dmloainhap);
            // 
            // loainhapTextEdit
            // 
            this.loainhapTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapBindingSource, "loainhap", true));
            this.loainhapTextEdit.Location = new System.Drawing.Point(62, 36);
            this.loainhapTextEdit.Name = "loainhapTextEdit";
            this.loainhapTextEdit.Size = new System.Drawing.Size(327, 20);
            this.loainhapTextEdit.StyleController = this.dataLayoutControl1;
            this.loainhapTextEdit.TabIndex = 5;
            // 
            // congnoCheckEdit
            // 
            this.congnoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapBindingSource, "congno", true));
            this.congnoCheckEdit.Location = new System.Drawing.Point(12, 60);
            this.congnoCheckEdit.Name = "congnoCheckEdit";
            this.congnoCheckEdit.Properties.Caption = "Công Nợ";
            this.congnoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.congnoCheckEdit.Size = new System.Drawing.Size(377, 19);
            this.congnoCheckEdit.StyleController = this.dataLayoutControl1;
            this.congnoCheckEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(401, 91);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForloainhap,
            this.emptySpaceItem2,
            this.ItemForcongno});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(381, 71);
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(190, 24);
            this.ItemForid.Text = "ID";
            this.ItemForid.TextSize = new System.Drawing.Size(47, 13);
            // 
            // ItemForloainhap
            // 
            this.ItemForloainhap.Control = this.loainhapTextEdit;
            this.ItemForloainhap.Location = new System.Drawing.Point(0, 24);
            this.ItemForloainhap.Name = "ItemForloainhap";
            this.ItemForloainhap.Size = new System.Drawing.Size(381, 24);
            this.ItemForloainhap.Text = "Loại Nhập";
            this.ItemForloainhap.TextSize = new System.Drawing.Size(47, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(190, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(191, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForcongno
            // 
            this.ItemForcongno.Control = this.congnoCheckEdit;
            this.ItemForcongno.Location = new System.Drawing.Point(0, 48);
            this.ItemForcongno.Name = "ItemForcongno";
            this.ItemForcongno.Size = new System.Drawing.Size(381, 23);
            this.ItemForcongno.Text = "Công Nợ";
            this.ItemForcongno.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForcongno.TextVisible = false;
            // 
            // f_loainhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 137);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_loainhap";
            this.Text = "Danh Mục Loại Nhập";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloainhapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loainhapTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.congnoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloainhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcongno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource dmloainhapBindingSource;
        private DevExpress.XtraEditors.TextEdit loainhapTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloainhap;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.CheckEdit congnoCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcongno;
    }
}