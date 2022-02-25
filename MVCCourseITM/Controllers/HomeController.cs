using MVCCourseITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCourseITM.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Singin()
        {
            return View();
        }


        ORIENTDBEntities1 db = new ORIENTDBEntities1();


        [HttpPost]
        public ActionResult Register(REGISTRATION user)
        {

            try
            {
                db.REGISTRATIONs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {

                return View();
            }
        }

       


        [HttpPost]
        public ActionResult Singin(REGISTRATION userr)
        {
            bool result = IsValid(userr.EMAIL, userr.PASSWORD);

            if (result)
            {
               
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Login Failed";
            }
            return View(userr);
        }

        private bool IsValid(string email, string password)
        {

            bool IsValid = false;


            var user = db.REGISTRATIONs.FirstOrDefault(u => u.EMAIL == email);

            if (user != null)
            {

                if (user.PASSWORD == password)
                {
                    IsValid = true;
                }
            }

            return IsValid;
        }



    }
}