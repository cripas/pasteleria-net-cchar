using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;

namespace APP_MVC02a.Controllers
{
    public class TiendaController : Controller
    {
        //
        // GET: /Tienda/
        bdpasteleliasEntities2 storeBD = new bdpasteleliasEntities2();

        public ActionResult Index(int idCategoria=0)
        {
             if (idCategoria == 0)
            {
                var lstProductos = storeBD.producto.ToList();
                return View(lstProductos);
            }
             var lstProductos2 = storeBD.producto.Where(p=>p.idcategoriaProd==idCategoria);

            return View(lstProductos2);
        }

        public ActionResult Detalle(int idproducto)
        {
            var producto = storeBD.producto.Find(idproducto);
            return View(producto);
        }

        public ActionResult Carrito()
        {
            return View();
        }

        public ActionResult Buscar(string search_query_top)
        {
            var lstProductos = storeBD.producto.Where(p => p.nomProducto.Contains(search_query_top));
            return View("Index",lstProductos);
        }
    }
}
