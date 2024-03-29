﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using ControlLocalizer;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace GUI.frm
{
    public partial class frmreport_dothi_bo : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private string _form;
        private bool dble1;
        private bool dble2;
        public frmreport_dothi_bo()
        {
            InitializeComponent();
        }

        private void gv1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv1, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd1, gv1);
            }));
        }

        private void gv2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv2, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd2, gv2);
            }));
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
            }
        }

        private void frmreport_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            thoigian.Text = "Tháng Này";
            changetime();
            _form = Biencucbo.form;
            txtdanhmuc.Properties.Items.Add("Đơn Vị");
            load();
        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changetime();
        }

        protected virtual void load()
        {

        }

        protected virtual void search()
        {

        }

        protected virtual void loaddata()
        {
            gd1.DataSource = dbData.SP_LayRP_GD1(txtdanhmuc.Text, Biencucbo.idnv, _form, Biencucbo.hostname, Biencucbo.donvi);
            gd2.DataSource = dbData.SP_LayRP_GD2(Biencucbo.idnv, _form, Biencucbo.hostname, Biencucbo.donvi);
        }
        


        private void add()
        {
            try
            {
                dbData = new KetNoiDBDataContext();
                dkreport dk = new dkreport();
                dk.id = gv1.GetFocusedRowCellValue("id").ToString();
                dk.name = gv1.GetFocusedRowCellValue("name").ToString();
                dk.key = gv1.GetFocusedRowCellValue("key").ToString().Trim();
                dk.loai = txtdanhmuc.Text;
                dk.idnv = Biencucbo.idnv;
                dk.form = _form;
                dk.PC = Biencucbo.hostname;dbData.dkreports.InsertOnSubmit(dk);
                dbData.SubmitChanges();
                loaddata();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void addall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                dbData = new KetNoiDBDataContext();
                for (int i = 0; i < gv1.DataRowCount; i++)
                {
                    dkreport dk = new dkreport();
                    dk.id = gv1.GetRowCellValue(i, "id").ToString();
                    dk.name = gv1.GetRowCellValue(i, "name").ToString();
                    dk.key = gv1.GetRowCellValue(i, "key").ToString();
                    dk.loai = txtdanhmuc.Text;
                    dk.idnv = Biencucbo.idnv;
                    dk.form = _form;
                    dk.PC = Biencucbo.hostname;
                    dbData.dkreports.InsertOnSubmit(dk);
                    dbData.SubmitChanges();
                }
                loaddata();
            }
            catch (Exception ex)
            {

            }
            SplashScreenManager.CloseForm();
        }

        private void remove()
        {
            try
            {
                dbData = new KetNoiDBDataContext();

                dkreport dk =
                     (from a in dbData.dkreports select a).Single(
                         t => t.key == gv2.GetFocusedRowCellValue("key").ToString());
                dbData.dkreports.DeleteOnSubmit(dk);
                dbData.SubmitChanges();

                loaddata();
            }
            catch (Exception ex)
            {

            }
        }
        private void removeall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                dbData = new KetNoiDBDataContext();
                for (int i = gv2.DataRowCount - 1; i >= 0; i--)
                {
                    dkreport dk =
                        (from a in dbData.dkreports select a).Single(
                            t => t.key == gv2.GetRowCellValue(i, "key").ToString());
                    dbData.dkreports.DeleteOnSubmit(dk);
                    dbData.SubmitChanges();
                }
                loaddata();

            }
            catch (Exception ex)
            {

            }
            SplashScreenManager.CloseForm();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnaddall_Click(object sender, EventArgs e)
        {
            addall();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            remove();
        }

        private void btnremoveall_Click(object sender, EventArgs e)
        {
            removeall();
        }

        private void gv1_Click(object sender, EventArgs e)
        {
            dble1 = false;
        }

        private void gv1_DoubleClick(object sender, EventArgs e)
        {
            dble1 = true;
        }

        private void gv1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(dble1)
                add();
        }

        private void gv2_Click(object sender, EventArgs e)
        {
            dble2 = false;
        }

        private void gv2_DoubleClick(object sender, EventArgs e)
        {
            dble2 = true;
        }

        private void gv2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(dble2)
                remove();
        }

        private void txtdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}