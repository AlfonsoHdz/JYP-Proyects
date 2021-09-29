using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CAgencia : IEntity
    {
        [Display(Name = "Id" )]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

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
