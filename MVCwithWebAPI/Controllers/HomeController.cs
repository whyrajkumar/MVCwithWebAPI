using MVCwithWebAPI.Models;
using MVCwithWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCwithWebAPI.Controllers
{
    public class HomeController : Controller
    {        
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
    
}