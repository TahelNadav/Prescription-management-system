using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DoctorLicense
    {
        public string GetDoctorApproval1(string mname, string license)
        {
            string re= "";
            ScrapHealthData dal = new ScrapHealthData();
            dal. GetDoctorApproval(mname, license);
            return re;
        }
    }
}
