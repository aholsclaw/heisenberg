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
    public class ResourceTypeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ResourceType
        public ActionResult Index()
        {
            return View(db.ResourceTypes.ToList());
        }

        // GET: ResourceType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceType resourceType = db.ResourceTypes.Find(id);
            if (resourceType == null)
            {
                return HttpNotFound();
            }
            return View(resourceType);
        }

        // GET: ResourceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourceTypeID,ResourceTypeName")] ResourceType resourceType)
        {
            if (ModelState.IsValid)
            {
                db.ResourceTypes.Add(resourceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceType);
        }

        // GET: ResourceType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceType resourceType = db.ResourceTypes.Find(id);
            if (resourceType == null)
            {
                return HttpNotFound();
            }
            return View(resourceType);
        }

        // POST: ResourceType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourceTypeID,ResourceTypeName")] ResourceType resourceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceType);
        }

        // GET: ResourceType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceType resourceType = db.ResourceTypes.Find(id);
            if (resourceType == null)
            {
                return HttpNotFound();
            }
            return View(resourceType);
        }

        // POST: ResourceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceType resourceType = db.ResourceTypes.Find(id);
            db.ResourceTypes.Remove(resourceType);
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
