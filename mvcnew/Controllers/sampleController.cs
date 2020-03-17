using mvcnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnew.Controllers
{
    public class sampleController : Controller
    {
        // GET: sample
        public ActionResult Index()
        {
            ViewBag.str = "my first MVC project";
            ViewData["str1"]= "my first project";
            TempData["str2"]= "my project";
            return View();
        }
        public ActionResult Sendobject()
        {
            emp E = new emp();
            E.Empno = 844441;
            E.Ename = "abhishek";
            E.Salary = 21700;
            return View(E);
        }
        public ActionResult sendList()
        {
            List<emp> l = new List<emp>();
            emp E = new emp();
            
            E.Empno = 844442;
            E.Ename = "kumar";
            E.Salary = 21700;
            l.Add(E);

            E = new emp();
            E.Empno = 844443;
            E.Ename = "gautam";
            E.Salary = 21700;
            l.Add(E);

            return View(l);

        }
        public ActionResult sendObjectVB()
        {
            emp E = null;
            E = new emp();
            E.Empno = 441;
            E.Ename = "shek";
            E.Salary = 700;
            ViewBag.emp = E;
            return View();

            
        }
        public ActionResult SendObjectsVB()
        {

            List<emp> l = new List<emp>();
            emp E = new emp();

            E.Empno = 844442;
            E.Ename = "kumar";
            E.Salary = 21700;
            l.Add(E);

            E = new emp();
            E.Empno = 844443;
            E.Ename = "gautam";
            E.Salary = 21700;
            l.Add(E);
            ViewBag.xyz = l;
            return View();
        }
    }
}