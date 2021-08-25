using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoctorDAL
    {
        public void AddDoctor(Doctor doc)
        {
            using (var ctx = new MedicineContext())
            {
                Doctor d = ctx.Doctors.Find(doc.Id);
                if (d != null)
                    throw new Exception("רופא זה כבר קיים במערכת");
                ctx.Doctors.Add(doc);
                ctx.SaveChanges();
            }
        }

        public void UpdateDoctor(Doctor doc)
        {
            using (var ctx = new MedicineContext())
            {
                Doctor doctor = ctx.Doctors.Find(doc.Id);
                if (doc == null)
                    throw new Exception("לא נמצא הרופא במערכת");
                ctx.Doctors.Remove(doctor);
                ctx.Doctors.Add(doc);
                ctx.SaveChanges();


            }
        }

        public Doctor GetDoctor(int id)
        {
            using (var ctx = new MedicineContext())
            {
                Doctor doc = ctx.Doctors.Find(id);
                if (doc == null)
                    throw new Exception("לא נמצא הרופא במערכת");
                return doc;

            }
        }

        public List<Doctor> GetAllDoctors()
        {
            using (var ctx = new MedicineContext())
            {
                List<Doctor> doctors = new List<Doctor>();
                doctors = ctx.Doctors.ToList();
                return doctors;

            }
        }
    }
}
