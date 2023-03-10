using Microsoft.SqlServer.Server;
using MvcGlAtelier2023.Models;
using MVCGLATELIER2023.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGlAtelier2023.Controllers
{
    public class EmployeeController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(db.employees.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            db.employees.Add(emp);
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetbyID(int ID)
        {
             Employee emp= db.employees.Find(ID);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            Employee e = db.employees.Find(emp.Id);
            e.Name = emp.Name;
            e.Country = emp.Country;
            e.State = emp.State;
            e.Age = emp.Age;
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            Employee e = db.employees.Find(ID);
            db.employees.Remove(e);
            db.SaveChanges();
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public DataTable GetTableEmployees()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Country", typeof(string));

            var liste = db.employees.ToList();
            foreach (var i in liste)
            {
     table.Rows.Add(i.Name, i.Age, i.State, i.Country);
            }
         
            return table;

        }

        public ActionResult ReportEmployees()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument Rpt
           = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {
                Rpt.Load(Server.MapPath("~/Report/rpt.rpt"));
                Rpt.SetDataSource(GetTableEmployees());
                Stream stream =
               Rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.AppendHeader("Content-Disposition", "inline");
                return File(stream, "application/pdf");
            }
            finally
            {
                Rpt.Dispose();
                Rpt.Close();
            }
        }

    }
}