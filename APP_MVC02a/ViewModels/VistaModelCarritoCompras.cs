using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APP_MVC02a.Models;

namespace APP_MVC02a.ViewModels
{
    public class VistaModelCarritoCompras
    {
        public List<Carrito> CarritoItems{ get; set; }
        public decimal CarritoTotal { get; set; }
    }
}