using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraRichEdit.Import.OpenXml;

namespace GUI.ChucNang
{
    public partial class f_thutienbanhang : frm.frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_ptt pn = new c_ptt();
        c_history hs = new c_history();

        /// <summary>
        /// 0: default
        /// 1: add
        /// 2: edit
        /// 3: coppy
        /// </summary>
        private int _hdong;

        private int _so;
        private string _key;
        private string _keytemp;
        private string _donvi = string.Empty;
        private string _link = string.Empty;
        private string _id = string.Empty;
        private string _idnv = string.Empty;
        private string _iddt = string.Empty;

        public f_thutienbanhang()
        {
            InitializeComponent();
        }

        private void laytttygiaSpinEditt(string tiente)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().tientes select a).Single(t => t.tentiente == tiente);
                tygiaSpinEdit.Text = lst.tygia.ToString();
            }
            catch (Exception ex)
            {
                tygiaSpinEdit.Text = "0";
            }
        }

        private void tienteSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            laytttygiaSpinEditt(tienteSearchLookUpEdit.Text);
            loadtientra();
            loadthanhtien();
        }

        private void loadslutienteSearchLookUpEdit()
        {
            tienteSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().tientes select a);
        }

        private bool kiemtra()
        {
            int checknull = 0;

            ngaythuDateEdit.Properties.ContextImage = null;
            if (custom.checknulltext(ngaythuDateEdit))
                checknull++;
            tienteSearchLookUpEdit.Properties.ContextImage = null;
            if (custom.checknulltext(tienteSearchLookUpEdit))
                checknull++;
            tienthuSpinEdit.Properties.ContextImage = null;
            tienthuSpinEdit.Properties.ContextImage = null;
            if (custom.checknulltext(tienthuSpinEdit))
                checknull++;
            if (custom.checknulltext(tienthuSpinEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
                return false;
            }
            return true;
        }

        private void loadinfothanhtoan()
        {
            if (_hdong == 1)
            {
                var lst = (from a in dbData.ptts where a.link == _link select a);
                if (lst.Count() > 0)
                {
                    txttongtien.EditValue = Biencucbo.tongtien;
                    txttongtra.EditValue = double.Parse(lst.Sum(t => t.thanhtientt).ToString()) +
                                           double.Parse(thanhtienttSpinEdit.Text);
                    txttongcon.EditValue = double.Parse(txttongtien.Text) - double.Parse(txttongtra.Text);
                }
                else
                {
                    txttongtien.EditValue = Biencucbo.tongtien;
                    txttongtra.EditValue = 0 + double.Parse(thanhtienttSpinEdit.Text);
                    txttongcon.EditValue = double.Parse(txttongtien.Text) - double.Parse(txttongtra.Text);
                }
            }
            else if (_hdong == 0)
            {
                var lst = (from a in dbData.ptts where a.link == _link select a);
                if (lst.Count() > 0)
                {
                    txttongtien.EditValue = Biencucbo.tongtien;
                    txttongtra.EditValue = double.Parse(lst.Sum(t => t.thanhtientt).ToString());
                    txttongcon.EditValue = double.Parse(txttongtien.Text) - double.Parse(txttongtra.Text);
                }
                else
                {
                    txttongtien.EditValue = Biencucbo.tongtien;
                    txttongtra.EditValue = 0 + double.Parse(thanhtienttSpinEdit.Text);
                    txttongcon.EditValue = double.Parse(txttongtien.Text) - double.Parse(txttongtra.Text);
                }
            }
            else if (_hdong == 2)
            {
                var lst = (from a in dbData.ptts where a.link == _link select a);

                txttongtien.EditValue = Biencucbo.tongtien;
                double _tra = 0;
                _tra = double.Parse(lst.Sum(t => t.thanhtientt).ToString()) -
                       double.Parse(lst.Single(t => t.key == _key).thanhtientt.ToString());
                txttongtra.EditValue = _tra +
                                       double.Parse(thanhtienttSpinEdit.Text);
                txttongcon.EditValue = double.Parse(txttongtien.Text) - double.Parse(txttongtra.Text);

            }

        }

        private void loadthanhtien()
        {
            try
            {
                thanhtienttSpinEdit.EditValue = (double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) - double.Parse(tientraSpinEdit.Text);
                loadinfothanhtoan();
            }
            catch (Exception ex)
            {

            }
        }

        private void loadtientra()
        {
            try
            {
                if (_hdong == 1)
                {
                    double _tra = 0;
                    var lst = (from a in dbData.ptts where a.link == _link select a);
                    if (lst.Count() > 0)
                    {

                        _tra = Biencucbo.tongtien - double.Parse(lst.Sum(t => t.thanhtientt).ToString());
                        if ((double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) > _tra)
                            tientraSpinEdit.EditValue = (double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) -
                                                        _tra;
                        else
                        {
                            tientraSpinEdit.EditValue = 0;
                        }
                    }
                    else
                    {
                        _tra = Biencucbo.tongtien - 0;
                        if ((double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) > _tra)
                            tientraSpinEdit.EditValue = (double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) -
                                                        _tra;
                        else
                        {
                            tientraSpinEdit.EditValue = 0;
                        }
                    }

                }

                else if (_hdong == 2)
                {
                    double _tra = 0;
                    var lst = (from a in dbData.ptts where a.link == _link select a);


                    _tra = Biencucbo.tongtien - (double.Parse(lst.Sum(t => t.thanhtientt).ToString()) - double.Parse(lst.Single(t => t.key == _key).thanhtientt.ToString()));
                    if ((double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) > _tra)
                        tientraSpinEdit.EditValue = (double.Parse(tienthuSpinEdit.Text) * double.Parse(tygiaSpinEdit.Text)) -
                                                    _tra;
                    else
                    {
                        tientraSpinEdit.EditValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        #region Method

        private void dongedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.True;
            _hdong = 0;
        }

        private void moedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.False;
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.Default;
            // Textbox readonly = true

            thanhtienttSpinEdit.ReadOnly = true;
            tientraSpinEdit.ReadOnly = true;
            tygiaSpinEdit.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txttongtra.ReadOnly = true;
            txttongcon.ReadOnly = true;
            tienthuSpinEdit.Focus();



        }

        private void themtxt()
        {
            _keytemp = _key;
            _key = custom.laykey();
            xoatxt();
            _hdong = 1;
            _idnv = Biencucbo.idnv;
            ngaythuDateEdit.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tienteSearchLookUpEdit.Text = custom.laytientechinh();

            moedit();

        }

        private void xoatxt()
        {
            dataLayoutControl1.DataSource = (from a in dbData.ptts where a.key == _key select a);
            //Textbox.text = string.empty

            ngaythuDateEdit.Text = string.Empty;
            tientraSpinEdit.EditValue = 0;
            tienthuSpinEdit.EditValue = 0;
            thanhtienttSpinEdit.EditValue = 0;
            //.Text = string.Empty;

            //tieptuc


            dongedit();


        }

        private void loadinfo(string key)
        {
            dongedit();
            try
            {
                var lst = (from a in new KetNoiDBDataContext().ptts select a).Single(t => t.key == key);
                dataLayoutControl1.DataSource = lst;
                _key = lst.key;
                _id = lst.id;
                _so = Convert.ToInt32(lst.so);
                _idnv = lst.idnv;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region override

        protected override void load()
        {

            // Load dữ liệu searchlookup 
            loadslutienteSearchLookUpEdit();
            if (_donvi == string.Empty)
            {
                _donvi = Biencucbo.donvi;
            }
            _link = Biencucbo.link;
            _iddt = Biencucbo.iddt;

            var lstlink =
                (from a in new KetNoiDBDataContext().ptts where a.link == _link && a.iddv == _donvi select a);
            if (lstlink.Count() > 0)
            {

                dongedit();
                try
                {
                    var so = (from a in lstlink select a.so).Max();
                    if (so == null)
                        return;
                    var lst = (from a in lstlink select a).Single(t => t.so == so);
                    loadinfo(lst.key);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                btnmo.Enabled = false;
                btnthem.Enabled = false;
                btnluu.Enabled = true;
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
                btnreload.Enabled = false;
                btnin.Enabled = false;
                btnsaochep.Enabled = false;
                btnfirst.Enabled = false;
                btnnext.Enabled = false;
                btnprev.Enabled = false;
                btnlast.Enabled = false;

                themtxt();
            }
        }

        protected override void mo()
        {
            f_dsthutienbanhang frm = new f_dsthutienbanhang();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _key = Biencucbo.key;
                loadinfo(_key);
            }
        }

        protected override void them()
        {
            themtxt();
        }

        protected override bool saochep()
        {
            XtraMessageBox.Show("Phiếu này không thêt sao chép");
            return false;
        }


        protected override bool luu()
        {
            try
            {

                if (kiemtra())
                {
                    if (_hdong == 1)
                    {
                        _id = custom.matutang("TT" + _donvi);
                        _so = Biencucbo.so;
                        pn.them(_key, _id, ngaythuDateEdit.DateTime, _idnv, _iddt, _so, _donvi, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text), _link, double.Parse(tienthuSpinEdit.Text), double.Parse(tientraSpinEdit.Text), double.Parse(thanhtienttSpinEdit.Text));

                        hs.add(_id, "Thêm Thu Tiền Bán Hàng");
                
                        dongedit();
                        return true;

                    }
                    if (_hdong == 2)
                    {
                        pn.sua(_key, ngaythuDateEdit.DateTime, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text), double.Parse(tienthuSpinEdit.Text), double.Parse(tientraSpinEdit.Text), double.Parse(thanhtienttSpinEdit.Text));

                        hs.add(_id, "Sửa Thu Tiền Bán Hàng");
                   
                        dongedit();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override bool sua()
        {
            if (_id != string.Empty)
            {
                dbData = new KetNoiDBDataContext();
                _hdong = 2;

                moedit();
                return true;
            }
            return false;
        }

        protected override bool xoa()
        {
            if (_id == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {


                pn.xoa(_key);
                hs.add(_id, "Xóa Thu Tiền Bán Hàng");
              
                dongedit();
                xoatxt();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void reload()
        {
            if (_hdong == 1)
            {
                _key = _keytemp;
            }
            loadinfo(_key);
            dongedit();
        }

        protected override void print()
        {
            DialogResult = DialogResult.OK;
        }

        protected override void first()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().ptts where a.iddv == _donvi && a.link == _link select a.so).Min();
                if (lst == null)
                    return;
                var lst1 =
                    (from a in new KetNoiDBDataContext().ptts where a.iddv == _donvi && a.link == _link select a).Single(t => t.so == lst);
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void prev()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().ptts where a.iddv == _donvi && a.link == _link && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().ptts where a.iddv == _donvi && a.so == lst && a.link == _link select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void next()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().ptts where a.iddv == _donvi && a.so > _so && a.link == _link select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().ptts where a.iddv == _donvi && a.so == lst && a.link == _link select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void last()
        {
            load();
        }





        #endregion

        private void tienthuSpinEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void tienthuSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            loadtientra();
            loadthanhtien();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
    
            if (btnluu.Enabled == false && double.Parse(txttongcon.Text) == 0)
            {
                DialogResult = DialogResult.OK;
            }
           
        }

        private void f_thutienbanhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tienthuSpinEdit.Text == "0.00")
                    return;

                if (btnluu.Enabled)
                {
                    btnmo.Enabled = true;
                    btnthem.Enabled = true;
                    btnsaochep.Enabled = true;
                    btnluu.Enabled = false;
                    btnsua.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;
                    btnfirst.Enabled = true;
                    btnprev.Enabled = true;
                    btnnext.Enabled = true;
                    btnlast.Enabled = true;
                    luu();
                    if (double.Parse(txttongcon.Text) == 0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        btnmo.Enabled = false;
                        btnthem.Enabled = false;
                        btnsaochep.Enabled = false;
                        btnluu.Enabled = true;
                        btnsua.Enabled = false;
                        btnxoa.Enabled = false;
                        btnin.Enabled = false;
                        btnreload.Enabled = true;
                        btnfirst.Enabled = false;
                        btnprev.Enabled = false;
                        btnnext.Enabled = false;
                        btnlast.Enabled = false;
                        them();

                    }
                }
               

            }
                
        }

        private void f_thutienbanhang_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
          //  this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "THU TIỀn BÁN HÀNG ").ToString();
            changeFont.Translate(this);
        }
    }
}