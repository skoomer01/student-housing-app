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
    public partial class LOGIN : Form
    {
        private UserManager userManager;
        User currentUser;
        Admin currentAdmin;

        //Constructor(s)
        public LOGIN()
        {
            userManager = new UserManager(); 
            InitializeComponent();
            DeSerializeObject();
        }

        public LOGIN(User currentUser, UserManager userManager)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.userManager = userManager;
            DeSerializeObject();
        }
        public LOGIN(Admin currentAdmin, UserManager userManager)
        {
            InitializeComponent();
            this.currentAdmin = currentAdmin;
            this.userManager = userManager;
            DeSerializeObject();
        }

        #region <Seerialization>
        public void DeSerializeObject()
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream("SaveData", FileMode.Open, FileAccess.Read);
                bf = new BinaryFormatter();
                this.userManager = (UserManager)bf.Deserialize(fs);

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { if (fs != null) fs.Close(); }
        }
        #endregion <Serialization>


        private void btLogIn_Click(object sender, EventArgs e)
        {
            string username = Convert.ToString(tbxUsername.Text);
            string password = Convert.ToString(tbxPassword.Text);

            
            if (userManager.CheckUser(username, password) == true)
            {
                User currentUser = userManager.getUser(username, password);
                STUDENT studentForm = new STUDENT(userManager, currentUser);
                studentForm.Show();
                Hide();
                
            }
            else if (userManager.CheckUserAdmin(username, password) == true)
            {
                Admin currentAdmin = userManager.getAdmin(username, password);
                ADMIN adminForm = new ADMIN( userManager, currentAdmin);
                adminForm.Show();
                Hide();
            }
            else
                MessageBox.Show("Incorrect password or username");


        }
    }
}
