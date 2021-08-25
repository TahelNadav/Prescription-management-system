using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicineContext : DbContext
    {
        public MedicineContext() : base()
        {
            Database.SetInitializer<MedicineContext>(new MedicineDBInitializer());
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<UserPassword> UsersPasswords { get; set; }
        public DbSet<Month> Months { get; set; }

       

    }
}
