using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    [Serializable]
    public class Admin
    {
        //atributes
        private string username;
        private string password;

        //constructor
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public Admin(string username = "Admin", string password = "1234", bool isLoggedIn = false)
        {

        }
        //properties
        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
