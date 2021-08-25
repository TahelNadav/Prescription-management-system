using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DoctorBL
    {
        public void AddDoctor(Doctor doc)
        {
            DoctorDAL dal = new DoctorDAL();
            dal.AddDoctor(doc);
        }
        public void UpdateDoctor(Doctor doc)
        {
            DoctorDAL dal = new DoctorDAL();
            dal.UpdateDoctor(doc);
        }
        public Doctor GetDoctor(int id)
        {
            DoctorDAL dal = new DoctorDAL();
            return dal.GetDoctor(id);
        }
        public List<Doctor> GetAllDoctors()
        {
            DoctorDAL dal = new DoctorDAL();
            return dal.GetAllDoctors();
        }
        public bool CheckDoctorLicense(int docId)
        {
            //Doctor doc = GetDoctor(docId);
            //DoctorLicense doctorLicense = new DoctorLicense();
            //return doctorLicense.GetDoctorApprovell();
            return true;

        }
    }
}
