using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CAgencia : IEntity
    {
       // [Display(Name = "Id" )]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
      
        public string Nombre { get; set; }

        [Required]
        [MaxLength(300)]
        
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(100)]
        
        public string Direccion { get; set; }

        [Required]
        [MaxLength(50)]
       
        public string Telefono { get; set; }

        [Required]
        [MaxLength(25)]

        public string Correo { get; set; }


        public ICollection<CVenta> CVentas { get; set; }

        public ICollection<CBodega> CBodegas { get; set; }

        //Relacion 1:1
        public ICollection<CProveedor> CProveedors { get; set; }



    }
}
