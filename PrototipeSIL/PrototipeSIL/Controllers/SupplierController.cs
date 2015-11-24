using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrototipeSIL.DAL;

namespace PrototipeSIL.Controllers
{
    public class SupplierController : Controller
    {
        SILDBEntities db = new SILDBEntities();

        // GET: Supplier
        public ActionResult Index()
        {
            List<Supplier> supplier = db.Supplier.ToList();

            return View(supplier);
        }
    }
}