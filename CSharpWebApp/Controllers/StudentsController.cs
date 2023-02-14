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
    public class StudentsController : Controller
    {
        private StudentsAndProfessorsEntities db = new StudentsAndProfessorsEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Subject1);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
   
        [Authorize(Users = "admin@unyt.edu.al, professorAcc@unyt.edu.al")]

        public ActionResult Create()
        {
            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin@unyt.edu.al, professorAcc@unyt.edu.al")]

        public ActionResult Create([Bind(Include = "Full_Name,E_Mail,ID,Faculty,Subject")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1", student.Subject);
            return View(student);
        }

        // GET: Students/Edit/5

        [Authorize(Users = "admin@unyt.edu.al, professorAcc@unyt.edu.al")]


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1", student.Subject);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Users = "admin@unyt.edu.al, professorAcc@unyt.edu.al")]
 
        public ActionResult Edit([Bind(Include = "Full_Name,E_Mail,ID,Faculty,Subject")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Subject = new SelectList(db.Subjects, "Subject1", "Subject1", student.Subject);
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Users = "admin@unyt.edu.al, professorAcc@unyt.edu.al")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin@unyt.edu.al, professorAcc@unyt.edu.al")]


        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
