using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class Police_officer
    {
        public string name;
        public string code;
        public string designation;

        public Police_officer(string nm, string cd, string dsgn) 
        {
            name = nm;
            code = cd;
            designation = dsgn;
        }
    }
}
