using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;
using System.IO;

namespace APP_MVC02a.Controllers
{
    public class ProductoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.categoriaProd).Include(p => p.estado);
            return View(producto.ToList());
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id = 0)
        {
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.idcategoriaProd = new SelectList(db.categoriaProd, "idcategoriaProd", "descrip");
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip");
            return View();
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        public ActionResult Create(producto producto, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                string nombreArchivo = "";
                if (archivo != null && archivo.ContentLength > 0)
                {
                    nombreArchivo = Path.GetFileName(archivo.FileName);
                    var path = Path.Combine(Server.MapPath("~/imagenes/productosimg/"), nombreArchivo);
                    archivo.SaveAs(path);
                }

                producto.nomFoto = nombreArchivo;

                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoriaProd = new SelectList(db.categoriaProd, "idcategoriaProd", "descrip", producto.idcategoriaProd);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", producto.idestado);
            return View(producto);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoriaProd = new SelectList(db.categoriaProd, "idcategoriaProd", "descrip", producto.idcategoriaProd);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", producto.idestado);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        public ActionResult Edit(producto producto, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                string nombreArchivo = "";
                if (archivo != null && archivo.ContentLength > 0)
                {
                    nombreArchivo = Path.GetFileName(archivo.FileName);
                    var path = Path.Combine(Server.MapPath("~/imagenes/productosimg/"), nombreArchivo);
                    archivo.SaveAs(path);
                    producto.nomFoto = nombreArchivo;
                }

                
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoriaProd = new SelectList(db.categoriaProd, "idcategoriaProd", "descrip", producto.idcategoriaProd);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", producto.idestado);
            return View(producto);
        }

        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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