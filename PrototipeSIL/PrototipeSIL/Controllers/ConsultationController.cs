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

        [HttpPost]
        public ActionResult Pertanyaan2()
        {
            return PartialView("_Pertanyaan2");
        }

        [HttpPost]
        public ActionResult Pertanyaan3()
        {
            return PartialView("_Pertanyaan3");
        }

        [HttpPost]
        public ActionResult Pertanyaan4()
        {
            return PartialView("_Pertanyaan4");
        }
    }
}