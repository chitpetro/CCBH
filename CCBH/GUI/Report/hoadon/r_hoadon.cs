using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using BUS;
namespace GUI
{
    public partial class r_hoadon : DevExpress.XtraReports.UI.XtraReport
    {
        public r_hoadon()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);

            s_kip.Text = string.Format("{0:#,#}",Biencucbo.skip) + " (Kip)";
            s_usd.Text = string.Format("{0:n2}", Biencucbo.susd) + " (USD)";
            s_bath.Text = string.Format("{0:n2}", Biencucbo.sbath) + " (Bath)";
            s_discount.Text = string.Format("{0:#,#}", Biencucbo.sdiscount) ;
            //s_vnd.Text = string.Format("{0:n2}", double.Parse(f_banhang._vnd.ToString()));
            txtcash.Text = string.Format("{0:n0}", Biencucbo.cash);
            txtchange.Text = string.Format("{0:n0}", Biencucbo.change);
        }

        private void r_hoadon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
