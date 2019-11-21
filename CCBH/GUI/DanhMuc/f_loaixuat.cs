using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using GUI.Properties;

namespace GUI.DanhMuc
{
    public partial class f_loaixuat : frm.frmthemds
    {
        public f_loaixuat()
        {
            InitializeComponent();
        }


        private int _hdong = 0;
        private string _key = "";
        c_dmloaixuat lx = new c_dmloaixuat();
        c_history hs = new c_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                idTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().dmloaixuats select a).Single(t => t.id == _key);

                dataLayoutControl1.DataSource = lst;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmloaixuats select a).Single(t => t.id == _key);
                dataLayoutControl1.DataSource = lst;
                idTextEdit.Text = string.Empty;
                _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    lx.them(idTextEdit.Text,loaixuatTextEdit.Text, doanhthuCheckEdit.Checked, noiboCheckEdit.Checked);
                    hs.add(idTextEdit.Text, "Thêm Loại Xuất");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    lx.sua(idTextEdit.Text,loaixuatTextEdit.Text,doanhthuCheckEdit.Checked,noiboCheckEdit.Checked);
                    hs.add(idTextEdit.Text, "Sửa Loại Xuất");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }   

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            idTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(idTextEdit))
                checknull++;

            loaixuatTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(loaixuatTextEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().dmloaixuats select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == idTextEdit.Text).Count() > 0)
                {
                    idTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.loaixuat == loaixuatTextEdit.Text).Count() > 0)
                {
                    loaixuatTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != idTextEdit.Text && t.loaixuat == loaixuatTextEdit.Text).Count() > 0)
                {
                    loaixuatTextEdit.Properties.ContextImage = Resources.trung;
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