//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_MVC02a.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class distrito
    {
        public distrito()
        {
            this.empleado = new HashSet<empleado>();
            this.pedido = new HashSet<pedido>();
        }
     [Column("iddistrito"), Key]
        public int iddistrito { get; set; }
        public string descrip { get; set; }
    
        public virtual ICollection<empleado> empleado { get; set; }
        public virtual ICollection<pedido> pedido { get; set; }
    }
}
