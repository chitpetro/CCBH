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
using GUI.frm;
using DAL;
using BUS;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;

namespace GUI.HeThong
{
    public partial class f_DsNhomDonVi : frmds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_history hs = new c_history();
        c_nhomdonvi dv = new c_nhomdonvi();
        public f_DsNhomDonVi()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new HeThong.f_NhomDonVi();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new HeThong.f_NhomDonVi();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool xoa()
        {
            try
            {
                dv.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa Nhóm Đơn Vị");
                custom.mes_done();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
      protected override void load()
        {
            gd.DataSource = new KetNoiDBDataContext().nhomdonvis;

        }
        protected override bool saochep()
        {
            Biencucbo.hdong = 3;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new HeThong.f_NhomDonVi();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        #endregion
        private void gv_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {


        }
    }
}