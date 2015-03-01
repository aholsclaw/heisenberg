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
    public class CostController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Cost
        public ActionResult Index()
        {
            return View(db.Costs.ToList());
        }

        // GET: Cost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = db.Costs.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        // GET: Cost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CostID,ProjectID,CostTypeID,Amount,Year,Quarter,PostProject")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Costs.Add(cost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cost);
        }

        // GET: Cost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = db.Costs.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        // POST: Cost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CostID,ProjectID,CostTypeID,Amount,Year,Quarter,PostProject")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cost);
        }

        // GET: Cost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = db.Costs.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        // POST: Cost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cost cost = db.Costs.Find(id);
            db.Costs.Remove(cost);
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
