using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace account
{
    public static class AdminList
    {
         public static List<Account> adminList;

        static AdminList()
        {
            adminList = new List<Account>();
            string filePath = "admins.txt";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();

            foreach(var line in fileLines )
            {
                string[] adminData = line.Split(';');
                Admin temp = new Admin();

                temp.id = Int32.Parse(adminData[0]);
                temp.username = adminData[1];
                temp.password = adminData[2];

                adminList.Add(temp);
            }
        }
        
        public static bool isOnTheList(string _username,string _password)
        {
            Admin temp = new Admin(_username, _password);

            if (adminList.Contains(temp)) return true;
           
            return false;
        }
        public static void initializeAdminList() { }
    }
}
