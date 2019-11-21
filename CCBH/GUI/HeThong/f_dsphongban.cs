using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;



namespace GUI.HeThong
{
    public partial class f_dsphongban : frm.frmds
    {
        c_phongban pb =new c_phongban();
        c_history hs = new c_history();

        public f_dsphongban()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new f_phongban();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new f_phongban();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool saochep()
        {
            Biencucbo.hdong = 3;
                Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
                var frm = new f_phongban();
                if (frm.ShowDialog() == DialogResult.OK)
                    return true;
                return false;
            
        }

        protected override bool xoa()
        {
            try
            {
                pb.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa Phòng Ban");
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
            gd.DataSource = new KetNoiDBDataContext().phongbans;
        }


        #endregion
    
    }
}