using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class NormalExpenses
    {
        public static string AddTenants(int index)
        {
            if (index >= UserManager.users.Count)
            {
                index = index % UserManager.users.Count;
                //if (index == 0)
                //{
                //    index = 1;
                //}
            }
            return UserManager.users[index].Username;
        }
    }
}
