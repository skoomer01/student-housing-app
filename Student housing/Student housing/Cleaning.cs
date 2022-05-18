using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Cleaning
    {
        //methods
        public static string AddUsers(int index)
        {
            if (index >= UserManager.users.Count)
            {
                index = index % UserManager.users.Count;
            }
            return UserManager.users[index].Username;
        }
    }
}
