using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2_Feb.Models;

namespace _2_Feb.Controllers
{
    public class PersonsController : Controller
    {
        private MVCEntities1 db = new MVCEntities1();

        // GET: Persons
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }
        public ActionResult Search(string searching, string search)
        {
            if (searching == "fName")
            {
                var fname = db.Persons.Where(s => s.First_Name.Contains(search) || search == null).ToList();
                return View("Index",fname);
            }
            else if (searching == "lName")
            {
                var lname = db.Persons.Where(s => s.Last_Name.Contains(search) || search == null).ToList();
                return View("Index", lname);
            }
            else
            {
                var email = db.Persons.Where(s => s.E_mail.Contains(search) || search == null).ToList();
                return View("Index", email);
            }
        }


        // GET: Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] Person person, HttpPostedFileBase Image, HttpPostedFileBase CV)
        {


            if (ModelState.IsValid)
            {
                string path = "../Image/" + Image.FileName;
                Image.SaveAs(Server.MapPath(path));
                person.Image = path;

                string CvPath = "../CV/" + Path.GetFileName(CV.FileName);
                CV.SaveAs(Server.MapPath(CvPath));
                person.CV = CvPath;
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
              
            }

            return View(person);
        }
       
        // GET: Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "PersonID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] Person person, HttpPostedFileBase Image, HttpPostedFileBase CV)
        {
            var existingModel = db.Persons.AsNoTracking().FirstOrDefault(x => x.PersonID == id);

            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    string path = "../../Image/" + Image.FileName;
                    Image.SaveAs(Server.MapPath(path));
                    person.Image = path;
                }
                else
                {
                    person.Image = existingModel.Image;
                }

                if (CV !=null)
                {
                    string CvPath = "../../CV/" + Path.GetFileName(CV.FileName);
                    CV.SaveAs(Server.MapPath(CvPath));
                    person.CV = CvPath;
                }
                else
                {
                   person.CV =existingModel.CV;
                }

                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(person);
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
