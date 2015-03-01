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
    public class ProjectTaskTypeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ProjectTaskType
        public ActionResult Index()
        {
            var projectTaskTypes = db.ProjectTaskTypes.Include(p => p.ProjectTask);
            return View(projectTaskTypes.ToList());
        }

        // GET: ProjectTaskType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTaskType projectTaskType = db.ProjectTaskTypes.Find(id);
            if (projectTaskType == null)
            {
                return HttpNotFound();
            }
            return View(projectTaskType);
        }

        // GET: ProjectTaskType/Create
        public ActionResult Create()
        {
            ViewBag.ProjectTaskTypeID = new SelectList(db.ProjectTasks, "ProjectTaskID", "ProjectTaskID");
            return View();
        }

        // POST: ProjectTaskType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectTaskTypeID,ProjectTaskTypeName")] ProjectTaskType projectTaskType)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTaskTypes.Add(projectTaskType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectTaskTypeID = new SelectList(db.ProjectTasks, "ProjectTaskID", "ProjectTaskID", projectTaskType.ProjectTaskTypeID);
            return View(projectTaskType);
        }

        // GET: ProjectTaskType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTaskType projectTaskType = db.ProjectTaskTypes.Find(id);
            if (projectTaskType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectTaskTypeID = new SelectList(db.ProjectTasks, "ProjectTaskID", "ProjectTaskID", projectTaskType.ProjectTaskTypeID);
            return View(projectTaskType);
        }

        // POST: ProjectTaskType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectTaskTypeID,ProjectTaskTypeName")] ProjectTaskType projectTaskType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTaskType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectTaskTypeID = new SelectList(db.ProjectTasks, "ProjectTaskID", "ProjectTaskID", projectTaskType.ProjectTaskTypeID);
            return View(projectTaskType);
        }

        // GET: ProjectTaskType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTaskType projectTaskType = db.ProjectTaskTypes.Find(id);
            if (projectTaskType == null)
            {
                return HttpNotFound();
            }
            return View(projectTaskType);
        }

        // POST: ProjectTaskType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTaskType projectTaskType = db.ProjectTaskTypes.Find(id);
            db.ProjectTaskTypes.Remove(projectTaskType);
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
