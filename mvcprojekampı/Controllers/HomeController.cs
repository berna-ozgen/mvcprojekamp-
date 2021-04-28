using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekampı.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()//hakkımda metodu
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()//iletişim metodu
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
 
    }
}