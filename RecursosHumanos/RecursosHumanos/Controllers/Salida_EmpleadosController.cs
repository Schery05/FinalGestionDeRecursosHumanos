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
    public class Salida_EmpleadosController : Controller
    {
        private Model1Container1 db = new Model1Container1();

        // GET: Salida_Empleados
        public ActionResult Index()
        {
            var salida_EmpleadosSet = db.Salida_EmpleadosSet.Include(s => s.Empleados);
            return View(salida_EmpleadosSet.ToList());
        }

        // GET: Salida_Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleados salida_Empleados = db.Salida_EmpleadosSet.Find(id);
            if (salida_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleados);
        }

        // GET: Salida_Empleados/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado");
            return View();
        }

        // POST: Salida_Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo_Salida,Motivo,Fecha_Salida,EmpleadosId")] Salida_Empleados salida_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Salida_EmpleadosSet.Add(salida_Empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", salida_Empleados.EmpleadosId);
            return View(salida_Empleados);
        }

        // GET: Salida_Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleados salida_Empleados = db.Salida_EmpleadosSet.Find(id);
            if (salida_Empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", salida_Empleados.EmpleadosId);
            return View(salida_Empleados);
        }

        // POST: Salida_Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo_Salida,Motivo,Fecha_Salida,EmpleadosId")] Salida_Empleados salida_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida_Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadosId = new SelectList(db.EmpleadosSet, "Id", "Codigo_Empleado", salida_Empleados.EmpleadosId);
            return View(salida_Empleados);
        }

        // GET: Salida_Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleados salida_Empleados = db.Salida_EmpleadosSet.Find(id);
            if (salida_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleados);
        }

        // POST: Salida_Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida_Empleados salida_Empleados = db.Salida_EmpleadosSet.Find(id);
            db.Salida_EmpleadosSet.Remove(salida_Empleados);
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
