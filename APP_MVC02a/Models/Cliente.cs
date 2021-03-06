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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.pedido = new HashSet<pedido>();
            this.Seguimiento = new HashSet<Seguimiento>();
        }
     [Column("idCliente"), Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
        public string ruc { get; set; }
        public Nullable<System.DateTime> fechaNac { get; set; }
        public Nullable<System.DateTime> fechaRegistro { get; set; }
        public int idrol { get; set; }
        public int idestado { get; set; }
        public string clave { get; set; }
    
        public virtual estado estado { get; set; }
        public virtual rol rol { get; set; }
        public virtual ICollection<pedido> pedido { get; set; }
        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
    }
}
