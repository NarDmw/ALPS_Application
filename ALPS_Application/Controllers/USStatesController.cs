﻿using ALPS_Application.Models;
using System.Linq;
using System.Web.Mvc;


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
