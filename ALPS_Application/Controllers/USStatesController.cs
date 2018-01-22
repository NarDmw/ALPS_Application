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
    }
}
