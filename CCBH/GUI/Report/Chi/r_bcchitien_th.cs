using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Chi
{
    public partial class r_bcchitien_th : frm.rp
    {
        private int _stt = 0;
    
        private int _stt0 = 0;

        public r_bcchitien_th()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

      

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            _stt++;
            stt.Text = stt0.Text + "." + _stt;
        }

   

        private void stt0_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
            _stt = 0;
            _stt0 ++;
            stt0.Text = _stt0.ToString();
        }
    }
}
