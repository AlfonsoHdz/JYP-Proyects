

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data
{
    using JYP_Proyects.Web.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<User>

    {

        

        public DbSet<CAgencia> CAgencias { get; set; }

        public DbSet<CAgentes_Venta> CAgentes_Ventas { get; set; }

        public DbSet<CBodega> CBodegas { get; set; }

        public DbSet<CCliente> CClientes { get; set; }

        public DbSet<CCompra> CCompras { get; set; }
        public DbSet<CInventario> CInventarios { get; set; }
        public DbSet<CProveedor> CProveedores { get; set; }

        public DbSet<CVehiculo> CVehiculos { get; set; }

        public DbSet<CVenta> CVentas { get; set; }

















        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }

        //TODO: sobreescribir el metodo onmodelcreating para la eliminacion de cascada

    }
}
