using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Doctor: Person
    {
        [DisplayName("מספר רישיון רופא")]
        public string LicenseNumber { get; set; }

    }
}
