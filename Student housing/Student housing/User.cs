using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class User
    {
        //aributes
        private String username;
        private String password;

        //constructor
        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }


        //property
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
