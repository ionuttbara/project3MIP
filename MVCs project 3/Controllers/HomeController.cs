using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCs_project_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a project meant for a good grade, I need dem 30 whack ahh points";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "0747 198 596";

            return View();
        }

		public ActionResult ChangeLanguage(string lang)
		{
			Session["lang"] = lang;

			return RedirectToAction("Index", "Home",
				new { language = lang });
		}
	}
}