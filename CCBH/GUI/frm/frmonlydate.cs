using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLocalizer;
using DevExpress.XtraEditors;

namespace GUI.frm
{
    public partial class frmonlydate : DevExpress.XtraEditors.XtraForm
    {
        public frmonlydate()
        {
            InitializeComponent();
        }

        private void changetime()

        {

            string time = thoigian.Text;
            int chieudai = time.Length;
            string chu = time.Substring(0, 5);
            string so = "";
            DateTime ngay;

            if (thoigian.Text == "Tùy Ý")
            {
                tungay.ReadOnly = false;
                denngay.ReadOnly = false;
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
                else if (thoigian.Text == "Cả Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }

                else if (thoigian.Text == "Hôm Nay")
                {
                    ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    denngay.DateTime = ngay;
                }
                search();
                tungay.ReadOnly = true;
                denngay.ReadOnly = true;
            }
        }

        protected virtual void search()
        {

        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changetime();
        }

        private void frmonlydate_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            thoigian.Text = "Tháng Này";
            changetime();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}