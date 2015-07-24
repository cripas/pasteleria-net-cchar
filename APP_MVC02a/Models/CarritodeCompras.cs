using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;
using System.Data;

namespace APP_MVC02a.Models
{
    public class CarritodeCompras
    {
        bdpasteleliasEntities2 storeBD = new bdpasteleliasEntities2();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public double igvfijo = 0.16;

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public static CarritodeCompras GetCart(HttpContextBase context)
        {
            var cart = new CarritodeCompras();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static CarritodeCompras GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        public void AddToCart(producto producto,int cantidad)
        {
            
            var cartItem = storeBD.Carrito.SingleOrDefault
                (c => c.CartId == ShoppingCartId && c.idproducto == producto.idproducto);

            if (cartItem == null)
            {
                cartItem = new Carrito
                {
                    idproducto = producto.idproducto,
                    CartId = ShoppingCartId,
                    Count = cantidad,
                    DateCreated = DateTime.Now
                };
                storeBD.Carrito.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            storeBD.SaveChanges();
        }



        public int RemoveFromCart(int id)
        {
            var cartItem = storeBD.Carrito.Single
                (cart => cart.CartId == ShoppingCartId && cart.RecordId == id);
            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeBD.Carrito.Remove(cartItem);
                }
                storeBD.SaveChanges();
            }

            return itemCount;
        }

        public int EliminarDelCarrito(int id)
        {
            var cartItem = storeBD.Carrito.Single
                (cart => cart.CartId == ShoppingCartId && cart.RecordId == id);
            int itemCount = 0;

            storeBD.Carrito.Remove(cartItem);

            itemCount = storeBD.SaveChanges();


            return itemCount;
        }




        public void EmptyCart()
        {
            var cartItems = storeBD.Carrito.Where(cart => cart.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                storeBD.Carrito.Remove(cartItem);
            }
            storeBD.SaveChanges();
        }

        public List<Carrito> GetCartItems()
        {
            return storeBD.Carrito.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in storeBD.Carrito
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeBD.Carrito
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.producto.precio).Sum();
            return total ?? 0;
        }

        public pedido CreateOrder(pedido pedido)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                var detallePedido = new pedido_productos
                {
                    idproducto = item.idproducto,
                    idpedido = pedido.idpedido,
                    precio = item.producto.precio,
                    cantidad = item.Count,
                    total = item.Count * item.producto.precio,

                };
                orderTotal +=(decimal) (item.Count * item.producto.precio);
                storeBD.pedido_productos.Add(detallePedido);
            }
           pedido.subTotal = orderTotal;
           pedido.igv = (decimal)igvfijo * orderTotal;
           pedido.totalpedido = pedido.subTotal + pedido.igv;
           
            storeBD.SaveChanges();
            EmptyCart();
            return pedido;

        }

        public string tablaDetalle()
        {
            string carritoTable = "";
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                carritoTable += "<tr> <td>" + item.producto.nomProducto + "</td> <td>S/. " + item.producto.precio + " </td> <td>" + item.Count + "</td> <td> S/. " + item.Count * item.producto.precio + "</td> </tr>";
            }
            return carritoTable;

        }











    }
}