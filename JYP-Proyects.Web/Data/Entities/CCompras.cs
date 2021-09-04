using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CCompras
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Fecha de la Compra")]
        public string FechaC { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Descripcion de la Compra")]
        public string DescripcionC { get; set; }


        [Required]
        [MaxLength(20)]
        [Display(Name = "Costo de la Compra")]
        public double CostoC { get; set; }


    }
}
