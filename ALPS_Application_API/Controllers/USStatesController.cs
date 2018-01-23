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
    public class USStatesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/USStates
        public IQueryable<USState> GetUSStates()
        {
            return db.USStates;
        }

        // GET: api/USStates/5
        [ResponseType(typeof(USState))]
        public IHttpActionResult GetUSState(int id)
        {
            USState uSState = db.USStates.Find(id);
            if (uSState == null)
            {
                return NotFound();
            }

            return Ok(uSState);
        }

        // PUT: api/USStates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSState(int id, USState uSState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSState.ID)
            {
                return BadRequest();
            }

            db.Entry(uSState).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USStateExists(id))
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

        // POST: api/USStates
        [ResponseType(typeof(USState))]
        public IHttpActionResult PostUSState(USState uSState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USStates.Add(uSState);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSState.ID }, uSState);
        }

        // DELETE: api/USStates/5
        [ResponseType(typeof(USState))]
        public IHttpActionResult DeleteUSState(int id)
        {
            USState uSState = db.USStates.Find(id);
            if (uSState == null)
            {
                return NotFound();
            }

            db.USStates.Remove(uSState);
            db.SaveChanges();

            return Ok(uSState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USStateExists(int id)
        {
            return db.USStates.Count(e => e.ID == id) > 0;
        }
    }
}