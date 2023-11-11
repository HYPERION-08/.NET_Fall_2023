using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test2.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio


        public ActionResult Home() {

            ViewBag.Basic = "Just a simple home page";

            return View(); 
        
        }

        public ActionResult Student_Information()
        {
            return View();
        }

        public ActionResult Education()
        {

            ViewBag.History = "Education History.";
            return View();          
        }

        public ActionResult Projects()
        {
            ViewBag.Project_Name = "Completed Projects.";
            return View();
        }

        public ActionResult Reference()
        {
            ViewBag.Reference = "Reference Teachers.";
            return View();
        }

    }
}