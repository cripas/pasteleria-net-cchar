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
    
    public partial class Proveedor
    {
        public Proveedor()
        {
            this.insumo_proveedor = new HashSet<insumo_proveedor>();
        }
         [Column("idProveedor"), Key]

        public int idProveedor { get; set; }
        public string nomProveedor { get; set; }
        public string numero { get; set; }
    
        public virtual ICollection<insumo_proveedor> insumo_proveedor { get; set; }
    }
}
