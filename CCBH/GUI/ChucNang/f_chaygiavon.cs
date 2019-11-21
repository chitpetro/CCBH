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
using DevExpress.PivotGrid.Printing;
using DevExpress.XtraRichEdit.Model;


namespace GUI.ChucNang
{
    public partial class f_chaygiavon : frm.frmonlydate
    {

        KetNoiDBDataContext db = new KetNoiDBDataContext();
        c_chaygiavon c = new c_chaygiavon();
        public f_chaygiavon()
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

        private void f_chaygiavon_Load(object sender, EventArgs e)
        {

        }

        private void loaddata()
        {
            try
            {
                gd.DataSource = new KetNoiDBDataContext().SP_LayDsChayGiaVon(tungay.DateTime, denngay.DateTime, Biencucbo.donvi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void search()
        {

            loaddata();
        }

       
        private void btnchaygiavon_Click(object sender, EventArgs e)
        {
            try
            {
                var lst =
                (from a in new KetNoiDBDataContext().SP_ChayGiaVon(Biencucbo.donvi, tungay.DateTime, denngay.DateTime)
                 select a).ToList();
                foreach (var row in lst)
                {
                  c.chay(row.keypxct,double.Parse(db.FC_TinhGiaVon(row.idsp, row.ngayxuat, row.so, row.iddv).ToString()));
                }
                XtraMessageBox.Show("Done");
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}