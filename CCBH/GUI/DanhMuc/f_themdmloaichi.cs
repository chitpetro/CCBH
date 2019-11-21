using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using GUI.Properties;

namespace GUI.DanhMuc
{
    public partial class f_themdmloaichi : frm.frmthemds
    {
        public f_themdmloaichi()
        {
            InitializeComponent();
        }



        private int _hdong = 0;
        private string _key = "";
        c_dmloaichi lc = new c_dmloaichi();
        c_history hs = new c_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                idTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().dmloaichis select a).Single(t => t.id == _key);

                dataLayoutControl1.DataSource = lst;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmloaichis select a).Single(t => t.id == _key);
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
                    lc.them(idTextEdit.Text, loaichiTextEdit.Text,chiphiCheckEdit.Checked, congnoCheckEdit.Checked);
                    hs.add(idTextEdit.Text, "Thêm Loại Chi");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    lc.sua(idTextEdit.Text, loaichiTextEdit.Text,chiphiCheckEdit.Checked,congnoCheckEdit.Checked);
                    hs.add(idTextEdit.Text, "Sửa Loại Chi");
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

            loaichiTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(loaichiTextEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().dmloaichis select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == idTextEdit.Text).Count() > 0)
                {
                    idTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.loaichi == loaichiTextEdit.Text).Count() > 0)
                {
                    loaichiTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != idTextEdit.Text && t.loaichi == loaichiTextEdit.Text).Count() > 0)
                {
                    loaichiTextEdit.Properties.ContextImage = Resources.trung;
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