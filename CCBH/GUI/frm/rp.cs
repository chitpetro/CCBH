using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using BUS;
using ControlLocalizer;
using DevExpress.XtraReports.UI;
using DAL;

namespace GUI.frm
{
    public partial class rp : DevExpress.XtraReports.UI.XtraReport
    {
        public rp()
        {
            InitializeComponent();

            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            txtngayxem.Text = Biencucbo.ngaybc;
            txtinfo.Text = Biencucbo.info;
            txttitle.Text = Biencucbo.title;
            try
            {
                lbltendv.Text = (from a in new  KetNoiDBDataContext().donvis select  a).Single(t=>t.id == Biencucbo.donvi).tendonvi;
                
            }
            catch (Exception ex)
            {
              
            }
        }

    }
}
