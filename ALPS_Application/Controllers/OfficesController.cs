using ALPS_Application.Models;
using DataTables;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;


namespace ALPS_Application.Controllers
{
    public class OfficesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Table()
        {
            //TODO
            var request = System.Web.HttpContext.Current.Request;
            var settings = Properties.Settings.Default;
            using (var db = new DataTables.Database(settings.DbType, settings.DbConnection))
            {
                var response = new Editor(db, "offices")
                    .Model<JoinModelOffices>("offices")
                    .Model<JoinModelUSStates>("usstates")
                    .Field(new Field("offices.usstate")
                        .Options(new Options()
                            .Table("usstates")
                            .Value("id")
                            .Label("name")
                        ))
                    .Process(request)
                    .Data();

                return Json(response);
            }
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
