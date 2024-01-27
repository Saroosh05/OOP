using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class User
    {
        public string name;
        public string password;
        public string role;

        public User(string nm, string pass, string rl) 
        {
            name = nm;
            password = pass;
            role = rl;
        }
    }
}
