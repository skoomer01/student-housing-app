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
        User currentUser;
        Admin currentAdmin;
        ClassesManager classesManager;


        //Constructor(s)
        public LOGIN()
        {
            classesManager = new ClassesManager();
            
            InitializeComponent();
        }

        public LOGIN(User currentUser, UserManager userManager, ClassesManager classesManager)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.classesManager = classesManager;
        }
        public LOGIN(Admin currentAdmin, UserManager userManager, ClassesManager classesManager)
        {
            InitializeComponent();
            this.currentAdmin = currentAdmin;
            this.classesManager = classesManager;
        }


        private void btLogIn_Click(object sender, EventArgs e)
        {
            string username = Convert.ToString(tbxUsername.Text);
            string password = Convert.ToString(tbxPassword.Text);

            
            if (classesManager.UserManager.CheckUser(username, password) == true)
            {
                User currentUser = classesManager.UserManager.getUser(username, password);
                STUDENT studentForm = new STUDENT(classesManager.UserManager, currentUser, classesManager);
                studentForm.Show();
                Hide();
                
            }
            else if (classesManager.UserManager.CheckUserAdmin(username, password) == true)
            {
                Admin currentAdmin = classesManager.UserManager.getAdmin(username, password);
                ADMIN adminForm = new ADMIN(classesManager.UserManager, currentAdmin, classesManager);
                adminForm.Show();
                Hide();
            }
            else
                MessageBox.Show("Incorrect password or username");


        }
    }
}
