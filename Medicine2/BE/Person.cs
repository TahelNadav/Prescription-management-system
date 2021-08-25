using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("מספר זהות")]
        public int Id { get; set; }
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }
        [DisplayName("כתובת")]
        public string Address { get; set; }
        [DisplayName("תאריך לידה")]
        public DateTime dateOfBirth { get; set; }
        [DisplayName("תאריך לידה")]
        public string DateOfBirth { get { return dateOfBirth.ToString("dd/MM/yyyy"); } }
    }
}
