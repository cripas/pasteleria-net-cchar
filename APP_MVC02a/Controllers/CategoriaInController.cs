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
    public class CategoriaInController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /CategoriaIn/

        public ActionResult Index()
        {
            return View(db.categoriaIn.ToList());
        }

        //
        // GET: /CategoriaIn/Details/5

        public ActionResult Details(int id = 0)
        {
            categoriaIn categoriain = db.categoriaIn.Find(id);
            if (categoriain == null)
            {
                return HttpNotFound();
            }
            return View(categoriain);
        }

        //
        // GET: /CategoriaIn/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoriaIn/Create

        [HttpPost]
        public ActionResult Create(categoriaIn categoriain)
        {
            if (ModelState.IsValid)
            {
                db.categoriaIn.Add(categoriain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriain);
        }

        //
        // GET: /CategoriaIn/Edit/5

        public ActionResult Edit(int id = 0)
        {
            categoriaIn categoriain = db.categoriaIn.Find(id);
            if (categoriain == null)
            {
                return HttpNotFound();
            }
            return View(categoriain);
        }

        //
        // POST: /CategoriaIn/Edit/5

        [HttpPost]
        public ActionResult Edit(categoriaIn categoriain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriain);
        }

        //
        // GET: /CategoriaIn/Delete/5

        public ActionResult Delete(int id = 0)
        {
            categoriaIn categoriain = db.categoriaIn.Find(id);
            if (categoriain == null)
            {
                return HttpNotFound();
            }
            return View(categoriain);
        }

        //
        // POST: /CategoriaIn/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            categoriaIn categoriain = db.categoriaIn.Find(id);
            db.categoriaIn.Remove(categoriain);
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