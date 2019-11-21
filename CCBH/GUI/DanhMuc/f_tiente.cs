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
    public partial class f_tiente : frm.frmthemds
    {
        public f_tiente()
        {
            InitializeComponent();
        }



        private int _hdong = 0;
        private string _key = "";
        c_tiente tt = new c_tiente();
        c_history hs = new c_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                tentienteTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().tientes select a).Single(t => t.tentiente == _key);

                dataLayoutControl1.DataSource = lst;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().tientes select a).Single(t => t.tentiente == _key);
                dataLayoutControl1.DataSource = lst;
                tentienteTextEdit.Text = string.Empty;
                _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    tt.them(tentienteTextEdit.Text,double.Parse(tygiaSpinEdit.Text),ghichuMemoExEdit.Text);
                    hs.add(tentienteTextEdit.Text, "Thêm Tiền Tệ");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    tt.sua(tentienteTextEdit.Text, double.Parse(tygiaSpinEdit.Text), ghichuMemoExEdit.Text);
                    hs.add(tentienteTextEdit.Text, "Sửa Tiền Tệ");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }              
        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            tentienteTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(tentienteTextEdit))
                checknull++;

            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().tientes select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.tentiente == tentienteTextEdit.Text).Count() > 0)
                {
                    tentienteTextEdit.Properties.ContextImage = Resources.trung;
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