using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RolesEntity
    {
        [Key]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "El nombre del rol es requerido")]
        [MinLength(2, ErrorMessage = "DNI debe ser mayor o igual a 2 caracteres")]
        public string RoleName { get; set; }
    }
}
