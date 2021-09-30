using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class CAgentes_Venta : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Nombre de Usurio")]
        public string Usuario { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        public ICollection<CVenta> CVentas { get; set; }

    }
}
