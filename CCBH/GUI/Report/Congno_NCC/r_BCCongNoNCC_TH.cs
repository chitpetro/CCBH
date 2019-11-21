using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Congno_NCC
{
    public partial class r_BCCongNoNCC_TH : frm.rp
    {
        private int _stt = 0;
        private int _stt1 = 0;
        public r_BCCongNoNCC_TH()
        {
            InitializeComponent();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
            _stt ++;
            stt.Text = _stt.ToString();
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 ++;
            stt1.Text = stt.Text + "." + _stt1;
        }
    }
}
