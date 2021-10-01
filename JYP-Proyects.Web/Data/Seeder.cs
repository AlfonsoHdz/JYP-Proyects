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
              ////  await CheckVehiculo("Tsuru", "Tsuru tuneado", "2000", 100000);
              //  await CheckVehiculo("Sentra", "Sentra tuneado", "2005", 300000);
              //  await CheckVehiculo("Vocho", "Vocho tuneado", "2006", 200000);
              //  await CheckVehiculo("Lamborghini", "Lamborghini tuneado", "2020", 1000000);
            }
        }


        //Metodos

        private async Task CheckVehiculo(string name, string descripcionV, string año, double precio)
        {
            this.dataContext.CVehiculos.Add(new CVehiculo { Nombre = name });
            this.dataContext.CVehiculos.Add(new CVehiculo { DescripcionV = descripcionV });
            this.dataContext.CVehiculos.Add(new CVehiculo { Año = año });
            this.dataContext.CVehiculos.Add(new CVehiculo { Precio = precio });
           // await this.dataContext.SaveChangesAsync();
        }
    }
}
