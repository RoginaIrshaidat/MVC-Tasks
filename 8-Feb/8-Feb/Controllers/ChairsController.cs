using _8_Feb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8_Feb.Controllers
{
    [Authorize]

    public class ChairsController : Controller
    {
        MVCEntities1 mVC = new MVCEntities1();
        public ActionResult Index()
        {
            var chair = mVC.Chairs.FirstOrDefault();
            return View(chair);
        }
    }
}