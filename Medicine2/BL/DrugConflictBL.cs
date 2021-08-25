using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class DrugConflictBL
    {
        public List<string> DrugConflictcheck(string drugNDC,List<string> DrugsListNDC,ref bool ans)
        {
           
            DrugConflict dal = new DrugConflict();

            //בדאל עם התרופה להוספה  DrugConflictcheck לעבור על כלאחד ולשלוח לפונקצית   idpatient לבקש מהדאל את רשימת תרופותיו של 
            List<string> re = dal.DrugConflictchecklist(drugNDC, DrugsListNDC);
            List<string> result = new List<string>();
            foreach (var item in re)
            {
                if (item.Contains("severity:high"))
                {
                    
                    result.Add("אין אישור למרשם זה-תרופות חופפות");
                    ans = true;
                }
            }
            result.Add("המרשם עודכן בהצלחה");

            return result;
        }
    }
}
