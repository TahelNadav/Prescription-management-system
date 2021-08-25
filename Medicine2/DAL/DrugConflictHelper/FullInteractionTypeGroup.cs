using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DrugConflictHelper
{
   public class FullInteractionTypeGroup
    {
        public string sourceDisclaimer { get; set; }
        public string sourceName { get; set; }
        public FullInteractionType fullInteractionType { get; set; }
    }
}
