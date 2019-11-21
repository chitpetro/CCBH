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
using DAL;
using DevExpress.XtraEditors;

namespace GUI.ChucNang
{
    public partial class f_POS2 : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public f_POS2()
        {
            InitializeComponent();

            sluidsp.DataSource = (from a in new DAL.KetNoiDBDataContext().dmsanphams select a);

        }

        private void gv_CustomDrawRowIndicator(object sender,
            DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void layttlblteniddt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == id);
                lblteniddt.Text = lst.tendt;
                txtphone.Text = lst.dd;
            }
            catch (Exception ex)
            {
                lblteniddt.Text = "";
                txtphone.Text = "";
            }
        }



        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            layttlblteniddt(txtiddt.Text);
        }

        private void f_POS2_Load(object sender, EventArgs e)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[sc.Length - 1].Bounds.Right - sc[sc.Length - 1].Bounds.Width, sc[sc.Length - 1].Bounds.Top);
            this.WindowState = FormWindowState.Normal;
            this.Size = sc[sc.Length - 1].Bounds.Size;
            //this.Size = sc[sc.Length - 1].Bounds.Size;

            try
            {
                playvideo.URL = "D:\\video\\sfw.mp4";
                playvideo.settings.setMode("loop", true);

                // int abc = int.Parse(Color.Transparent.ToString());
                //  playvideo.BackgroundColor = int.Parse(Color.Transparent.ToString());
            }
            catch
            {
                
            }


        }

        public void truyenxoaall()
        {
            //if (gridView1.RowCount == 0)
            //{
            //    txttotal.Text = "0";
            //    return;
            //}
            for (int i = gv.DataRowCount - 1; i >= 0; i--)
            {

                gv.DeleteRow(i);
            }
            gv.UpdateCurrentRow();
            txttong.Text = "0";
        }
        public void truyendt(string a)
        {
            txtiddt.Text = a;
            layttlblteniddt(a);

        }

        public void truyenxoact(int row)
        {
            gv.UpdateCurrentRow();
            gv.DeleteRow(row);
            gv.UpdateCurrentRow();
            txttong.Text = colthanhtien.SummaryItem.SummaryValue.ToString();
        }

        //public void truyensuact( double b, int row)
        //{
        //    int abcd = gridView1.DataRowCount;
        //    try
        //    {
        //        gridView1.UpdateCurrentRow();
        //        gridView1.SetRowCellValue(gridView1.DataRowCount - 1, "idsanpham", a);
        //        gridView1.SetRowCellValue(gridView1.DataRowCount - 1, "soluong", b.ToString());
        //        gridView1.UpdateCurrentRow();

        //        txttotal.Text = colnguyente.SummaryItem.SummaryValue.ToString();
        //    }
        //    catch
        //    {

        //    }
        //}

        public void truyensuact2(double sl, double nt, double ck, int row)
        {
            try
            {
                //var ct = gv.GetRow(row) as pxuatct;
                //ct.soluong = sl;
                //ct.nguyente = nt;
                //ct.thanhtien = nt;
                //gv.PostEditor();
                //gv.UpdateCurrentRow();
                //txttong.Text = colthanhtien.SummaryItem.SummaryValue.ToString();
                gv.PostEditor();
                gv.UpdateCurrentRow();
                gv.SetRowCellValue(row,"soluong",sl);
                gv.SetRowCellValue(row, "chietkhau", ck);
                gv.SetRowCellValue(row, "nguyente", nt);
                gv.SetRowCellValue(row, "thanhtien", nt);
                 gv.PostEditor();
                gv.UpdateCurrentRow();
                string a = colthanhtien.SummaryItem.SummaryValue.ToString();
                txttong.Text = a;
            }
            catch
            {
                
            }
        }
        private string _key;
        private string _keypx;
        private string _idsp;
        private double _soluong;
        private double _dongia;
        private double _chietkhau ;
        private int _stt;

        public void truyenthemct(string key, string keypx, string idsp, double soluong, double dongia, double chietkhau, int stt)
        {
            _key = key;
            _keypx = keypx;
            _idsp = idsp;
            _soluong = soluong;
            _dongia = dongia;
            _chietkhau = chietkhau;
            _stt = stt;
            gv.AddNewRow();
            gv.UpdateCurrentRow();
            string a = colthanhtien.SummaryItem.SummaryValue.ToString();
            txttong.Text = a;

        }

        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           
            var ct = gv.GetFocusedRow() as pxuatct;
            if (ct == null)
                return;

            ct.key = _key;
            ct.keypx = _keypx;
            ct.idsp = _idsp;
            ct.soluong = _soluong;
            ct.dongia = _dongia;
            ct.chietkhau = _chietkhau;
            ct.ghichu = string.Empty;
            ct.stt = _stt;
            ct.nguyente = (_soluong * _dongia) - _chietkhau;
            ct.thanhtien = (_soluong * _dongia) - _chietkhau;
            
            gv.UpdateCurrentRow();
 
          
        }

        private void txttong_EditValueChanged(object sender, EventArgs e)
        {
            double tong;
            double tygia = 0;
            double tiente = 0;
            tong = double.Parse(txttong.Text);
            var lst = (from a in dbData.tientes where a.tentiente == "Bath" select a);
            if (lst != null)
            {
                tygia = double.Parse(lst.Single().tygia.ToString());
                tiente = tong / tygia;
                txtbath.Text = tiente.ToString();
                lobath.Text = "Bath (" + tygia + ")";
            }

             lst = (from a in dbData.tientes where a.tentiente == "USD" select a);
            if (lst != null)
            {
                tygia = double.Parse(lst.Single().tygia.ToString());
                tiente = tong / tygia;
                txtusd.Text = tiente.ToString();
                lousd.Text = "USD (" + tygia + ")";
            }
        }
    }
}