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
        private string firstName;
        private string lastName;

        //constructor
        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
            this.firstName = "";
            this.lastName = "";
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

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
    }
}
