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
using DevExpress.XtraBars;

namespace GUI.DanhMuc
{
    public partial class f_dsloainhap : frm.frmds
    {
        c_dmloainhap ln= new c_dmloainhap();
        c_history hs = new c_history();
        public f_dsloainhap()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new f_loainhap();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            if (btnsua.Visibility == BarItemVisibility.Never)
                return false;
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("key").ToString();
            var frm = new f_loainhap();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool saochep()
        {
            Biencucbo.hdong = 3;
            Biencucbo.key = gv.GetFocusedRowCellValue("key").ToString();
            var frm = new f_loainhap();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool xoa()
        {
            try
            {
                ln.xoa(gv.GetFocusedRowCellValue("key").ToString());
                hs.add(gv.GetFocusedRowCellValue("key").ToString(), "Xóa Loại Nhập Kho");
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
            gd.DataSource = new KetNoiDBDataContext().dmloainhaps;
        }


        #endregion
    }
}