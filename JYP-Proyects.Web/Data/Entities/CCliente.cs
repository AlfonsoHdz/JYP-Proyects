using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CCliente : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Correo")]
        public int Correo { get; set; }




    }
}
