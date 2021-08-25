using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicineDBInitializer : DropCreateDatabaseIfModelChanges<MedicineContext>
    {
        protected override void Seed(MedicineContext context)
        {
            IList<Month> months = new List<Month>
                {
                    new Month() { MonthNum = 1 },
                    new Month() { MonthNum = 2 },
                    new Month() { MonthNum = 3 },
                    new Month() { MonthNum = 4 },
                    new Month() { MonthNum = 5 },
                    new Month() { MonthNum = 6 },
                    new Month() { MonthNum = 7 },
                    new Month() { MonthNum = 8 },
                    new Month() { MonthNum = 9 },
                    new Month() { MonthNum = 10 },
                    new Month() { MonthNum = 11 },
                    new Month() { MonthNum = 12 }
                };
            context.Months.AddRange(months);
            base.Seed(context);
        }
    }
}
