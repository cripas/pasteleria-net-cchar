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
    public class InsumoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Insumo/

        public ActionResult Index()
        {
            var insumo = db.insumo.Include(i => i.categoriaIn).Include(i => i.tipo_medida);
            return View(insumo.ToList());
        }

        //
        // GET: /Insumo/Details/5

        public ActionResult Details(int id = 0)
        {
            insumo insumo = db.insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        //
        // GET: /Insumo/Create

        public ActionResult Create()
        {
            ViewBag.idcategoriaIn = new SelectList(db.categoriaIn, "idcategoriaIn", "descrip");
            ViewBag.idtipo_medida = new SelectList(db.tipo_medida, "idtipo_medida", "descrip");
            return View();
        }

        //
        // POST: /Insumo/Create

        [HttpPost]
        public ActionResult Create(insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.insumo.Add(insumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoriaIn = new SelectList(db.categoriaIn, "idcategoriaIn", "descrip", insumo.idcategoriaIn);
            ViewBag.idtipo_medida = new SelectList(db.tipo_medida, "idtipo_medida", "descrip", insumo.idtipo_medida);
            return View(insumo);
        }

        //
        // GET: /Insumo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            insumo insumo = db.insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoriaIn = new SelectList(db.categoriaIn, "idcategoriaIn", "descrip", insumo.idcategoriaIn);
            ViewBag.idtipo_medida = new SelectList(db.tipo_medida, "idtipo_medida", "descrip", insumo.idtipo_medida);
            return View(insumo);
        }

        //
        // POST: /Insumo/Edit/5

        [HttpPost]
        public ActionResult Edit(insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoriaIn = new SelectList(db.categoriaIn, "idcategoriaIn", "descrip", insumo.idcategoriaIn);
            ViewBag.idtipo_medida = new SelectList(db.tipo_medida, "idtipo_medida", "descrip", insumo.idtipo_medida);
            return View(insumo);
        }

        //
        // GET: /Insumo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            insumo insumo = db.insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        //
        // POST: /Insumo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            insumo insumo = db.insumo.Find(id);
            db.insumo.Remove(insumo);
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