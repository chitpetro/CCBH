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
using DevExpress.XtraSplashScreen;
using DAL;

namespace GUI.Report.DoThi
{
    public partial class f_doanhthu_theothoigian : frm.frmreport_dothi
    {
        private KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        
        public f_doanhthu_theothoigian()
        {
            InitializeComponent();
        }

        protected override void search()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));

            var lst = (from a in new KetNoiDBDataContext().SP_InBCDoanhThu_Dothi_Duong(Biencucbo.idnv, "f_doanhthu_theothoigian",
                Biencucbo.hostname, tungay.DateTime, denngay.DateTime, txtiddv.Text)
                       select a).ToList();
            chartControl1.DataSource = lst;

            //Biencucbo.title = "BÁOCÁOTỔNGHỢPNHẬPKHO";
            //inbc<r_bcnhapkho_th>();

            SplashScreenManager.CloseForm();
        }

        private void txtiddv_EditValueChanged(object sender, EventArgs e)
        {
            search();
        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}