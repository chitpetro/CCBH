using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using System.IO.Ports;
using ControlLocalizer;

namespace GUI.ChucNang
{
    public partial class f_soluongdongia_mavach : DevExpress.XtraEditors.XtraForm
    {
        private int sec;
        private SerialPort _serialPort;
        private SerialPort _checkPort;//<-- declares a SerialPort Variable to be used throughout the form
        private const int BaudRate = 9600;

        public f_soluongdongia_mavach()
        {
            InitializeComponent();

            if (Biencucbo.banhang == true)
            {
                txtdongia.Text = Biencucbo.dongia.ToString();
                txtdongia.ReadOnly = true;

            }

        
        }

        private void f_soluongdongia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               if (double.Parse(txtsoluong.Text) > 0 && double.Parse(txtdongia.Text) > 0)
                {
                    Biencucbo.soluong = double.Parse(txtsoluong.Text);
                    Biencucbo.dongia = double.Parse(txtdongia.Text);
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void f_soluongdongia_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
        }
        

        private void f_soluongdongia_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }

}