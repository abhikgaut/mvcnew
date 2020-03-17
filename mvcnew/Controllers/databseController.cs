using mvcnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnew.Controllers
{
    public class databseController : Controller
    {
        static List<DEPTDATA> list = null;
        static List<EMPDATA> list1 = null;
        // GET: databse
        public ActionResult IndexDB()
        {
            EMPDATA E = new EMPDATA();
            return View(E);
        }
        [HttpPost]
        public ActionResult IndexDB(EMPDATA E)
        {
            ViewBag.msg=empdataDB.insertEmp(E);
            return View();
        }
        public ActionResult getDeptData()
        {
            return View();
        }
        public ActionResult getDept()
        {
            int deptno = int.Parse(Request.Form["txtdno"]);
            List<EMPDATA> L = empdataDB.GetEmp(deptno);
            return View("getDeptData",L);
        }
        public ActionResult getEmpddata()
        {
            list = empdataDB.Getdept();
            ViewBag.L = list;
            return View();
        }
        public ActionResult getdata()
        {

            int deptno = int.Parse(Request.QueryString["d"]);
            ViewBag.L = list;
            ViewBag.dnum = deptno; 
            List<EMPDATA> L = empdataDB.GetEmp(deptno);
            return View("getEmpddata",L);
        }
        public ActionResult getEmpno()
        {
            list1 = empdataDB.GetEno();
            ViewBag.En = list1;
            return View();
        }
        public ActionResult getdataEmp()
        {
            int eno = int.Parse(Request.Form["ddleno"]);
            string msg = empdataDB.delEmp(eno);
            ViewBag.En = empdataDB.GetEno();
            ViewBag.m = msg;
            return View("getEmpno");
        }
        public ActionResult EmpUpdate()
        {
            return View();
        }
        public ActionResult EmpnoUpdate()
        {
            int empno = int.Parse(Request.QueryString["empno"]);
            EMPDATA emp = empdataDB.GetEmpupdate(empno);
            return View("EmpUpdate", emp);
        }
       [HttpPost]
        public ActionResult ButtonUpdateEmp(EMPDATA E)
        {
            
            string m = empdataDB.GetEmpnoData(E);
            ViewBag.res = m;
            return View("EmpUpdate");
        }
        public ActionResult Empdate()
        {
            return View();
        }
        
        public ActionResult EmpdateShow()
        {
            DateTime start = DateTime.Parse(Request.Form["txtstart"]);
            DateTime end = DateTime.Parse(Request.Form["txtend"]);
            List<EMPDATA> L = empdataDB.searchOnDate(start,end);
            return View("Empdate",L);
        }
        public ActionResult EmpDeptnoDate()
        {
            list = empdataDB.Getdept();
            ViewBag.DL = list;
            return View();
        }
        public ActionResult EmpDeptnoSubmit()
        {
            string value = Request.Form["rdbHdDeptno"];
            
            if (value == "hiredate")
            {
                DateTime sdate = DateTime.Parse(Request.Form["txtStartDate"]);
                DateTime edate = DateTime.Parse(Request.Form["txtEndDate"]);
                list1 = empdataDB.searchOnDate(sdate, edate);
                return View("EmpDeptnoDate", list1);
            }
            else if (value == "deptno")
            {
                int deptno = int.Parse(Request.Form["ddlDeptno"]);
                List<EMPDATA> L = empdataDB.GetEmp(deptno);
                ViewBag.Dept = deptno;
                return View("EmpDeptnoDate", L);
            }
            return View("EmpDeptnoDate");
        }
        public ActionResult lis temp()
        {
            list1 = empdataDB.GetEno();
            return View(list1);
        }
        public ActionResult listShow()
        {
            int eno = Convert.ToInt32(Request.Form["eid"]);
            EMPDATA listnew = empdataDB.GetEmpupdate(eno);
            return View(listnew);
        }
    }
}