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
    public class StockController : Controller
    {
        SILDBEntities db = new SILDBEntities();

        // GET: Stock
        public ActionResult Index()
        {
            List<Stock> stok = db.Stock.ToList();

            return View(stok);
        }
    }
}