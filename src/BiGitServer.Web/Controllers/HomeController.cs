using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Url.Host == "localhost")
            {
                return Redirect("/dist/index.html");
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