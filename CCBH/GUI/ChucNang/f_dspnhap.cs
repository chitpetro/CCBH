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
using DAL;


namespace GUI.ChucNang
{
    public partial class f_dspnhap : frm.frmmop
    {
        public f_dspnhap()
        {
            InitializeComponent();
        }

        protected override void search()
        {
            gd.DataSource = new KetNoiDBDataContext().SP_LayDSPNhap(tungay.DateTime,denngay.DateTime,Biencucbo.donvi,false);
        }
        protected override void searchall()
        {
            gd.DataSource = new KetNoiDBDataContext().SP_LayDSPNhap(tungay.DateTime, denngay.DateTime, Biencucbo.donvi, true);
        }
    }
}