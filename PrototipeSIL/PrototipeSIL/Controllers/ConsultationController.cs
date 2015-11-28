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

        [HttpPost]
        public ActionResult ShowResultConsultationYes()
        {
            return PartialView("_ShowResultConsultationYes");
        }

        [HttpPost]
        public ActionResult ShowResultConsultationNo()
        {
            return PartialView("_ShowResultConsultationNo");
        }

        [HttpPost]
        public ActionResult ShowResultDSS(String option)
        {
            RekomendasiSuplaiModel model = new RekomendasiSuplaiModel();
            if (option.Equals("EOQ"))
            {
                return PartialView("_ShowResultEOQ", model);
            }
            else
            {
                return PartialView("_ShowResultSMH", model);
            }
        }
    }
}