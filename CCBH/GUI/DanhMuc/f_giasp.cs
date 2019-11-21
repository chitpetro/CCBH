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
    public partial class f_giasp : frm.frmthemds
    {
        c_giasp g = new c_giasp();
        c_history hs = new c_history();
        private int _hdong = 0;
        private string _key = "";
        public f_giasp()
        {
            InitializeComponent();
        }

        private void loadslutxtidsp()
        {
            var lst = (from a in new KetNoiDBDataContext().giasps select a.idsp).ToList();
            txtidsp.Properties.DataSource = (from a in new KetNoiDBDataContext().SP_Laydssp_giasp()  select a).ToList();
        }

        private void layttlbltensp(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dmsanphams select a).Single(t => t.id == id);
                lbltensp.Text = lst.tensp;
            }
            catch (Exception ex)
            {
                lbltensp.Text = "";
            }
        }

        #region slu idsp

        private void txtidsp_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            //btn edit
            var txtidspbutton = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };

            txtidspbutton.Click += txtidspbutton_Click;

            txtidspbutton.Location = new Point(5, popupControl.PopupWindow.Height - txtidspbutton.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtidspbutton);
            txtidspbutton.BringToFront();
            // BTN load
            var txtidspbutton2 = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            txtidspbutton2.Location = new Point(90, popupControl.PopupWindow.Height - txtidspbutton2.Height - 10);
            popupControl.PopupWindow.Controls.Add(txtidspbutton2);
            txtidspbutton2.BringToFront();
            txtidspbutton2.Click += txtidspbutton2_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
        }

        public void txtidspbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnsanpham");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dssanpham();
            frm.ShowDialog();
            loadslutxtidsp();
            txtidsp.ShowPopup();
        }

        public void txtidspbutton2_Click(object sender, EventArgs e)
        {
            loadslutxtidsp();
            txtidsp.ShowPopup();
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

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            txtidsp.Properties.ContextImage = null;

            if (custom.checknulltext(txtidsp))
                checknull++;

            var lst = (from a in new KetNoiDBDataContext().giasps select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.idsp == txtidsp.Text && t.iddv == Biencucbo.donvi).Count() > 0)
                {
                    txtidsp.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (checdup > 0)
                custom.mes_trunglap();
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }

        #region overide

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            loadslutxtidsp();
            if (_hdong == 2)
            {
                txtidsp.Properties.DataSource = new KetNoiDBDataContext().dmsanphams.ToList();
                _key = Biencucbo.key;
                txtidsp.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().SP_LayDSSanPhamKemGia(Biencucbo.donvi) select a).Single(t => t.key == _key);
                txtidsp.Text = lst.id;
                layttlbltensp(lst.id);
                lbldonvi.Text = "Đơn Vị " + lst.iddv + "-" + lst.tendonvi;
                txtgia.Text = lst.gia.ToString();
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().SP_LayDSSanPhamKemGia(Biencucbo.donvi) select a).Single(t => t.key == _key);
                txtidsp.Text = lst.id;
                layttlbltensp(lst.id);
                lbldonvi.Text = "Đơn Vị " + lst.iddv + "-" + lst.tendonvi;
                txtgia.Text = lst.gia.ToString();
                    _hdong = 1;

            }

            if (_hdong == 1)
            {
                _key = custom.laykey();
                lbldonvi.Text = "Đơn Vị " + Biencucbo.donvi + "-" + (from a in new  KetNoiDBDataContext().donvis select a).Single(t=>t.id == Biencucbo.donvi).tendonvi;
            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    g.them(_key,txtidsp.Text,Biencucbo.donvi,double.Parse(txtgia.Text));
                    hs.add(txtidsp.Text, "Thêm DoiTuong");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    g.sua(_key, txtidsp.Text, Biencucbo.donvi, double.Parse(txtgia.Text));
                    hs.add(txtidsp.Text, "Sửa DoiTuong");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }
        #endregion

        private void txtidsp_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltensp(txtidsp.Text);
        }
    }
}