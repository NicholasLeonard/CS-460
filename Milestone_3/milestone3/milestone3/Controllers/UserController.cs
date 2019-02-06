using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using milestone3.Models;
using System.Data.Entity;
using System.Data;


namespace milestone3.Controllers
{
    public class UserController : Controller
    {
        private ToasterItContext db = new ToasterItContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            //if the user is already logged in, show error message, redirect to the index page *@
            if (Session["UserID"] != null)
            {
                ViewBag.Message = "You are already logged in!";
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                using (ToasterItContext db = new ToasterItContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                //clear the input control contents after finish
                ModelState.Clear();

                //user is sucessfully registered message.
                ViewBag.Message = user.Username + "(" + user.Pseudonym + ")" + " successfully registered!";
            }
            return View();
        }

        //user login page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (ToasterItContext db = new ToasterItContext())
            {
                var usr = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                ViewBag.Mes1 = usr;
                // if is logged
                if (usr != null)
                {
                    //set the session variables
                    Session["UserID"] = usr.Userid.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Pseudonym"] = usr.Pseudonym.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username/Password is invalid.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                //return to login page
                return RedirectToAction("Login");
            }
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Logout()
        {
            //remove the user session and cookies on logout.
            Session.Clear();
            return View();
        }


    }
}