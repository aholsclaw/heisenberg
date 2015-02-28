using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class ReferencesController : Controller
    {
        public References oReferences = new References();
        public ActionResult References()
        {
            ViewData["ProjectReferences"] = oReferences.GetReferences();
            return View();
        }
	}
}