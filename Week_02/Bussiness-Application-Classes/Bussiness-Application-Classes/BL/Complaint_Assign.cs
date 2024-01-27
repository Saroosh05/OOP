using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class Complaint_Assign
    {
        public string assignedCompCodes;  //code of complaints being assigned
        public string assignedOffCode;   //codes of police officers who are assigned the complaints

        public Complaint_Assign(string compCode, string offCode) 
        {
            assignedCompCodes = compCode;
            assignedOffCode = offCode;
        }
    }
}
