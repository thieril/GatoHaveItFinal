using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GatoHaveItFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "GatoHaveIt was launched in 2016.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us With Your Questions.";

            return View();
        }
    }
}