using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_doidonvi : DevExpress.XtraEditors.XtraForm
    {
        public f_doidonvi()
        {
            InitializeComponent();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private bool dble = false;
        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(dble)
                try
                {
                    Biencucbo.donvi = gv.GetFocusedRowCellValue("id").ToString();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void f_doidonvi_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            gd.DataSource = new KetNoiDBDataContext().SP_LayDsDonVi(Biencucbo.DonViMain);
        }
    }
}