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
    public class PhaseTypeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: PhaseType
        public ActionResult Index()
        {
            return View(db.PhaseTypes.ToList());
        }

        // GET: PhaseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhaseType phaseType = db.PhaseTypes.Find(id);
            if (phaseType == null)
            {
                return HttpNotFound();
            }
            return View(phaseType);
        }

        // GET: PhaseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhaseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhaseTypeID,PhaseTypeName")] PhaseType phaseType)
        {
            if (ModelState.IsValid)
            {
                db.PhaseTypes.Add(phaseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phaseType);
        }

        // GET: PhaseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhaseType phaseType = db.PhaseTypes.Find(id);
            if (phaseType == null)
            {
                return HttpNotFound();
            }
            return View(phaseType);
        }

        // POST: PhaseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhaseTypeID,PhaseTypeName")] PhaseType phaseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phaseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phaseType);
        }

        // GET: PhaseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhaseType phaseType = db.PhaseTypes.Find(id);
            if (phaseType == null)
            {
                return HttpNotFound();
            }
            return View(phaseType);
        }

        // POST: PhaseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhaseType phaseType = db.PhaseTypes.Find(id);
            db.PhaseTypes.Remove(phaseType);
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
