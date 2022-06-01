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

        private void button1_Click(object sender, EventArgs e)
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
    }
}
