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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using GUI.Properties;

namespace GUI.DanhMuc
{
    public partial class f_doituong : frm.frmthemds
    {
        public f_doituong()
        {
            InitializeComponent();
        }


        private int _hdong = 0;
        private string _key = "";
        c_doituong dt = new c_doituong();
        c_history hs = new c_history();

        protected override void load()
        {
            loadslutxtnhomdt();
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                txtid.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                txttendt.Text = lst.tendt;
                txtnhomdt.Text = lst.nhom;
                layttlblnhomdt(lst.nhom);
                txtgioitinh.Text = lst.gioitinh;
                txtdiachi.Text = lst.diachi;
                txtmsthue.Text = lst.msthue;
                txtdienthoai.Text = lst.dienthoai;
                txtemail.Text = lst.email;
                txtfax.Text = lst.fax;
                txtdd.Text = lst.dd;
                txttaikhoan.Text = lst.taikhoan;
                txtnganhang.Text = lst.nganhang;
                


            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == _key);
                txttendt.Text = lst.tendt;
                txtnhomdt.Text = lst.nhom;
                layttlblnhomdt(lst.nhom);
                txtgioitinh.Text = lst.gioitinh;
                txtdiachi.Text = lst.diachi;
                txtmsthue.Text = lst.msthue;
                txtdienthoai.Text = lst.dienthoai;
                txtemail.Text = lst.email;
                txtfax.Text = lst.fax;
                txtdd.Text = lst.dd;
                txttaikhoan.Text = lst.taikhoan;
                txtnganhang.Text = lst.nganhang;
                _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    dt.them(txtid.Text,txttendt.Text,txtnhomdt.Text,txtdiachi.Text,txtmsthue.Text,txtdienthoai.Text,txtemail.Text,txtfax.Text,txtdd.Text,txttaikhoan.Text,txtnganhang.Text,txtgioitinh.Text);
                    hs.add(txtid.Text, "Thêm Đối Tượng");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    dt.sua(txtid.Text,txttendt.Text,txtnhomdt.Text,txtdiachi.Text,txtmsthue.Text,txtdienthoai.Text,txtemail.Text,txtfax.Text,txtdd.Text,txttaikhoan.Text,txtnganhang.Text,txtgioitinh.Text);
                    hs.add(txtid.Text, "Sửa Đối Tượng");
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

            txttendt.Properties.ContextImage = null;

            if (custom.checknulltext(txttendt))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().doituongs select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.tendt == txttendt.Text).Count() > 0)
                {
                    txttendt.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.tendt == txttendt.Text).Count() > 0)
                {
                    txttendt.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
            }
            if (checdup > 0)
                custom.mes_trunglap();
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }

        private void layttlblnhomdt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhomdoituongs select a).Single(t => t.id == id);
                lblnhomdt.Text = lst.tennhom;
            }
            catch (Exception ex)
            {
                lblnhomdt.Text = "";
            }
        }

        private void loadslutxtnhomdt()
        {
            txtnhomdt.Properties.DataSource = (from a in new KetNoiDBDataContext().nhomdoituongs select a);
        }

        private void txtnhomdt_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            //btn edit
            var txtnhomdtbutton = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };

            txtnhomdtbutton.Click += txtnhomdtbutton_Click;

            txtnhomdtbutton.Location = new Point(5, popupControl.PopupWindow.Height - txtnhomdtbutton.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtnhomdtbutton);
            txtnhomdtbutton.BringToFront();
            // BTN load
            var txtnhomdtbutton2 = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            txtnhomdtbutton2.Location = new Point(90, popupControl.PopupWindow.Height - txtnhomdtbutton2.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtnhomdtbutton2);
            txtnhomdtbutton2.BringToFront();
            txtnhomdtbutton2.Click += txtnhomdtbutton2_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
        }

        public void txtnhomdtbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnnhomdt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dsnhomdoituong();
            frm.ShowDialog();
            loadslutxtnhomdt();
            txtnhomdt.ShowPopup();
        }

        public void txtnhomdtbutton2_Click(object sender, EventArgs e)
        {
            loadslutxtnhomdt();
            txtnhomdt.ShowPopup();
        }

        private static void txt_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }
    }
}