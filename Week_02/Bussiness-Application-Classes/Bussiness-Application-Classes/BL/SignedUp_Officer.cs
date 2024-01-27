using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Application_Classes.BL
{
    internal class SignedUp_Officer
    {
        public string signedUpOff;
        public string signedUpOffPass;
        public string signedOffCodes;

        public SignedUp_Officer(string officer, string pass, string code) 
        {
            signedUpOff = officer;
            signedUpOffPass = pass;
            signedOffCodes = code;
        }
    }
}
