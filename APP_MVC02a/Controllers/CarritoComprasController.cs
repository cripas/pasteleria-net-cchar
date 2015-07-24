using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;
using APP_MVC02a.ViewModels;

namespace APP_MVC02a.Controllers
{
    public class CarritoComprasController : Controller
    {
        //
        // GET: /CarritoCompras/

        bdpasteleliasEntities2 storeDB = new bdpasteleliasEntities2();

        public ActionResult Index()
        {
            var carrito = CarritodeCompras.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new VistaModelCarritoCompras
            {
                CarritoItems = carrito.GetCartItems(),
                CarritoTotal = carrito.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }


        public ActionResult AddToCart(int id,int cant)
        {

            Console.WriteLine("codigo del producto a agregar", id); 
            // Retrieve the album from the database
            var addedProducto = storeDB.producto
            .Single(producto => producto.idproducto== id);
            // Add it to the shopping cart
            var carrito = CarritodeCompras.GetCart(this.HttpContext);
            carrito.AddToCart(addedProducto,cant);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var carrito = CarritodeCompras.GetCart(this.HttpContext);
            // Get the name of the album to display confirmation
            string nombreProducto = storeDB.Carrito
            .Single(item => item.RecordId == id).producto.descProd;
            // Remove from cart
            int itemCount = carrito.RemoveFromCart(id);
            // Display the confirmation message
            var results = new VistaModelRemoverCarritoCompras
            {
                Mensaje = Server.HtmlEncode(nombreProducto) +
                " ha sido removido de su carrito de compras.",
                TotalCarrito  = carrito.GetTotal(),
                CartCount = carrito.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [HttpPost]
        public ActionResult EliminarDelCarrito(int id)
        {
            // Remove the item from the cart
            var carrito = CarritodeCompras.GetCart(this.HttpContext);
            // Get the name of the album to display confirmation
            string nombreProducto = storeDB.Carrito
            .Single(item => item.RecordId == id).producto.nomProducto;
            // Remove from cart
            int itemCount = carrito.EliminarDelCarrito(id);
            // Display the confirmation message
            var results = new VistaModelRemoverCarritoCompras
            {
                Mensaje = Server.HtmlEncode(nombreProducto) +
                " ha sido removido de su carrito de compras.",
                TotalCarrito = carrito.GetTotal(),
                CartCount = carrito.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }



        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var carrito = CarritodeCompras.GetCart(this.HttpContext);
            ViewData["CartCount"] = carrito.GetCount();
            return PartialView("CartSummary");
        }













    }
}
