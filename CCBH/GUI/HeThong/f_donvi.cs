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

namespace GUI.HeThong
{
    public partial class f_donvi : frm.frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_history hs = new c_history();
        c_donvi dv = new c_donvi();
        private int _hdong = 0;
        private string _key = "";
        public f_donvi()
        {
            InitializeComponent();
        }

        private void layttnhom(string id)
        {
            try
            {
                var lst = (from a in dbData.nhomdonvis select a).Single(t => t.id == id);
                lbltennhom.Text = lst.tennhom;
            }
            catch (Exception ex)
            {
                lbltennhom.Text = "";
            }
        }
        private void layttdvql(string id)
        {
            try
            {
                var lst = (from a in dbData.donvis select a).Single(t => t.id == id);
                lbltendvql.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lbltendvql.Text = "";
            }
        }

        private void laydatadvql()
        {
            txtdvql.Properties.DataSource =
                (from a in new KetNoiDBDataContext().donvis where a.cap == (int.Parse(txtcap.Text) - 1) select a);
        }
        private void laydatanhom()
        {
            txtnhomdonvi.Properties.DataSource =
                (from a in new KetNoiDBDataContext().nhomdonvis select a);
        }
        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                var lst = (from a in dbData.donvis select a).Single(t => t.id == _key);
                txtid.ReadOnly = true;
                txtid.Text = lst.id;
                txttendonvi.Text = lst.tendonvi;
                txtdiachi.Text = lst.diachi;
                txtnhomdonvi.Text = lst.nhomdonvi;
                layttnhom(lst.nhomdonvi);
                txtcap.Text = lst.cap.ToString();
                txtdvql.Text = lst.dvql;
                layttdvql(lst.dvql);
            }
            else if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in dbData.donvis select a).Single(t => t.id == _key);

                txttendonvi.Text = lst.tendonvi;
                txtdiachi.Text = lst.diachi;
                txtnhomdonvi.Text = lst.nhomdonvi;
                layttnhom(lst.nhomdonvi);
                txtcap.Text = lst.cap.ToString();
                txtdvql.Text = lst.dvql;
                layttdvql(lst.dvql);
                _hdong = 1;
            }
            laydatadvql();
            laydatanhom();
        }

        private void txtcap_EditValueChanged(object sender, EventArgs e)
        {
            laydatadvql();
            layttdvql(txtdvql.Text);
        }

        private void txtnhomdonvi_EditValueChanged(object sender, EventArgs e)
        {
            layttnhom(txtnhomdonvi.Text);
        }

        private void txtdvql_EditValueChanged(object sender, EventArgs e)
        {
            layttdvql(txtdvql.Text);
        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    dv.them(txtid.Text,txttendonvi.Text,txtnhomdonvi.Text,txtdvql.Text,int.Parse(txtcap.Text),txtdiachi.Text);
                    hs.add(txtid.Text,"Thêm Đơn Vị");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                else if (_hdong == 2)
                {
                    dv.sua(txtid.Text, txttendonvi.Text, txtnhomdonvi.Text, txtdvql.Text, int.Parse(txtcap.Text),txtdiachi.Text);
                    hs.add(txtid.Text, "Sửa Đơn Vị");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }
        private bool kiemtra()
        {
            txtid.Properties.ContextImage = null;
            txttendonvi.Properties.ContextImage = null;
            var lst = (from a in new KetNoiDBDataContext().donvis select a);
            int checknull = 0;
            int checdup = 0;
            if (custom.checknulltext(txtid))
                checknull++;
            if (custom.checknulltext(txttendonvi))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = GUI.Properties.Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.tendonvi == txttendonvi.Text).Count() > 0)
                {
                    txttendonvi.Properties.ContextImage = GUI.Properties.Resources.trung;
                    checdup++;
                }
            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.tendonvi == txttendonvi.Text).Count() > 0)
                {
                    txttendonvi.Properties.ContextImage = GUI.Properties.Resources.trung;
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