using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PrescriptionBL
    {

        public List<string> AddPres(Prescription pres)
        {
            DoctorBL doctorBL = new DoctorBL();
            if (doctorBL.CheckDoctorLicense(pres.DoctorId) == false)
                throw new Exception();

            PatientBL patientBL = new PatientBL();
            List<string> Drugs = patientBL.GetPatientDrugs(pres.PatientId);

            bool b = false;
            DrugConflictBL drugConf = new DrugConflictBL();
            List<string> drugsconflict = drugConf.DrugConflictcheck(pres.DrugNDC, Drugs, ref b);
            if (b == false)
            {
                PrescriptionDAL dal = new PrescriptionDAL();
                dal.AddPres(pres);
            }
            return drugsconflict;

        }

    }
}
