using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace account
{
    public class User : Account
    {
       public string birthday { get; set; }
        public User() { }
        public User(string _username, string _password,string _birthday="")
        {
            this.username = _username;
            this.password = _password;
            this.birthday = _birthday;
            this.id = UserList.getMaxId() + 1;
        }
    }
}
