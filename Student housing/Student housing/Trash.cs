using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    
    public class Trash
    {
        UserManager userManager;
        private int index = 0;
        private int turn = 0;

        public Trash(UserManager userManager)
        {
            this.userManager = userManager;
        }

        //methods

        public string GetUser()
        {
            turn++;
            if (turn == 1)
            {
                turn = 0;
                index = (index + 1) % userManager.GetUsers().Length;
            }
            return userManager.getUserByIndex(index).Username;
        }
    }
}
