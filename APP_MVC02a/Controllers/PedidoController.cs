using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;
using System.Net.Mail;

namespace APP_MVC02a.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pedido()
        {
           
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip");
            ViewBag.idtipopago = new SelectList(db.TIPO_PAGO, "idtipopago", "descrip");
            ViewBag.idtipo_compPago = new SelectList(db.tipo_compPago, "idtipo_compPago", "descrip");
            Cliente cl = getClienteLogueado(User.Identity.Name);
            pedido ped = new pedido();
            ped.contacto_nom = cl.nombre;
            ped.contacto_ape = cl.apePaterno + " " + cl.apeMaterno;
            ped.contacto_mail = cl.email;
            
            return View(ped);
        }
        [HttpPost]
        public ActionResult Pedido(pedido pedido)
        {
            if (ModelState.IsValid)
            {
        //        pedido.subTotal= 23;
          //      pedido.igv = 2;
          //      pedido.totalpedido = 25;
                pedido.idestado = 3;
               
                if (Request.IsAuthenticated)
                {
                    Cliente cl = getClienteLogueado(User.Identity.Name);
                    pedido.idCliente = cl.idCliente;
                }
                else 
                {
                    pedido.idCliente = 1;
                }
                pedido.fechaPedido = DateTime.Now;
               // ViewData["miPedido"] = pedido;
                return View("Pago",pedido);
            }
            
            ViewBag.iddistrito = new SelectList(db.distrito, "iddistrito", "descrip");
          //  ViewBag.idtipopago = new SelectList(db.TIPO_PAGO, "idtipopago", "descrip");
            ViewBag.idtipo_compPago = new SelectList(db.tipo_compPago, "idtipo_compPago", "descrip");
            return View(pedido);
        }

        public ActionResult Pago()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pago(pedido pedido)
        {
            db.pedido.Add(pedido);
            db.SaveChanges();

            //Process the order
            var cart = CarritodeCompras.GetCart(this.HttpContext);
            string cartDetalle = cart.tablaDetalle();
            pedido ped = cart.CreateOrder(pedido);
            db.Entry(ped).State = EntityState.Modified;
            db.SaveChanges();
            enviarEmail(pedido.idpedido, cartDetalle);

            return RedirectToAction("Completo", new { idPed = pedido.idpedido });
        }


        public ActionResult Completo(int idPed)
        {
            pedido pedido = db.pedido.Find(idPed);
            return View(pedido);
        }

        public Cliente getClienteLogueado(string email)
        {
            Cliente cli = db.Cliente.FirstOrDefault(c => c.email == email);
            return cli;
        }

        public void enviarEmail(int idped,string carroDetalle)
        {
            pedido ped = db.pedido.Find(idped);

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("tortaselias@gmail.com", "Pasteleria SAN ELIAS");
            mm.To.Add(new MailAddress(ped.contacto_mail, ped.contacto_nom + " " + ped.contacto_ape));
            mm.Subject = "Su pedido " + ped.idpedido + " ha sido generado ";

            string carritoTable="<table id='xptContentMain' style='display:none;'> <tr><td> <span style='float:left'><img alt='tortas' src='~/imagenes/logoFinal.fw.png' height='90px' width='200px' ></span> <span style='float:right'><img alt='tortas' src='~/imagenes/viabcp.png' height='40px' width='200px' ></span> </td> <td align='right'><h3><b>Nro de Orden:" + ped.idpedido + "</b></h3></td></tr> <tr><td><h3>PERSONA DE CONTACTO</h3></td></tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Nombre:</strong></span> <span>" + ped.contacto_nom + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Apellidos:</strong></span> <span>" + ped.contacto_ape + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Email:</strong></span> <span>" + ped.contacto_mail + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Telefono Celular:</strong></span> <span>" + ped.contacto_movil + "</span> </div> </td> </tr> <tr><td><h3>Datos del Pedido</h3></td></tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Tipo de Entrega:</strong></span> <span>" + ped.tipoentrega + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Fecha de Entrega:</strong></span> <span>" + ped.fechaentrega + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Fecha del Pedido:</strong></span> <span>" + ped.fechaPedido + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Comprobante de Pago:</strong></span> <span>" + getTipoComPago(ped.idtipo_compPago) + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Medio de Pago:</strong></span> <span>" + getTipoPago(ped.idtipopago) + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>RUC:</strong></span> <span>" + ped.ruc + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Razon Social:</strong></span> <span>" + ped.razonsocial + "</span> </div> </td> </tr> <tr><td><h3>Direccion de Entrega</h3></td></tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Direccion:</strong></span> <span>" + ped.entrega_dir + "</span> </div> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Urbanizacion:</strong></span> <span>" + ped.entrega_urba + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Distrito:</strong></span> <span>" + getDistrito(ped.iddistrito) + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>Referencia:</strong></span> <span>" + ped.entrega_ref + "</span> </div> </td> </tr> <tr><td><h3>Detalle del Pedido</h3></td></tr>";
            
            carritoTable += "<tr> <td style='overflow:hidden;'> <table> <tr> <td> Producto </td> <td> Precio </td> <td> Cantidad </td> <td> Total </td> </tr>";
            carritoTable += carroDetalle;
            carritoTable += "</table></td></tr>";
            carritoTable += " <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>SubTotal: </strong></span> <span>" + ped.subTotal + "</span> </div> </td> </tr> <tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>IGV:</strong></span> <span>" + ped.igv + "</span> </div> </td> </tr> <tr> <td style='overflow:hidden;'> <div class='tituloResolucion' style='margin-left:15px; text-align: justify;'> <span><strong>TOTAL:</strong></span> <span>" + ped.totalpedido + "</span> </div> </td> </table>";
            mm.Body = carritoTable;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("tortaselias@gmail.com", "mistortas");
            smtp.Send(mm);
        }
        public string getDistrito(int id)
        {
            var dis = db.distrito.SingleOrDefault(d => d.iddistrito == id);
            return dis.descrip;
        }
        public string getTipoComPago(int id)
        {
            var dis = db.tipo_compPago.SingleOrDefault(d => d.idtipo_compPago == id);
            return dis.descrip;
        }

        public string getTipoPago(int id)
        {
            var dis = db.TIPO_PAGO.SingleOrDefault(d => d.idtipopago == id);
            return dis.descrip;
        }



    }
}
