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
        ClassesManager classesManager;

        //Constructor(s)
        public ADMIN(UserManager userManager, Admin admin, ClassesManager classesManager)
        {
            InitializeComponent();
            this.admin = admin;
            this.userManager = userManager;
            this.classesManager = classesManager;
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
            FillComplaintLbx();
            FillComplaintCbx();
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            User newUser = new User(username, password);
            userManager.addUser(newUser);
            classesManager.SerializeObject();
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
        public void LoadFromFile(string filename)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                fs.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(fs);
                if(filename == "Rules")
                {
                        rtbRules.Text = sr.ReadToEnd();
                }
                else
                {
                        rtbGuidelines.Text = sr.ReadToEnd();
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

        public void WriteToFile(string filename, string text)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                fs.SetLength(0);
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
                if (fs != null)
                {
                    fs.Close();
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

        #region <Complaints>

        public void FillComplaintLbx()
        {
            if(classesManager.ComplaintManager != null)
            {
                foreach (Complaint complaint in classesManager.ComplaintManager.Complaints)
                {
                    lbxAllComplaints.Items.Add(complaint.GetInfo());
                }
            }
            
        }

        public void FillComplaintCbx()
        {
            foreach (User user in userManager.GetUsers())
            {
                cbxComplaintUser.Items.Add(user.Username);
            }
        }

        private void btnRemoveComplaint_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllComplaints.SelectedIndex;
            if(selectedIndex != -1)
            {
                for (int i = 0; i <= lbxAllComplaints.Items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        lbxAllComplaints.Items.RemoveAt(i);
                    }
                }
            }
            else
                MessageBox.Show("Please select a complaint!");
        }

        private void btnSendWarning_Click(object sender, EventArgs e)
        {
            string complaintUser = cbxComplaintUser.SelectedItem.ToString();
            string warningText = rtxCreateWarning.Text.ToString();

            if(rtxCreateWarning.Text == "")
            {
                MessageBox.Show("No complaint written");
            }
            else if(cbxComplaintUser.SelectedIndex == -1)
            {
                MessageBox.Show("No user selected");
            }
            else
            {
                Complaint revisedComplaint = new Complaint(userManager.getUser(complaintUser), warningText, userManager);
                classesManager.ComplaintManager.AddRevisedComplaint(revisedComplaint);
                MessageBox.Show("Warning sent to " + complaintUser);
                rtxCreateWarning.Clear();

            }
        }

        #endregion <Complaints>

        private void pbxLogOut_Click(object sender, EventArgs e)
        {
            LOGIN loginform = new LOGIN(admin, userManager, classesManager);
            loginform.Show();
            this.Close();
        }
    }
}
