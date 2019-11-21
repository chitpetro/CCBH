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
using DAL;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace GUI
{
    public partial class f_skin : DevExpress.XtraEditors.XtraForm
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly ImageCollection img;
        private readonly t_skinabc sk = new t_skinabc();
        public f_skin()
        {
            InitializeComponent();
            img = new ImageCollection();
            imageComboBoxEdit1.Properties.SmallImages = img;
            for (var i = 0; i < SkinManager.Default.Skins.Count; i++)
            {
                var skinName = SkinManager.Default.Skins[i].SkinName;
                img.AddImage(SkinCollectionHelper.GetSkinIcon(skinName, SkinIconsSize.Small), skinName);
                imageComboBoxEdit1.Properties.Items.Add(new ImageComboBoxItem(skinName, i));
                //if (skinName == Properties.Settings.Default.theme)
                //{
                //    imageComboBoxEdit1.SelectedIndex = i;
                //}
            }
        }

        private void f_skin_Load(object sender, EventArgs e)
        {
            var lst = (from a in new KetNoiDBDataContext().skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
        }

        private void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Biencucbo.skin2 = Biencucbo.skin;
            Biencucbo.skin = imageComboBoxEdit1.Text;
            var frm = new f_main();
            frm.Refresh();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Biencucbo.skin = Biencucbo.skin2;
            var frm = new f_main();
            frm.Refresh();
            Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (imageComboBoxEdit1.Text == "")
                return;
            sk.sua(Biencucbo.skin);
            var frm = new f_main();
            frm.Refresh();
            Close();
        }
    }
}