using mvcnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnew.Controllers
{
    public class validationController : Controller
    {
        // GET: validation
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult getBack(validationcls V)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Addpage");
            }
            return View("Index");
        }
        public ActionResult AddPage()
        {
            return View();
        }
    }
}