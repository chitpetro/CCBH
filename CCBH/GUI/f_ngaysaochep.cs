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
using ControlLocalizer;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_ngaysaochep : DevExpress.XtraEditors.XtraForm
    {
        public f_ngaysaochep()
        {
            InitializeComponent();
        }

        private void f_ngaysaochep_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            txtngaycu.DateTime = Biencucbo.ngaysaochep;
            txtngaymoi.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtngaymoi.Text != string.Empty)
            {
                Biencucbo.ngaysaochep = txtngaymoi.DateTime;
                DialogResult = DialogResult.OK;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}