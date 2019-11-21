using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
namespace GUI.DanhMuc
{
    public partial class f_giamgia : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_giamgia()
        {
            InitializeComponent();
        }

        private void f_giamgia_Load(object sender, EventArgs e)
        {
            phantramSpinEdit.Text = (from a in dbData.giamgias select a).Single().phantram.ToString();
        }

        private void f_giamgia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var g = (from a in dbData.giamgias select a).Single();
                g.phantram = double.Parse(phantramSpinEdit.Value.ToString());
                dbData.SubmitChanges();
                XtraMessageBox.Show("Done");
                Close();
            }
        }
    }
}