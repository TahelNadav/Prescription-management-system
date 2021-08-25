using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DrugDAL
    {
        public void AddDrug(Drug drug)
        {
            using (var ctx = new MedicineContext())
            {
                drug.Active = true;
                Drug d = ctx.Drugs.Find(drug.NDC);
                if (d != null)
                {
                    if (d.Active == true)
                        throw new Exception("תרופה זו כבר קיימת במערכת");
                    else
                    {
                        d.Name = drug.Name;d.GenericName = drug.GenericName;
                        d.ManufacturerName = drug.ManufacturerName; 
                        d.ActiveIngredientUnit = drug.ActiveIngredientUnit;d.ImagePath = drug.ImagePath;
                    }
                }
                else
                    ctx.Drugs.Add(drug);

                ctx.SaveChanges();
            }
        }
        public void RemoveDrug(string drugNDC)
        {
            using (var ctx = new MedicineContext())
            {
                Drug drug = ctx.Drugs.Find(drugNDC);
                if (drug == null || drug.Active == false)
                    throw new Exception("לא נמצאה התרופה במערכת");
                drug.Active = false;
                ctx.SaveChanges();
            }
        }

        public Drug GetDrug(string drugNDC)
        {
            using (var ctx = new MedicineContext())
            {
                Drug drug = ctx.Drugs.Find(drugNDC);
                if (drug == null || drug.Active == false)
                    throw new Exception("לא נמצאה התרופה במערכת");
                return drug;

            }
        }
        public Drug GetDrugByName(string drugName)
        {
            using (var ctx = new MedicineContext())
            {
                Drug drug = ctx.Database.SqlQuery<Drug>(@"Select * FROM Drugs 
                    WHERE Name = @drugName AND Active = 'true'", new SqlParameter("@drugName", drugName)).FirstOrDefault();
                if (drug == null)
                    throw new Exception("לא נמצאה התרופה במערכת");
                return drug;

            }
        }

        public List<Drug> GetAllDrugs()
        {
            using (var ctx = new MedicineContext())
            {
                List<Drug> drugs = new List<Drug>();
                drugs = ctx.Database.SqlQuery<Drug>(@"Select * FROM Drugs WHERE Active = 'true'").ToList();
                return drugs;

            }
        }

        public void UpdateDrugImage(string drugNDC, string imagePath)
        {
            using (var ctx = new MedicineContext())
            {
                Drug drug = ctx.Drugs.Find(drugNDC);
                if (drug == null || drug.Active==false)
                    throw new Exception("לא נמצאה התרופה במערכת");
                drug.ImagePath = imagePath;
                ctx.SaveChanges();

            }
        }

        public int[] GetDrugUse(string drugNDC, int year)
        {
            int[] arr = new int[12];
            using (var ctx = new MedicineContext())
            {
                Drug drug = ctx.Drugs.Find(drugNDC);
                if (drug == null || drug.Active == false)
                    throw new Exception("לא נמצאה התרופה במערכת");
                arr = ctx.Database.SqlQuery<int>(@"SELECT CASE WHEN Num IS NULL THEN 0 ELSE Num END
                    FROM Months LEFT JOIN(SELECT MONTH(StartDate) AS MonthNum, COUNT(*) AS Num FROM Prescriptions  
                    WHERE DrugNDC=@drugNDC AND YEAR(StartDate)=@year
                    GROUP BY MONTH(StartDate))Temp  
                    ON Months.MonthNum = Temp.MonthNum",
                    new SqlParameter("@drugNDC", drugNDC), new SqlParameter("@year", year)).ToArray();
            }

            return arr;

        }


    }
}
