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
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Win;
using DevExpress.XtraBars.Ribbon;
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
    public partial class f_POS : DevExpress.XtraEditors.XtraForm
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
        private double _chietkhau = double.Parse((from a in new KetNoiDBDataContext().giamgias select a.phantram).Single().ToString());
        f_POS2 bh = new f_POS2();
        public f_POS()
        {
            InitializeComponent();

            glc.Gallery.ItemClick += new GalleryItemClickEventHandler(Gallery_ItemClick);
            loadslutxtkhachhang();
            btnsp.DataSource = (from a in dbData.dmsanphams select a);
        }

        private void f_banhang_new_Load(object sender, EventArgs e)
        {
            bh.Show();

            LanguageHelper.Translate(this);
            LanguageHelper.Translate(gd);
            //  this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "POS").ToString();
            changeFont.Translate(this);


            txtmavach.ReadOnly = true;
            _donvi = Biencucbo.donvi;
            btnnew.Enabled = true;
            btncancel.Enabled = false;
            btnpay.Enabled = false;
            glc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            glc.Gallery.ImageSize = new Size(80, 80);
            glc.Gallery.ShowItemText = true;
            glc.Gallery.ShowGroupCaption = true;
            var lstgroup = (from a in dbData.dmsanphams where a.mavach == false select a).GroupBy(t => t.loai).Select(c => new
            {
                loai = c.Key,

            });
            var lst = (from a in dbData.dmsanphams
                       join b in dbData.giasps on a.id equals b.idsp
                       where a.mavach == false
                       select a);

            foreach (var group in lstgroup)
            {

                var GalleryItem = new GalleryItemGroup();
                var lst2 = (from a in dbData.dmloaisps select a).Single(t => t.id == group.loai);
                GalleryItem.Caption = lst2.tenloaisp;
                GalleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;

                foreach (var item in lst)
                {

                    if (group.loai.Equals(item.loai))
                    {
                        var gc_item = new GalleryItem();
                        gc_item.AppearanceCaption.Normal.Font = new Font("Tahoma", 12, FontStyle.Bold);
                        gc_item.AppearanceCaption.Hovered.Font = new Font("Tahoma", 12, FontStyle.Bold);
                        gc_item.AppearanceCaption.Pressed.Font = new Font("Tahoma", 12, FontStyle.Bold);

                        try
                        {
                            ImageConverter objfile = new ImageConverter();
                            gc_item.ImageOptions.Image = (Image)objfile.ConvertFrom(item.hinhanh.ToArray());
                        }
                        catch
                        {
                        }

                        gc_item.Caption = item.tensp;
                        gc_item.Value = item.id;
                        GalleryItem.Items.Add(gc_item);
                    }
                }
                glc.Gallery.Groups.Add(GalleryItem);

            }


        }


        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //var gc_item = new GalleryItem();
            if (_hdong == 0)
                return;

            txtmavach.Text = e.Item.Value.ToString();


            var lst = (from a in new KetNoiDBDataContext().dmsanphams where a.id == txtmavach.Text select a);
            if (lst.Count() == 0)
            {
                MessageBox.Show("Sản phẩm này chưa được đưa vào danh mục-Vui lòng kiểm tra lại!", "Thông Báo");
                txtmavach.Text = "";
                txtmavach.Focus();
                return;
            }
            var lst2 = from a in new KetNoiDBDataContext().giasps where a.idsp == txtmavach.Text select a;
            if (lst2.Count() == 0)
            {
                MessageBox.Show("Sản phẩm này chưa được quy định giá bán-Vui lòng kiểm tra lại!", "Thông Báo");
                txtmavach.Text = "";
                txtmavach.Focus();
                return;
            }



            Biencucbo.dongia = double.Parse(lst2.Single().gia.ToString());
            Biencucbo.banhang = true;
            f_soluongdongia frm = new f_soluongdongia();

            frm.ShowDialog();
            if (frm.DialogResult != DialogResult.OK)
            {
                XtraMessageBox.Show("Bạn đã hủy chọn sản phẩm này");
                txtmavach.Text = "";
                txtmavach.Focus();
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
                    ct.chietkhau = ct.dongia * _chietkhau / 100 * _sl;
                    ct.nguyente = (_sl * ct.dongia) - (ct.dongia * _chietkhau / 100 * _sl);
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    Biencucbo.soluong = 0;
                    Biencucbo.dongia = 0;
                    ct.thanhtien = ct.nguyente * 1;
                    ct.giavon = 0;
                    bh.truyensuact2(double.Parse(ct.soluong.ToString()), double.Parse(ct.nguyente.ToString()), double.Parse(ct.chietkhau.ToString()), i);
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
            txtmavach.Focus();

            double tong;
            double discount;
            double tygia = 0;
            double tiente = 0;
            tong = double.Parse(colthanhtien.SummaryItem.SummaryValue.ToString());
            Biencucbo.skip = tong;
            discount = double.Parse(colchietkhau.SummaryItem.SummaryValue.ToString());
            Biencucbo.sdiscount = discount;
            var lsttt = (from a in dbData.tientes where a.tentiente == "Bath" select a);
            if (lsttt != null)
            {
                tygia = double.Parse(lsttt.Single().tygia.ToString());
                tiente = tong / tygia;
                Biencucbo.sbath = tiente;
                txtbath.Text = tiente.ToString();
                lobath.Text = "Bath (" + tygia + ")";
            }

            lsttt = (from a in dbData.tientes where a.tentiente == "USD" select a);
            if (lsttt != null)
            {
                tygia = double.Parse(lsttt.Single().tygia.ToString());
                tiente = tong / tygia;
                Biencucbo.susd = tiente;
                txtusd.Text = tiente.ToString();
                lousd.Text = "USD (" + tygia + ")";
            }


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
        private void f_banhang_new_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void txtmavach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                txtmavach.Text = "";
            }
        }

        private void txtmavach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_hdong == 0)
                    return;
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
                        var lst2 = from a in new KetNoiDBDataContext().giasps where a.idsp == txtmavach.Text select a;
                        if (lst2.Count() == 0)
                        {
                            MessageBox.Show("Sản phẩm này chưa được quy định giá bán-Vui lòng kiểm tra lại!", "Thông Báo");
                            txtmavach.Text = "";

                            return;
                        }

                        if (checksl.Checked)
                        {

                            Biencucbo.dongia = double.Parse(lst2.Single().gia.ToString());
                            Biencucbo.banhang = true;
                            f_soluongdongia_mavach frm = new f_soluongdongia_mavach();

                            frm.ShowDialog();
                            if (frm.DialogResult != DialogResult.OK)
                            {
                                XtraMessageBox.Show("Bạn đã hủy chọn sản phẩm này");
                                txtmavach.Text = "";

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
                                    ct.chietkhau = ct.dongia * _chietkhau / 100 * _sl;
                                    ct.nguyente = (_sl * ct.dongia) - (ct.dongia * _chietkhau / 100 * _sl);
                                    gv.PostEditor();
                                    gv.UpdateCurrentRow();
                                    Biencucbo.soluong = 0;
                                    Biencucbo.dongia = 0;
                                    ct.thanhtien = ct.nguyente * 1;
                                    bh.truyensuact2(double.Parse(ct.soluong.ToString()), double.Parse(ct.nguyente.ToString()), double.Parse(ct.chietkhau.ToString()), i);
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

                            txtmavach.Focus();
                        }
                        else
                        {

                            Biencucbo.dongia = double.Parse(lst2.Single().gia.ToString());
                            Biencucbo.soluong = 1;
                            bool fn = false;
                            for (int i = 0; i < gv.DataRowCount; i++)
                            {
                                var ct = gv.GetRow(i) as pxuatct;
                                if (ct.idsp == txtmavach.Text)
                                {
                                    double _sl = double.Parse(ct.soluong.ToString()) + Biencucbo.soluong;
                                    double _dongia = double.Parse(ct.dongia.ToString());
                                    ct.soluong = _sl;
                                    ct.chietkhau = ct.dongia * _chietkhau / 100 * _sl;
                                    ct.nguyente = (_sl * ct.dongia) - (ct.dongia * _chietkhau / 100 * _sl);
                                    gv.PostEditor();
                                    gv.UpdateCurrentRow();
                                    Biencucbo.soluong = 0;
                                    Biencucbo.dongia = 0;
                                    ct.thanhtien = ct.nguyente * 1;
                                    bh.truyensuact2(double.Parse(ct.soluong.ToString()), double.Parse(ct.nguyente.ToString()), double.Parse(ct.chietkhau.ToString()), i);
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

                            txtmavach.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }


                double tong;
                double tygia = 0;
                double tiente = 0;
                tong = double.Parse(colthanhtien.SummaryItem.SummaryValue.ToString());
                Biencucbo.skip = tong;
                var lsttt = (from a in dbData.tientes where a.tentiente == "Bath" select a);
                if (lsttt != null)
                {
                    tygia = double.Parse(lsttt.Single().tygia.ToString());
                    tiente = tong / tygia;
                    Biencucbo.sbath = tiente;
                    txtbath.Text = tiente.ToString();
                    lobath.Text = "Bath (" + tygia + ")";
                }

                lsttt = (from a in dbData.tientes where a.tentiente == "USD" select a);
                if (lsttt != null)
                {
                    tygia = double.Parse(lsttt.Single().tygia.ToString());
                    tiente = tong / tygia;
                    Biencucbo.susd = tiente;
                    txtusd.Text = tiente.ToString();
                    lousd.Text = "USD (" + tygia + ")";
                }




            }
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }



        #region Lay Du Lieu

        private void layttlbltenkh(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongs select a).Single(t => t.id == id);
                lbltenkh.Text = lst.tendt;
            }
            catch (Exception ex)
            {
                lbltenkh.Text = "";
            }
            txtmavach.Focus();
        }

        private void layttlbltendonvi(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lbltendonvi.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lbltendonvi.Text = "";
            }
        }

        private void layttlbltennhanvien(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lbltennhanvien.Text = lst.name;
            }
            catch (Exception ex)
            {
                lbltennhanvien.Text = "";
            }
        }

        #endregion

        #region SLUPOPUP khách hàng

        private void txtkhachhang_Popup(object sender, EventArgs e)
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

        private void loadslutxtkhachhang()
        {
            txtkhachhang.Properties.DataSource = (from a in new KetNoiDBDataContext().doituongs select a);
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
            var frm = new f_dsdoituong();
            frm.ShowDialog();
            loadslutxtkhachhang();
            txtkhachhang.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslutxtkhachhang();
            txtkhachhang.ShowPopup();
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

        private void gv_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "ghichu")
            {
                e.RepositoryItem = btn_del;
            }
        }

        #region Load dữ liệu Thông Tin

        private void txtkhachhang_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltenkh(txtkhachhang.Text);
            bh.truyendt(txtkhachhang.Text);
        }

        private void txtdonvi_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltendonvi(txtdonvi.Text);
        }

        private void txtnhanvien_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltennhanvien(txtnhanvien.Text);
        }

        #endregion


        #region Method
        private void dongedit()
        {
            txtkhachhang.ReadOnly = true;
            txtmavach.ReadOnly = true;
            gv.OptionsBehavior.Editable = false;
            chonsoluong(false);
            _hdong = 0;
        }

        private void moedit()
        {

            txtkhachhang.ReadOnly = false;
            txtmavach.ReadOnly = false;
            gv.OptionsBehavior.Editable = true;
            txtmavach.Focus();
            chonsoluong(false);
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
            txtdonvi.Text = _donvi;
            txtid.Text = "YYYY";

            txtngayxuat.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            txtnhanvien.Text = Biencucbo.idnv;
            txtkhachhang.Text = "KH_01";
            moedit();

        }

        private void xoatxt()
        {

            txtdonvi.Text = string.Empty;
            txtid.Text = string.Empty;
            txtngayxuat.Text = string.Empty;

            txtnhanvien.Text = string.Empty;
            txtkhachhang.Text = string.Empty;
            chonsoluong(false);
            dongedit();

        }



        #endregion

        private void btnnew_Click(object sender, EventArgs e)
        {

            bh.truyenxoaall();
            double tong = double.Parse(colthanhtien.SummaryItem.SummaryValue.ToString());
            Biencucbo.skip = tong;
            double discount = double.Parse(colchietkhau.SummaryItem.SummaryValue.ToString());
            Biencucbo.sdiscount = discount;
            var lsttt = (from a in dbData.tientes where a.tentiente == "Bath" select a);
            if (lsttt != null)
            {
                double tygia = double.Parse(lsttt.Single().tygia.ToString());
                double tiente = tong / tygia;
                Biencucbo.sbath = tiente;
                txtbath.Text = tiente.ToString();
                lobath.Text = "Bath (" + tygia + ")";
            }

            lsttt = (from a in dbData.tientes where a.tentiente == "USD" select a);
            if (lsttt != null)
            {
                double tygia = double.Parse(lsttt.Single().tygia.ToString());
                double tiente = tong / tygia;
                Biencucbo.susd = tiente;
                txtusd.Text = tiente.ToString();
                lousd.Text = "USD (" + tygia + ")";
            }
            themtxt();
            btnnew.Enabled = false;
            btnpay.Enabled = true;
            btncancel.Enabled = true;
            btnprint.Enabled = false;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            xoatxt();
            try
            {
                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    var ct = gv.GetRow(i) as pxuatct;

                    gv.DeleteRow(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            bh.truyenxoaall();
            double tong = double.Parse(colthanhtien.SummaryItem.SummaryValue.ToString());
            Biencucbo.skip = tong;
            double discount = double.Parse(colchietkhau.SummaryItem.SummaryValue.ToString());
            Biencucbo.sdiscount = discount;
            var lsttt = (from a in dbData.tientes where a.tentiente == "Bath" select a);
            if (lsttt != null)
            {
                double tygia = double.Parse(lsttt.Single().tygia.ToString());
                double tiente = tong / tygia;
                Biencucbo.sbath = tiente;
                txtbath.Text = tiente.ToString();
                lobath.Text = "Bath (" + tygia + ")";
            }

            lsttt = (from a in dbData.tientes where a.tentiente == "USD" select a);
            if (lsttt != null)
            {
                double tygia = double.Parse(lsttt.Single().tygia.ToString());
                double tiente = tong / tygia;
                Biencucbo.susd = tiente;
                txtusd.Text = tiente.ToString();
                lousd.Text = "USD (" + tygia + ")";
            }
            btnnew.Enabled = true;
            btnprint.Enabled = true;
            btncancel.Enabled = false;
            btnpay.Enabled = false;
        }

        private bool LuuPhieu()
        {

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

        private void print()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().ptts where a.link == txtid.Text select a);
                Biencucbo.cash = double.Parse(lst.Sum(t => t.tienthu).ToString());
                Biencucbo.change = double.Parse(lst.Sum(t => t.tientra).ToString());
                var rp = new r_hoadon();
                rp.DataSource = (new KetNoiDBDataContext().SP_InHoaDonBanHang(_key));
                rp.ShowPrintStatusDialog = false;
                rp.ShowPrintMarginsWarning = false;
                // rp.ShowPreviewDialog();
                rp.Print();

            }
            catch (Exception ex)
            {

            }

        }
        private void thanhtoan()
        {
            if (_hdong == 0)
            {
                if (txtid.Text != string.Empty)
                {
                    Biencucbo.link = txtid.Text;
                    Biencucbo.iddt = txtkhachhang.Text;
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

        private void btnpay_Click(object sender, EventArgs e)
        {
            try
            {
                gv.PostEditor();
                gv.UpdateCurrentRow();

                if (_hdong == 1)
                {
                    txtid.Text = custom.matutang("BH" + _donvi);
                    _so = Biencucbo.so;
                    pn.them(_key, txtid.Text, txtngayxuat.DateTime, "XB", txtnhanvien.Text, txtkhachhang.Text, "", _so, txtdonvi.Text, "Kip", 1);
                    LuuPhieu();
                    hs.add(txtid.Text, "Thêm Phiếu Bán Hàng");
                    dongedit();
                    btnnew.Enabled = true;
                    btnprint.Enabled = true;
                    btncancel.Enabled = false;
                    btnpay.Enabled = false;
                    thanhtoan();
                }

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
            ct.chietkhau = (Biencucbo.dongia * _chietkhau / 100) * Biencucbo.soluong;
            ct.ghichu = string.Empty;
            ct.stt = k;
            ct.nguyente = (Biencucbo.soluong * Biencucbo.dongia) - ((Biencucbo.dongia * _chietkhau / 100) * Biencucbo.soluong);
            ct.thanhtien = (Biencucbo.soluong * Biencucbo.dongia) - ((Biencucbo.dongia * _chietkhau / 100) * Biencucbo.soluong);
            gv.PostEditor();
            gv.UpdateCurrentRow();
            Biencucbo.soluong = 0;
            Biencucbo.dongia = 0;
            bh.truyenthemct(ct.key, ct.keypx, ct.idsp, double.Parse(ct.soluong.ToString()), double.Parse(ct.dongia.ToString()), double.Parse(ct.chietkhau.ToString()), int.Parse(ct.stt.ToString()));

        }

        private void btn_del_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                var ct = gv.GetFocusedRow() as pxuatct;
                dbData.pxuatcts.DeleteOnSubmit(ct);
                bh.truyenxoact(gv.FocusedRowHandle);
                gv.DeleteRow(gv.FocusedRowHandle);

                double tong = double.Parse(colthanhtien.SummaryItem.SummaryValue.ToString());
                Biencucbo.skip = tong;
                double discount = double.Parse(colchietkhau.SummaryItem.SummaryValue.ToString());
                Biencucbo.sdiscount = discount;
                var lsttt = (from a in dbData.tientes where a.tentiente == "Bath" select a);
                if (lsttt != null)
                {
                    double tygia = double.Parse(lsttt.Single().tygia.ToString());
                    double tiente = tong / tygia;
                    Biencucbo.sbath = tiente;
                    txtbath.Text = tiente.ToString();
                    lobath.Text = "Bath (" + tygia + ")";
                }

                lsttt = (from a in dbData.tientes where a.tentiente == "USD" select a);
                if (lsttt != null)
                {
                    double tygia = double.Parse(lsttt.Single().tygia.ToString());
                    double tiente = tong / tygia;
                    Biencucbo.susd = tiente;
                    txtusd.Text = tiente.ToString();
                    lousd.Text = "USD (" + tygia + ")";
                }

            }
            catch (Exception ex)
            {
                gv.DeleteRow(gv.FocusedRowHandle);
            }
            txtmavach.Focus();
        }

        private void f_banhang_new_FormClosed(object sender, FormClosedEventArgs e)
        {
            bh.Close();
            DialogResult = DialogResult.OK;

        }

        private void layttlblmavach(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dmsanphams select a).Single(t => t.id == id);
                lblmavach.Text = lst.tensp;
            }
            catch (Exception ex)
            {
                lblmavach.Text = "";
            }
        }
        private void txtmavach_EditValueChanged(object sender, EventArgs e)
        {
            layttlblmavach(txtmavach.Text);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            print();
        }

        private void gv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // gv.Columns["colthanhtien"].AppearanceHeader.Font = new Font("Times New Roman", 15);
               //gv.Columns["colthanhtien"].AppearanceHeader.Font = new Font("Times New Roman", 15);
              // gv.Columns["colthanhtien"].AppearanceCell.Font = new Font("Times New Roman", 15);
        }
    }

}