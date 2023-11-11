using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Formvalid.Models;

namespace Formvalid.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Signup sign)
        {
            return View(sign);
        }

    }
}