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
    public class EstadoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Estado/

        public ActionResult Index()
        {
            return View(db.estado.ToList());
        }

        //
        // GET: /Estado/Details/5

        public ActionResult Details(int id = 0)
        {
            estado estado = db.estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        //
        // GET: /Estado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Estado/Create

        [HttpPost]
        public ActionResult Create(estado estado)
        {
            if (ModelState.IsValid)
            {
                db.estado.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        //
        // GET: /Estado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            estado estado = db.estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        //
        // POST: /Estado/Edit/5

        [HttpPost]
        public ActionResult Edit(estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        //
        // GET: /Estado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            estado estado = db.estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        //
        // POST: /Estado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            estado estado = db.estado.Find(id);
            db.estado.Remove(estado);
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