using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine.Models
{
    public class DoctorModel
    {

        
        public DoctorModel()
        {
            DoctorBL BL = new DoctorBL();
            List<Doctor> doctors = BL.GetAllDoctors();
           
        }

        public Doctor GetDoctor(int id)
        {
             DoctorBL BL = new DoctorBL();
            return BL.GetDoctor(id);
        }

        public List<Doctor> GetDoctors()
        {
            DoctorBL BL = new DoctorBL();
            return BL.GetAllDoctors();
        }


        public void EditDoctor( Doctor doc)
        {
            DoctorBL BL = new DoctorBL();
            BL.UpdateDoctor(doc);
        }
        public void AddDoctor(Doctor d)
        {
            DoctorBL BL = new DoctorBL();
            BL.AddDoctor(d);
        }
        public List<string> AddPrescription(Prescription p)
        {
            PrescriptionBL BL = new PrescriptionBL();
            List<string> l= BL.AddPres(p);
            return l;
        }
       

    }
}