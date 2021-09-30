using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYP_Proyects.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class CProveedor : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        public User User { get; set; }

        public CAgencia CAgencia { get; set; }

        public ICollection<CCompra> CCompras { get; set; }
    }
}
