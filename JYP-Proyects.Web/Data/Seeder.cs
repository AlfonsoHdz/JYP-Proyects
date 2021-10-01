using System;
using System.Collections.Generic;



namespace JYP_Proyects.Web.Data
{
    using JYP_Proyects.Web.Data.Entities;
    using System.Threading.Tasks;
    using System.Linq;

    public class Seeder
    {
        private readonly DataContext dataContext;

        public Seeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();

            


            //
            if (!this.dataContext.CVehiculos.Any())
            {
               await CheckVehiculo("Tsuru", "Tsuru tuneado", "2000", 100000);
               await CheckVehiculo("Sentra", "Sentra tuneado", "2005", 300000);
               await CheckVehiculo("Vocho", "Vocho tuneado", "2006", 200000);
               await CheckVehiculo("Lamborghini", "Lamborghini tuneado", "2020", 1000000);

                
            }

            if (!this.dataContext.CAgencias.Any())
            {
                await CheckAgencia("Jyp Proyects", "La mejor agencia", "Camino Real", "25242826", "jtp@gamil.com");
            }

            if (!this.dataContext.CBodegas.Any())
            {
                await CheckBodega("25", "Bodega de 3 naves");
            }

            if (!this.dataContext.CInventarios.Any())
            {
                await CheckInventario("21");
            }

            if (!this.dataContext.CVentas.Any())
            {
                await CheckVenta("21/02/2021","Coche de 4 puertas", 222000);
            }

        }
        //

        //Metodos
        //
        private async Task CheckVehiculo(string name, string descripcionV, string año, double precio)
        {
            this.dataContext.CVehiculos.Add(new CVehiculo { Nombre = name, DescripcionV = descripcionV , Año = año, Precio = precio });
            
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckAgencia(string name, string descripcion, string direccion, string telefono, string correo)
        {
            this.dataContext.CAgencias.Add(new CAgencia { Nombre = name, Descripcion = descripcion, Direccion = direccion, Telefono = telefono, Correo = correo });

            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckBodega( string cupo, string descripcion)
        {
            this.dataContext.CBodegas.Add(new CBodega {Cupo = cupo, Descripcion = descripcion });

            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckInventario(string cantidadAutos)
        {
            this.dataContext.CInventarios.Add(new CInventario { CantidadAutos = cantidadAutos });

            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckVenta(string fechaV, string descripcionV, double costoV)
        {
            this.dataContext.CVentas.Add(new CVenta { FechaV = fechaV, DescripcionV = descripcionV, CostoV= costoV });

            await this.dataContext.SaveChangesAsync();
        }


    }
}
