using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers
{
    public class Cal_NominaController : Controller
    {
        private Model1Container1 db = new Model1Container1();

        // GET: Cal_Nomina
        public ActionResult Index()
        {
            var cal_NominaSet = db.Cal_NominaSet.Include(c => c.Empleado);
            return View(cal_NominaSet.ToList());
        }

        // GET: Cal_Nomina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_Nomina cal_Nomina = db.Cal_NominaSet.Find(id);
            if (cal_Nomina == null)
            {
                return HttpNotFound();
            }
            return View(cal_Nomina);
        }

        // GET: Cal_Nomina/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado");
            Cal_Nomina cargo = new Cal_Nomina();

            cargo.Monto_Total = Convert.ToInt32(db.EmpleadosSet.Sum(a => a.Salario));
            ViewBag.TotalNomina = db.EmpleadosSet.Sum(a => a.Salario);

            return View();
        }

        // POST: Cal_Nomina/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ano,Mes,Monto_Total,EmpleadosId")] Cal_Nomina cal_Nomina)
        {
            if (ModelState.IsValid)
            {
                db.Cal_NominaSet.Add(cal_Nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", cal_Nomina.EmpleadosId);
            return View(cal_Nomina);
        }

        // GET: Cal_Nomina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_Nomina cal_Nomina = db.Cal_NominaSet.Find(id);
            if (cal_Nomina == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", cal_Nomina.EmpleadosId);
            return View(cal_Nomina);
        }

        // POST: Cal_Nomina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ano,Mes,Monto_Total,EmpleadosId")] Cal_Nomina cal_Nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cal_Nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", cal_Nomina.EmpleadosId);
            return View(cal_Nomina);
        }

        // GET: Cal_Nomina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_Nomina cal_Nomina = db.Cal_NominaSet.Find(id);
            if (cal_Nomina == null)
            {
                return HttpNotFound();
            }
            return View(cal_Nomina);
        }

        // POST: Cal_Nomina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cal_Nomina cal_Nomina = db.Cal_NominaSet.Find(id);
            db.Cal_NominaSet.Remove(cal_Nomina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
