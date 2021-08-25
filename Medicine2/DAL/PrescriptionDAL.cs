using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PrescriptionDAL
    {
        public void AddPres(Prescription pres)
        {
            using (var ctx = new MedicineContext())
            {
                ctx.Prescriptions.Add(pres);
                ctx.SaveChanges();

            }
        }
    }

}
