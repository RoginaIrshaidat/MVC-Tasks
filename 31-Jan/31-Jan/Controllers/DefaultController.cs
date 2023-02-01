using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31_Jan.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
       

        public string Img()
        {
            return "<h3>Click on the image to download it : </h3>" +
                "<a href='../Image/Task.jpg' download />"+
                 "<img src='../Image/Task.jpg'  />"
                ;
        }
        public void downloadImage()
        {
            var imagePath = Server.MapPath("../Image/Task.jpg");
            Response.AddHeader("Content-Disposition", "attachment;filename=Task.jpg");
            Response.WriteFile(imagePath);
            Response.End();
        }

        public string AboutUs()
        {
            return "The first task in MVC ";
        }
        public string Contact()
        {
            return "Contact ";
        }
    }
}