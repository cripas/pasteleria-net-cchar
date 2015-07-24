using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;
using System.Data.Entity;
using System.Data;
using APP_MVC02a.hilos;
using System.Threading; 


namespace APP_MVC02a.Controllers
{
    public class SeguimientoController : Controller
    {
        //
        // GET: /Seguimiento/

        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        public ActionResult Index()
        {
            var pedido = db.pedido.Include(p => p.Cliente).Include(p => p.distrito).Include(p => p.estado).Include(p => p.tipo_compPago).Include(p => p.TIPO_PAGO);
           
            return View(pedido.ToList());
        }
        public ActionResult Seguimiento(int idPedido)
        {
            var pedido = db.pedido.Include(p => p.Cliente).Include(p => p.distrito).Include(p => p.estado).Include(p => p.tipo_compPago).Include(p => p.TIPO_PAGO).FirstOrDefault(p => p.idpedido == idPedido);
            var pro_ped = db.pedido_productos.Include(p => p.producto).Where(pp => pp.idpedido == idPedido);
          //  ViewData["nomFoto"] = pro_ped.producto.nomFoto;
           // ViewData["nomProducto"] = pro_ped.producto.nomProducto;
            ViewData["pedido"] = pedido;
        //    ViewData["estados"] = db.estado.Where(e => e.cnPedido == 1);
            return View(pro_ped);
        }
        public ActionResult cambiaEstado(int idPedido)
        {
            var pedido = db.pedido.Include(p => p.Cliente).Include(p => p.distrito).Include(p => p.estado).Include(p => p.tipo_compPago).Include(p => p.TIPO_PAGO).FirstOrDefault(p => p.idpedido == idPedido);
            pedido.idestado = pedido.idestado + 1;
            db.Entry(pedido).State = EntityState.Modified;
            db.SaveChanges();

            pedido ped = pedido;

            HiloLlamada h1 = new HiloLlamada(ped);
            Thread hllamada = new Thread(new ThreadStart(h1.lanzar));
            hllamada.Start();

            return RedirectToAction("Index");
        }

        public ActionResult rechazarPedido(int idPedido)
        {
            var pedido = db.pedido.Include(p => p.Cliente).Include(p => p.distrito).Include(p => p.estado).Include(p => p.tipo_compPago).Include(p => p.TIPO_PAGO).FirstOrDefault(p => p.idpedido == idPedido);
            pedido.idestado = 10;
            db.Entry(pedido).State = EntityState.Modified;
            db.SaveChanges();

            pedido ped = pedido;

            HiloLlamada h1 = new HiloLlamada(ped);
            Thread hllamada = new Thread(new ThreadStart(h1.lanzar));
            hllamada.Start();

            return RedirectToAction("Index");
        }

    }
}
