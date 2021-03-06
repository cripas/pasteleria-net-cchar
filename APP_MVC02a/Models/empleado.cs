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
    
    public partial class empleado
    {
        public empleado()
        {
            this.Seguimiento = new HashSet<Seguimiento>();
            this.ordenProduccion = new HashSet<ordenProduccion>();
        }
        [Column("idempleado"), Key]
        public int idempleado { get; set; }

        [Required(ErrorMessage = "El Nombre es dato requerido"), StringLength(100)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es dato requerido"), StringLength(100)]
        public string apePat { get; set; }

        [Required(ErrorMessage = "EL Apellido Materno es dato requerido"), StringLength(100)]
        public string apeMate { get; set; }

        [Required(ErrorMessage = "La Direccion es dato requerido"), StringLength(300)]
        public string direccion { get; set; }

        [Required(ErrorMessage = "El DNI es un dato requerido"), RegularExpression("^[0-9]{8}", ErrorMessage = "Son 8 los digitos para el DNI")]
        public string dni { get; set; }

        [Required(ErrorMessage = "El email es dato requerido"),
       RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Formato de email no válido")]
        public string email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public Nullable<System.DateTime> fechaRegistro { get; set; }

        [Required(ErrorMessage = "La clave es dato requerido para ingreso al sistema")]
        public string clave { get; set; }

        public int idestado { get; set; }

        [Required(ErrorMessage = "Debe elegir un rol")]
        public int idrol { get; set; }

        [Required(ErrorMessage = "Debe elegir un distrito")]
        public int iddistrito { get; set; }
    
        public virtual distrito distrito { get; set; }
        public virtual estado estado { get; set; }
        public virtual rol rol { get; set; }
        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
        public virtual ICollection<ordenProduccion> ordenProduccion { get; set; }
    }
}
