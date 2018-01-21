using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ALPS_Application.Models;
using ALPS_Test.Models;

namespace ALPS_Application.Controllers
{
    public class USStatesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: USStates
        public ActionResult Index()
        {
            return View(db.USStates.ToList());
        }

        // GET: USStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USState uSState = db.USStates.Find(id);
            if (uSState == null)
            {
                return HttpNotFound();
            }
            return View(uSState);
        }

        // GET: USStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] USState uSState)
        {
            if (ModelState.IsValid)
            {
                db.USStates.Add(uSState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSState);
        }

        // GET: USStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USState uSState = db.USStates.Find(id);
            if (uSState == null)
            {
                return HttpNotFound();
            }
            return View(uSState);
        }

        // POST: USStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] USState uSState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSState);
        }

        // GET: USStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USState uSState = db.USStates.Find(id);
            if (uSState == null)
            {
                return HttpNotFound();
            }
            return View(uSState);
        }

        // POST: USStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USState uSState = db.USStates.Find(id);
            db.USStates.Remove(uSState);
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
