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
    public partial class f_pthutien : frm.frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_pthu pt = new c_pthu();
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
        public f_pthutien()
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
            int checdup = 0;
            ngaythuDateEdit.Properties.ContextImage = null;
            if (custom.checknulltext(ngaythuDateEdit))
                checknull++;
            idloaithuSearchLookUpEdit.Properties.ContextImage = null;
            if (custom.checknulltext(idloaithuSearchLookUpEdit))
                checknull++;
            iddtSearchLookUpEdit.Properties.ContextImage = null;
            tienteSearchLookUpEdit.Properties.ContextImage = null;
            if (custom.checknulltext(iddtSearchLookUpEdit))
                checknull++;
            if (custom.checknulltext(tienteSearchLookUpEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
                return false;
            }
            return true;
        }


        #region Lấy Thông Tin SearchLookup

        // Lấy thông tin loại thu
        private void layttlblloaithu(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dmloaithus select a).Single(t => t.id == id);
                lblloaithu.Text = lst.loaithu;
            }
            catch (Exception ex)
            {
                lblloaithu.Text = "";
            }
        }

        // Lấy thông tin đối tượng
        private void layttlbliddt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == id);
                lbliddt.Text = lst.tendt;
                diachiTextEdit.Text = lst.diachi;
            }
            catch (Exception ex)
            {
                lbliddt.Text = "";
                diachiTextEdit.Text = "";
            }
        }

        // Lấy thông tin nhân viên
        private void layttlblidnv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lblidnv.Text = lst.name;
                var lst2 = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == lst.phongban);
                tenphongbanTextEdit.Text = lst2.ten;
            }
            catch (Exception ex)
            {
                lblidnv.Text = "";
                tenphongbanTextEdit.Text = "";
            }
        }

        // Lấy thông tin tiền tệ - tỷ giá
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

        // Lấy thông tin đon vị
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

        #region Thay Đổi Thông Tin Searchlookup

        private void idloaithuSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblloaithu(idloaithuSearchLookUpEdit.Text);
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
                    var ct = gv.GetRow(i) as pthuct;
                    if(ct == null)
                        return;
                    try
                    {
                        ct.thanhtien = ct.nguyente*double.Parse(tygiaSpinEdit.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void idnvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblidnv(idnvTextEdit.Text);
        }

        private void iddvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbliddv(iddvTextEdit.Text);
        }
        #endregion

        #region SearchLookup Popup

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

        private void loadsluiddtSearchLookUpEdit()
        {
            iddtSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().doituongs select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btndoituong");
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

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
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

        // Loại Thu
        private void idloaithuSearchLookUpEdit_Popup(object sender, EventArgs e)
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
            var btnaddidloaithuSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddidloaithuSearchLookUpEdit.Click += btnaddidloaithuSearchLookUpEdit_Click;

            // BTN load
            var btnreloadidloaithuSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadidloaithuSearchLookUpEdit.Click += btnreloadidloaithuSearchLookUpEdit_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtnidloaithuSearchLookUpEdit)
            {
                myLCI.Control = btnaddidloaithuSearchLookUpEdit;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadidloaithuSearchLookUpEdit;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtnidloaithuSearchLookUpEdit = false;
            }
        }

        private bool checkbtnidloaithuSearchLookUpEdit = true;

        private void loadsluidloaithuSearchLookUpEdit()
        {
            idloaithuSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().dmloaithus select a);
        }

        public void btnaddidloaithuSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnloaithu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dmloaithu();
            frm.ShowDialog();
            loadsluidloaithuSearchLookUpEdit();
            idloaithuSearchLookUpEdit.ShowPopup();
        }

        public void btnreloadidloaithuSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            loadsluidloaithuSearchLookUpEdit();
            idloaithuSearchLookUpEdit.ShowPopup();
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
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btntiente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_tiente();
            frm.ShowDialog();
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();
        }

        public void btnreloadtienteSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();

        }

        #endregion

        private double _nguyente;
        private string _ghichu;

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
            // Textbox readonly = true
            iddvTextEdit.ReadOnly = true;
            idTextEdit.ReadOnly = true;
            idnvTextEdit.ReadOnly = true;
            tenphongbanTextEdit.ReadOnly = true;
            diachiTextEdit.ReadOnly = true;
            tygiaSpinEdit.ReadOnly = true;

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
                gd.DataSource = (from a in dbData.pthucts where a.keypt == _key select a);

            }
            catch (Exception ex)
            {

            }

            gv.AddNewRow();
            iddvTextEdit.Text = _donvi;
            idTextEdit.Text = "YYYY";
            ngaythuDateEdit.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tienteSearchLookUpEdit.Text = custom.laytientechinh();
            idnvTextEdit.Text = Biencucbo.idnv;
            iddtSearchLookUpEdit.Text = "";
            idloaithuSearchLookUpEdit.Text = "TBH";
            iddtSearchLookUpEdit.Focus();
            moedit();

        }

        private void xoatxt()
        {
            dataLayoutControl1.DataSource = (from a in dbData.pthus where a.key == _key select a);
            //Textbox.text = string.empty

            iddvTextEdit.Text = string.Empty;
            idTextEdit.Text = string.Empty;
            ngaythuDateEdit.Text = string.Empty;
            idnvTextEdit.Text = string.Empty;
            iddtSearchLookUpEdit.Text = string.Empty;
            diengiaiTextEdit.Text = string.Empty;

            tienteSearchLookUpEdit.Text = string.Empty;
            idloaithuSearchLookUpEdit.Text = string.Empty;

            dongedit();
        }

        private void loadinfo(string key)
        {
            dongedit();
            try
            {
                var lst = (from a in new KetNoiDBDataContext().v_pthus where a.iddv == _donvi select a).Single(t => t.key == key);
                dataLayoutControl1.DataSource = lst;
                tygiaSpinEdit.Text = lst.tygia.ToString();
                var lst2 = (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi select a).Single(t => t.key == key);
                gd.DataSource = lst2.pthucts;
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

            //  
            loadslutienteSearchLookUpEdit();
            loadsluiddtSearchLookUpEdit();
            loadsluidloaithuSearchLookUpEdit();

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
                    var so = (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi select a.so).Max();
                    if (so == null)
                        return;
                    var lst =
                        (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi select a).Single(
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
            f_dspthutien frm = new f_dspthutien();
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
                Biencucbo.ngaysaochep = ngaythuDateEdit.DateTime;
                var frm = new f_ngaysaochep();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _hdong = 3;
                    dbData = new KetNoiDBDataContext();
                    _keytemp = _key;
                    _key = custom.laykey();

                    dataLayoutControl1.DataSource = (from a in new KetNoiDBDataContext().pthus where a.key == _key select a);
                    ngaythuDateEdit.DateTime = Biencucbo.ngaysaochep;
                    idTextEdit.Text = "YYYY";
                    int dong = gv.DataRowCount;
                    DataTable dt = new DataTable();
                    /// <summary>
                    /// dt.Columns.Add("idsp", typeof(string));
                    /// dt.Columns.Add("soluong", typeof(double));
                    /// dt.Columns.Add("dongia", typeof(double));
                    /// dt.Columns.Add("ghichu", typeof(string));
                    /// </summary>

                    // 
                    dt.Columns.Add("ghichu", typeof(string));
                    dt.Columns.Add("nguyente", typeof(double));

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

                        //	
                        var ct = gv.GetRow(i) as pthuct;
                        row = dt.NewRow();
                        row["ghichu"] = ct.ghichu;
                        row["nguyente"] = ct.nguyente;
                        dt.Rows.Add(row);
                    }

                    gd.DataSource = (from a in dbData.pthucts where a.keypt == _key select a);

                    foreach (DataRow item in dt.Rows)
                    {
                        /// <summary>
                        ///   _idsp = item[0].ToString();
                        /// _soluong = double.Parse(item[1].ToString());
                        ///   _dongia = double.Parse(item[2].ToString());
                        ///   _ghichu = item[3].ToString();
                        ///   gv.AddNewRow();
                        /// </summary>

                        // 
                        _nguyente = double.Parse(item[1].ToString());
                        _ghichu = item[0].ToString();
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

        private bool LuuPhieu()
        {
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = dbData.pthucts.Context.GetChangeSet();
                dbData.pthucts.Context.SubmitChanges();
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
                        idTextEdit.Text = custom.matutang("PT" + _donvi);
                        _so = Biencucbo.so;
                        pt.them(_key, idTextEdit.Text, ngaythuDateEdit.DateTime, idloaithuSearchLookUpEdit.Text, idnvTextEdit.Text, iddtSearchLookUpEdit.Text, diengiaiTextEdit.Text, _so, iddvTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text));
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Thêm Phiếu Thu Tiền Mặt");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;

                    }
                    if (_hdong == 2)
                    {
                        pt.sua(_key, ngaythuDateEdit.DateTime, idloaithuSearchLookUpEdit.Text, iddtSearchLookUpEdit.Text, diengiaiTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text));
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Sửa Phiếu Thu Tiền Mặt")
                        ;
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
                gd.DataSource = (from a in dbData.pthucts where a.keypt == _key select a);
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
                    var ct = gv.GetRow(i) as pthuct;
                    pt.xoact(ct.key);
                    gv.DeleteRow(i);
                }
                pt.xoa(_key);
                hs.add(idTextEdit.Text, "Xóa Phiếu Thu Tiền Mặt");
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
            try
            {
                Biencucbo.title = "PHIẾU THU TIỀN MẶT";
                Biencucbo.ngaybc = "Ngày lập phiếu " + ngaythuDateEdit.Text;
                Biencucbo.info = lblloaithu.Text;
                var lst = (from a in dbData.v_dspthus where a.key == _key select a);
                var rp = new Report.Thu.r_pthu();
                rp.DataSource = lst;
                rp.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void first()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi select a.so).Min();
                if (lst == null)
                    return;
                var lst1 =
                    (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi select a).Single(t => t.so == lst);
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
                var lst = (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi && a.so == lst select a).Single();
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
                var lst = (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi && a.so > _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().pthus where a.iddv == _donvi && a.so == lst select a).Single();
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

        private void gv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var ct = gv.GetFocusedRow() as pthuct;
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
            ct.keypt = _key;
            ct.ghichu = string.Empty;
            ct.stt = k;
            ct.nguyente = 0.00;
            ct.thanhtien = 0.00;

            if (_hdong == 3)
            {
                ct.nguyente = _nguyente;
                ct.ghichu = _ghichu;
                ct.thanhtien = _nguyente*double.Parse(tygiaSpinEdit.Text);
            }
        }

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            gv.PostEditor();
            gv.UpdateCurrentRow();

            var ct = gv.GetFocusedRow() as pthuct;
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

        private void gvloaithu_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void gvtiente_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void gvdt_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void f_pthutien_KeyDown(object sender, KeyEventArgs e)
        {
            if (_hdong != 0)
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.Insert)
                    {
                        gv.AddNewRow();
                    }
                    if (e.KeyCode == Keys.Delete)
                    {
                        try
                        {
                            var ct = gv.GetFocusedRow() as pthuct;
                            // .
                            dbData.pthucts.DeleteOnSubmit(ct);
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                        catch (Exception ex)
                        {
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                    }
                }
            }       
        }
    }
}