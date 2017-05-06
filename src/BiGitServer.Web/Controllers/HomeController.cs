using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiGitServer.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Url.Host == "localhost")
            {
                //return View("/dist/index.html");
                var result = new FilePathResult("~/dist/index.html", "text/html");
                return Redirect("index.html");
            }
            return View();
        }
        public JsonResult FakeData()
        {
            object obj = new{ id = 421, name = "fatih" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}