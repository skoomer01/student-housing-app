using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    [Serializable]
    public class User
    {
        //instance variables
        private string username;
        private string password;

        //constructor
        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }


        //property
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
