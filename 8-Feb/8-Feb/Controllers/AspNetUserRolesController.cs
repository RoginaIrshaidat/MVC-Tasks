using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _8_Feb.Models;

namespace _8_Feb.Controllers
{
    public class AspNetUserRolesController : Controller
    {
        private MVCEntities1 db = new MVCEntities1();

        // GET: AspNetUserRoles
        public ActionResult Index()
        {
            var aspNetUserRoles = db.AspNetUserRoles.Include(a => a.AspNetUser).Include(a => a.AspNetRole);
            return View(aspNetUserRoles.ToList());
        }

        // GET: AspNetUserRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            if (aspNetUserRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name");
            return View();
        }

        // POST: AspNetUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,RoleId,Note")] AspNetUserRole aspNetUserRole)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUserRoles.Add(aspNetUserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            if (aspNetUserRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
            return View(aspNetUserRole);
        }

        // POST: AspNetUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,RoleId,Note")] AspNetUserRole aspNetUserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            if (aspNetUserRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserRole);
        }

        // POST: AspNetUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            db.AspNetUserRoles.Remove(aspNetUserRole);
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
