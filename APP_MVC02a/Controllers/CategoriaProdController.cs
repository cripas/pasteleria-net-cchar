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
    public class CategoriaProdController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /CategoriaProd/

        public ActionResult Index()
        {
            return View(db.categoriaProd.ToList());
        }

        //
        // GET: /CategoriaProd/Details/5

        public ActionResult Details(int id = 0)
        {
            categoriaProd categoriaprod = db.categoriaProd.Find(id);
            if (categoriaprod == null)
            {
                return HttpNotFound();
            }
            return View(categoriaprod);
        }

        //
        // GET: /CategoriaProd/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoriaProd/Create

        [HttpPost]
        public ActionResult Create(categoriaProd categoriaprod)
        {
            if (ModelState.IsValid)
            {
                db.categoriaProd.Add(categoriaprod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaprod);
        }

        //
        // GET: /CategoriaProd/Edit/5

        public ActionResult Edit(int id = 0)
        {
            categoriaProd categoriaprod = db.categoriaProd.Find(id);
            if (categoriaprod == null)
            {
                return HttpNotFound();
            }
            return View(categoriaprod);
        }

        //
        // POST: /CategoriaProd/Edit/5

        [HttpPost]
        public ActionResult Edit(categoriaProd categoriaprod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaprod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaprod);
        }

        //
        // GET: /CategoriaProd/Delete/5

        public ActionResult Delete(int id = 0)
        {
            categoriaProd categoriaprod = db.categoriaProd.Find(id);
            if (categoriaprod == null)
            {
                return HttpNotFound();
            }
            return View(categoriaprod);
        }

        //
        // POST: /CategoriaProd/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            categoriaProd categoriaprod = db.categoriaProd.Find(id);
            db.categoriaProd.Remove(categoriaprod);
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