using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;



namespace GUI.Report.Nhapkho
{
    public partial class r_bcnhapkho_th : frm.rp
    {
        public r_bcnhapkho_th()
        {
            InitializeComponent();
        }

        string _stt;
        int index = 0;

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_stt != txtidsp.Text)
            {
                index ++;
                stt.Text = index.ToString();
            }
        }
    }
}
