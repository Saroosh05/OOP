using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class Complainant
    {
        public string complainant;      // user name of complainants
        public string password;        // password of complainants
        public int complaints;        // number of filed complaints by the complainant

        public Complainant(string user, string pass, string comp)
        {
            string complainant = user;
            string password = pass;
            string complaints = comp;
        }

        public Complainant(string user, string pass)
        {
            complainant = user;
            password = pass;
        }

        
    }
}
