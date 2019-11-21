using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Ton
{
    public partial class r_bcnhapxuatton_ct : frm.rp
    {
        private int _stt = 0;
        private int _stt1 = 0;
       
        DataTable dt = new DataTable();
        public r_bcnhapxuatton_ct(){
            InitializeComponent();
            dt.Columns.Add("idpn", typeof(string));
            dt.Columns.Add("idpx", typeof(string));
            dt.Columns.Add("key", typeof(string));
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("idpn").ToString(), GetCurrentColumnValue("idpx").ToString(),
                GetCurrentColumnValue("key").ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void xrTableCell39_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {

            if (e.Brick.Text != null)
            {
                try
                {
                    string _key = "";
                    DataRow[] rows = dt.Select();
                    foreach (DataRow item in rows)
                    {
                        if (item[0].ToString() == e.Brick.Text)
                        {
                            _key = item[2].ToString();
                            Biencucbo.key = _key;
                            custom.mofombc(e.Brick.Text);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void xrTableCell40_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            if (e.Brick.Text != null)
            {
                try
                {
                    string _key = "";
                    DataRow[] rows = dt.Select();
                    foreach (DataRow item in rows)
                    {
                        if (item[1].ToString() == e.Brick.Text)
                        {
                            _key = item[2].ToString();
                            Biencucbo.key = _key;
                            custom.mofombc(e.Brick.Text);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
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
            stt1.Text = stt.Text + "." + _stt1.ToString();
        }
    }
}
