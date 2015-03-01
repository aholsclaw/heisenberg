﻿using System;
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
    public class ResourceController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Resource
        public ActionResult Index()
        {
            var resources = db.Resources.Include(r => r.Project).Include(r => r.ResourceType);
            return View(resources.ToList());
        }

        // GET: Resource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title");
            ViewBag.ResourceID = new SelectList(db.ResourceTypes, "ResourceTypeID", "ResourceTypeName");
            return View();
        }

        // POST: Resource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourceID,ProjectID,ResourceTypeID,FTE,Year,Quarter,PostProject")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", resource.ProjectID);
            ViewBag.ResourceID = new SelectList(db.ResourceTypes, "ResourceTypeID", "ResourceTypeName", resource.ResourceID);
            return View(resource);
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", resource.ProjectID);
            ViewBag.ResourceID = new SelectList(db.ResourceTypes, "ResourceTypeID", "ResourceTypeName", resource.ResourceID);
            return View(resource);
        }

        // POST: Resource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourceID,ProjectID,ResourceTypeID,FTE,Year,Quarter,PostProject")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", resource.ProjectID);
            ViewBag.ResourceID = new SelectList(db.ResourceTypes, "ResourceTypeID", "ResourceTypeName", resource.ResourceID);
            return View(resource);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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
