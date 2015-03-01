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
    public class CostTypeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: CostType
        public ActionResult Index()
        {
            return View(db.CostTypes.ToList());
        }

        // GET: CostType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostType costType = db.CostTypes.Find(id);
            if (costType == null)
            {
                return HttpNotFound();
            }
            return View(costType);
        }

        // GET: CostType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CostTypeID,CostTypeName")] CostType costType)
        {
            if (ModelState.IsValid)
            {
                db.CostTypes.Add(costType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costType);
        }

        // GET: CostType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostType costType = db.CostTypes.Find(id);
            if (costType == null)
            {
                return HttpNotFound();
            }
            return View(costType);
        }

        // POST: CostType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CostTypeID,CostTypeName")] CostType costType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costType);
        }

        // GET: CostType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostType costType = db.CostTypes.Find(id);
            if (costType == null)
            {
                return HttpNotFound();
            }
            return View(costType);
        }

        // POST: CostType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CostType costType = db.CostTypes.Find(id);
            db.CostTypes.Remove(costType);
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
