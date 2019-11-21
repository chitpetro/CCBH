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

namespace GUI.ChucNang
{
    public partial class f_dspthutien : frm.frmmop
    {
        public f_dspthutien()
        {
            InitializeComponent();
        }
        protected override void search()
        {
            gd.DataSource = new KetNoiDBDataContext().SP_LayDSPThu(tungay.DateTime, denngay.DateTime, Biencucbo.donvi, false);
        }
        protected override void searchall()
        {
            gd.DataSource = new KetNoiDBDataContext().SP_LayDSPThu(tungay.DateTime, denngay.DateTime, Biencucbo.donvi, true);
        }

    }
}