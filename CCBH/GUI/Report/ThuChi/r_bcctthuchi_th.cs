using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraReports.UI;

namespace GUI.Report.ThuChi
{
    public partial class r_bcctthuchi_th : frm.rp

    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private int _stt = 0;
        private int _stt1 = 0;
      
    
      
        public r_bcctthuchi_th()
        {
            InitializeComponent();
       

        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void txttondau_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void txttoncuoi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
        
            _stt ++;
            stt.Text = _stt.ToString();
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1++;
          
            stt1.Text = stt.Text + "." + _stt1;
        }

      
        
    }
}
