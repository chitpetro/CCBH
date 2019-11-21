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
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using GUI.Properties;

namespace GUI.HeThong
{
    public partial class f_tientechinh : frm.frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_tientechinh()
        {
            InitializeComponent();
        }


        private int _hdong = 0;
        private string _key = "";

        c_history hs = new c_history();

        protected override void load()
        {
            loadslutentienteSearchLookUpEdit();
            _key = Biencucbo.key;
            var lst = (from a in new KetNoiDBDataContext().maincurrencies select a).Single(t => t.key == "main");
            dataLayoutControl1.DataSource = lst;
        }

        protected override void luu()
        {
            if (kiemtra())
            {

                var mc = (from a in dbData.maincurrencies select a).Single(t => t.key == "main");
                mc.tentiente = tentienteSearchLookUpEdit.Text;
                dbData.SubmitChanges();
                hs.add(tentienteSearchLookUpEdit.Text, "Thay Đổi Tiền Tệ Chính");
                custom.mes_done();
                DialogResult = DialogResult.OK;
            }
        }

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            tentienteSearchLookUpEdit.Properties.ContextImage = null;

            if (custom.checknulltext(tentienteSearchLookUpEdit))
                checknull++;

            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            if (checknull > 0)
                return false;
            return true;
        }


        private void tentienteSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem) popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem) clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem) clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnadd = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnadd.Click += btnadd_Click;

            // BTN load
            var btnreload = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreload.Click += btnreload_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
            if (checkbtn)
            {
                myLCI.Control = btnadd;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreload;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtn = false;
            }
        }

        private bool checkbtn = true;

        private void loadslutentienteSearchLookUpEdit()
        {
            tentienteSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().tientes select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.ChucNang == "btntiente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new DanhMuc.f_dstiente();
            frm.ShowDialog();
            loadslutentienteSearchLookUpEdit();
            tentienteSearchLookUpEdit.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslutentienteSearchLookUpEdit();
            tentienteSearchLookUpEdit.ShowPopup();
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