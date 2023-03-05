using NewsletterMVC.Models;
using NewsletterMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signups = db.SignUps;
                    var signupVms = new List<SignupVm>();
                    foreach (var signup in signups)
                    {
                        SignupVm signupVm = new SignupVm();
                    signupVm.Id = signup.Id; 
                        signupVm.FirstName = signup.FirstName;
                        signupVm.LastName = signup.Lastname;
                        signupVm.EmailAddress = signup.EmailAddress;
                        signupVms.Add(signupVm);
                    }
                    return View(signupVms);
                }
        }

        public ActionResult Unsubscribe(int Id)
        {
            using(NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();

            }

            return RedirectToAction("Index"); 
        }
    }
}