using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSharpWebApp.Models;

namespace CSharpWebApp.Controllers
{
    
    public class ProfessorsController : Controller
    {
        private StudentsAndProfessorsEntities db = new StudentsAndProfessorsEntities();

        // GET: Professors
        [Authorize]
        public ActionResult Index()
        {
            var professors = db.Professors.Include(p => p.Subject1);
            return View(professors.ToList());
        }

        // GET: Professors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professors/Create
        [Authorize(Roles = "CanManageStudentsAndProfessors")]
        public ActionResult Create()
        {
            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1");
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageStudentsAndProfessors")]
        public ActionResult Create([Bind(Include = "Full_Name,E_Mail,ID,Faculty,Subject")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();
                return RedirectToAction("ReIndex");
            }

            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1", professor.Subject);
            return View(professor);
        }

        // GET: Professors/Edit/5
        [Authorize(Roles = "CanManageStudentsAndProfessors")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1", professor.Subject);
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageStudentsAndProfessors")]
        public ActionResult Edit([Bind(Include = "Full_Name,E_Mail,ID,Faculty,Subject")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1", professor.Subject);
            return View(professor);
        }

        // GET: Professors/Delete/5
        [Authorize(Roles = "CanManageStudentsAndProfessors")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageStudentsAndProfessors")]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
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
