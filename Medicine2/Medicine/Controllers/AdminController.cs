using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BE;
using BL;
using Medicine.Models;

namespace Medicine.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult LogIn(FormCollection collection)
        {
            try
            {
                Passwordmodel passwordmodel = new Passwordmodel();
                passwordmodel.CheckAdminPassword(int.Parse(collection["IdAdmin"]), collection["PassName"]);
                if (passwordmodel.CheckAdminPassword(int.Parse(collection["IdAdmin"]), collection["PassName"]))
                {
                   
                    return RedirectToAction("AdminOps");
                }
            }
            catch(Exception e)
            {
                 
                Response.Write("<script language=javascript>alert('"+e.Message+"');</script>");
                return View("index");
            }
            return RedirectToAction("Error");
        }
        public ActionResult AdminOps()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        } 
    
        public ActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPatient(FormCollection collection)
        {
            try
            {
                Patient p = new Patient() { FirstName = collection["FirstName"], LastName = collection["LastName"], Id = int.Parse(collection["Id"]), Address = collection["Address"], dateOfBirth = DateTime.Parse(collection["dateOfBirth"]) };
                PatientModel model = new PatientModel();
                model.AddPatient(p);
                return RedirectToAction("AdminOps");
            }
            catch (Exception e)
            {
                Response.Write("<script language=javascript>alert('"+e.Message+"');</script>");
                return View("AddPatient");
            }
        }

        public ActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(FormCollection collection)
        {
            try
            {
                Doctor d = new Doctor() { FirstName = collection["FirstName"], LastName = collection["LastName"], Id = int.Parse(collection["Id"]), LicenseNumber = collection["LicenseNumber"], Address = collection["Address"], dateOfBirth = DateTime.Parse(collection["dateOfBirth"]) };
                DoctorModel model = new DoctorModel();
                model.AddDoctor(d);
                Passwordmodel passwordmodel = new Passwordmodel();
                UserPassword user = new UserPassword() { Id = int.Parse(collection["Id"]), Password = collection["DoctorPassword"] };
                passwordmodel.AddPassword(user);
            }
            catch (Exception e)
            {

                Response.Write("<script language=javascript>alert('"+e.Message+"');</script>");
                return View("AddDoctor");
            }
            return RedirectToAction("AdminOps");
        }
        public ActionResult viewDoctors()
        {
            DoctorModel model = new DoctorModel();
            return View(model.GetDoctors());
        }
        public ActionResult EditDoctor(int id)
        {
            DoctorModel model = new DoctorModel();
            Doctor d = model.GetDoctor(id);
            return View(d);
        }
        [HttpPost]
        public ActionResult EditDoctor(int id, FormCollection collection)
        {
            DoctorModel model = new DoctorModel();

            Doctor d = new Doctor() { FirstName = collection["FirstName"], LastName = collection["LastName"], LicenseNumber = collection["LicenseNumber"], Id = id, Address = collection["Address"], dateOfBirth = DateTime.Parse(collection["dateOfBirth"]) };
            model.EditDoctor( d);
            return RedirectToAction("viewDoctors");
        }

        public ActionResult viewPatients()
        {
            PatientModel model = new PatientModel();

            return View(model.GetPatients());
        }
        public ActionResult EditPatient(int id)
        {
            PatientModel model = new PatientModel();
            Patient p = model.GetPatient(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult EditPatient(int id, FormCollection collection)
        {
            PatientModel model = new PatientModel();
            Patient p = new Patient() { FirstName = collection["FirstName"], LastName = collection["LastName"], Id = id, Address = collection["Address"], dateOfBirth = DateTime.Parse(collection["dateOfBirth"]) };
            model.EditPatient(p);
            return RedirectToAction("viewPatients");
        }

        public ActionResult DrugData(Drug d)
        {
            DrugCatalogModel model = new DrugCatalogModel();
            DrugDataModel dataModel = new DrugDataModel() { DrugName = d.Name, Values = model.GetDrugUse(d.NDC) };
            return View(dataModel);
        }

        public ActionResult updateCatalog()
        {
            DrugCatalogModel catalogModel = new DrugCatalogModel();
            List<Drug> ld = catalogModel.GetDrugs();   
             return View(ld);
        }

        public ActionResult UpdateImage(String NDC)
        {
            return View(model:NDC);


        }
        [HttpPost]
        public ActionResult UpdateImage(FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                //  string filefullpath = Path.GetFullPath(file.FileName);
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                string path = @"\GoogleDriveFiles\" + fileName;
                DrugCatalogModel catalogModel = new DrugCatalogModel();
                catalogModel.UpdateImage(collection["NDC"], file, path);
            }
            catch (Exception e)
            {

                Response.Write("<script language=javascript>alert('"+e.Message+"');</script>");
                return View("UpdateImage");
            }
            Response.Write(@"<script language='javascript'>alert('התמונה עודכנה בהצלחה');</script>");
            return View("AdminOps");

        }
        public ActionResult DeleteDrug(string NDC)
        {
            DrugCatalogModel model = new DrugCatalogModel();
            model.deleteDrug(NDC);
            return RedirectToAction("updateCatalog");
        }


        public ActionResult getDrugFromAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getDrugFromAdmin(FormCollection collection)
        {
            DrugCatalogModel model = new DrugCatalogModel();
            Drug d = model.GetDrugByName(collection["drug"]);
            return RedirectToAction("DrugData", d);
        }
        public ActionResult CreateDrug()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDrug(FormCollection collection)
        {
            try
            {
                DrugCatalogModel model = new DrugCatalogModel();  
                var image = @"\GoogleDriveFiles\" + collection["Img"];
                Drug dr = new Drug() { Name = collection["Name"], ManufacturerName = collection["ManufacturerName"], ActiveIngredientUnit = collection["ActiveIngredientUnit"], GenericName = collection["GenericName"], ImagePath = image, NDC = collection["NDC"] };
                model.AddDrug(dr); 
                return RedirectToAction("updateCatalog");

            }
            catch (Exception e)
            {
                Response.Write("<script language=javascript>alert('"+e.Message +"');</script>");
                return View("CreateDrug");
            }
            
        }

        public ActionResult ExeptionHandler(string s)
        {
            ExeptionHandler model = new ExeptionHandler() { Message = s };
            return View(model);
        }
    }
}