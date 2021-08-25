using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DrugConflictHelper
{
 public  class FullInteractionType
    {
        public string comment { get; set; }
        public List<MinConcept> minConcept { get; set; }
        public List<InteractionPair> interactionPair { get; set; }
    }
}
