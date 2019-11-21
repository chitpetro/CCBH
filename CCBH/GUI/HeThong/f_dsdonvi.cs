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

namespace GUI.HeThong
{
    public partial class f_dsdonvi : frmds
    {
        c_history hs = new c_history();
        c_donvi dv = new c_donvi();
        public f_dsdonvi()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new f_donvi();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new f_donvi();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
          }

        protected override bool saochep()
        {
            Biencucbo.hdong = 3;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new f_donvi();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
                     
        }

        protected override bool xoa()
        {
            try
            {
                dv.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa Đơn Vị");
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
            gd.DataSource = new KetNoiDBDataContext().SP_LayDsDonVi(Biencucbo.donvi);
        }


        #endregion


    }
}