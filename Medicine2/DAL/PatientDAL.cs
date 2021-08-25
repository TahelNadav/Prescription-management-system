using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PatientDAL
    {
        public void AddPatient(Patient patient)
        {
            using (var ctx = new MedicineContext())
            {
                Patient p = ctx.Patients.Find(patient.Id);
                if (p != null)
                    throw new Exception("פציינט זה כבר קיים במערכת");
                ctx.Patients.Add(patient);
                ctx.SaveChanges();

            }
        }

        public void UpdatePatient(Patient patient)
        {
            using (var ctx = new MedicineContext())
            {
                Patient p = ctx.Patients.Find(patient.Id);
                if (p == null)
                    throw new Exception("לא נמצא פציינט במערכת");
                ctx.Patients.Remove(p);
                ctx.Patients.Add(patient);
                ctx.SaveChanges();


            }
        }

        public Patient GetPatient(int id)
        {
            using (var ctx = new MedicineContext())
            {
                Patient p = ctx.Patients.Find(id);
                if (p == null)
                    throw new Exception("לא נמצא פציינט במערכת");
                return p;

            }
        }

        public List<Patient> GetAllPatients()
        {
            using (var ctx = new MedicineContext())
            {
                List<Patient> patients = new List<Patient>();
                patients = ctx.Patients.ToList();
                return patients;

            }
        }

        public List<Prescription> GetPatientPrescription(int patientId)
        {
            using (var ctx = new MedicineContext())
            {
                Patient p = ctx.Patients.Find(patientId);
                if (p == null)
                    throw new Exception("לא נמצא פציינט במערכת");
                List<Prescription> prescriptions = ctx.Database.SqlQuery<Prescription>(@"Select * FROM Prescriptions 
                    WHERE PatientId=@patientId", new SqlParameter("@patientId", patientId)).ToList();
                return prescriptions;
            }
        }


        public List<string> GetPatientDrugs(int patientId)
        {
            List<string> DrugList = new List<string>();
            using (var ctx = new MedicineContext())
            {
                Patient p = ctx.Patients.Find(patientId);
                if (p == null)
                    throw new Exception("לא נמצא פציינט במערכת");

                DrugList = ctx.Database.SqlQuery<string>(@"SELECT DrugNDC FROM Prescriptions
                    WHERE PatientId= @patientId AND EndDate >= @Today", new SqlParameter("@patientId", patientId), new SqlParameter("@Today", DateTime.Today)).ToList();
            }

            return DrugList;
        }
    }
}
