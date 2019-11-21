using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Ton
{
    public partial class r_bcnhapxuatton_th : frm.rp
    {
        private int _stt = 0;
        public r_bcnhapxuatton_th()
        {
            InitializeComponent();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt++;
            stt.Text = _stt.ToString();
        }
    }
}
