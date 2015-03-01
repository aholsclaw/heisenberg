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
    public class ProjectTaskController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ProjectTask
        public ActionResult Index()
        {
            var projectTasks = db.ProjectTasks.Include(p => p.Project).Include(p => p.ProjectTaskType);
            return View(projectTasks.ToList());
        }

        // GET: ProjectTask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            return View(projectTask);
        }

        // GET: ProjectTask/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title");
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTaskTypes, "ProjectTaskTypeID", "ProjectTaskTypeName");
            return View();
        }

        // POST: ProjectTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectTaskID,ProjectTaskTypeID,ProjectID,OriginalForecast,RevisedForecast,Actual")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTasks.Add(projectTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectTask.ProjectID);
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTaskTypes, "ProjectTaskTypeID", "ProjectTaskTypeName", projectTask.ProjectTaskID);
            return View(projectTask);
        }

        // GET: ProjectTask/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectTask.ProjectID);
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTaskTypes, "ProjectTaskTypeID", "ProjectTaskTypeName", projectTask.ProjectTaskID);
            return View(projectTask);
        }

        // POST: ProjectTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectTaskID,ProjectTaskTypeID,ProjectID,OriginalForecast,RevisedForecast,Actual")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectTask.ProjectID);
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTaskTypes, "ProjectTaskTypeID", "ProjectTaskTypeName", projectTask.ProjectTaskID);
            return View(projectTask);
        }

        // GET: ProjectTask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            return View(projectTask);
        }

        // POST: ProjectTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            db.ProjectTasks.Remove(projectTask);
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
