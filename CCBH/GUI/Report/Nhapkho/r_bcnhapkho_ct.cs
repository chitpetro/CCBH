using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;


namespace GUI.Report.Nhapkho
{
    public partial class r_bcnhapkho_ct : frm.rp
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        private string _stt;
        private int _index = 0;
        DataTable dt = new DataTable();
        public r_bcnhapkho_ct()
        {
            InitializeComponent();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("key", typeof(string));
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_stt != txtid.Text)
            {
                _stt = txtid.Text;
                _index++;
            }
            stt.Text = _index.ToString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {

                dt.Rows.Add(GetCurrentColumnValue("id").ToString(), GetCurrentColumnValue("key").ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void txtid_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            if (e.Brick.Text != null)
            {
                try
                {

                    string _key = "";
                    DataRow[] result = dt.Select();
                    foreach (DataRow item in result)
                    {
                        if (item[0].ToString() == e.Brick.Text)
                        {

                            _key = item[1].ToString();
                         
                            Biencucbo.key = _key;
                            custom.mofombc(e.Brick.Text);
                            break;
                        }
                    }
                  

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }

            }
        }
    }
}
