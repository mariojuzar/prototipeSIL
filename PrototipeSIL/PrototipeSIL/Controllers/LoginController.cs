using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrototipeSIL.DAL;
using PrototipeSIL.Models;

namespace PrototipeSIL.Controllers
{
    public class LoginController : Controller
    {
        SILDBEntities db = new SILDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            LoginModel model = new LoginModel();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Username,Password")]LoginModel model)
        {
            List<User> user = db.User.ToList();
            bool found = CheckUsername(user, model);
            
            if (found)
            {
                User Us = FindUser(model.Username);

                HttpContext.Session.Add("Name", Us.Name);
                HttpContext.Session.Add("Username", Us.Username);
                HttpContext.Session.Add("Role", Us.Role);
                return RedirectToRoute(new { controller = "Dashboard", action = "Index" });
            }
            return PartialView(model);
        }

        [MyAuthorize]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.RemoveAll();
            return RedirectToAction("Index");
        }

        private bool CheckUsername(List<User> user, LoginModel model)
        {
            bool found = false;

            foreach (var u in user)
            {
                if ((u.Username == model.Username && u.Password == model.Password))
                {
                    found = true;
                }
            }

            return found;
        }

        private User FindUser(string username)
        {
            List<User> user = db.User.ToList();

            foreach (var u in user)
            {
                if (u.Username == username)
                {
                    return u;
                }
            }
            return null;
        }
    }
}