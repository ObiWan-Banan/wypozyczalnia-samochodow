using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace account
{
    public abstract class  Account : IEquatable<Account>
    {
        public string username { get; set; }
        public string password { get; set; }
        public int id { get; set; }

        public bool Equals(Account a)
        {
            if (a == null) return false;
            if (a.username == username && a.password == password) return true;

            return false;
        }
       
    }
}
