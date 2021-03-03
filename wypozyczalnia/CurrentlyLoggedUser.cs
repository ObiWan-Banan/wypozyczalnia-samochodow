using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cars;

namespace account
{
    public static  class CurrentlyLoggedUser
    {
        public static int currentlyLoggedUserId { get; set; }

        static CurrentlyLoggedUser() { }
        
        public static void InitilizeCurrentyLoggedUser(int id)
        {
            currentlyLoggedUserId = id;
        }
        public static string GetSpecificUserUsername()
        {
            foreach (var user in UserList.userList)
            {
                if (currentlyLoggedUserId == user.id)
                {
                    return user.username;
                }
            }
            return null;
        }
    }
}