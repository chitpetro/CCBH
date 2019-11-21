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


namespace GUI.HeThong
{
    public partial class f_account : frm.frmthemds
    {
        c_account ac = new c_account();
        c_history hs = new c_history();
        private int _hdong = 0;
        private string _key = "";
        public f_account()
        {
            InitializeComponent();
            loadslutxtdonvi();
            loadslutxtphongban();
        }


        private void btnpass_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnpass.Properties.UseSystemPasswordChar)
            {
                btnpass.Properties.UseSystemPasswordChar = false;
                e.Button.Image = GUI.Properties.Resources.hide_16x16;

            }
            else
            {
                btnpass.Properties.UseSystemPasswordChar = true;
                e.Button.Image = GUI.Properties.Resources.show_16x161;
            }
        }

        private void btnrepass_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnrepass.Properties.UseSystemPasswordChar)
            {
                btnrepass.Properties.UseSystemPasswordChar = false;
                e.Button.Image = GUI.Properties.Resources.hide_16x16;

            }
            else
            {
                btnrepass.Properties.UseSystemPasswordChar = true;
                e.Button.Image = GUI.Properties.Resources.show_16x161;
            }
        }

        #region Lấy Thông Tin searchlookup edit

        private void layttlbldonvi(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lbldonvi.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lbldonvi.Text = "";
            }
        }

        private void layttlblphongban(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == id);
                lblphongban.Text = lst.ten;
            }
            catch (Exception ex)
            {
                lblphongban.Text = "";
            }
        }

        #endregion

        #region Load data SLU

        private void loadslutxtdonvi()
        {
            txtdonvi.Properties.DataSource = (from a in new KetNoiDBDataContext().donvis select a);
        }

        private void loadslutxtphongban()
        {
            txtphongban.Properties.DataSource = (from a in new KetNoiDBDataContext().phongbans select a);
        }
        #endregion

        #region SLU Phòng Ban

        private void txtphongban_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            //btn edit
            var txtphongbanbutton = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };

            txtphongbanbutton.Click += txtphongbanbutton_Click;

            txtphongbanbutton.Location = new Point(5, popupControl.PopupWindow.Height - txtphongbanbutton.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtphongbanbutton);
            txtphongbanbutton.BringToFront();
            // BTN load
            var txtphongbanbutton2 = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            txtphongbanbutton2.Location = new Point(90, popupControl.PopupWindow.Height - txtphongbanbutton2.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtphongbanbutton2);
            txtphongbanbutton2.BringToFront();
            txtphongbanbutton2.Click += txtphongbanbutton2_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
        }

        public void txtphongbanbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.ChucNang == "btnphongban");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dsphongban();
            frm.ShowDialog();
            loadslutxtphongban();
        }

        public void txtphongbanbutton2_Click(object sender, EventArgs e)
        {
            loadslutxtphongban();
            txtphongban.ShowPopup();
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

        #endregion

        #region SLU Đơn Vị

        private void txtdonvi_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            //btn edit
            var txtdonvibutton = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };

            txtdonvibutton.Click += txtdonvibutton_Click;

            txtdonvibutton.Location = new Point(5, popupControl.PopupWindow.Height - txtdonvibutton.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtdonvibutton);
            txtdonvibutton.BringToFront();
            // BTN load
            var txtdonvibutton2 = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            txtdonvibutton2.Location = new Point(90, popupControl.PopupWindow.Height - txtdonvibutton2.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtdonvibutton2);
            txtdonvibutton2.BringToFront();
            txtdonvibutton2.Click += txtdonvibutton2_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
        }

        public void txtdonvibutton_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.ChucNang == "btndonvi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dsdonvi();
            frm.ShowDialog();
            loadslutxtdonvi();
        }

        public void txtdonvibutton2_Click(object sender, EventArgs e)
        {
            loadslutxtdonvi();

        }

        #endregion

        private void txtphongban_EditValueChanged(object sender, EventArgs e)
        {
            layttlblphongban(txtphongban.Text);

        }

        private void txtdonvi_EditValueChanged(object sender, EventArgs e)
        {
            layttlbldonvi(txtdonvi.Text);
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 1)
            {
                txtid.Text = "YYYY";
            }
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                txtid.ReadOnly = true;
                txtuname.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                txtname.Text = lst.name;
                txtuname.Text = lst.uname;
                txtphongban.Text = lst.phongban;
                layttlblphongban(lst.phongban);
                txtdonvi.Text = lst.madonvi;
                checkactive.Checked = (bool) lst.IsActived;
                ckpos.Checked = (bool) lst.pos;
                layttlbldonvi(lst.madonvi);
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;


                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == _key);

                txtname.Text = lst.name;
                txtphongban.Text = lst.phongban;
                layttlblphongban(lst.phongban);
                txtdonvi.Text = lst.madonvi;
                layttlbldonvi(lst.madonvi);
                _hdong = 1;
            }
        }


        #region Kiemtra

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            txtid.Properties.ContextImage = null;

            if (custom.checknulltext(txtid))
                checknull++;

            txtuname.Properties.ContextImage = null;

            if (custom.checknulltext(txtuname))
                checknull++;

            txtname.Properties.ContextImage = null;

            if (custom.checknulltext(txtname))
                checknull++;

            txtphongban.Properties.ContextImage = null;

            if (custom.checknulltext(txtphongban))
                checknull++;
            txtdonvi.Properties.ContextImage = null;

            if (custom.checknulltext(txtdonvi))
                checknull++;


            var lst = (from a in new KetNoiDBDataContext().accounts select a);
            if (_hdong == 1)
            {
                btnpass.Properties.ContextImage = null;

                if (custom.checknulltext(btnpass))
                    checknull++;

                //btnrepass.Properties.ContextImage = null;

                //if (custom.checknulltext(btnrepass))
                //    checknull++;

                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.uname == txtuname.Text).Count() > 0)
                {
                    txtuname.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.uname == txtuname.Text).Count() > 0)
                {
                    txtuname.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
            }


            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            if (checdup > 0)
                custom.mes_trunglap();
            if (checdup > 0 || checknull > 0)
                return false;

            if (btnpass.Text != btnrepass.Text)
            {
                XtraMessageBox.Show("Mật Khẩu Xác Nhận Chưa Chính xác Vui Lòng Kiểm Tra Lại");
                btnrepass.ErrorText = "Confirmation Error.";
                return false;
            }

            return true;
        }
        #endregion

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    txtid.Text = custom.matutang("NV" + txtdonvi.Text + "_");
                    ac.them(txtid.Text, txtuname.Text, txtname.Text, custom.Encrypt(btnpass.Text), txtphongban.Text, txtdonvi.Text, checkactive.Checked, ckpos.Checked);
                    hs.add(txtid.Text, "Thêm Tài Khoản");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;

                }
                if (_hdong == 2)
                {
                    if (Biencucbo.phongban != "AD")
                    {
                        Biencucbo.key = txtid.Text;
                        var frm = new f_xacnhanmatkhau();
                        if (frm.ShowDialog() != DialogResult.OK)
                            return;}

                    if (btnpass.Text.Trim() != "")
                    {
                        ac.sua(txtid.Text, txtname.Text, custom.Encrypt(btnpass.Text), txtphongban.Text, txtdonvi.Text, checkactive.Checked, ckpos.Checked);
                        hs.add(txtid.Text, "Thay đổi mật khẩu");
                        custom.mes_done();
                        DialogResult = DialogResult.OK;
                    }

                    ac.sua2(txtid.Text, txtname.Text, txtphongban.Text, txtdonvi.Text, checkactive.Checked,ckpos.Checked);
                    hs.add(txtid.Text, "Sửa Tài Khoản");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }

        }
    }

}