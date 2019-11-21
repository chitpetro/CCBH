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
using DAL;
using DevExpress.XtraEditors;
using GUI.Properties;

namespace GUI.DanhMuc
{
    public partial class f_themdmloaithu : frm.frmthemds
    {
        public f_themdmloaithu()
        {
            InitializeComponent();
        }


        private int _hdong = 0;
        private string _key = "";
        c_dmloaithu lt = new c_dmloaithu();
        c_history hs = new c_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                idTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().dmloaithus select a).Single(t => t.id == _key);

                dataLayoutControl1.DataSource = lst;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmloaithus select a).Single(t => t.id == _key);
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
                    lt.them(idTextEdit.Text, loaithuTextEdit.Text);
                    hs.add(idTextEdit.Text, "Thêm Loại Thu");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    lt.sua(idTextEdit.Text, loaithuTextEdit.Text);
                    hs.add(idTextEdit.Text, "Sửa Loại Thu");
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

            loaithuTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(loaithuTextEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().dmloaithus select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == idTextEdit.Text).Count() > 0)
                {
                    idTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.loaithu == loaithuTextEdit.Text).Count() > 0)
                {
                    loaithuTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != idTextEdit.Text && t.loaithu == loaithuTextEdit.Text).Count() > 0)
                {
                    loaithuTextEdit.Properties.ContextImage = Resources.trung;
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