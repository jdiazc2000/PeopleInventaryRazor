using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EmpresasEntity
    {
        [Key]
        public int EmpresaID { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerida")]
        [MinLength(2, ErrorMessage = "La tasa debe ser mayor o igual a 2 caracteres")]
        public string EmpresaName { get; set; }
    }
}
