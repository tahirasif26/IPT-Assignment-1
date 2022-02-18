using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K181169_Q4.Models;

namespace K181169_Q4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Results obj = new Results();
            obj.readfile();
            obj.count_votes();
            obj.get_names();
            return View(obj);
        }

        
    }
}