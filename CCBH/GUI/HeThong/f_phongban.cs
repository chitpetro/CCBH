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

namespace GUI.HeThong
{
    public partial class f_phongban : frm.frmthemds
    {
        c_phongban pb = new c_phongban();
        c_history hs = new c_history();
        private int _hdong = 0;
        private string _key = "";
        public f_phongban()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                txtid.ReadOnly = true;
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                txtten.Text = lst.ten;
            }
            if (_hdong == 3)
            {
                
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == _key);
                txtten.Text = lst.ten;
                _hdong = 1;
            }
        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    pb.them(txtid.Text,txtten.Text);
                    hs.add(txtid.Text,"Thêm Phòng Ban");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    pb.sua(txtid.Text, txtten.Text);
                    hs.add(txtid.Text, "Sửa Phòng Ban");
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
          
            txtten.Properties.ContextImage = null;

            if (custom.checknulltext(txtten))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().phongbans select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.ten == txtten.Text).Count() > 0)
                {
                    txtten.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.ten == txtten.Text).Count() > 0)
                {
                    txtten.Properties.ContextImage = Resources.trung;
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