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
    public class LicenciasController : Controller
    {
        private Model1Container1 db = new Model1Container1();

        // GET: Licencias
        public ActionResult Index()
        {
            var licenciasSet = db.LicenciasSet.Include(l => l.Empleado);
            return View(licenciasSet.ToList());
        }

        // GET: Licencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias licencias = db.LicenciasSet.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // GET: Licencias/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado");
            return View();
        }

        // POST: Licencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Desde,Hasta,Motivo,Comentario,EmpleadosId")] Licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.LicenciasSet.Add(licencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", licencias.EmpleadosId);
            return View(licencias);
        }

        // GET: Licencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias licencias = db.LicenciasSet.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", licencias.EmpleadosId);
            return View(licencias);
        }

        // POST: Licencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Desde,Hasta,Motivo,Comentario,EmpleadosId")] Licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", licencias.EmpleadosId);
            return View(licencias);
        }

        // GET: Licencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias licencias = db.LicenciasSet.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // POST: Licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licencias licencias = db.LicenciasSet.Find(id);
            db.LicenciasSet.Remove(licencias);
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
