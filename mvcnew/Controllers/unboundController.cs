using mvcnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnew.Controllers
{
    public class unboundController : Controller
    {
        // GET: unbound
        public ActionResult unbound()
        {
            return View();
        }
        public ActionResult showResult()
        {
            emp E = new emp();
            E.Empno = int.Parse(Request.Form["txtEmpno"]);
            E.Ename = Request.Form["txtEname"];
            E.Salary = double.Parse(Request.Form["txtSalary"]);
            return View(E);
        }
    }
}