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
    public class BudgetController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Budget
        public ActionResult Index()
        {
            var budgets = db.Budgets.Include(b => b.PhaseType);
            return View(budgets.ToList());
        }

        // GET: Budget/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // GET: Budget/Create
        public ActionResult Create()
        {
            ViewBag.PhaseTypeID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName");
            return View();
        }

        // POST: Budget/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BudgetID,PhaseTypeID,ForecastCapital,ForecastExpense,ActualCapital,ActualExpense")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhaseTypeID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName", budget.PhaseTypeID);
            return View(budget);
        }

        // GET: Budget/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhaseTypeID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName", budget.PhaseTypeID);
            return View(budget);
        }

        // POST: Budget/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudgetID,PhaseTypeID,ForecastCapital,ForecastExpense,ActualCapital,ActualExpense")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhaseTypeID = new SelectList(db.PhaseTypes, "PhaseTypeID", "PhaseTypeName", budget.PhaseTypeID);
            return View(budget);
        }

        // GET: Budget/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budget budget = db.Budgets.Find(id);
            db.Budgets.Remove(budget);
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
