using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnew.Models
{
    public class empdataDB
    {
        static db4Entities D = D = new db4Entities();
        
        public static string insertEmp(EMPDATA Em)
        {
            try
            {
                D.EMPDATAs.Add(Em);
                D.SaveChanges();
            }
            catch(DbUpdateException d)
            { 
                SqlException ex=d.GetBaseException() as SqlException;
                if (ex.Message.Contains("EMP_PK"))
                    return "employee no cannot be dupicate";
                else if (ex.Message.Contains("FK__EMPDATA__DEPTNO__412EB0B6"))
                    return "no proper deptno";
                else
                    return "error occured";
            }
            return "done";
        }
        public static List<EMPDATA> GetEmp(int deptno)
        {
            var LE = from L in D.EMPDATAs
                     where L.DEPTNO == deptno
                     select L;
            return LE.ToList();
        }
        public static List<DEPTDATA> Getdept()
        {
            var LE = from L in D.DEPTDATAs
                     select L;
            return LE.ToList();
        }
        public static List<EMPDATA> GetEno()
        {
            var EN = from L in D.EMPDATAs
                     select L;
            return EN.ToList();
        }
        public static string delEmp(int empno)
        {
            var E = (from L in D.EMPDATAs
                     where L.EMPNO == empno
                     select L).FirstOrDefault();
            D.EMPDATAs.Remove(E);
            D.SaveChanges();
            return "record deleted";
        }
        public static EMPDATA GetEmpupdate(int Empno)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == Empno
                     select L;
            return LE.FirstOrDefault();
        }
        public static string GetEmpnoData(EMPDATA emp)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == emp.EMPNO
                     select L;
            EMPDATA E = LE.First();
                E.JOB = emp.JOB;
                E.MGR = emp.MGR;
                E.SAL = emp.SAL;
                E.COMM = emp.COMM;
                E.DEPTNO = emp.DEPTNO;
            
            D.SaveChanges();
            return "1 Row Updated";
        }
        public static List<EMPDATA> searchOnDate(DateTime start,DateTime end)
        {
            var L = from SE in D.EMPDATAs
                    where SE.HIREDATE >= start && SE.HIREDATE <= end
                    select SE;
            return L.ToList();
        }

    }
}