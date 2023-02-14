using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MajourApi.Models;

namespace MajourApi.Controllers
{
    public class MajoursController : Controller
    {
        private APIEntities db = new APIEntities();

        // GET: Majours
        public ActionResult Index()
        {
            var majours = db.Majours.Include(m => m.Faculty);
            return View(majours.ToList());
        }
        public ActionResult Show(int id)
        {
            var major = db.Majours.Where(a => a.FacultieID == id);
            return View(major.ToList());
        }

        // GET: Majours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majour majour = db.Majours.Find(id);
            if (majour == null)
            {
                return HttpNotFound();
            }
            return View(majour);
        }

        // GET: Majours/Create
        public ActionResult Create()
        {
            ViewBag.FacultieID = new SelectList(db.Faculties, "FacultieID", "FacultieName");
            return View();
        }

        // POST: Majours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MajourID,MajourName,img,FacultieID")] Majour majour)
        {
            if (ModelState.IsValid)
            {
                db.Majours.Add(majour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultieID = new SelectList(db.Faculties, "FacultieID", "FacultieName", majour.FacultieID);
            return View(majour);
        }

        // GET: Majours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majour majour = db.Majours.Find(id);
            if (majour == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultieID = new SelectList(db.Faculties, "FacultieID", "FacultieName", majour.FacultieID);
            return View(majour);
        }

        // POST: Majours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MajourID,MajourName,img,FacultieID")] Majour majour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultieID = new SelectList(db.Faculties, "FacultieID", "FacultieName", majour.FacultieID);
            return View(majour);
        }

        // GET: Majours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majour majour = db.Majours.Find(id);
            if (majour == null)
            {
                return HttpNotFound();
            }
            return View(majour);
        }

        // POST: Majours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Majour majour = db.Majours.Find(id);
            db.Majours.Remove(majour);
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
