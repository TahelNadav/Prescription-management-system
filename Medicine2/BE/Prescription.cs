using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DrugNDC { get; set; }

        [DisplayName("תאריך הנפקה")]
        public DateTime StartDate { get; set; }

        [DisplayName("תאריך תפוגה")]
        public DateTime EndDate { get; set; }

    }
}
