using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraBars;
using BUS;
using DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using GUI.ChucNang;
using GUI.DanhMuc;
using GUI.frm;
using GUI.HeThong;
using ControlLocalizer;

namespace GUI
{
    public partial class f_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public f_main()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
        }
        private void OpenForm<T>()
        {

            var fm = MdiChildren.FirstOrDefault(f => f is T);
            if (fm == null)
            {
                fm = Activator.CreateInstance<T>() as Form; // tao đối tượng T thôi
                fm.MdiParent = this;
                fm.Show();
            }
            else
                fm.Activate();

        }
        private void btnaccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsaccount>();
        }
        private readonly t_chucnang t_cn = new t_chucnang();

        public void duyetRibbon(RibbonControl ribbonControl)
        {
            {
                foreach (RibbonPage page in ribbonControl.Pages)
                {
                    t_cn.moi(page.Name, page.Text, string.Empty);
                    foreach (RibbonPageGroup g in page.Groups)
                    {
                        t_cn.moi(g.Name, g.Text, page.Name);

                        foreach (BarItemLink i in g.ItemLinks)
                        {
                            if (i.Item == btndangxuat) continue;

                            t_cn.moi(i.Item.Name, i.Item.Caption, g.Name);

                            // lay quyen
                            //var quyen = db.PhanQuyen2s
                            //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == i.Item.Name);

                            var quyen = db.PhanQuyen2s
                                .FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == i.Item.Name);

                            // cheat tài khoản quan tri
                            //if (Biencucbo.idnv == "AD")

                            if (Biencucbo.phongban == "AD")
                            {
                                if (quyen == null)
                                {
                                    quyen = new PhanQuyen2();
                                    quyen.TaiKhoan = Biencucbo.phongban;
                                    quyen.ChucNang = i.Item.Name;
                                    quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;

                                    db.PhanQuyen2s.InsertOnSubmit(quyen);
                                    db.SubmitChanges();
                                }
                            }

                            i.Item.Enabled = quyen == null ? false : Convert.ToBoolean(quyen.Xem);
                            //if (quyen == null)
                            //{
                            //    i.Item.Visibility = BarItemVisibility.Never;
                            //}
                            //else
                            //{
                            //    if (Convert.ToBoolean(quyen.Xem))
                            //    {
                            //        i.Item.Visibility = BarItemVisibility.Always;
                            //    }
                            //    else
                            //    {
                            //        i.Item.Visibility = BarItemVisibility.Never;
                            //    }
                            //}
                            // luu vào tag của nút tren ribbon de xu ly sau
                            i.Item.Tag = quyen;


                            if (i.Item is BarSubItem)
                            {
                                var sub = i.Item as BarSubItem;
                                sub.Enabled = true;
                                foreach (BarItemLink y in sub.ItemLinks)
                                {
                                    t_cn.moi(y.Item.Name, y.Item.Caption, i.Item.Name);
                                    // lay quyen
                                    //quyen = db.PhanQuyen2s
                                    //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == y.Item.Name);
                                    quyen = db.PhanQuyen2s
                                        .FirstOrDefault(
                                            p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == y.Item.Name);

                                    // cheat tài khoản quan tri
                                    //if (Biencucbo.idnv == "AD")
                                    if (Biencucbo.phongban == "AD")
                                    {
                                        if (quyen == null)
                                        {
                                            quyen = new PhanQuyen2();
                                            //quyen.TaiKhoan = Biencucbo.idnv;
                                            quyen.TaiKhoan = Biencucbo.phongban;
                                            quyen.ChucNang = y.Item.Name;

                                           quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;

                                            db.PhanQuyen2s.InsertOnSubmit(quyen);
                                            db.SubmitChanges();
                                        }
                                    }

                                    y.Item.Enabled = quyen == null ? false : Convert.ToBoolean(quyen.Xem);
                                    //if (quyen == null)
                                    //{
                                    //    y.Item.Visibility = BarItemVisibility.Never;
                                    //}
                                    //else
                                    //{
                                    //    if (Convert.ToBoolean(quyen.Xem))
                                    //    {
                                    //        y.Item.Visibility = BarItemVisibility.Always;
                                    //    }
                                    //    else
                                    //    {
                                    //        y.Item.Visibility = BarItemVisibility.Never;
                                    //    }
                                    //}
                                    // luu vào tag của nút tren ribbon de xu ly sau
                                    y.Item.Tag = quyen;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnnhomdonvi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_DsNhomDonVi>();
        }

        private void btndonvi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
             OpenForm<f_dsdonvi>();
        }



        private void btnphongban_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_dsphongban();
            frm.ShowDialog();
        }
        private void DangNhap()
        {
            // dang xuat


            try
            {

                foreach (var form in MdiChildren)
                    form.Close();
                Hide();
                // dang nhap
                var f = new f_login();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    WindowState = FormWindowState.Maximized;
                    if (Biencucbo.phongban.Trim() != "AD")
                    {
                        //btnskinht.Visibility = BarItemVisibility.Never;
                    }

                    var lst = (from a in new KetNoiDBDataContext().skins select a).Single(t => t.trangthai == true);
                    Biencucbo.skin = lst.tenskin;
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
                    btninfo_account.Caption = Biencucbo.ten;
                    btninfo_data.Caption = Biencucbo.DbName;
                    btninfo_donvi.Caption =
                        (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == Biencucbo.donvi)
                            .tendonvi;
                    btninfo_phongban.Caption =
                        (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == Biencucbo.phongban)
                            .ten;
                    btninfo_version.Caption = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                    LanguageHelper.Language = (ControlLocalizer.LanguageEnum)Biencucbo.ngonngu;
                    changeFont.Translate(this);
                    changeFont.Translate(ribbon);
                    LanguageHelper.Active(LanguageHelper.Language);
                    LanguageHelper.Translate(this);
                    LanguageHelper.Translate(ribbon);
                    duyetRibbon(ribbon);
                    if (Biencucbo.ngonngu.ToString() == "Lao")
                    {
                        this.Font =
                        btninfo_account.ItemAppearance.Normal.Font =
                        btninfo_account.ItemAppearance.Disabled.Font =
                        btninfo_account.ItemAppearance.Hovered.Font =
                        btninfo_account.ItemAppearance.Pressed.Font =
                        btninfo_donvi.ItemAppearance.Normal.Font =
                        btninfo_donvi.ItemAppearance.Disabled.Font =
                        btninfo_donvi.ItemAppearance.Hovered.Font =
                        btninfo_donvi.ItemAppearance.Pressed.Font =
                      changeFont.FontLao;
                    }

                   

                    //code moi 

                }
                else
                    Application.ExitThread();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void f_main_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            DangNhap();
            try
            {
                Show();
                var lst = (from a in db.accounts select a).Single(t => t.id == Biencucbo.idnv);
                if ((bool)lst.pos)
                {
                    loadPOS();
                    try
                    {
                        Show();
                        Application.Exit();

                    }
                    catch
                    {
                        Application.Exit();
                    }
                }

            }
            catch
            {
                Application.Exit();
            }
        }

        private void btndangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Hide();
            DangNhap();
            try
            {
                Show();
                var lst = (from a in db.accounts select a).Single(t => t.id == Biencucbo.idnv);
                if ((bool)lst.pos)
                {
                    loadPOS();
                    try
                    {
                        Show();
                        Application.Exit();

                    }
                    catch
                    {
                        Application.Exit();
                    }
                }


            }
            catch
            {
                Application.Exit();
            }
        }

        private void btnphanquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_phanquyen>();
        }

        private void btnloaisp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsloaisp>();
        }

        private void btnsanpham_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dssanpham>();
        }

        private void btngiasp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsgiasp>();
        }

        private void btnnhomdoituong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsnhomdoituong>();
        }

        private void btndoituong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsdoituong>();
        }

        private void btnloainhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsloainhap>();
        }

        private void btnloaixuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsloaixuat>();
        }

        private void btnmaincurrency_ItemClick(object sender, ItemClickEventArgs e)
        {
            f_tientechinh frm = new f_tientechinh();
            frm.ShowDialog();
        }

        private void btntiente_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dstiente>();
        }

        private void btnnhapkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pnhap>();
        }

        private void btnbanhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_banhang>();
        }

        private void btnloaithu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dmloaithu>();
        }

        private void btnphieuthu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pthutien>();
        }

        private void btnloaichi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dmloaichi>();
        }

        private void btnphieuchi_ItemClick(object sender, ItemClickEventArgs e)
        {

            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pchi>();
        }

        private void btnbcnhapkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcnhapkho";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhapkho.f_bcnhapkho>();
        }

        private void btnxuatkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcxuatkho";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.XuatKho.f_bcxuatkho>();
        }

        private void btnbcnhapxuatton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcnhapxuatton";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Ton.f_bcnhapxuatton>();
        }

        private void btnbcthutien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcthutien";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Thu.f_bcthutien>();
        }

        private void btnbcpchi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcpchi";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Chi.f_bcpchi>();
        }

        private void btnbcthuchi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcctthuchi";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.ThuChi.f_bcctthuchi>();
        }

        private void btnbcdoanhthu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bcdoanhthu";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.DoanhThu.f_bcdoanhthu>();
        }

        private void btnbccongno_ncc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bccongno_ncc";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Congno_NCC.f_bccongno_ncc>();
        }

        private void btndoidonvi_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new f_doidonvi();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                btninfo_donvi.Caption =
                        (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == Biencucbo.donvi)
                            .tendonvi;

        }

        private void btnbieudodoanhthuchiphi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.DoThi.f_dtdoanhthuchiphi>();
        }

        private void btndothidoanhthu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.DoThi.f_dtdoanhthu_sanpham>();
        }

        private void btndothidoanhthu_duong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_doanhthu_theothoigian";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.DoThi.f_doanhthu_theothoigian>();
        }

        private void btnmuccp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<DanhMuc.f_muccp>();
        }
        private void loadPOS()
        {
            // dang xuat
            try
            {

                //foreach (var form in MdiChildren)
                //    form.Close();
                Hide();
                // dang nhap
                var f = new f_POS();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    WindowState = FormWindowState.Maximized;

                    var lst = (from a in new KetNoiDBDataContext().skins select a).Single(t => t.trangthai == true);
                    Biencucbo.skin = lst.tenskin;
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);

                    //code moi 

                }
                else
                    Application.ExitThread();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void btnpos_ItemClick(object sender, ItemClickEventArgs e)
        {

            loadPOS();
            try
            {
                Show();
               
            }
            catch
            {
                Application.Exit();
            }
        }

        private void btnhistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new HeThong.f_history();

            frm.ShowDialog();
        }

        private void btnngonngu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            LanguageHelper.ShowTranslateTool();
        }

        private void btnchaygiavon_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_chaygiavon>();
        }

        private void btnbclailo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.KetQuaKinhDoanh.f_BCKetQuaKinhDoanh>();
        }

        private void btnskin_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new f_skin();
            frm.ShowDialog();
        }

        private void btngiamgia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_giamgia();
            frm.ShowDialog();
        }
    }
}