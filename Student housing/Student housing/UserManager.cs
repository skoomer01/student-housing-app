using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    [Serializable]
    public class UserManager
    {
        private  List<User> users = new List<User>();
        private  List<Admin> admins = new List<Admin>();
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

        public User getUser(string username)
        {
            User foundUser = new User(username,"");
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return foundUser;
                }
            }

            return null;
        }

        public User getUserByIndex(int index)
        {
            User foundUser;
            for(int i = 0; i<= users.Count; i++)
            {
                if (index == i)
                {
                    foundUser = users[i];
                    return foundUser;
                }
            }
            return null;
        }

        public User[] GetUsers()
        {
            return this.users.ToArray();
        }

        public Admin[] GetAdmins()
        {
            return this.admins.ToArray();
        }

        public Admin getAdmin(string username, string password)
        {
            Admin foundAdmin = new Admin(username, password);
            foreach (Admin admin in admins)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    return foundAdmin;
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

        public bool CheckUser(string username, string password)
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


        public bool CheckUserAdmin(string username, string password)
        {
            if (admins.Count != 0)
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
