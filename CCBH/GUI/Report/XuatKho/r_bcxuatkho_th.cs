using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace GUI.Report.XuatKho
{
    public partial class r_bcxuatkho_th : frm.rp
    {
        private string _stt;
        private int index = 0;
        public r_bcxuatkho_th()
        {
            InitializeComponent();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtidsp.Text != _stt)
            {
                index ++;
                stt.Text = index.ToString();
            }
        }
    }
}
