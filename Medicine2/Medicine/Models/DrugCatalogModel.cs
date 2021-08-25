using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine.Models
{
    public class DrugCatalogModel
    {

        public List<Drug> GetDrugs()
        {
            DrugBL bl = new DrugBL();
            return bl.GetAllDrugs();
           
        }
        public void UpdateImage(string NDC, HttpPostedFileBase drivefile, string path)
        {
            DrugBL bl = new DrugBL();
            bl.UpdateDrugImage(NDC, path, drivefile);

        }

        public Drug GetDrugByName(string name)
        {
            DrugBL bl = new DrugBL();
            return bl.GetDrugByName(name);
        }
        public Drug GetDrug(string NDC)
        {
            DrugBL bl = new DrugBL();
            return bl.GetDrug(NDC);
        }

        public void deleteDrug(string NDC)
        {
            DrugBL bl = new DrugBL();
            bl.RemoveDrug(NDC);
        }

        public int[] GetDrugUse(string drugNDC)
        {
            DrugBL bL = new DrugBL();
            int[] a = bL.GetDrugUse(drugNDC, 2020);
            return a;


        }

        internal void AddDrug(Drug dr)
        {
            DrugBL bl = new DrugBL();
            bl.AddDrug(dr);
        }
    }
}