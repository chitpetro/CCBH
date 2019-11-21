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
using DevExpress.XtraEditors;
using DAL;

namespace GUI.ChucNang
{
    public partial class f_dsthutienbanhang : DevExpress.XtraEditors.XtraForm
    {
        private string _link = "";
        public f_dsthutienbanhang()
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

        private void f_dsthutienbanhang_Load(object sender, EventArgs e)
        {
            _link = Biencucbo.link;
            var lst = (from a in new KetNoiDBDataContext().ptts where a.link == _link select a);
            gd.DataSource = lst;
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
            if (dble)
            {
                Biencucbo.key = gv.GetFocusedRowCellValue("key").ToString();
                DialogResult = DialogResult.OK;
            }
        }
    }
}