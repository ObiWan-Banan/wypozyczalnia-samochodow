using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace account
{
    public static class UserList
    {
        public static List<Account> userList;
        
        static UserList()
        {
            userList = new List<Account>();
            string filePath = "users.txt";

            List<string> fileLines = File.ReadAllLines(filePath).ToList();

            foreach(var line in fileLines)
            {
                string[] userData = line.Split(';');

                User temp = new User();

                temp.id = Int32.Parse(userData[0]);
                temp.username = userData[1];
                temp.password = userData[2];
                temp.birthday = userData[3];

                userList.Add(temp);
            }
        }

        public static int getMaxId()
        {
            int max = 0;
            foreach (var user in userList)
            {
                if (user.id > max) max = user.id;
            }
            return max;
        }
        public static bool isOnTheList(string _username, string _password)
        {
            User temp = new User(_username, _password);

            if (userList.Contains(temp)) return true;

            return false;
        }
        public static bool isUsernameTaken(string _username)
        {
            foreach(var user in userList )
            {
                if (user.username == _username) return true;
            }
            return false;
        }
        public static void initializeUserList() { }

        public static string getUsername(int userId)
        {
            foreach(var user in userList)
            {
                if(user.id==userId)
                {
                    return user.username;
                }
            }
            return null;
        }

        public static int GetId(string _username, string _password)
        {
            foreach(var user in userList)
            {
                if (user.username.Equals(_username) && user.password.Equals(_password)) return user.id;
            }
            return 0;
        }

        public static void deleteUserFromList(int userId)
        {
            foreach(var user in userList)
            {
                if(user.id==userId)
                {
                    userList.Remove(user);
                    return;
                }
            }
        }
    }
}
