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
    public class TipoMedidaController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /TipoMedida/

        public ActionResult Index()
        {
            return View(db.tipo_medida.ToList());
        }

        //
        // GET: /TipoMedida/Details/5

        public ActionResult Details(int id = 0)
        {
            tipo_medida tipo_medida = db.tipo_medida.Find(id);
            if (tipo_medida == null)
            {
                return HttpNotFound();
            }
            return View(tipo_medida);
        }

        //
        // GET: /TipoMedida/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoMedida/Create

        [HttpPost]
        public ActionResult Create(tipo_medida tipo_medida)
        {
            if (ModelState.IsValid)
            {
                db.tipo_medida.Add(tipo_medida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_medida);
        }

        //
        // GET: /TipoMedida/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipo_medida tipo_medida = db.tipo_medida.Find(id);
            if (tipo_medida == null)
            {
                return HttpNotFound();
            }
            return View(tipo_medida);
        }

        //
        // POST: /TipoMedida/Edit/5

        [HttpPost]
        public ActionResult Edit(tipo_medida tipo_medida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_medida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_medida);
        }

        //
        // GET: /TipoMedida/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipo_medida tipo_medida = db.tipo_medida.Find(id);
            if (tipo_medida == null)
            {
                return HttpNotFound();
            }
            return View(tipo_medida);
        }

        //
        // POST: /TipoMedida/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_medida tipo_medida = db.tipo_medida.Find(id);
            db.tipo_medida.Remove(tipo_medida);
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