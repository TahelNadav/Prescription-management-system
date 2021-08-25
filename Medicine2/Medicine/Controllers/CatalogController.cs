using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE;
using Medicine.Models;

namespace Medicine.Controllers
{
    public class CatalogController : Controller
    {
        // GET: DrugCatalog
        public ActionResult Index()
        {
            DrugCatalogModel model = new DrugCatalogModel();

            return View(model.GetDrugs());
        }

        
    }
}