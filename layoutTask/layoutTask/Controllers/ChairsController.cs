using layoutTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layoutTask.Controllers
{

    public class ChairsController : Controller
    {
        // GET: Chairs
        MVCEntities1 mVC = new MVCEntities1();
        public ActionResult Index()
        {
            var chair= mVC.Chairs.FirstOrDefault();
            return View(chair);
        }
    }
}