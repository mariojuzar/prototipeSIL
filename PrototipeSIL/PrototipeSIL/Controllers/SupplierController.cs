using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrototipeSIL.DAL;
using PrototipeSIL.Models;

namespace PrototipeSIL.Controllers
{
    [MyAuthorize]
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