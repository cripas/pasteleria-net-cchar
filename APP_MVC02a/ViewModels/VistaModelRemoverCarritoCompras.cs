using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_MVC02a.ViewModels
{
    public class VistaModelRemoverCarritoCompras
    {
        public string Mensaje { get; set; }
        public decimal TotalCarrito { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }


    }
}