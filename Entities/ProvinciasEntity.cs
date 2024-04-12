using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProvinciasEntity
    {
        [Key]
        public string? id { get; set; }
        public string? name { get; set; }
        public string? department_id { get; set; }
    }
}
