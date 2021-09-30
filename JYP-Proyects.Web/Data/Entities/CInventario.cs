using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class CInventario : IEntity
    {
        public int Id { get; set; }

        
        [Required]
        [MaxLength(300)]
        public string CantidadAutos { get; set; }

      

        public ICollection<CBodega> CBodegas { get; set; }
        public ICollection<CVehiculo> CVehiculos { get; set; }
    }
}
