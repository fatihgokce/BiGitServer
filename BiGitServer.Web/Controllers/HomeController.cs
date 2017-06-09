using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiGitServer.Data;
using Microsoft.EntityFrameworkCore;
namespace BiGitServer.Web.Controllers
{
    public class HomeController : Controller
    {
        BiGitContext db;
        public HomeController(BiGitContext context)
        {
            db=context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            Role role1 = db.Roles.Include(c => c.Users).FirstOrDefault();
            ViewData["role"]=role1;
            ViewData["Message"] = $"Your application description page. {role1} "+ new Thing().Get(19, 23);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
