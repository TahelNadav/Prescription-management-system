using BE;
using Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Medicine.Controllers
{
    public class DoctorController : Controller
    {
        static private Doctor CurrentDoctor = new Doctor();
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection,string DocId, string PassName)
        {
            try
            {
                Passwordmodel passwordmodel = new Passwordmodel();
                if (passwordmodel.CheckDoctorPassword(int.Parse(DocId), PassName))//אם הסיסמא טובה
                {
                    DoctorModel doctorModel = new DoctorModel();
                    CurrentDoctor = doctorModel.GetDoctor(int.Parse(DocId));
                    return View("IndexPost");

                }

                else
                    return RedirectToAction("Index", "Doctor");
            }
            catch (Exception e)
            {
                Response.Write("<script language=javascript>alert('" + e.Message + "');</script>");
                return View("Index");
            }
        }

        public ActionResult IndexPost()
        {
            return View("IndexPost");
        }
        public ActionResult Prescription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Prescription(FormCollection collection,string selectdrug,string idpatient)
        {
            try
            {
                DrugCatalogModel drugmodel = new DrugCatalogModel();
                PatientModel pmodel = new PatientModel();
                DoctorModel doctormodel = new DoctorModel();
                Doctor d = CurrentDoctor;
                Drug h = drugmodel.GetDrugByName(collection["selectdrug"]);
                Patient p = pmodel.GetPatient(int.Parse(collection["idpatient"]));
                Prescription pres = new Prescription() { DoctorId = d.Id, StartDate = DateTime.Parse(collection["StartDate"]), EndDate = DateTime.Parse(collection["EndDate"]), PatientId = p.Id, DrugNDC = h.NDC };
                List<string> j = doctormodel.AddPrescription(pres);
                return View("clashDrug", j);
            }
            catch (Exception e)
            {
                Response.Write("<script language=javascript>alert('"+e.Message+"');</script>");
                return View("Prescription");
            }
        }
        public ActionResult clashDrug(List<string> l)
        {
            if (l != null)
                return View(l);
            else
                return View("IndexPost");

        }


    }
}