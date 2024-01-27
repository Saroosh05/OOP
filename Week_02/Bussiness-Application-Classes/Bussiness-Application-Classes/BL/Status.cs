using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class Status
    {
        public string status; 
        public string codeStatus;

        public Status(string sts , string code) 
        {
            status = sts;
            codeStatus = code;
        }
    }
}
