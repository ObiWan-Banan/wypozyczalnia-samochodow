using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace account
{
    public class Admin : Account
    {
        public Admin() { }
         public Admin(string _username, string _password)
        {
            this.username = _username;
            this.password = _password;
            this.id = (AdminList.adminList.Count()) + 1;
        }
    }
}
