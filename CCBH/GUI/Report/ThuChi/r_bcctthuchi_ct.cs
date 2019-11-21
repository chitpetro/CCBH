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
    public partial class r_bcctthuchi_ct : frm.rp

    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private int _stt = 0;
        private int _stt1 = 0;
        private int _stt2 = 0;
        private string tiente = "";
        private string iddv = "";
        private DateTime _tungay;
        private DateTime _denngay;
        DataTable dt = new DataTable();
        public r_bcctthuchi_ct()
        {
            InitializeComponent();

            _tungay = Biencucbo.tungay;
            _denngay = Biencucbo.denngay;
            dt.Columns.Add("id", typeof (string));
            dt.Columns.Add("key", typeof (string)); 

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
            _stt2 = 0;
            _stt ++;
            stt.Text = _stt.ToString();
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1++;
            _stt2 = 0;
            stt1.Text = stt.Text + "." + _stt1;
        }

        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt2++;
            stt2.Text = stt1.Text + "." + _stt2;
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

        private void txtidthu_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            try
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
                                    _key = item[1].ToString();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
           
        }

        private void txtidchi_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
              try
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
                                    _key = item[1].ToString();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        
    }
}
