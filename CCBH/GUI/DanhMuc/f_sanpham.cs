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
    public partial class f_sanpham : frm.frmthemds
    {
        c_sanpham sp = new c_sanpham();
        c_history hs = new c_history();
        private string _key = "";
        private int _hdong = 0;

        public f_sanpham()
        {
            InitializeComponent();
        }

        private void layttlblloaisp(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dmloaisps select a).Single(t => t.id == id);
                lblloaisp.Text = lst.tenloaisp;
            }
            catch (Exception ex)
            {
                lblloaisp.Text = "";
            }
        }

        private void loadslutxtloaisp()
        {
            txtloaisp.Properties.DataSource = (from a in new KetNoiDBDataContext().dmloaisps select a);
            }

        private void txtloaisp_EditValueChanged(object sender, EventArgs e)
        {
            layttlblloaisp(txtloaisp.Text);
        }

        #region slu loai san pham

        private void txtloaisp_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            //btn edit
            var txtloaispbutton = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };

            txtloaispbutton.Click += txtloaispbutton_Click;

            txtloaispbutton.Location = new Point(5, popupControl.PopupWindow.Height - txtloaispbutton.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtloaispbutton);
            txtloaispbutton.BringToFront();
            // BTN load
            var txtloaispbutton2 = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            txtloaispbutton2.Location = new Point(90, popupControl.PopupWindow.Height - txtloaispbutton2.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtloaispbutton2);
            txtloaispbutton2.BringToFront();
            txtloaispbutton2.Click += txtloaispbutton2_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
        }

        public void txtloaispbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnloaisp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dsloaisp();
            frm.ShowDialog();
            loadslutxtloaisp();
        }

        public void txtloaispbutton2_Click(object sender, EventArgs e)
        {
            loadslutxtloaisp();
            txtloaisp.ShowPopup();
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


        protected override void load()
        {
            loadslutxtloaisp();
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                txtid.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().dmsanphams select a).Single(t => t.id == _key);
                txtid.Text = lst.id;
                
                txttensp.Text = lst.tensp;
                ckmavach.Checked = bool.Parse(lst.mavach.ToString());
                try
                {
                    ImageConverter objfile = new ImageConverter();
                    hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                }
                catch
                {


                }
                txtdvt.Text = lst.dvt;
                txtloaisp.Text = lst.loai; layttlblloaisp(lst.loai);
                txtghichu.Text = lst.ghichu;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmsanphams select a).Single(t => t.id == _key);
                
                txttensp.Text = lst.tensp;
                ckmavach.Checked = bool.Parse(lst.mavach.ToString());
                try
                {
                    ImageConverter objfile = new ImageConverter();
                    hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
              }
                catch
                {


                }
                txtdvt.Text = lst.dvt;
                txtloaisp.Text = lst.loai; layttlblloaisp(lst.loai);
                txtghichu.Text = lst.ghichu;
                _hdong = 1;

            }

        }

        public static byte[] converterhinhanh(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    sp.them(txtid.Text,txttensp.Text,txtdvt.Text,txtloaisp.Text,txtghichu.Text,ckmavach.Checked,converterhinhanh(hinhanh.Image));
                    hs.add(txtid.Text, "Thêm Sản Phẩm");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    sp.sua(txtid.Text, txttensp.Text, txtdvt.Text, txtloaisp.Text, txtghichu.Text,ckmavach.Checked, converterhinhanh(hinhanh.Image));
                    hs.add(txtid.Text, "Sửa Sản Phẩm");
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
          
            txttensp.Properties.ContextImage = null;

            if (custom.checknulltext(txttensp))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().dmsanphams select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == txtid.Text).Count() > 0)
                {
                    txtid.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.tensp == txttensp.Text).Count() > 0)
                {
                    txttensp.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != txtid.Text && t.tensp == txttensp.Text).Count() > 0)
                {
                    txttensp.Properties.ContextImage = Resources.trung;
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