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
    public class EmpleadosController : Controller
    {
        private Model1Container1 db = new Model1Container1();

        public ActionResult Activos(string searching)
        {
            var empleados = db.EmpleadosSet.Include(e => e.Departamento).Include(e => e.Cargos);
            return View(empleados.Where(x => x.Nombre.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Inactivos(string searching)
        {
            var empleados = db.EmpleadosSet.Include(e => e.Departamento).Include(e => e.Cargos);
            return View(empleados.Where(x => x.Nombre.Contains(searching) || searching == null).ToList());
        }

        // GET: Empleados
        public ActionResult Index()
        {
            var empleadosSet = db.EmpleadosSet.Include(e => e.Departamento).Include(e => e.Cargos);
            return View(empleadosSet.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.EmpleadosSet.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentosId = new SelectList(db.DepartamentosSet, "Id", "Nombre");
            ViewBag.CargosId = new SelectList(db.CargosSet, "Id", "Cargo");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Fecha_Ingreso,Salario,Estatus,DepartamentosId,CargosId")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadosSet.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentosId = new SelectList(db.DepartamentosSet, "Id", "Nombre", empleados.DepartamentosId);
            ViewBag.CargosId = new SelectList(db.CargosSet, "Id", "Cargo", empleados.CargosId);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.EmpleadosSet.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentosId = new SelectList(db.DepartamentosSet, "Id", "Nombre", empleados.DepartamentosId);
            ViewBag.CargosId = new SelectList(db.CargosSet, "Id", "Cargo", empleados.CargosId);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Fecha_Ingreso,Salario,Estatus,DepartamentosId,CargosId")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentosId = new SelectList(db.DepartamentosSet, "Id", "Nombre", empleados.DepartamentosId);
            ViewBag.CargosId = new SelectList(db.CargosSet, "Id", "Cargo", empleados.CargosId);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.EmpleadosSet.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.EmpleadosSet.Find(id);
            db.EmpleadosSet.Remove(empleados);
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
