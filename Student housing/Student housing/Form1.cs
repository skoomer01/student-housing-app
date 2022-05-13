using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_housing
{
    public partial class LOGIN : Form
    {
        public UserManager userManager = new UserManager();

        public LOGIN()
        {
            InitializeComponent();
            AddInitialData();
        }

        public void AddInitialData()
        {
            Admin admin = new Admin("Admin", "1234");
            userManager.addAdmin(admin);
            User user1 = new User("Radu", "0000");
            userManager.addUser(user1);
            User user2 = new User("Andrei", "1111");
            userManager.addUser(user2);
            User user3 = new User("Bogdan", "2222");
            userManager.addUser(user3);
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            string username = Convert.ToString(tbxUsername.Text);
            string password = Convert.ToString(tbxPassword.Text);

            
            if (UserManager.CheckUser(username, password) == true)
            {
                User currentUser = userManager.getUser(username, password);
                STUDENT studentForm = new STUDENT(userManager, currentUser);
                studentForm.Show();
                Hide();
                
            }
            else if (UserManager.CheckUserAdmin(username, password) == true)
            {
                MessageBox.Show("You are logged in as admin");
            }
            else
                MessageBox.Show("Incorrect password or username");


        }
    }
}
