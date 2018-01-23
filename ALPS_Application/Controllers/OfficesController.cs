using DataTables;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ALPS_Application.Models;

namespace ALPS_Application.Controllers
{
    public class OfficesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Table()
        {
            var settings = Properties.Settings.Default;
            var formData = HttpContext.Request.Form;

            return View();
            //using (var db = new DataTables.Database(settings.DbType, settings.DbConnection))
            //{
            //    var response = new Editor(db, "Office")
            //        .Model<Office>()
            //        .Field(new Field("start_date")
            //        .Validator(Validation.DateFormat(Format.DATE_ISO_8601,
            //        new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
            //        ))
            //        .GetFormatter(Format.DateSqlToFormat(Format.DATE_ISO_8601))
            //        .SetFormatter(Format.DateFormatToSql(Format.DATE_ISO_8601))
            //        )
            //        .Process(formData)
            //        .Data();

            //    return Json(response, JsonRequestBehavior.AllowGet);
            //}
        }


        // GET: Offices
        public ActionResult Index()
        {
            var offices = db.Offices.Include(o => o.USState);
            return View(offices.ToList());
        }

        // GET: Offices/Create
        public ActionResult Create()
        {
            ViewBag.USStateId = new SelectList(db.USStates, "ID", "Name");
            return View();
        }

        // POST: Offices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,City,USStateId")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Offices.Add(office);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USStateId = new SelectList(db.USStates, "ID", "Name", office.USStateId);
            return View(office);
        }

        // GET: Offices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            ViewBag.USStateId = new SelectList(db.USStates, "ID", "Name", office.USStateId);
            return View(office);
        }

        // POST: Offices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,City,USStateId")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(office).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USStateId = new SelectList(db.USStates, "ID", "Name", office.USStateId);
            return View(office);
        }

        // GET: Offices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Office office = db.Offices.Find(id);
            db.Offices.Remove(office);
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
