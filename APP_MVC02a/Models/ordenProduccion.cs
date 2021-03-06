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
    
    public partial class ordenProduccion
    {
        public ordenProduccion()
        {
            this.maquinaria = new HashSet<maquinaria>();
            this.empleado = new HashSet<empleado>();
        }
     [Column("idordenProduccion"), Key]
        public int idordenProduccion { get; set; }
        public int idpedido { get; set; }
        public int idestado { get; set; }
    
        public virtual datosProduccion datosProduccion { get; set; }
        public virtual estado estado { get; set; }
        public virtual pedido pedido { get; set; }
        public virtual ICollection<maquinaria> maquinaria { get; set; }
        public virtual ICollection<empleado> empleado { get; set; }
    }
}
