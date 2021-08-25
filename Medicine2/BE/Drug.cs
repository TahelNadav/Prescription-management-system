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
    public class Drug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NDC { get; set; }

        [DisplayName("שם תרופה")]
        public string Name { get; set; }
        [DisplayName("שם גנרי")]
        public string GenericName { get; set; }
        [DisplayName("יצרן")]
        public string ManufacturerName { get; set; }
        [DisplayName("חומר פעיל")]
        public string ActiveIngredientUnit { get; set; }
        [DisplayName("תמונה")]
        public string ImagePath { get; set; }
        public  bool Active { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }




    }
}
