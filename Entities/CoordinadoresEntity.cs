using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CoordinadoresEntity
    {
        [Key]
        public int CoordinadorID { get; set; }

        [Required(ErrorMessage = "El nombre del coordinador es requerido")]
        [MinLength(2, ErrorMessage = "La tasa debe ser mayor o igual a 2 caracteres")]
        public string Nombre { get; set; }
    }
}
