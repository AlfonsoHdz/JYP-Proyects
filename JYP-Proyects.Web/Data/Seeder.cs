using System;
using System.Collections.Generic;



namespace JYP_Proyects.Web.Data
{
    using JYP_Proyects.Web.Data.Entities;
    using System.Threading.Tasks;
    using System.Linq;
    using JYP_Proyects.Web.Helper;
    using Microsoft.AspNetCore.Identity;

    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();

            //Roles de usuario
            await userHelper.CheckRoleAsync("SaleAgent");
            await userHelper.CheckRoleAsync("Client");
            await userHelper.CheckRoleAsync("Provider");

            //Alta de usuarios
            if (!this.dataContext.CAgentes_Ventas.Any())
            {
                var user = await CheckUser("Juan","Mendez","222526287","juan@gmail.com","12345");
                await CheckAgent(user, "SaleAgent");
                
            }

            if (!this.dataContext.CClientes.Any())
            {
                var user = await CheckUser("Pedro", "Palacios", "22262824", "palacios@gmail.com", "54321");
                await CheckClient(user, "Client");

            }

            if (!this.dataContext.CProveedores.Any())
            {
                var user = await CheckUser("Jesse", "Cerezo", "22272924", "jesse@gmail.com", "2000");
                await CheckProvider(user, "Provider");

            }



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

        private async Task CheckProvider(User user, string rol)
        {
            this.dataContext.CProveedores.Add(new CProveedor { User = user });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        private async Task CheckClient(User user, string rol)
        {
            this.dataContext.CClientes.Add(new CCliente { User = user });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        private async Task CheckAgent(User user, string rol)
        {
            this.dataContext.CAgentes_Ventas.Add(new CAgentes_Venta { User = user });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
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

        private async Task<User> CheckUser(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            var user = await userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    UserName = email
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Error no se pudo crear el usuario");
                }
            }
            return user;
        }

    }
}
