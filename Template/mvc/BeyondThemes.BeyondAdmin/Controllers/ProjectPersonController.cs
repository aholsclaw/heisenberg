using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ProjectPersonController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ProjectPerson
        public ActionResult Index()
        {
            return View(db.ProjectPersons.ToList());
        }

        // GET: ProjectPerson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPerson projectPerson = db.ProjectPersons.Find(id);
            if (projectPerson == null)
            {
                return HttpNotFound();
            }
            return View(projectPerson);
        }

        // GET: ProjectPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectPersonId,ProjectID,PersonID,RoleID")] ProjectPerson projectPerson)
        {
            if (ModelState.IsValid)
            {
                db.ProjectPersons.Add(projectPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectPerson);
        }

        // GET: ProjectPerson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPerson projectPerson = db.ProjectPersons.Find(id);
            if (projectPerson == null)
            {
                return HttpNotFound();
            }
            return View(projectPerson);
        }

        // POST: ProjectPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectPersonId,ProjectID,PersonID,RoleID")] ProjectPerson projectPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectPerson);
        }

        // GET: ProjectPerson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPerson projectPerson = db.ProjectPersons.Find(id);
            if (projectPerson == null)
            {
                return HttpNotFound();
            }
            return View(projectPerson);
        }

        // POST: ProjectPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectPerson projectPerson = db.ProjectPersons.Find(id);
            db.ProjectPersons.Remove(projectPerson);
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
