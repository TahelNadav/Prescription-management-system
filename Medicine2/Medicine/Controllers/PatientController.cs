using BE;
using BL;
using Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicine.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string idp)
        {
            try
            {
                PatientModel patientModel = new PatientModel() { PatientId = int.Parse(idp)};
                Patient p = patientModel.GetPatient(int.Parse(idp));
                return View("IndexPo", patientModel);
            }
            catch (Exception e)
            {
                Response.Write("<script language=javascript>alert('" + e.Message + "');</script>");
                return View("Index");
            }

        }
         
        public ActionResult Prescription(int id)
        {
            try
            {
                PatientBL BL = new PatientBL();
                List<Prescription> l = BL.GetPatientPrescription(id);
                return View(l);
            }
            catch (Exception e)
            {
                Response.Write("<script language=javascript>alert('" + e.Message + "');</script>");
                return View("IndexPo");
            }

        }

    }
}
