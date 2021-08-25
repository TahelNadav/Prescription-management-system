using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PatientBL
    {
        public void AddPatient(Patient patient)
        {
            PatientDAL dal = new PatientDAL();
            dal.AddPatient(patient);
        }
        public void UpdatePatient(Patient patient)
        {
            PatientDAL dal = new PatientDAL();
            dal.UpdatePatient(patient);
        }
        public Patient GetPatient(int id)
        {
            PatientDAL dal = new PatientDAL();
            return dal.GetPatient(id);
        }
        public List<Patient> GetAllPatients()
        {
            PatientDAL dal = new PatientDAL();
            return dal.GetAllPatients();
        }
        public List<string> GetPatientDrugs(int patientId)
        {
            PatientDAL dal = new PatientDAL();
            return dal.GetPatientDrugs(patientId);
        }
        public List<Prescription> GetPatientPrescription(int patientId)
        {
            PatientDAL dal = new PatientDAL();
            return dal.GetPatientPrescription(patientId);
        }
    }
}
