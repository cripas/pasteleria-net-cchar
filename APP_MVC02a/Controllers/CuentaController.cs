using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
//using APP_MVC02a.Filters;
using System.Web.Mvc;
using APP_MVC02a.Models;
using System.Data.Entity;

namespace APP_MVC02a.Controllers
{
   
 //   [InitializeSimpleMembership]
    public class CuentaController : Controller
    {
        //
        // GET: /Cuenta/
        bdpasteleliasEntities2 bd = new bdpasteleliasEntities2();

        public ActionResult Logueo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logueo(Cliente cli)
        {
           if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
            {
                if (verificaCliente(cli.email,cli.clave).Equals("cliente"))//Verificar que el email y clave exista utilizando el método privado
                {
                    FormsAuthentication.SetAuthCookie(cli.email, false); //crea variable de usuario con el correo del usuario
                    return RedirectToAction("Index", "Tienda"); //dirigir al controlador home vista Index una vez se a autenticado en el sistema
                }
                else if(verificaCliente(cli.email,cli.clave).Equals("empleado")){
                    // FormsAuthentication.SetAuthCookie(cli.email, false); 
                    var emp = bd.empleado.FirstOrDefault(e => e.email == cli.email && e.clave==cli.clave);
                    this.HttpContext.Session["sessionEmpleado"] = emp;
                    
                    return RedirectToAction("Index", "Producto"); 
                }               
            }
           ModelState.AddModelError("", "Usuario o contraseña es Incorrecto"); //adicionar mensaje de error al model
           return View(cli);
        }

     
        public ActionResult Registrar(string email_nuevo)
        {
            ViewData["email_nuevo"] = email_nuevo;
            Cliente cl = new Cliente();
            cl.email = email_nuevo;

            return View(cl);
        }

        [HttpPost]
        public ActionResult Registrar(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                int i = 0;

                if (cli.nombre == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de nombre");
                    i++;
                }
                if (cli.apePaterno == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de A.Paterno");
                    i++;
                }

                if (cli.apeMaterno == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de A. Materno");
                    i++;
                }
                if (cli.email == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de email");
                    i++;
                }
                if (cli.dni == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de dni");
                    i++;
                }
                if (cli.fechaNac == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de fecha nacimiento");
                    i++;
                }
                if (cli.clave == null)
                {
                    ModelState.AddModelError("", "Formato incorrecto de clave");
                    i++;
                }

                if (i > 0)
                {
                    return View(cli);
                }
                else
                {

                    cli.fechaRegistro = DateTime.Now;
                    cli.idestado = 1;
                    cli.idrol = 5;
                    bd.Cliente.Add(cli);
                    bd.SaveChanges();
                    FormsAuthentication.SetAuthCookie(cli.email, false); //crea variable de usuario con el correo del usuario
                    return RedirectToAction("Index", "Tienda");

                }



            }
            return View();

        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Tienda");
        }

       

        public ActionResult CerrarSesionEmp()
        {
            this.HttpContext.Session["sessionEmpleado"] = null;
            return RedirectToAction("Index","Tienda");
        }


        public ActionResult VerificaCliente(Cliente cli)
        {
            if (ModelState.IsValid)
            {

                if (cli.email == null)
                {
                    ViewData["error"] = "Por favor escriba un email";
                    return View("Logueo");
                }
                else
                {
                    if (verificaEmailCliente(cli.email))
                    {
                       
                        ViewData["error"] = "Ya existe usuario con el mismo correo electrónico";
                        return View("Logueo");

                    }
                }



            }
            return RedirectToAction("Registrar", "Cuenta", new { email_nuevo = cli.email });
        }

        [Authorize]
        public ActionResult MisPedidos() 
        {
            Cliente cl = getClienteLogueado(User.Identity.Name);
            var pedido = bd.pedido.Include(p => p.Cliente).Include(p => p.distrito).Include(p => p.estado).Include(p => p.tipo_compPago).Include(p => p.TIPO_PAGO).Where(p=>p.idCliente==cl.idCliente);
            return View(pedido.ToList());
        }

        [Authorize]
        public ActionResult SeguimientoPedidoC(int idPedido=-1)
        {
            Cliente cl = getClienteLogueado(User.Identity.Name);
            IQueryable<Seguimiento> resulta = null;

            if (idPedido != null)
            {
                resulta = bd.Seguimiento.Include("estado").Where(s => s.idCliente == cl.idCliente && s.idpedido == idPedido);
                resulta.OrderBy(x=>x.idestado);
            }

            return View(resulta);
        }


    /*   private bool verificaCliente2(string email, string password)
        {
            bool Isvalid = false;
            
            var user = bd.Cliente.FirstOrDefault(u => u.email == email); //consultar el primer registro con los el email del usuario
            if (user !=null)
            {
                if (user.clave == password) //Verificar password del usuario
                {
                    Isvalid = true;
                }
            }
        
            return Isvalid;
        }*/

        private string verificaCliente(string email, string password)
        {
            string Isvalid = "";

            var user = bd.Cliente.FirstOrDefault(u => u.email == email); //consultar el primer registro con los el email del usuario
            var emp = bd.empleado.FirstOrDefault(e => e.email == email);
            
           
            if (user != null)
            {
                if (user.clave == password) //Verificar password del usuario
                {
                    Isvalid = "cliente";
                }
            }

            if (emp != null)
            {
                if (emp.clave == password) //Verificar password del usuario
                {
                    Isvalid = "empleado";
                }
            }
            

            return Isvalid;
        }

        private bool verificaEmailCliente(string email_nuevo)
        {
            bool Isvalid = false;

            var user = bd.Cliente.FirstOrDefault(u => u.email == email_nuevo); //consultar el primer registro con los el email del usuario
            if (user != null)
            {
                Isvalid = true;
            }

            return Isvalid;
        }

        public Cliente getClienteLogueado(string email)
        {
            Cliente cli = bd.Cliente.FirstOrDefault(c => c.email == email);
            return cli;
        }
        

    }
}
