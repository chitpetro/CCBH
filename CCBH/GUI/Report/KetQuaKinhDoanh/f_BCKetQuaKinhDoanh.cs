using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;

namespace GUI.Report.KetQuaKinhDoanh
{
    public partial class f_BCKetQuaKinhDoanh : frm.frmonlydate
    {
        public f_BCKetQuaKinhDoanh()
        {
            InitializeComponent();
            txtdonvi.Properties.DataSource = new KetNoiDBDataContext().SP_LayDsDonVi(Biencucbo.donvi);
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        protected override void search()
        {
            try
            {
                gd.DataSource = new KetNoiDBDataContext().SP_BCKetQuaKinhDoanh(tungay.DateTime,denngay.DateTime,txtdonvi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtdonvi_EditValueChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}