namespace GUI.DanhMuc
{
    partial class f_tiente
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
            this.tentienteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tygiaSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ghichuMemoExEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemFortentiente = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFortygia = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForghichu = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tentienteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tygiaSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghichuMemoExEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortentiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortygia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForghichu)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.tentienteTextEdit);
            this.dataLayoutControl1.Controls.Add(this.tygiaSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.ghichuMemoExEdit);
            this.dataLayoutControl1.DataSource = this.tienteBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(357, 130);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // tentienteTextEdit
            // 
            this.tentienteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tienteBindingSource, "tentiente", true));
            this.tentienteTextEdit.Location = new System.Drawing.Point(52, 12);
            this.tentienteTextEdit.Name = "tentienteTextEdit";
            this.tentienteTextEdit.Size = new System.Drawing.Size(124, 20);
            this.tentienteTextEdit.StyleController = this.dataLayoutControl1;
            this.tentienteTextEdit.TabIndex = 4;
            // 
            // tienteBindingSource
            // 
            this.tienteBindingSource.DataSource = typeof(DAL.tiente);
            // 
            // tygiaSpinEdit
            // 
            this.tygiaSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tienteBindingSource, "tygia", true));
            this.tygiaSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tygiaSpinEdit.Location = new System.Drawing.Point(220, 12);
            this.tygiaSpinEdit.Name = "tygiaSpinEdit";
            this.tygiaSpinEdit.Properties.AllowMouseWheel = false;
            this.tygiaSpinEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.tygiaSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.tygiaSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tygiaSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tygiaSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.tygiaSpinEdit.Properties.Mask.EditMask = "n2";
            this.tygiaSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tygiaSpinEdit.Size = new System.Drawing.Size(125, 20);
            this.tygiaSpinEdit.StyleController = this.dataLayoutControl1;
            this.tygiaSpinEdit.TabIndex = 5;
            // 
            // ghichuMemoExEdit
            // 
            this.ghichuMemoExEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tienteBindingSource, "ghichu", true));
            this.ghichuMemoExEdit.Location = new System.Drawing.Point(52, 36);
            this.ghichuMemoExEdit.Name = "ghichuMemoExEdit";
            this.ghichuMemoExEdit.Size = new System.Drawing.Size(293, 82);
            this.ghichuMemoExEdit.StyleController = this.dataLayoutControl1;
            this.ghichuMemoExEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(357, 130);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemFortentiente,
            this.ItemFortygia,
            this.ItemForghichu});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(337, 110);
            // 
            // ItemFortentiente
            // 
            this.ItemFortentiente.Control = this.tentienteTextEdit;
            this.ItemFortentiente.Location = new System.Drawing.Point(0, 0);
            this.ItemFortentiente.Name = "ItemFortentiente";
            this.ItemFortentiente.Size = new System.Drawing.Size(168, 24);
            this.ItemFortentiente.Text = "Tiền Tệ";
            this.ItemFortentiente.TextSize = new System.Drawing.Size(37, 13);
            // 
            // ItemFortygia
            // 
            this.ItemFortygia.Control = this.tygiaSpinEdit;
            this.ItemFortygia.Location = new System.Drawing.Point(168, 0);
            this.ItemFortygia.Name = "ItemFortygia";
            this.ItemFortygia.Size = new System.Drawing.Size(169, 24);
            this.ItemFortygia.Text = "Tỷ Giá";
            this.ItemFortygia.TextSize = new System.Drawing.Size(37, 13);
            // 
            // ItemForghichu
            // 
            this.ItemForghichu.Control = this.ghichuMemoExEdit;
            this.ItemForghichu.Location = new System.Drawing.Point(0, 24);
            this.ItemForghichu.Name = "ItemForghichu";
            this.ItemForghichu.Size = new System.Drawing.Size(337, 86);
            this.ItemForghichu.Text = "Ghi Chú";
            this.ItemForghichu.TextSize = new System.Drawing.Size(37, 13);
            // 
            // f_tiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 177);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_tiente";
            this.Text = "Tiền Tệ";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tentienteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tygiaSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghichuMemoExEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortentiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortygia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForghichu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit tentienteTextEdit;
        private System.Windows.Forms.BindingSource tienteBindingSource;
        private DevExpress.XtraEditors.SpinEdit tygiaSpinEdit;
        private DevExpress.XtraEditors.MemoEdit ghichuMemoExEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemFortentiente;
        private DevExpress.XtraLayout.LayoutControlItem ItemFortygia;
        private DevExpress.XtraLayout.LayoutControlItem ItemForghichu;
    }
}