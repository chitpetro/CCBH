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

    public partial class f_dtdoanhthu_sanpham : DevExpress.XtraEditors.XtraForm
    {

        public f_dtdoanhthu_sanpham()
        {
            InitializeComponent();
            loadslutxtiddv();
            thoigian.Text = "Tháng Này";
        }


        private string _form = "";

        private void changetime()

        {

            string time = thoigian.Text;
            int chieudai = time.Length;
            string chu = time.Substring(0, 5);
            string so = "";
            DateTime ngay;

            if (thoigian.Text == "Tùy Ý")
            {

            }
            else
            {
                if (chu == "Tháng") //vietnam
                {
                    if (chieudai == 7)
                    {
                        so = time.Substring(6, 1);

                    }
                    else if (chieudai == 8)
                    {
                        so = time.Substring(6, 2);
                    }
                    else
                    {
                        if (thoigian.Text == "Tháng Này")
                        {
                            int month = DateTime.Now.Month;
                            if (month < 10)
                            {
                                so = "0" + month;
                            }
                            else
                            {
                                so = month.ToString();
                            }
                        }
                        else if (thoigian.Text == "Tháng Trước")
                        {
                            int month = DateTime.Now.Month;
                            month = month - 1;
                            if (month < 10)
                            {
                                so = "0" + month;
                            }
                            else
                            {
                                so = month.ToString();
                            }
                        }
                    }
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(so)));
                    denngay.DateTime = ngay;
                }

                //              
                if (thoigian.Text == "Quý 1")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3));
                    denngay.DateTime = ngay;

                }
                else if (thoigian.Text == "Quý 2")
                {
                    ngay = new DateTime(DateTime.Now.Year, 4, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Quý 3")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Quý 4")
                {
                    ngay = new DateTime(DateTime.Now.Year, 10, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "6 Tháng Đầu Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "6 Tháng Cuối Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Năm Nay")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Năm Trước")
                {
                    int year = DateTime.Now.Year;
                    year = year - 1;
                    ngay = new DateTime(year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                    denngay.DateTime = ngay;
                }


                tungay.ReadOnly = true;
                denngay.ReadOnly = true;
                loaddata();
            }
        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changetime();
        }

        private void f_dtdoanhthuchiphi_Load(object sender, EventArgs e)
        {
            

        }

        private void layttlbliddv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lbliddv.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lbliddv.Text = "";
            }
        }

        private void loadslutxtiddv()
        {
            var lst = (from a in new KetNoiDBDataContext().SP_LayDsDonVi(Biencucbo.donvi) select a).ToList();
            txtiddv.Properties.DataSource = lst;
        }

        public void loaddata()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                var lst =
                    (from a in
                        new KetNoiDBDataContext().SP_InBCDoanhThu_DoThi(Biencucbo.idnv, "f_dtdoanhthuchiphi",
                            Biencucbo.hostname, tungay.DateTime.Month, denngay.DateTime.Month, tungay.DateTime.Year,
                            denngay.DateTime.Year, txtiddv.Text)
                     select a).ToList();

                chartControl1.Series["Series 1"].DataSource = lst;
                chartControl1.DataSource = lst;
                //n1 = tungay;
                //n2 = denngay;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
            SplashScreenManager.CloseForm();
        }

        private void txtiddv_EditValueChanged(object sender, EventArgs e)
        {
            layttlbliddv(txtiddv.Text);
            loaddata();
        }
    }
}