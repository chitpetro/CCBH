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
using DevExpress.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using GUI.Report.Nhapkho;

namespace GUI.Report.DoThi
{
    public partial class f_doanhthu_theothoigian_bo : frm.frmreport_dothi
    {
        public f_doanhthu_theothoigian_bo()
        {
            InitializeComponent();
        }

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        protected override void load()
        {

            //txtdanhmuc.Properties.Items.Add("loại Nhập");
            
        }

        private bool layinfo(string tungay, string denngay)
        {
            Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
            Biencucbo.info = "";
            bool checkdv = true;
            string loai = "";
            gv2.Columns["loai"].SortOrder = ColumnSortOrder.Ascending;
            for (int i = 0; i < gv2.DataRowCount; i++)
            {
                if (gv2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
                {
                    checkdv = true;
                }
                if (loai != gv2.GetRowCellValue(i, "loai").ToString())
                {
                    if (Biencucbo.info == "")
                    {
                        Biencucbo.info = gv2.GetRowCellValue(i, "loai") + ": " + gv2.GetRowCellValue(i, "name");
                    }
                    else
                    {
                        Biencucbo.info = Biencucbo.info + "\n" + gv2.GetRowCellValue(i, "loai") + ": " +
                                         gv2.GetRowCellValue(i, "name");
                    }
                }
                else
                {
                    Biencucbo.info = Biencucbo.info + ", " + gv2.GetRowCellValue(i, "name");
                }
                loai = gv2.GetRowCellValue(i, "loai").ToString();
            }
            if (Biencucbo.info == "")
                Biencucbo.info = "Tất cả";
            return checkdv;
        }

        //private void inbc<T>()
        //{
        //    if (
        //        layinfo(DateTime.Parse(tungay.EditValue.ToString()).ToShortDateString(),
        //            DateTime.Parse(denngay.EditValue.ToString()).ToShortDateString()) ==
        //        false)
        //    {
        //        XtraMessageBox.Show("Cần phải chọn một đơn vị bất kỳ để xem báo cáo", "THÔNG BÁO");
        //        return;
        //    }
        //    try
        //    {
        //        //var rp = Activator.CreateInstance<T>() as XtraReport;
        //        //rp.DataSource = dbData.SP_InBCDoanhThu_Dothi_Duong(Biencucbo.idnv, "f_doanhthu_theothoigian",
        //        //    Biencucbo.hostname, tungay.DateTime, denngay.DateTime, "");
        //        //rp.ShowPreview();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        protected override void search()
        {
            SplashScreenManager.ShowForm(typeof (SplashScreen1));

            var lst = (from a in dbData.SP_InBCDoanhThu_Dothi_Duong(Biencucbo.idnv, "f_doanhthu_theothoigian",
                Biencucbo.hostname, tungay.DateTime, denngay.DateTime, "")
                select a).ToList();
            chartControl1.DataSource = lst;

            //Biencucbo.title = "BÁOCÁOTỔNGHỢPNHẬPKHO";
            //inbc<r_bcnhapkho_th>();

            SplashScreenManager.CloseForm();
        }
    }


}