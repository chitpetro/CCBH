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
    public partial class f_NhomDonVi : frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_history hs = new c_history();
        c_nhomdonvi dv = new c_nhomdonvi();
        private int _hdong = 0;
        private string _key = "";
        public f_NhomDonVi()
        {
            InitializeComponent();

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    dv.them(txtid.Text, txttennhom.Text);
                    hs.add(txtid.Text, "Thêm Nhóm Đơn Vị");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    dv.sua(txtid.Text, txttennhom.Text);
                    hs.add(txtid.Text, "Sửa Nhóm Đơn Vị");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                var lst = (from a in dbData.nhomdonvis select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                txttennhom.Text = lst.tennhom;
                txtid.ReadOnly = true;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in dbData.nhomdonvis select a).Single(t => t.id == _key);
                txttennhom.Text = lst.tennhom;
                _hdong = 1;
            }

        }

        private bool kiemtra()
        {
            int checknull = 0;
            int checkdub = 0;

            txtid.Properties.ContextImage = null;
            txttennhom.Properties.ContextImage = null;
            if (custom.checknulltext(txtid))
                checknull++;
            if (custom.checknulltext(txttennhom))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }


            if (_hdong == 1)
            {
                var lst = (from a in new KetNoiDBDataContext().nhomdonvis select a);
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = GUI.Properties.Resources.trung;
                    checkdub++;
                }

                if (lst.Where(t => t.tennhom == txttennhom.Text).Count() > 0)
                {
                    txttennhom.Properties.ContextImage = GUI.Properties.Resources.trung;
                    checkdub++;
                }
                if (checkdub > 0)
                {
                    custom.mes_trunglap();
                }
            }
            else if (_hdong == 2)
            {
                var lst = (from a in new KetNoiDBDataContext().nhomdonvis where a.id != txtid.Text select a);
                if (lst.Where(t => t.tennhom == txttennhom.Text).Count() > 0)
                {
                    txttennhom.Properties.ContextImage = GUI.Properties.Resources.trung;
                    checkdub++;
                }
                if (checkdub > 0)
                {
                    custom.mes_trunglap();
                }
            }
            if (checknull > 0 || checkdub > 0)
                return false;
            return true;

        }
    }
}