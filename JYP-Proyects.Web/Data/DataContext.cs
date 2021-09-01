

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

        public DbSet<Period> Periods { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }

        //TODO: sobreescribir el metodo onmodelcreating para la eliminacion de cascada

    }
}
