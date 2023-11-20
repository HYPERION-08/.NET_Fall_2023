using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class LoginController : Controller
    {
      

        [HttpGet]
        public ActionResult Login()
        {
            int id = int.Parse(Request.QueryString["id"]);
            ViewBag.id = id;
            return View();
        }

        public ActionResult Logout() { 
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            Session["log"] = "log";

            string username = fc["username"];
            string password = fc["password"];
            string id = fc["id"];

            var db = new ZeroHungerEntities1();
            if (id == "1")
            {
                var user = (from s in db.admins
                            where s.username == username && s.password == password
                            select s).FirstOrDefault();

            if (user != null)
                {
                    Session["admin"] = username;
                    Session["admin_id"] = user.admin_id;
                    return RedirectToAction("Admin_Dashboard","Admin");
                }
            else
                {
                    Session["password"] = "Wrong Password";
                    return View();

                }
            }

            else if (id == "2")
            {
                var user = (from s in db.restaurants
                            where s.res_username == username && s.res_password == password
                            select s).FirstOrDefault();

                if (user != null)
                {
                    Session["restaurant"] = username;
                    Session["res_id"] = user.restaurants_id;
                    return RedirectToAction("Restaurant_Dashboard", "Restaurant");
                }
                else
                {
                    Session["restaurant"] = "Wrong password";
                    return View();
                }
            }

            else if(id == "3")
            {
                var user = (from s in db.employees
                            where s.username == username && s.password == password
                            select s).FirstOrDefault();
                if (user != null)
                {
                    Session["admin"] = username;
                    Session["emp_id"] = user.emp_id;
                    return RedirectToAction("Employee_Dashboard", "Employee");

                }
                else
                {
                    Session["password"] = "wrong password";
                    return View();
                }

            }


            else
            {
                return View();
            }
        }

    }
}