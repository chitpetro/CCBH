using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_login : DevExpress.XtraEditors.XtraForm
    {
        c_history hs = new c_history();
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool chek = false;
        public f_login()
        {
            InitializeComponent();
            var lst = (from a in dbData.skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
            

        }

        private void f_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chek == false)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "THÔNG BÁO", MessageBoxButtons.YesNo) ==
                DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void f_login_Load(object sender, EventArgs e)
        {

            lbldata.Text = "Data: " + Biencucbo.DbName;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load("appconfig.xml");
                }
                catch
                {
                    try
                    {

                        string filepath = "appconfig.xml";
                        WebClient webClient = new WebClient();
                        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        webClient.DownloadFileAsync(new Uri("http://www.petrolao.com.la/config/CCS/appconfig.xml"), filepath);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                int Remember = Convert.ToInt32(xmlDoc.DocumentElement["Remember"].InnerText);//gán giá trị cho biến Remmber từ file.xml
                if (Remember == 1)//xét xem nó bằng 0 hay bằng 1, như mình nói ở trên: 1 là ghi nhớ, 0 là không ghi nhớ
                {
                    checkremem.Checked = true;
                    txtuser.Text = xmlDoc.DocumentElement["UserLogin"].InnerText;
                    txtpass.Text = custom.Decrypt((xmlDoc.DocumentElement["PassLogin"].InnerText));
                    if (xmlDoc.DocumentElement["lang"].InnerText == "lao")
                    {
                        btnLangLA.Enabled = false;
                        btnLangVI.Enabled = true;
                    }
                    else
                    {
                        btnLangLA.Enabled = true;
                        btnLangVI.Enabled = false;
                    }
                    txtpass.Focus();
                    if (btnLangLA.Enabled == false)
                    {
                        LanguageHelper.Active((LanguageEnum)LanguageEnum.Lao);
                        Biencucbo.ngonngu = LanguageEnum.Lao;
                    }
                    else
                    {
                        LanguageHelper.Active((LanguageEnum)LanguageEnum.Vietnam);
                        Biencucbo.ngonngu = LanguageEnum.Vietnam;
                    }
                    ActiveControl = txtpass;
                }
                else if (Remember == 0)
                {
                    checkremem.Checked = false;
                    txtuser.Text = xmlDoc.DocumentElement["UserLogin"].InnerText;
                    txtuser.Focus();
                    ActiveControl = txtuser;
                }
                //LanguageHelper.Translate(this);
                //changeFont.Translate(this);
            }
            catch
            {


            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }
        private void login()
        {
            //Kiểm tra Tên và Pass có tồn tại hay không 
            var dn = (from tk in new KetNoiDBDataContext().accounts where tk.uname == txtuser.Text & tk.pass == custom.Encrypt(txtpass.Text) select tk).ToList();
            
            if (dn.Count == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! Vui lòng kiểm tra lại!");
                txtpass.Text = "";
            }
            else
            {
                //kiểm tra Tài khoản có đang hoạt động không 
                if (dn.Where(t=>t.IsActived == true).Count() == 0)
                {
                    MessageBox.Show("Tài khoản của bạn đang bị khoá! Vui lòng liên hệ Admin!");
                }
                else
                {
                   
                    // lấy thông tin máy
                    var hostname = "";
                    var ip = new IPHostEntry();
                    hostname = Dns.GetHostName();
                    ip = Dns.GetHostByName(hostname);
                    Biencucbo.hostname = ip.HostName;

                    foreach (var listip in ip.AddressList)
                    {
                        Biencucbo.IPaddress = listip.ToString();
                    }

                    Biencucbo.ten = dn.Single().name;
                    Biencucbo.DonViMain = dn.Single().madonvi;
                    Biencucbo.phongban = dn.Single().phongban;
                    Biencucbo.donvi = dn.Single().madonvi;
                    Biencucbo.idnv = dn.Single().id;
                    hs.add("Login", "Đăng nhập");
                    try
                    {
                        if (checkremem.Checked) //Nếu checkbox ghi nhớ được check
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load("appconfig.xml"); //mở file.xml lên
                            xmlDoc.DocumentElement["UserLogin"].InnerText = txtuser.Text.Trim(); //lưu username
                            xmlDoc.DocumentElement["PassLogin"].InnerText = custom.Encrypt(txtpass.Text.Trim());
                            //lưu mật khẩu
                            xmlDoc.DocumentElement["Remember"].InnerText = "1"; //đánh dấu = 1 nghĩa là ghi nhớ
                            if (btnLangLA.Enabled == false)
                            {
                                xmlDoc.DocumentElement["lang"].InnerText = "lao";
                            }
                            else
                            {
                                xmlDoc.DocumentElement["lang"].InnerText = "viet";
                            }
                            xmlDoc.Save("appconfig.xml"); //save file.xml lại
                        }
                        else
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load("appconfig.xml");
                            xmlDoc.DocumentElement["UserLogin"].InnerText = txtuser.Text.Trim();
                            xmlDoc.DocumentElement["PassLogin"].InnerText = "";
                            xmlDoc.DocumentElement["Remember"].InnerText = "0"; //đánh dấu = 0 nghĩa là không ghi nhớ
                            if (btnLangLA.Enabled == false)
                            {
                                xmlDoc.DocumentElement["lang"].InnerText = "lao";
                            }
                            else
                            {
                                xmlDoc.DocumentElement["lang"].InnerText = "viet";
                            }
                            xmlDoc.Save("appconfig.xml");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                    chek = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            login();
           
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                login();
        }

        private void btnconnectdb_Click(object sender, EventArgs e)
        {
            var frm = new f_connectDB();
            frm.ShowDialog();
            lbldata.Text = "Data: " + Biencucbo.DbName;
        }

        private void btnLangLA_Click(object sender, EventArgs e)
        {
            btnLangVI.Enabled = true;
            btnLangLA.Enabled = false;
          //  imageComboBoxEdit1_EditValueChanged(sender, e);
            LanguageHelper.Active((LanguageEnum)LanguageEnum.Lao);
            Biencucbo.ngonngu = LanguageEnum.Lao;
        }

        private void btnLangVI_Click(object sender, EventArgs e)
        {
            btnLangVI.Enabled = false;
            btnLangLA.Enabled = true;
           // imageComboBoxEdit1_EditValueChanged(sender, e);
            LanguageHelper.Active((LanguageEnum)LanguageEnum.Vietnam);
            Biencucbo.ngonngu = LanguageEnum.Vietnam;
        }

        private void txtpass_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtpass.Properties.UseSystemPasswordChar)
            {
                txtpass.Properties.UseSystemPasswordChar = false;
                e.Button.Image = GUI.Properties.Resources.hide_16x16;

            }
            else
            {
                txtpass.Properties.UseSystemPasswordChar = true;
                e.Button.Image = GUI.Properties.Resources.show_16x161;
            }
        }
    }
}