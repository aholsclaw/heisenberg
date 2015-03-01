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
    public class ProjectPhaseController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ProjectPhase
        public ActionResult Index()
        {
            var projectPhases = db.ProjectPhases.Include(p => p.PhaseType).Include(p => p.Project);
            return View(projectPhases.ToList());
        }

        // GET: ProjectPhase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            if (projectPhase == null)
            {
                return HttpNotFound();
            }
            return View(projectPhase);
        }

        // GET: ProjectPhase/Create
        public ActionResult Create()
        {
            ViewBag.ProjectPhaseID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title");
            return View();
        }

        // POST: ProjectPhase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectPhaseID,ProjectID,PhaseTypeID,ForecastCompletion,ActualCompletion")] ProjectPhase projectPhase)
        {
            if (ModelState.IsValid)
            {
                db.ProjectPhases.Add(projectPhase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectPhaseID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName", projectPhase.ProjectPhaseID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectPhase.ProjectID);
            return View(projectPhase);
        }

        // GET: ProjectPhase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            if (projectPhase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectPhaseID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName", projectPhase.ProjectPhaseID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectPhase.ProjectID);
            return View(projectPhase);
        }

        // POST: ProjectPhase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectPhaseID,ProjectID,PhaseTypeID,ForecastCompletion,ActualCompletion")] ProjectPhase projectPhase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectPhase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectPhaseID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName", projectPhase.ProjectPhaseID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectPhase.ProjectID);
            return View(projectPhase);
        }

        // GET: ProjectPhase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            if (projectPhase == null)
            {
                return HttpNotFound();
            }
            return View(projectPhase);
        }

        // POST: ProjectPhase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            db.ProjectPhases.Remove(projectPhase);
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
