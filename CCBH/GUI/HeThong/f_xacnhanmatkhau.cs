using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DAL;

namespace GUI.HeThong
{
    public partial class f_xacnhanmatkhau : DevExpress.XtraEditors.XtraForm
    {
        private string _key;
        public f_xacnhanmatkhau()
        {
            InitializeComponent();
            _key = Biencucbo.key;
        }

       

        private void f_xacnhanmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnpass_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnpass.Properties.UseSystemPasswordChar)
            {
                btnpass.Properties.UseSystemPasswordChar = false;
                e.Button.Image = GUI.Properties.Resources.hide_16x16;

            }
            else
            {
                btnpass.Properties.UseSystemPasswordChar = true;
                e.Button.Image = GUI.Properties.Resources.show_16x161;
            }
        }
    }
}