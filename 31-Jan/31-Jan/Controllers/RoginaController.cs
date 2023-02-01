using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31_Jan.Controllers
{
    public class RoginaController : Controller
    {
        // GET: Rogina
       
        public string Name()
        {
            return "My name is : Rogina Irshaidat ";
        }
        public int ID()
        {
            return 32 ;
        }
        public string Majour()
        {
            return "My majour is : Computer Science ";
        }
        public double Salary()
        {
            return 450.50;
        }
    }
}