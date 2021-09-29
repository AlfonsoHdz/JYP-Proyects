using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CBodega : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required]
        [MaxLength(20)]
        [Display(Name = "Cupo")]
        public string Cupo { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }





    }
}
