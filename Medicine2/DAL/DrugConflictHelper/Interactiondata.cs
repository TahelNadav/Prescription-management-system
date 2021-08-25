using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DrugConflictHelper
{
  public  class Interactiondata
    {
        public string nlmDisclaimer { get; set; }
        public UserInput userInput { get; set; }
        public FullInteractionTypeGroup fullInteractionTypeGroup { get; set; }
    }
}
