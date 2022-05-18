using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class UserManager
    {
        static public List<User> users = new List<User>();
        static public List<Admin> admins = new List<Admin>();
        private User currentStudent;

        //methods

        public void createUser(string username, string password)
        {
            User user = new User(username, password);
        }

        public void createAdmin(string username, string password)
        {
            Admin admin = new Admin(username, password);
        }

        public User getUser(string username, string password)
        {
            User foundUser = new User(username, password);
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return foundUser;
                } 
            }

            return null;
        }
        public User getCurrentStudent()
        {
            return this.currentStudent;
        }


        public void addAdmin(Admin admin)
        {
            admins.Add(admin);
        }

        public void addUser(User user)
        {
            users.Add(user);
        }

        public void removeUser(User user)
        {
            users.Remove(user);
        }

        public void modifyUser(User user, string newUsername, string newPassword)
        {
            user.Username = newUsername;
            user.Password = newPassword;
        }

        public string displayUser(User user)
        {
            string s = user.Username + " " + user.Password + " ";
            return s;
        }

        public static bool CheckUser(string username, string password)
        {
            if (users.Count != 0)
            {
                foreach (User user in users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool CheckUserAdmin(string username, string password)
        {
            if (users.Count != 0)
            {
                foreach (Admin admin in admins)
                {
                    if (admin.Username == username && admin.Password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
