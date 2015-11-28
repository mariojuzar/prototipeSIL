using PrototipeSIL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrototipeSIL.Controllers
{
    [MyAuthorize]
    public class ConsultationController : Controller
    {
        // GET: Consultation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pertanyaan1()
        {
            return PartialView("_Pertanyaan1");
        }
    }
}