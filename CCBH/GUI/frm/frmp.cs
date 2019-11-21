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
using DevExpress.XtraBars;

namespace GUI.frm
{
    public partial class frmp : DevExpress.XtraEditors.XtraForm
    {
        public frmp()
        {
            InitializeComponent();

        }

        private PhanQuyen2 q { get; set; } = Biencucbo.QuyenDangChon;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
           
            if (q == null) return;
            if ((bool)q.Them)
            {
                btnthem.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnthem.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Sua)
            {
                btnsua.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Xoa)
            {
                btnxoa.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = BarItemVisibility.Never;
            }
        }

        private void loadbtn()
        {
            btnmo.Enabled = true;
            btnthem.Enabled = true;
            btnsaochep.Enabled = true;
            btnluu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;
            btnreload.Enabled = false;
            btnfirst.Enabled = true;
            btnprev.Enabled = true;
            btnnext.Enabled = true;
            btnlast.Enabled = true;
            
          
        }

        private void editbtn()
        {
            btnmo.Enabled = false;
            btnthem.Enabled = false;
            btnsaochep.Enabled = false;
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            btnreload.Enabled = true;
            btnfirst.Enabled = false;
            btnprev.Enabled = false;
            btnnext.Enabled = false;
            btnlast.Enabled = false;

        }
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    LanguageHelper.Translate(this.bar2);
        //    // LanguageHelper.Translate(gd);
        //   // this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "title").ToString();
        //    changeFont.Translate(this);
        //}
        protected virtual void load()
        {
            
        }

        protected virtual void mo()
        {

        }

        protected virtual void them()
        {

        }

        protected virtual bool saochep()
        {
            return false;
        }
        protected virtual bool luu()
        {
            return true;
        }

        protected virtual bool sua()
        {
            return false;
        }

        protected virtual bool xoa()
        {
            return false;
        }

        protected virtual void print()
        {

        }

        protected virtual void first()
        {

        }

        protected virtual void prev()
        {

        }

        protected virtual void next()
        {

        }

        protected virtual void last()
        {

        }

        protected virtual void reload()
        {

        }

        private void frmp_Load(object sender, EventArgs e)
        {

            // LanguageHelper.Translate(gd);
            // this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "title").ToString();
            LanguageHelper.Translate_frm(bm,"frm");
            LanguageHelper.Translate(this);
            
            // LanguageHelper.Translate(gd);
        //    this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "title").ToString();
            changeFont.Translate(this);
          loadbtn();
            load();

        }

        private void btnreload_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadbtn();
            reload();
        }

        private void btnxoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {
                if (xoa())
                {
                    loadbtn();
                }
            }
        }

        private void btnmo_ItemClick(object sender, ItemClickEventArgs e)
        {
            mo();
        }

        private void btnthem_ItemClick(object sender, ItemClickEventArgs e)
        {
            them();
            editbtn();
        }

        private void btnluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (luu())
                loadbtn();
        }

        private void btnsua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (sua())
            {
                editbtn();
            }
            

        }

        private void btnin_ItemClick(object sender, ItemClickEventArgs e)
        {
            print();
        }

        private void btnfirst_ItemClick(object sender, ItemClickEventArgs e)
        {
            first();
        }

        private void btnprev_ItemClick(object sender, ItemClickEventArgs e)
        {
            prev();
        }

        private void btnnext_ItemClick(object sender, ItemClickEventArgs e)
        {
            next();
        }

        private void btnlast_ItemClick(object sender, ItemClickEventArgs e)
        {
            last();
        }

        private void btnsaochep_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saochep())
            {
                editbtn();
            }
        
    }

        private void frmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (btnmo.Visibility == BarItemVisibility.Always)
                {
                    if(btnmo.Enabled)
                    { mo(); }
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (btnthem.Visibility == BarItemVisibility.Always)
                {
                   if(btnthem.Enabled)
                    {
                        them();
                        editbtn();
                    }
                }

            }
            else if (e.KeyCode == Keys.F3)
            {
                if (btnsaochep.Visibility == BarItemVisibility.Always)
                {
                   if(btnsaochep.Enabled)
                    {
                        saochep();
                        editbtn();
                    }
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (btnluu.Visibility == BarItemVisibility.Always)
                {
                    if(btnluu.Enabled)
                    {
                        if (luu())
                            loadbtn();
                    }
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (btnsua.Visibility == BarItemVisibility.Always)
                {
                   if(btnsua.Enabled)
                    {
                        sua();
                        editbtn();
                    }
                }
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (btnxoa.Visibility == BarItemVisibility.Always)
                {
                    if (btnxoa.Enabled)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)

                        {
                            if (xoa())
                            {
                                loadbtn();
                            }
                        }
                    }
                }
            }

            else if (e.KeyCode == Keys.F7)
            {
                if (btnreload.Enabled)
                {
                    loadbtn();
                    reload();
                }
            }

            else if (e.KeyCode == Keys.F8)
            {
                if (btnin.Enabled)
                {
                    print();
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (btnfirst.Enabled)
                {
                    first();
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                if (btnprev.Enabled)
                {
                    prev();
                }
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (btnnext.Enabled)
                {
                    next();
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (btnlast.Enabled)
                {
                    last();
                }
            }
        }
    }
}