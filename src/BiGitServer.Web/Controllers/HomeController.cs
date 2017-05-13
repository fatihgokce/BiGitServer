using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiGitServer.Data;
using NHibernate;

namespace BiGitServer.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Url.Host == "localhost")
            {
                //using (BiGitServerDbContext db = new BiGitServerDbContext())
                //{
                //    BiGitServer.Data.Models.User user = new Data.Models.User();
                //    user.Id = Guid.NewGuid();
                //    user.Email = "fddf";
                //    user.Surname = "dsdc";
                //    user.Password = "cdscs";
                //    user.Name = "cdscsd";
                //    db.Users.Add(user);
                //    db.SaveChanges();
                //}
                //return View("/dist/index.html");
                //var result = new FilePathResult("~/dist/index.html", "text/html");
                //using(ISession session = NHibernateHelper.NSession)
                //{
                //    using (var transaction = session.BeginTransaction())
                //    {
                //        BiGitServer.Data.Models.User user = new Data.Models.User();
                //        user.Id = Guid.NewGuid();
                //        user.Username = "fatih";
                //        user.Email = "fddf";
                //        user.Surname = "dsdc";
                //        user.Password = "cdscs";
                //        user.Name = "cdscsd";
                //        session.Save(user);
                //        transaction.Commit();
                //    }
                 
                //}
                return View();
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