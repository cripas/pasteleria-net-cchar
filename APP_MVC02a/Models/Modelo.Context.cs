﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bdpasteleliasEntities2 : DbContext
    {
        public bdpasteleliasEntities2()
            : base("name=bdpasteleliasEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<categoriaIn> categoriaIn { get; set; }
        public DbSet<categoriaProd> categoriaProd { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<datosProduccion> datosProduccion { get; set; }
        public DbSet<distrito> distrito { get; set; }
        public DbSet<empleado> empleado { get; set; }
        public DbSet<estado> estado { get; set; }
        public DbSet<estadoPed> estadoPed { get; set; }
        public DbSet<insumo> insumo { get; set; }
        public DbSet<insumo_proveedor> insumo_proveedor { get; set; }
        public DbSet<maquinaria> maquinaria { get; set; }
        public DbSet<opciones> opciones { get; set; }
        public DbSet<ordenProduccion> ordenProduccion { get; set; }
        public DbSet<PAGO> PAGO { get; set; }
        public DbSet<pedido> pedido { get; set; }
        public DbSet<pedido_estados> pedido_estados { get; set; }
        public DbSet<pedido_productos> pedido_productos { get; set; }
        public DbSet<producto> producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<rol> rol { get; set; }
        public DbSet<Seguimiento> Seguimiento { get; set; }
        public DbSet<tipo_compPago> tipo_compPago { get; set; }
        public DbSet<tipo_medida> tipo_medida { get; set; }
        public DbSet<TIPO_PAGO> TIPO_PAGO { get; set; }
    }
}