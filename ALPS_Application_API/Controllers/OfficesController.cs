using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ALPS_Application.Models;

namespace ALPS_Application_API.Controllers
{
    public class OfficesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Offices
        public IQueryable<Office> GetOffices()
        {
            return db.Offices;
        }

        // GET: api/Offices/5
        [ResponseType(typeof(Office))]
        public IHttpActionResult GetOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        // PUT: api/Offices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffice(int id, Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != office.ID)
            {
                return BadRequest();
            }

            db.Entry(office).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Offices
        [ResponseType(typeof(Office))]
        public IHttpActionResult PostOffice(Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offices.Add(office);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = office.ID }, office);
        }

        // DELETE: api/Offices/5
        [ResponseType(typeof(Office))]
        public IHttpActionResult DeleteOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            db.Offices.Remove(office);
            db.SaveChanges();

            return Ok(office);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficeExists(int id)
        {
            return db.Offices.Count(e => e.ID == id) > 0;
        }
    }
}