using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Thu
{
    public partial class r_bcthutien_th : frm.rp
    {
        private int _stt0 = 0;
        private int _stt = 0;
    

        public r_bcthutien_th()
        {
            InitializeComponent();
       
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void att_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        
            _stt ++;
            att.Text = stt0.Text + "." + _stt.ToString();
        }

     

        private void stt0_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          _stt = 0;
            _stt0 ++;
            stt0.Text = _stt0.ToString();
        }
    }
}
