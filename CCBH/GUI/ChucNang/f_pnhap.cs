using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Layout;
using GUI.DanhMuc;
using GUI.frm;
using GUI.Properties;


namespace GUI.ChucNang
{
    public partial class f_pnhap : frm.frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_pnhap pn = new c_pnhap();
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
        public f_pnhap()
        {
            InitializeComponent();


        }

        private void f_pnhap_Load(object sender, EventArgs e)
        {

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
            ngaynhapDateEdit.Properties.ContextImage = null;
            loainhapSearchLookUpEdit.Properties.ContextImage = null;
            iddtSearchLookUpEdit.Properties.ContextImage = null;
            tienteSearchLookUpEdit.Properties.ContextImage = null;

            if (custom.checknulltext(ngaynhapDateEdit))
                checknull++;
            if (custom.checknulltext(loainhapSearchLookUpEdit))
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

        #region laytt Searchlookup

        private void layttlblloainhap(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dmloainhaps select a).Single(t => t.id == id);
                lblloainhap.Text = lst.loainhap;
                dataLayoutControl1.Refresh();
            }
            catch (Exception ex)
            {
                lblloainhap.Text = "";
            }
        }

        private void layttlbliddt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == id);
                lbliddt.Text = lst.tendt;
                txtdiachi.Text = lst.diachi;
            }
            catch (Exception ex)
            {
                lbliddt.Text = "";
                txtdiachi.Text = "";
            }
        }

        private void layttlblidnv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lblidnv.Text = lst.name;
                var lst2 = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == lst.phongban);
                tenphongTextEdit.Text = lst2.ten;
            }
            catch (Exception ex)
            {
                lblidnv.Text = "";
                tenphongTextEdit.Text = "";
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
                tygiaSpinEdit.Text = "";
            }
        }

        private void layttlbliddv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lbliddv.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lbliddv.Text = "";
            }
        }



        #endregion

        #region thay đổi thông tin searchlookup

        private void loainhapSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            layttlblloainhap(loainhapSearchLookUpEdit.Text);

        }

        private void idnvTextEdit_EditValueChanged(object sender, EventArgs e)
        {

            layttlblidnv(idnvTextEdit.Text);

        }

        private void iddtSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            layttlbliddt(iddtSearchLookUpEdit.Text);

        }

        private void tienteSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_hdong != 0)
            {
                laytttygiaSpinEdit(tienteSearchLookUpEdit.Text);
                for (int i = 0; i < gv.DataRowCount; i++)
                {
                    gv.PostEditor();

                    var ct = gv.GetRow(i) as pnhap_ct;
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
            }


        }

        #endregion

        #region Searchlookup_popup (gridview idsp)

        private void loainhapSearchLookUpEdit_Popup(object sender, EventArgs e)
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

        private void loadsluloainhapSearchLookUpEdit()
        {
            loainhapSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().dmloainhaps select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnloainhap");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dsloainhap();
            frm.ShowDialog();
            loadsluloainhapSearchLookUpEdit();
            loainhapSearchLookUpEdit.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadsluloainhapSearchLookUpEdit();
            loainhapSearchLookUpEdit.ShowPopup();
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
            var frm = new f_dsdoituong();
            frm.ShowDialog();
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        public void btnreloadiddtSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();

        }

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

        private void sidsp_Click(object sender, EventArgs e)
        {

        }

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
            checkbtnsidsp = true;
        }

        public void btnaddsidsp_Click(object sender, EventArgs e)
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
            var frm = new DanhMuc.f_dssanpham();
            frm.ShowDialog();
            loadslusidsp();

        }

        public void btnreloadsidsp_Click(object sender, EventArgs e)
        {
            loadslusidsp();

        }

        private void f_pnhap_KeyDown(object sender, KeyEventArgs e)
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
                            var ct = gv.GetFocusedRow() as pnhap_ct;

                            dbData.pnhap_cts.DeleteOnSubmit(ct);
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
                    gv.AddNewRow();
                    
                }
            }
        }

        private void sidsp_EditValueChanged(object sender, EventArgs e)
        {
            gv.PostEditor();

        }

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gv.PostEditor();

            var ct = gv.GetFocusedRow() as pnhap_ct;
            if (ct == null)
                return;

            try
            {
                ct.nguyente = ct.soluong * ct.dongia;
                ct.thanhtien = ct.nguyente * double.Parse(tygiaSpinEdit.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            //if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia")
            //{
            //    try
            //    {
            //        if (double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString()) == 0 ||
            //            double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()) == 0)
            //        {
            //            gv.SetFocusedRowCellValue("nguyente", 0);
            //            gv.SetFocusedRowCellValue("thanhtien", 0);
            //            gv.PostEditor();
            //        }
            //        else
            //        {
            //            gv.SetFocusedRowCellValue("nguyente", (double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString()) * double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString())));
            //            gv.PostEditor();
            //            gv.SetFocusedRowCellValue("thanhtien", (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString()) * double.Parse(tygiaSpinEdit.Text)));
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
        }
        #endregion

        #region Method
        private void dongedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.True;
            gv.OptionsBehavior.Editable = false;
            _hdong = 0;
        }

        private void moedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.False;
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.Default;
            iddvTextEdit.ReadOnly = true;
            idTextEdit.ReadOnly = true;
            idnvTextEdit.ReadOnly = true;
            tenphongTextEdit.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            tienteSearchLookUpEdit.ReadOnly = true;
            tygiaSpinEdit.ReadOnly = true;
            dataLayoutControl1.Refresh();
            gv.OptionsBehavior.Editable = true;
        }

        private void themtxt()
        {
            _keytemp = _key;
            _key = custom.laykey();
            xoatxt();
            _hdong = 1;


            try
            {
                gd.DataSource = (from a in dbData.pnhap_cts where a.keypn == _key select a);

            }
            catch (Exception ex)
            {

            }

            //gv.AddNewRow();
            iddvTextEdit.Text = _donvi;
            idTextEdit.Text = "YYYY";
            ngaynhapDateEdit.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tienteSearchLookUpEdit.Text = custom.laytientechinh();
            idnvTextEdit.Text = Biencucbo.idnv;
            iddtSearchLookUpEdit.Text = "";
            loainhapSearchLookUpEdit.Text = "NM";
            iddtSearchLookUpEdit.Focus();
            moedit();

        }

        private void xoatxt()
        {
            dataLayoutControl1.DataSource = (from a in dbData.pnhaps where a.key == _key select a);
            iddvTextEdit.Text = string.Empty;
            idTextEdit.Text = string.Empty;
            ngaynhapDateEdit.Text = string.Empty;
            loainhapSearchLookUpEdit.Text = string.Empty;
            idnvTextEdit.Text = string.Empty;
            iddtSearchLookUpEdit.Text = string.Empty;
            tienteSearchLookUpEdit.Text = string.Empty;
            diengiaiTextEdit.Text = string.Empty;
            dongedit();

        }

        private void loadinfo(string key)
        {
            dongedit();
            try
            {
                var lst = (from a in new KetNoiDBDataContext().v_pnhaps where a.iddv == _donvi select a).Single(t => t.key == key);
                dataLayoutControl1.DataSource = lst;
                tygiaSpinEdit.Text = lst.tygia.ToString();
                var lst2 = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi select a).Single(t => t.key == key);
                gd.DataSource = lst2.pnhap_cts;
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
            loadsluiddtSearchLookUpEdit();
            loadsluloainhapSearchLookUpEdit();
            loadslutienteSearchLookUpEdit();
            loadslusidsp();
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
                    var so = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi select a.so).Max();
                    if (so == null)
                        return;
                    var lst =
                        (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi select a).Single(
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
            f_dspnhap frm = new f_dspnhap();
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
            _keytemp = _key;
            _hdong = 3;
            dbData = new KetNoiDBDataContext();
            if (idTextEdit.Text != string.Empty)
            {
                Biencucbo.ngaysaochep = ngaynhapDateEdit.DateTime;
                var frm = new f_ngaysaochep();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _keytemp = _key;
                    _key = custom.laykey();
                    //HTAGQPFW9je87nOQ4FmsMu7gC/YH07hxMcge0yIcBAFMcEUjf35HTF03V2BHYjfVbGzAcaKwFGI=
                    dataLayoutControl1.DataSource = (from a in new KetNoiDBDataContext().pnhaps where a.key == _key select a);
                    ngaynhapDateEdit.DateTime = Biencucbo.ngaysaochep;
                    idTextEdit.Text = "YYYY";
                    int dong = gv.DataRowCount;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("idsp", typeof(string));
                    dt.Columns.Add("soluong", typeof(double));
                    dt.Columns.Add("dongia", typeof(double));
                    dt.Columns.Add("ghichu", typeof(string));
                    DataRow row;
                    for (int i = 0; i < dong; i++)
                    {
                        var ct = gv.GetRow(i) as pnhap_ct;
                        row = dt.NewRow();
                        row["idsp"] = ct.idsp;
                        row["soluong"] = ct.soluong;
                        row["dongia"] = ct.dongia;
                        row["ghichu"] = ct.ghichu;
                        dt.Rows.Add(row);
                    }
                    gd.DataSource = (from a in dbData.pnhap_cts where a.keypn == _key select a);

                    foreach (DataRow item in dt.Rows)
                    {
                        _idsp = item[0].ToString();
                        _soluong = double.Parse(item[1].ToString());
                        _dongia = double.Parse(item[2].ToString());
                        _ghichu = item[3].ToString();
                        gv.AddNewRow();
                        _hdong = 1;
                        moedit();
                    }
                    return true;


                }
                return false;
            }
            return false;
        }

        private bool LuuPhieu()
        {
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = dbData.pnhap_cts.Context.GetChangeSet();
                dbData.pnhap_cts.Context.SubmitChanges();
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
                        idTextEdit.Text = custom.matutang("PN" + _donvi);
                        _so = Biencucbo.so;
                        pn.them(_key, idTextEdit.Text, ngaynhapDateEdit.DateTime, loainhapSearchLookUpEdit.Text, idnvTextEdit.Text, iddtSearchLookUpEdit.Text, diengiaiTextEdit.Text, _so, iddvTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text));
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Thêm Phiếu Nhập");
                        loadinfo(_key);
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;

                    }
                    if (_hdong == 2)
                    {
                        pn.sua(_key, ngaynhapDateEdit.DateTime, loainhapSearchLookUpEdit.Text, iddtSearchLookUpEdit.Text, diengiaiTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text));
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Sửa Phiếu Nhập");
                        loadinfo(_key);
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
                dbData = new KetNoiDBDataContext();
                _hdong = 2;
                gd.DataSource = (from a in dbData.pnhap_cts where a.keypn == _key select a);
                moedit();
                return true;
            }
            return false;
        }

        protected override bool xoa()
        {
            if (idTextEdit.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {

                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    var ct = gv.GetRow(i) as pnhap_ct;
                    pn.xoact(ct.key);
                    gv.DeleteRow(i);
                }
                pn.xoa(_key);
                hs.add(idTextEdit.Text, "Xóa Phiếu Nhập");
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
            Biencucbo.title = "PHIẾU NHẬP KHO";
            Biencucbo.ngaybc = "Ngày Lập Phiếu: " + ngaynhapDateEdit.Text;
            Biencucbo.info = lblloainhap.Text;
            var lst = (from a in dbData.v_pnhapANDcts where a.key == _key select a);
            var rp = new Report.Nhapkho.r_pnhap();
            rp.DataSource = lst;
            rp.ShowPreviewDialog();

        }

        protected override void first()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi select a.so).Min();
                if (lst == null)
                    return;
                var lst1 = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi select a).Single(t => t.so == lst);
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
                var lst = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi && a.so == lst select a).Single();
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
                var lst = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi && a.so > _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 = (from a in new KetNoiDBDataContext().pnhaps where a.iddv == _donvi && a.so == lst select a).Single();
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


        private void iddvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbliddv(iddvTextEdit.Text);
        }

        private void gv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var ct = gv.GetFocusedRow() as pnhap_ct;
            if (ct == null)
                return;
            int i = 0, k = 0;
            string a;

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
            ct.keypn = _key;
            ct.idsp = txtmavach.Text;
            ct.soluong = Biencucbo.soluong;
            ct.dongia = Biencucbo.dongia;
            ct.ghichu = string.Empty;
            ct.stt = k;
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
                ct.nguyente = _soluong * _dongia;
                ct.thanhtien = _soluong*_dongia*double.Parse(tygiaSpinEdit.Text);
            }

        }

        private void txtmavach_KeyUp(object sender, KeyEventArgs e)
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
                        //var lst2 = from a in db.r_giasps where a.idsp == txtmavach.Text && a.iddv == Biencucbo.donvi select a;
                        //if (lst2.Count() == 0)
                        //{
                        //    MessageBox.Show("Sản phẩm này chưa được quy định giá bán-Vui lòng kiểm tra lại!", "Thông Báo");
                        //    txtmavach.Text = "";
                        //    return;
                        //}


                        lbltensp.Text = lst.Single().tensp;
                        f_soluongdongia frm = new f_soluongdongia();

                        frm.ShowDialog();
                        if (frm.DialogResult != DialogResult.OK)
                        {
                            XtraMessageBox.Show("Bạn đã hủy chọn sản phẩm này");
                            txtmavach.Text = "";
                            lbltensp.Text = "";
                            return;
                        }
                        gv.AddNewRow();

                        gv.PostEditor();
                        gv.UpdateCurrentRow();
                        txtmavach.Text = "";
                        lbltensp.Text = "";
                        txtmavach.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
        }

        private double _soluong, _dongia;

        private void lblloainhap_TextChanged(object sender, EventArgs e)
        {
            // layttlblloainhap(loainhapSearchLookUpEdit.Text);
        }

        private void tygiaSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btnreloadsp_Click(object sender, EventArgs e)
        {
            loadslusidsp();
        }

        private string _idsp, _ghichu;
    }
}