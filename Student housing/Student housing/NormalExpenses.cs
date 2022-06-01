using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class NormalExpenses
    {
        UserManager userManager;

        public NormalExpenses(UserManager userManager)
        {
            this.userManager = userManager;
        }
        public string AddTenants(int index)
        {
            if (index >= userManager.GetUsers().Length)
            {
                index = index % userManager.GetUsers().Length;
                //if (index == 0)
                //{
                //    index = 1;
                //}
            }
            return userManager.getUserByIndex(index).Username;
        }
    }
}
