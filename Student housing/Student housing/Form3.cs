using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Student_housing
{
    public partial class ADMIN : Form
    {
        UserManager userManager;
        Admin admin;

        //Constructor(s)
        public ADMIN(UserManager userManager, Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.userManager = userManager;
        }
        private void ADMIN_Load(object sender, EventArgs e)
        {
            //Design code
            tcAdmin.Appearance = TabAppearance.FlatButtons;
            tcAdmin.ItemSize = new Size(0, 1);
            tcAdmin.SizeMode = TabSizeMode.Fixed;
            buttonPannelAdmin.Height = btnUsersAdminTab.Height;
            buttonPannelAdmin.Top = btnUsersAdminTab.Top;

            lblTitle.Text = "Welcome back, " + admin.Username + "!";
            LoadFromFile("Rules");
            LoadFromFile("Guidelines");
        }

        public void LoadFromFile(string filename)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                fs.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(fs);
                string text;
                while (sr.EndOfStream != true)
                {
                    if(filename == "Rules")
                    {
                        text = sr.ReadLine();
                        rtbRules.Text = rtbRules.Text + text;
                    }
                    else
                    {
                        text = sr.ReadLine();
                        rtbGuidelines.Text = rtbGuidelines.Text + text;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        public void SerializeObject()
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream("SaveData", FileMode.OpenOrCreate, FileAccess.Write);
                bf = new BinaryFormatter();
                bf.Serialize(fs, this.userManager);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { if (fs != null) fs.Close(); }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            User newUser = new User(username, password);
            userManager.addUser(newUser);
            SerializeObject();
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            LOGIN loginform = new LOGIN(admin, userManager);
            loginform.Show();
            this.Close();
        }

        #region <Tab control design>

        private void btnUsersAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminUsers;
            buttonPannelAdmin.Height = btnUsersAdminTab.Height;
            buttonPannelAdmin.Top = btnUsersAdminTab.Top;
        }

        private void btnComplaintsAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminComplaints;
            buttonPannelAdmin.Height = btnComplaintsAdminTab.Height;
            buttonPannelAdmin.Top = btnComplaintsAdminTab.Top;
        }

        private void btnTechnicalAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminTechnical;
            buttonPannelAdmin.Height = btnTechnicalAdminTab.Height;
            buttonPannelAdmin.Top = btnTechnicalAdminTab.Top;
        }

        private void btnRuesAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminRules;
            buttonPannelAdmin.Height = btnRulesAdminTab.Height;
            buttonPannelAdmin.Top = btnRulesAdminTab.Top;
        }
        #endregion

        #region <Rules and guidelines>

        public void WriteToFile(string filename, string text)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(text);
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rules = rtbRules.Text.ToString();
            string guidelines = rtbGuidelines.Text.ToString();
            WriteToFile("Rules", rules);
            WriteToFile("Guidelines", guidelines);
        }

        #endregion
    }
}
