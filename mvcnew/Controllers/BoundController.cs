using mvcnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnew.Controllers
{
    public class BoundController : Controller
    {
        // GET: Bound
        public ActionResult Index()
        {
            emp E = new emp();
            return View(E);
        }
        public ActionResult Display(emp Em)
        {
            return View(Em);
        }
        public ActionResult Index1()
        {
            emp E = new emp();
            return View(E);
        }
        [HttpPost]
        public ActionResult Index1(emp Em)
        {
            return View("Display",Em);
        }
    }
}