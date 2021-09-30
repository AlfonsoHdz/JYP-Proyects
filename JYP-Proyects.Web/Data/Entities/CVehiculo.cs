using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CVehiculo : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required]
        [MaxLength(20)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Descripcion del Vehiculo")]
        public string DescripcionV { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Modelo del Vehiculo")]
        public string Año { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Precio del Vehiculo")]
        public double Precio { get; set; }


        
    }
}
