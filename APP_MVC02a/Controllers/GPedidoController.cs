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
    public class GPedidoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        //
        // GET: /GPedido/

        public ActionResult Index()
        {
            var pedido = db.pedido.Include(p => p.Cliente).Include(p => p.distrito).Include(p => p.estado).Include(p => p.tipo_compPago).Include(p => p.TIPO_PAGO);
            return View(pedido.ToList());
        }

        //
        // GET: /GPedido/Details/5

        public ActionResult Details(int id = 0)
        {
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // GET: /GPedido/Create

        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip");
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip");
            ViewBag.idtipo_compPago = new SelectList(db.tipo_compPago, "idtipo_compPago", "descrip");
            ViewBag.idtipopago = new SelectList(db.TIPO_PAGO, "idtipopago", "descrip");
            return View();
        }

        //
        // POST: /GPedido/Create

        [HttpPost]
        public ActionResult Create(pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", pedido.idCliente);
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip", pedido.iddistrito);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", pedido.idestado);
            ViewBag.idtipo_compPago = new SelectList(db.tipo_compPago, "idtipo_compPago", "descrip", pedido.idtipo_compPago);
            ViewBag.idtipopago = new SelectList(db.TIPO_PAGO, "idtipopago", "descrip", pedido.idtipopago);
            return View(pedido);
        }

        //
        // GET: /GPedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", pedido.idCliente);
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip", pedido.iddistrito);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", pedido.idestado);
            ViewBag.idtipo_compPago = new SelectList(db.tipo_compPago, "idtipo_compPago", "descrip", pedido.idtipo_compPago);
            ViewBag.idtipopago = new SelectList(db.TIPO_PAGO, "idtipopago", "descrip", pedido.idtipopago);
            return View(pedido);
        }

        //
        // POST: /GPedido/Edit/5

        [HttpPost]
        public ActionResult Edit(pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", pedido.idCliente);
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip", pedido.iddistrito);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descrip", pedido.idestado);
            ViewBag.idtipo_compPago = new SelectList(db.tipo_compPago, "idtipo_compPago", "descrip", pedido.idtipo_compPago);
            ViewBag.idtipopago = new SelectList(db.TIPO_PAGO, "idtipopago", "descrip", pedido.idtipopago);
            return View(pedido);
        }

        //
        // GET: /GPedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // POST: /GPedido/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            pedido pedido = db.pedido.Find(id);
            db.pedido.Remove(pedido);
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