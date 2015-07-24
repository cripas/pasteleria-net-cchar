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
    public class ClienteController : Controller
    {
        //
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(e => e.rol).Include(e => e.estado);
            return View(cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip");
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip");
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            //cliente.estado.idestado = 1;

            if (ModelState.IsValid)
            {

                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.idestado = new SelectList(db.estado, "idestado==1", "descrip", cliente.idestado == 1);
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip", cliente.idrol);
            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", cliente.idestado);
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip", cliente.idrol);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", cliente.idestado);
            ViewBag.idrol = new SelectList(db.rol, "idrol", "descrip", cliente.idrol);
            return View(cliente);
        }

        //
        // GET: /Empleado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Empleado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
