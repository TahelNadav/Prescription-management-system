using BE;
using DAL;
using BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL
{
    public class DrugBL
    {
        public void AddDrug(Drug drug)
        {
            if (drug.ImagePath != null && CheckImage(drug.ImagePath) == false)
                throw new Exception("unapproved image");
            DrugDAL dal = new DrugDAL();
            dal.AddDrug(drug);
        }
        public void RemoveDrug(string drugNDC)
        {
            DrugDAL dal = new DrugDAL();
            dal.RemoveDrug(drugNDC);
        }
        public void UpdateDrugImage(string drugNDC, string imagePath, HttpPostedFileBase drivefile)
        {
            if (CheckImage(imagePath) == false)
                throw new Exception("unapproved image");
            DrugDAL dal = new DrugDAL();
           string g= imagePath.Substring(18);
            dal.UpdateDrugImage(drugNDC, imagePath);
            CheckDrive checkDrive = new CheckDrive();
            checkDrive.del(g);
            checkDrive.Uplaod(drivefile);
           
        }
        public Drug GetDrug(string drugNDC)
        {
            DrugDAL dal = new DrugDAL();
            return dal.GetDrug(drugNDC);
        }
        public Drug GetDrugByName(string drugName)
        {
            DrugDAL dal = new DrugDAL();
            return dal.GetDrugByName(drugName);
        }
        public List<Drug> GetAllDrugs()
        {
            DrugDAL dal = new DrugDAL();
            return dal.GetAllDrugs();
        }
        public bool CheckImage(string imagePath)
        {
            ImageTagsLogic Immaga = new ImageTagsLogic();
            return Immaga.GetTags(imagePath);

        }
        public int[] GetDrugUse(string drugNDC, int year)
        {
            DrugDAL dal = new DrugDAL();
            return dal.GetDrugUse(drugNDC, year);
        }
    }
}
