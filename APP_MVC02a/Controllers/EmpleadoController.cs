using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;

namespace APP_MVC02a.Controllers
{
    public class EmpleadoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.distrito).Include(e => e.estado).Include(e => e.rol);
            return View(empleado.ToList());
        }

        //
        // GET: /Empleado/Details/5

        public ActionResult Details(int id = 0)
        {
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //
        // GET: /Empleado/Create

        public ActionResult Create()
        {
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip");
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip");
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip");
            return View();
        }

        //
        // POST: /Empleado/Create

        [HttpPost]
        public ActionResult Create(empleado empleado)
        {
            //empleado.estado.idestado = 1;

            if (ModelState.IsValid)
            {
              
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip", empleado.iddistrito);
            ViewBag.idestado = new SelectList(db.estado, "idestado==1", "descrip", empleado.idestado==1);
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip", empleado.idrol);
            return View(empleado);
        }

        //
        // GET: /Empleado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip", empleado.iddistrito);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", empleado.idestado);
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip", empleado.idrol);
            return View(empleado);
        }

        //
        // POST: /Empleado/Edit/5

        [HttpPost]
        public ActionResult Edit(empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip", empleado.iddistrito);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", empleado.idestado);
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip", empleado.idrol);
            return View(empleado);
        }

        //
        // GET: /Empleado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //
        // POST: /Empleado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}