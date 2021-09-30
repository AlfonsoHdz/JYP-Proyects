using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CVenta : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Fecha de la Venta")]
        public string FechaV { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Descripcion de la Venta")]
        public string DescripcionV { get; set; }


        [Required]
        [MaxLength(20)]
        [Display(Name = "Costo de la Venta")]
        public double CostoV { get; set; }


        public CCliente CCliente { get; set; }

        public CAgentes_Venta CAgentes_Venta { get; set; }



    }
}
