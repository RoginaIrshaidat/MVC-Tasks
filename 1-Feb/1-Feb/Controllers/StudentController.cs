using _1_Feb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_Feb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Models.Student> student = new List<Student>();
            student.Add(new Student { ID=30,Name="Razan",Majour="Computer Enginer",Faculity="IT"});
            student.Add(new Student { ID = 32, Name = "Rogina", Majour = "Computer Science", Faculity = "IT" });
            student.Add(new Student { ID = 3, Name = "Amer", Majour = "Computer Science", Faculity = "IT" });


            return View(student);
        }
    }
}