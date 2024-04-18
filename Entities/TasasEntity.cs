using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TasasEntity
    {
        [Key]
        public int TasaID { get; set; }

        [Required(ErrorMessage = "El nombre de la tasa es requerida")]
        [MinLength(2, ErrorMessage = "La tasa debe ser mayor o igual a 2 caracteres")]
        public string TasaName { get; set; }
    }
}
