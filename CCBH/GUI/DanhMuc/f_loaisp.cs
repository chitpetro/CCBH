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
    public partial class f_loaisp : frm.frmthemds
    {
        c_loaisp sp = new c_loaisp();
        c_history hs = new c_history();
        private int _hdong = 0;
        private string _key = "";
        public f_loaisp()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmloaisps select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                txtid.ReadOnly = true;
                txttenloai.Text = lst.tenloaisp;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmloaisps select a).Single(t => t.id == _key);
                
                txttenloai.Text = lst.tenloaisp;
                _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    sp.them(txtid.Text,txttenloai.Text);
                    hs.add(txtid.Text,"Thêm Loại Sản Phẩm");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    sp.sua(txtid.Text, txttenloai.Text);
                    hs.add(txtid.Text, "Sửa Loại Sản Phẩm");
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
           txttenloai.Properties.ContextImage = null;

            if (custom.checknulltext(txttenloai))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().dmloaisps select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.tenloaisp == txttenloai.Text).Count() > 0)
                {
                    txttenloai.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.tenloaisp == txttenloai.Text).Count() > 0)
                {
                    txttenloai.Properties.ContextImage = Resources.trung;
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