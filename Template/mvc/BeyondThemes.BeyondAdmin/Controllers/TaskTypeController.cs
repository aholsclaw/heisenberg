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
    public class TaskTypeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: TaskType
        public ActionResult Index()
        {
            return View(db.TaskTypes.ToList());
        }

        // GET: TaskType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskType taskType = db.TaskTypes.Find(id);
            if (taskType == null)
            {
                return HttpNotFound();
            }
            return View(taskType);
        }

        // GET: TaskType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskTypeID,TaskTypeName")] TaskType taskType)
        {
            if (ModelState.IsValid)
            {
                db.TaskTypes.Add(taskType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskType);
        }

        // GET: TaskType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskType taskType = db.TaskTypes.Find(id);
            if (taskType == null)
            {
                return HttpNotFound();
            }
            return View(taskType);
        }

        // POST: TaskType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskTypeID,TaskTypeName")] TaskType taskType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskType);
        }

        // GET: TaskType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskType taskType = db.TaskTypes.Find(id);
            if (taskType == null)
            {
                return HttpNotFound();
            }
            return View(taskType);
        }

        // POST: TaskType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskType taskType = db.TaskTypes.Find(id);
            db.TaskTypes.Remove(taskType);
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
