using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class Complaint
    {
        public string compName;
        public string email;
        public string contact;
        public string address;
        public string city;
        public string province;
        public string date;
        public string detail;
        public string subject;
        public string code;
        public string urgencyLevel;

        public Complaint(string compNm, string eml, string phn, string add, string cty, string pro, string dt, string det, string sub, string cd, string ul) 
        {
            compName = compNm;
            email = eml;
            contact = phn;
            address = add;
            city = cty;
            province = pro;
            date = dt;
            detail = det;
            subject = sub;
            code = cd;
            urgencyLevel = ul;
        }

        public Complaint()
        {
        }

    }
}
