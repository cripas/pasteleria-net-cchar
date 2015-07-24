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
    public class RolController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Rol/

        public ActionResult Index()
        {
            return View(db.rol.ToList());
        }

        //
        // GET: /Rol/Details/5

        public ActionResult Details(int id = 0)
        {
            rol rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // GET: /Rol/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rol/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(rol rol)
        {
            if (ModelState.IsValid)
            {
                db.rol.Add(rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rol);
        }

        //
        // GET: /Rol/Edit/5

        public ActionResult Edit(int id = 0)
        {
            rol rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // POST: /Rol/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        //
        // GET: /Rol/Delete/5

        public ActionResult Delete(int id = 0)
        {
            rol rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // POST: /Rol/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rol rol = db.rol.Find(id);
            db.rol.Remove(rol);
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