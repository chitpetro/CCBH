namespace GUI.HeThong
{
    partial class f_tientechinh
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
            this.tentienteSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.maincurrencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemFortentiente = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tentienteSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maincurrencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortentiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.tentienteSearchLookUpEdit);
            this.dataLayoutControl1.DataSource = this.maincurrencyBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(290, 65);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // tentienteSearchLookUpEdit
            // 
            this.tentienteSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.maincurrencyBindingSource, "tentiente", true));
            this.tentienteSearchLookUpEdit.Location = new System.Drawing.Point(50, 12);
            this.tentienteSearchLookUpEdit.Name = "tentienteSearchLookUpEdit";
            this.tentienteSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tentienteSearchLookUpEdit.Properties.DataSource = this.tienteBindingSource;
            this.tentienteSearchLookUpEdit.Properties.DisplayMember = "tentiente";
            this.tentienteSearchLookUpEdit.Properties.NullText = "";
            this.tentienteSearchLookUpEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.tentienteSearchLookUpEdit.Properties.ValueMember = "tentiente";
            this.tentienteSearchLookUpEdit.Size = new System.Drawing.Size(228, 20);
            this.tentienteSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.tentienteSearchLookUpEdit.TabIndex = 4;
            this.tentienteSearchLookUpEdit.Popup += new System.EventHandler(this.tentienteSearchLookUpEdit_Popup);
            // 
            // maincurrencyBindingSource
            // 
            this.maincurrencyBindingSource.DataSource = typeof(DAL.maincurrency);
            // 
            // tienteBindingSource
            // 
            this.tienteBindingSource.DataSource = typeof(DAL.tiente);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tiền Tệ";
            this.gridColumn1.FieldName = "tentiente";
            this.gridColumn1.ImageOptions.Image = global::GUI.Properties.Resources.currency2_16x16;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(290, 65);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemFortentiente,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(270, 45);
            // 
            // ItemFortentiente
            // 
            this.ItemFortentiente.Control = this.tentienteSearchLookUpEdit;
            this.ItemFortentiente.Location = new System.Drawing.Point(0, 0);
            this.ItemFortentiente.Name = "ItemFortentiente";
            this.ItemFortentiente.Size = new System.Drawing.Size(270, 24);
            this.ItemFortentiente.Text = "Tiền Tệ";
            this.ItemFortentiente.TextSize = new System.Drawing.Size(35, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(270, 21);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // f_tientechinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 112);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_tientechinh";
            this.Text = "Tiền Tệ Chính";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tentienteSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maincurrencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortentiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SearchLookUpEdit tentienteSearchLookUpEdit;
        private System.Windows.Forms.BindingSource maincurrencyBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemFortentiente;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource tienteBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}