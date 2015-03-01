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
    public class GoLiveTaskController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: GoLiveTask
        public ActionResult Index()
        {
            return View(db.GoLiveTasks.ToList());
        }

        // GET: GoLiveTask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoLiveTask goLiveTask = db.GoLiveTasks.Find(id);
            if (goLiveTask == null)
            {
                return HttpNotFound();
            }
            return View(goLiveTask);
        }

        // GET: GoLiveTask/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoLiveTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoLiveTaskID,TaskTypeID,ProjectID,OriginalForecast,RevisedForecast,Actual")] GoLiveTask goLiveTask)
        {
            if (ModelState.IsValid)
            {
                db.GoLiveTasks.Add(goLiveTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goLiveTask);
        }

        // GET: GoLiveTask/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoLiveTask goLiveTask = db.GoLiveTasks.Find(id);
            if (goLiveTask == null)
            {
                return HttpNotFound();
            }
            return View(goLiveTask);
        }

        // POST: GoLiveTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoLiveTaskID,TaskTypeID,ProjectID,OriginalForecast,RevisedForecast,Actual")] GoLiveTask goLiveTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goLiveTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goLiveTask);
        }

        // GET: GoLiveTask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoLiveTask goLiveTask = db.GoLiveTasks.Find(id);
            if (goLiveTask == null)
            {
                return HttpNotFound();
            }
            return View(goLiveTask);
        }

        // POST: GoLiveTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoLiveTask goLiveTask = db.GoLiveTasks.Find(id);
            db.GoLiveTasks.Remove(goLiveTask);
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
