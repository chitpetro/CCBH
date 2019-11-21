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
using ControlLocalizer;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using GUI.DanhMuc;
using GUI.Properties;

namespace GUI.ChucNang
{
    public partial class f_banhang : frm.frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_pxuat pn = new c_pxuat();
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
        public f_banhang()
        {
            InitializeComponent();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }
        private bool kiemtra()
        {
            int checknull = 0;
            int checksp = 0;
            ngayxuatDateEdit.Properties.ContextImage = null;
            loaixuatSearchLookUpEdit.Properties.ContextImage = null;
            iddtSearchLookUpEdit.Properties.ContextImage = null;
            tienteSearchLookUpEdit.Properties.ContextImage = null;

            if (custom.checknulltext(ngayxuatDateEdit))
                checknull++;
            if (custom.checknulltext(loaixuatSearchLookUpEdit))
                checknull++;
            if (custom.checknulltext(iddtSearchLookUpEdit))
                checknull++;
            if (custom.checknulltext(tienteSearchLookUpEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }

            for (int i = 0; i < gv.DataRowCount; i++)
            {
                if (gv.GetRowCellValue(i, "idsp").ToString() == string.Empty)
                {
                    checksp++;
                }
            }

            if (checksp > 0)
            {
                XtraMessageBox.Show("Không được để trống sản phẩm - Vui lòng kiểm tra lại", "THÔNG BÁO");
            }
            if (checknull > 0 || checksp > 0)
                return false;
            return true;


        }


        #region Lấy thông tin searchlookup

        private void layttlblteniddv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lblteniddv.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lblteniddv.Text = "";
            }
        }

        private void layttlblteniddt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == id);
                lblteniddt.Text = lst.tendt;
                diachiTextEdit.Text = lst.diachi;
            }
            catch (Exception ex)
            {
                lblteniddt.Text = "";
                diachiTextEdit.Text = string.Empty;
            }
        }

        private void layttlbltenloaixuat(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dmloaixuats select a).Single(t => t.id == id);
                lbltenloaixuat.Text = lst.loaixuat;
            }
            catch (Exception ex)
            {
                lbltenloaixuat.Text = "";
            }
        }

        private void layttlbltenidnv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lbltenidnv.Text = lst.name;
                var lst2 = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == lst.phongban);
                tenphongbanTextEdit.Text = lst2.ten;
            }
            catch (Exception ex)
            {
                lbltenidnv.Text = "";
                tenphongbanTextEdit.Text = string.Empty;
            }
        }

        private void laytttygiaSpinEdit(string tentiente)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().tientes select a).Single(t => t.tentiente == tentiente);
                tygiaSpinEdit.Text = lst.tygia.ToString();
            }
            catch (Exception ex)
            {
                tygiaSpinEdit.Text = "0";
            }
        }

        #endregion

        #region Thay đổi thông tin SearchLookUp

        private void iddtSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblteniddt(iddtSearchLookUpEdit.Text);
        }

        private void iddvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblteniddv(iddvTextEdit.Text);
        }

        private void loaixuatSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltenloaixuat(loaixuatSearchLookUpEdit.Text);
        }

        private void idnvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltenidnv(idnvTextEdit.Text);
        }

        private void tienteSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (_hdong != 0)
            {
                laytttygiaSpinEdit(tienteSearchLookUpEdit.Text);
                for (int i = 0; i < gv.DataRowCount; i++)
                {
                    var ct = gv.GetRow(i) as pxuatct;
                    if (ct == null)
                        return;
                    try
                    {
                        ct.thanhtien = ct.nguyente * double.Parse(tygiaSpinEdit.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                txtmavach.Focus();
            }
        }



        #endregion

        #region Searchlookup_popup

        // Loại Xuất
        private void loaixuatSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

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

        private void loadsluloaixuatSearchLookUpEdit()
        {
            loaixuatSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().dmloaixuats select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                //Biencucbo.QuyenDangChon =
                   // (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnloaixuat");

                Biencucbo.QuyenDangChon =
                  (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnloaixuat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new DanhMuc.f_dsloaixuat();
            frm.ShowDialog();
            loadsluloaixuatSearchLookUpEdit();
            loaixuatSearchLookUpEdit.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadsluloaixuatSearchLookUpEdit();
            loaixuatSearchLookUpEdit.ShowPopup();
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

        // Đối Tượng
        private void iddtSearchLookUpEdit_Popup(object sender, EventArgs e)
        {

            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnaddiddtSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddiddtSearchLookUpEdit.Click += btnaddiddtSearchLookUpEdit_Click;

            // BTN load
            var btnreloadiddtSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadiddtSearchLookUpEdit.Click += btnreloadiddtSearchLookUpEdit_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtniddtSearchLookUpEdit)
            {
                myLCI.Control = btnaddiddtSearchLookUpEdit;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadiddtSearchLookUpEdit;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtniddtSearchLookUpEdit = false;
            }
        }

        private bool checkbtniddtSearchLookUpEdit = true;

        private void loadsluiddtSearchLookUpEdit()
        {
            iddtSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().doituongs select a);
        }

        public void btnaddiddtSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btndoituong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_doituong();
            frm.ShowDialog();
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        public void btnreloadiddtSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        // Tiền Tệ
        private void tienteSearchLookUpEdit_Popup(object sender, EventArgs e)
        {

            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnaddtienteSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddtienteSearchLookUpEdit.Click += btnaddtienteSearchLookUpEdit_Click;

            // BTN load
            var btnreloadtienteSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadtienteSearchLookUpEdit.Click += btnreloadtienteSearchLookUpEdit_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtntienteSearchLookUpEdit)
            {
                myLCI.Control = btnaddtienteSearchLookUpEdit;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadtienteSearchLookUpEdit;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtntienteSearchLookUpEdit = false;
            }
        }

        private bool checkbtntienteSearchLookUpEdit = true;

        private void loadslutienteSearchLookUpEdit()
        {
            tienteSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().tientes select a);
        }

        public void btnaddtienteSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btntiente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dstiente();
            frm.ShowDialog();
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();
        }

        public void btnreloadtienteSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();
        }

        // sản phẩm
        private void sidsp_Popup(object sender, EventArgs e)
        {

            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnaddsidsp = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddsidsp.Click += btnaddsidsp_Click;

            // BTN load
            var btnreloadsidsp = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadsidsp.Click += btnreloadsidsp_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtnsidsp)
            {
                myLCI.Control = btnaddsidsp;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadsidsp;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtnsidsp = false;
            }
        }

        private bool checkbtnsidsp = true;

        private void loadslusidsp()
        {
            sidsp.DataSource = (from a in new KetNoiDBDataContext().dmsanphams select a);
            stensp.DataSource = sidsp.DataSource;
            sdvt.DataSource = sidsp.DataSource;
        }

        public void btnaddsidsp_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnsanham");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_sanpham();
            frm.ShowDialog();
            loadslusidsp();

        }

        public void btnreloadsidsp_Click(object sender, EventArgs e)
        {
            loadslusidsp();


        }

        private void sidsp_EditValueChanged(object sender, EventArgs e)
        {
            gv.PostEditor();
            try
            {
                var ct = gv.GetFocusedRow() as pxuatct;

                string abc = ct.idsp;

                var lst = (from a in new KetNoiDBDataContext().dmsanphams where a.id == abc select a);
                if (lst.Count() == 0)
                {
                    MessageBox.Show("Sản phẩm này chưa được đưa vào danh mục-Vui lòng kiểm tra lại!", "Thông Báo");
                    ct.idsp = string.Empty;
                    ct.dongia = 0;
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    return;
                }
                var lst2 = from a in new KetNoiDBDataContext().giasps
                    where a.idsp == abc 
                    select a;
                if (lst2.Count() == 0)
                {
                    MessageBox.Show("Sản phẩm này chưa được quy định giá bán-Vui lòng kiểm tra lại!", "Thông Báo");
                    ct.idsp = string.Empty;
                    ct.dongia = 0;
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    return;
                }

                ct.dongia = lst2.Single().gia;
                gv.PostEditor();
                gv.UpdateCurrentRow();

            }
            catch (Exception ex)
            {

            }

     
        }

        #endregion

        #region Method
        private void dongedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.True;
            gv.OptionsBehavior.Editable = false;
            chonsoluong(false);
            _hdong = 0;
        }

        private void moedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.False;
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.Default;
            iddvTextEdit.ReadOnly = true;
            idTextEdit.ReadOnly = true;
            idnvTextEdit.ReadOnly = true;
            tenphongbanTextEdit.ReadOnly = true;
            tienteSearchLookUpEdit.ReadOnly = true;
            diachiTextEdit.ReadOnly = true;
          //  loaixuatSearchLookUpEdit.ReadOnly = true;
          //  iddtSearchLookUpEdit.ReadOnly = true;
            gv.OptionsBehavior.Editable = true;
            txtmavach.Focus();
            chonsoluong(false);
        }

        private void chonsoluong(bool _check)
        {
            checksl.Checked = _check;
            if (_check)
            {
                checksl.Text = "Yes";
            }
            else
            {
                checksl.Text = "No";
            }

        }

        private void themtxt()
        {
            _keytemp = _key;
            _key = custom.laykey();
            xoatxt();
            _hdong = 1;
            chonsoluong(false);
            try
            {
                gd.DataSource = (from a in dbData.pxuatcts where a.keypx == _key select a);

            }
            catch (Exception ex)
            {

            }

            //gv.AddNewRow();
            iddvTextEdit.Text = _donvi;
            idTextEdit.Text = "YYYY";

            ngayxuatDateEdit.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tienteSearchLookUpEdit.Text = custom.laytientechinh();
            idnvTextEdit.Text = Biencucbo.idnv;
            iddtSearchLookUpEdit.Text = "KH_01";
            loaixuatSearchLookUpEdit.Text = "XB";
            iddtSearchLookUpEdit.Focus();
            moedit();

        }

        private void xoatxt()
        {
            dataLayoutControl1.DataSource = (from a in dbData.pxuats where a.key == _key select a);
            iddvTextEdit.Text = string.Empty;
            idTextEdit.Text = string.Empty;
            ngayxuatDateEdit.Text = string.Empty;
            loaixuatSearchLookUpEdit.Text = string.Empty;
            idnvTextEdit.Text = string.Empty;
            iddtSearchLookUpEdit.Text = string.Empty;
            tienteSearchLookUpEdit.Text = string.Empty;
            diengiaiTextEdit.Text = string.Empty;
            chonsoluong(false);
            dongedit();

        }

        private void loadinfo(string key)
        {
            dongedit();
            try
            {
                var lst = (from a in new KetNoiDBDataContext().v_pxuats where a.iddv == _donvi select a).Single(t => t.key == key);
                dataLayoutControl1.DataSource = lst;
                tygiaSpinEdit.Text = lst.tygia.ToString();
                var lst2 = (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi select a).Single(t => t.key == key);
                gd.DataSource = lst2.pxuatcts;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so);
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

            if (_donvi == string.Empty)
            {
                _donvi = Biencucbo.donvi;
            }
            // Load dữ liệu searchlookup 

            //  loadsluiddtSearchLookUpEdit
            loadslutienteSearchLookUpEdit();
            loadsluloaixuatSearchLookUpEdit();
            loadslusidsp();
            loadsluiddtSearchLookUpEdit();

            dongedit();

            if (Biencucbo.xembc)
            {
                Biencucbo.xembc = false;
                loadinfo(Biencucbo.key);

            }
            else
            {
                try
                {
                    var so = (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi select a.so).Max();
                    if (so == null)
                        return;
                    var lst =
                        (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi select a).Single(
                            t => t.so == so);
                    loadinfo(lst.key);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void mo()
        {
            f_dsbanhang frm = new f_dsbanhang();
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
            if (idTextEdit.Text != string.Empty)
            {
                Biencucbo.ngaysaochep = ngayxuatDateEdit.DateTime;
                var frm = new f_ngaysaochep();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _hdong = 3;
                    dbData = new KetNoiDBDataContext();
                    _keytemp = _key;
                    _key = custom.laykey();

                    dataLayoutControl1.DataSource = (from a in new KetNoiDBDataContext().pxuats where a.key == _key select a);
                    ngayxuatDateEdit.DateTime = Biencucbo.ngaysaochep;
                    idTextEdit.Text = "YYYY";
                    int dong = gv.DataRowCount;
                    DataTable dt = new DataTable();
                    /// <summary>
                    /// dt.Columns.Add("idsp", typeof(string));
                    /// dt.Columns.Add("soluong", typeof(double));
                    /// dt.Columns.Add("dongia", typeof(double));
                    /// dt.Columns.Add("ghichu", typeof(string));
                    /// </summary>

                    // nhapdulieu1
                    dt.Columns.Add("idsp", typeof(string));
                    dt.Columns.Add("soluong", typeof(double));
                    dt.Columns.Add("dongia", typeof(double));
                    dt.Columns.Add("ghichu", typeof(string));


                    DataRow row;
                    for (int i = 0; i < dong; i++)
                    {
                        /// <summary>
                        ///  var ct = gv.GetRow(i) as pnhap_ct;
                        ///  row = dt.NewRow();
                        ///  row["idsp"] = ct.idsp;
                        /// row["soluong"] = ct.soluong;
                        ///   row["dongia"] = ct.dongia;
                        ///  row["ghichu"] = ct.ghichu;
                        ///  dt.Rows.Add(row);
                        /// </summary>

                        //	Nhapdulieu2
                        var ct = gv.GetRow(i) as pxuatct;
                        row = dt.NewRow();
                        row["idsp"] = ct.idsp;
                        row["soluong"] = ct.soluong;
                        row["dongia"] = ct.dongia;
                        row["ghichu"] = ct.ghichu;
                        dt.Rows.Add(row);
                    }

                    gd.DataSource = (from a in dbData.pxuatcts where a.keypx == _key select a);

                    foreach (DataRow item in dt.Rows)
                    {
                        /// <summary>
                        ///   _idsp = item[0].ToString();
                        /// _soluong = double.Parse(item[1].ToString());
                        ///   _dongia = double.Parse(item[2].ToString());
                        ///   _ghichu = item[3].ToString();
                        ///   gv.AddNewRow();
                        /// </summary>

                        // Nhapdulieu3
                        _idsp = item[0].ToString();
                        _soluong = double.Parse(item[1].ToString());
                        _dongia = double.Parse(item[2].ToString());
                        _ghichu = item[3].ToString();
                        gv.AddNewRow();
                    }
                    _hdong = 1;
                    moedit();
                    return true;
                }
                return false;
            }
            return false;
        }

        private double _soluong, _dongia;

        private string _idsp, _ghichu;
        private bool LuuPhieu()
        {
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = dbData.pxuatcts.Context.GetChangeSet();
                dbData.pxuatcts.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        protected override bool luu()
        {
            try
            {
                gv.PostEditor();
                gv.UpdateCurrentRow();
                if (kiemtra())
                {
                    if (_hdong == 1)
                    {
                        idTextEdit.Text = custom.matutang("BH" + _donvi);
                        _so = Biencucbo.so;
                        pn.them(_key, idTextEdit.Text, ngayxuatDateEdit.DateTime, loaixuatSearchLookUpEdit.Text, idnvTextEdit.Text, iddtSearchLookUpEdit.Text, diengiaiTextEdit.Text, _so, iddvTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text));
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Thêm Phiếu Bán Hàng");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;

                    }
                    if (_hdong == 2)
                    {
                        pn.sua(_key, ngayxuatDateEdit.DateTime, loaixuatSearchLookUpEdit.Text, iddvTextEdit.Text, diengiaiTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text));
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Sửa Phiếu Bán Hàng");
                        XtraMessageBox.Show("Done");
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
            if (idTextEdit.Text != string.Empty)
            {
                if (checklink("sửa"))
                {
                    dbData = new KetNoiDBDataContext();
                    _hdong = 2;
                    gd.DataSource = (from a in dbData.pxuatcts where a.keypx == _key select a);
                    moedit();
                    return true;
                }
                return false;
            }
            return true; 
        }

        protected override bool xoa()
        {
            if (idTextEdit.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            if (checklink("xóa"))
            {
                try
                {

                    for (var i = gv.DataRowCount - 1; i >= 0; i--)
                    {
                        var ct = gv.GetRow(i) as pxuatct;
                        pn.xoact(ct.key);
                        gv.DeleteRow(i);
                    }
                    pn.xoa(_key);
                    hs.add(idTextEdit.Text, "Xóa Phiếu Bán Hàng");
                    XtraMessageBox.Show("Done");
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
            return false;
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
            Biencucbo.title = "PHIẾU XUẤT KHO";
            Biencucbo.ngaybc = "Ngày Lập Phiếu " + ngayxuatDateEdit.Text;
            Biencucbo.info = lbltenloaixuat.Text;
            var lst = (from a in dbData.v_dspxuats where a.key == _key select a);
            var rp = new Report.XuatKho.r_pxuatkho();
            rp.DataSource = lst;
            rp.ShowPreviewDialog();
        }

        protected override void first()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi select a.so).Min();
                if (lst == null)
                    return;
                var lst1 =
                    (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi select a).Single(t => t.so == lst);
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
                var lst = (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void gv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var ct = gv.GetFocusedRow() as pxuatct;
            if (ct == null)
                return;

            int i = 0, k = 0;

            try
            {
                k = Convert.ToInt32(gv.GetRowCellValue(gv.DataRowCount - 1, "stt").ToString());
                k = k + 1;
            }
            catch (Exception ex)
            {

            }

            for (i = 0; i <= gv.DataRowCount - 1;)
            {
                if (k.ToString() == gv.GetRowCellValue(i, "stt").ToString())
                {
                    k = k + 1;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            ct.key = custom.laykey();
            ct.keypx = _key;
            ct.idsp = txtmavach.Text;
            ct.soluong = Biencucbo.soluong;
            ct.dongia = Biencucbo.dongia;
            ct.ghichu = string.Empty;
            ct.stt = k;
            ct.chietkhau = 0;
            ct.giavon = 0;
            ct.nguyente = Biencucbo.soluong * Biencucbo.dongia;
            gv.PostEditor();
            gv.UpdateCurrentRow();
            Biencucbo.soluong = 0;
            Biencucbo.dongia = 0;
            ct.thanhtien = ct.nguyente * double.Parse(tygiaSpinEdit.Text);

            if (_hdong == 3)
            {
                ct.idsp = _idsp;
                ct.soluong = _soluong;
                ct.dongia = _dongia;
                ct.ghichu = _ghichu;
                ct.chietkhau = 0;
                ct.giavon = 0;
                ct.nguyente = _soluong * _dongia;
                ct.thanhtien = (_soluong * _dongia) * double.Parse(tygiaSpinEdit.Text);
            }
        }

        private void txtmavach_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                string abc = txtmavach.Text;
                if (txtmavach.Text != "")
                {
                    try
                    {
                        var lst = (from a in new KetNoiDBDataContext().dmsanphams where a.id == abc select a);
                        if (lst.Count() == 0)
                        {
                            MessageBox.Show("Sản phẩm này chưa được đưa vào danh mục-Vui lòng kiểm tra lại!", "Thông Báo");
                            txtmavach.Text = "";
                            return;
                        }
                        var lst2 = from a in new KetNoiDBDataContext().giasps where a.idsp == txtmavach.Text  select a;
                        if (lst2.Count() == 0)
                        {
                            MessageBox.Show("Sản phẩm này chưa được quy định giá bán-Vui lòng kiểm tra lại!", "Thông Báo");
                            txtmavach.Text = "";

                            return;
                        }

                        if (checksl.Checked)
                        {
                            lbltensp.Text = lst.Single().tensp;
                            Biencucbo.dongia = double.Parse(lst2.Single().gia.ToString());
                            Biencucbo.banhang = true;
                            f_soluongdongia frm = new f_soluongdongia();

                            frm.ShowDialog();
                            if (frm.DialogResult != DialogResult.OK)
                            {
                                XtraMessageBox.Show("Bạn đã hủy chọn sản phẩm này");
                                txtmavach.Text = "";
                                lbltensp.Text = "";
                                return;
                            }
                            Biencucbo.banhang = false;
                            bool fn = false;
                            for (int i = 0; i < gv.DataRowCount; i++)
                            {
                                var ct = gv.GetRow(i) as pxuatct;
                                if (ct.idsp == txtmavach.Text)
                                {
                                    double _sl = double.Parse(ct.soluong.ToString()) + Biencucbo.soluong;
                                    ct.soluong = _sl;
                                    ct.nguyente = _sl * ct.dongia;
                                    gv.PostEditor();
                                    gv.UpdateCurrentRow();
                                    Biencucbo.soluong = 0;
                                    Biencucbo.dongia = 0;
                                    ct.thanhtien = ct.nguyente * double.Parse(tygiaSpinEdit.Text);
                                    fn = true;
                                    break;
                                }

                            }
                            if (fn == false)
                            {
                                gv.AddNewRow();

                            }


                            gv.PostEditor();
                            gv.UpdateCurrentRow();
                            txtmavach.Text = "";
                            lbltensp.Text = "";
                            txtmavach.Focus();
                        }
                        else
                        {
                            lbltensp.Text = lst.Single().tensp;
                            Biencucbo.dongia = double.Parse(lst2.Single().gia.ToString());
                            Biencucbo.soluong = 1;
                            bool fn = false;
                            for (int i = 0; i < gv.DataRowCount; i++)
                            {
                                var ct = gv.GetRow(i) as pxuatct;
                                if (ct.idsp == txtmavach.Text)
                                {
                                    double _sl = double.Parse(ct.soluong.ToString()) + Biencucbo.soluong;
                                    ct.soluong = _sl;
                                    ct.nguyente = _sl * ct.dongia;
                                    gv.PostEditor();
                                    gv.UpdateCurrentRow();
                                    Biencucbo.soluong = 0;
                                    Biencucbo.dongia = 0;
                                    ct.thanhtien = ct.nguyente * double.Parse(tygiaSpinEdit.Text);
                                    fn = true;
                                    break;
                                }

                            }
                            if (fn == false)
                            {
                                gv.AddNewRow();

                            }


                            gv.PostEditor();
                            gv.UpdateCurrentRow();
                            txtmavach.Text = "";
                            lbltensp.Text = "";
                            txtmavach.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
        }

        private void f_pxuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (_hdong != 0)
            {
                if (e.Control)
                {
                    //if (e.KeyCode == Keys.Insert)
                    //{
                    //    gv.AddNewRow();
                    //}
                    if (e.KeyCode == Keys.Delete)
                    {
                        try
                        {
                            var ct = gv.GetFocusedRow() as pxuatct;

                            dbData.pxuatcts.DeleteOnSubmit(ct);
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                        catch (Exception ex)
                        {
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                    }
                }
                if (e.KeyCode == Keys.Insert)
                {
                    txtmavach.Focus();
                    gv.AddNewRow();
                }
                if (e.KeyCode == Keys.Add)
                {
                    if (checksl.Checked)
                    {
                        checksl.Checked = false;
                        chonsoluong(checksl.Checked);
                    }
                    else
                    {
                        checksl.Checked = true;
                        chonsoluong(checksl.Checked);
                    }
                }
            }
        }

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
 
            var ct = gv.GetFocusedRow() as pxuatct;
            if (ct == null)
                return;

            try
            {
                ct.nguyente = (ct.soluong * ct.dongia) - ct.chietkhau;
                ct.thanhtien = ct.nguyente * double.Parse(tygiaSpinEdit.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            gv.PostEditor();
            gv.UpdateCurrentRow();

        }

        private void gv_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

         
        }

        private void checksl_CheckedChanged(object sender, EventArgs e)
        {
            chonsoluong(checksl.Checked);
        }

        private void txtmavach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                txtmavach.Text = "";
            }
        }

        private void btnthanhtoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_hdong == 0)
            {
                if (idTextEdit.Text != string.Empty)
                {
                    Biencucbo.link = idTextEdit.Text;
                    Biencucbo.iddt = iddtSearchLookUpEdit.Text;
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    Biencucbo.tongtien = double.Parse(colthanhtien.SummaryItem.SummaryValue.ToString());
                    custom.layquyen("btnbanhang");
                    var frm = new f_thutienbanhang();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        print();
                    }
                }
            }
        }

        protected override void next()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi && a.so > _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().pxuats where a.iddv == _donvi && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnreloadsp_Click(object sender, EventArgs e)
        {
            loadslusidsp();
        }

        private void f_banhang_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
         this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", this.Text).ToString();
            changeFont.Translate(this);
        }

        protected override void last()
        {
            load();
        }


        #endregion

        private bool checklink(string code)
        {
            if (idTextEdit.Text != "")
            {
                var lst = (from a in new KetNoiDBDataContext().ptts where a.link == idTextEdit.Text select a);
                if (lst.Count() > 0)
                {
                    XtraMessageBox.Show("Không thể " + code + " vì có sự liên kết với phiếu thu tiền bán hàng");
                    return false;
                }
            }
            return true;
        }




    }
}