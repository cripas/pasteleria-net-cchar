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
    public class DistritoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Distrito/

        public ActionResult Index()
        {
            return View(db.distrito.ToList());
        }

        //
        // GET: /Distrito/Details/5

        public ActionResult Details(int id = 0)
        {
            distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        //
        // GET: /Distrito/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Distrito/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.distrito.Add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distrito);
        }

        //
        // GET: /Distrito/Edit/5

        public ActionResult Edit(int id = 0)
        {
            distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        //
        // POST: /Distrito/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distrito);
        }

        //
        // GET: /Distrito/Delete/5

        public ActionResult Delete(int id = 0)
        {
            distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        //
        // POST: /Distrito/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            distrito distrito = db.distrito.Find(id);
            db.distrito.Remove(distrito);
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