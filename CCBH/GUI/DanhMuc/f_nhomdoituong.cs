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
using GUI.Properties;

namespace GUI.DanhMuc
{
    public partial class f_nhomdoituong : frm.frmthemds
    {
       
        public f_nhomdoituong()
        {
            InitializeComponent();
        }

        private int _hdong = 0;
        private string _key = "";
        c_nhomdoituong dt = new c_nhomdoituong();
        c_history hs = new c_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                txtid.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().nhomdoituongs select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                txttennhom.Text = lst.tennhom;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().nhomdoituongs select a).Single(t => t.id == _key);
                txttennhom.Text = lst.tennhom;
                    _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    dt.them(txtid.Text, txttennhom.Text);
                    hs.add(txtid.Text, "Thêm Nhóm Đối Tượng");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    dt.sua(txtid.Text, txttennhom.Text);
                    hs.add(txtid.Text, "Sửa Nhóm Đối Tượng");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }
        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            txtid.Properties.ContextImage = null;

            if (custom.checknulltext(txtid))
                checknull++;

            txttennhom.Properties.ContextImage = null;

            if (custom.checknulltext(txttennhom))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().nhomdoituongs select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.tennhom == txttennhom.Text).Count() > 0)
                {
                    txttennhom.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.tennhom == txttennhom.Text).Count() > 0)
                {
                    txttennhom.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
            }
            if (checdup > 0)
                custom.mes_trunglap();
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }
    }
}