using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Cleaning
    {
        private UserManager userManager;

        public Cleaning(UserManager userManager)
        {
            this.userManager = userManager;
        }
        //methods
        public string AddUsers(int index)
        {
            if (index >= userManager.GetUsers().Length)
            {
                index = index % userManager.GetUsers().Length;
            }
            return userManager.getUserByIndex(index).Username;
        }
    }
}
