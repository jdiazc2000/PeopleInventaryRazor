using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class PersonalEntity
    {
        [Key]
        [Required(ErrorMessage = "El ID del empleado es requerido")]
        [MinLength(6, ErrorMessage = "ID debe de contener 6 caracteres")]
        public double? ID { get; set; }

        [Required(ErrorMessage = "El DNI del empleado es requerido")]
        [MinLength(8, ErrorMessage = "DNI debe ser mayor o igual a 12 caracteres")]
        public string? DNI { get; set; }

        [Required(ErrorMessage = "El Nombre del empleado es requerido")]
        [MinLength((3), ErrorMessage = "El Nombre del empleado debe ser mayor de 3 caracteres")]
        public string? PERSONAL { get; set; }
        public DateTime? CUMPLEAÑOS { get; set; }
        public string? PUESTO { get; set; }
        public string? CARGO { get; set; }
        public string? FUNCION { get; set; }
        public string? MODALIDAD { get; set; }
        public string? ROL { get; set; }
        public string? TASA { get; set; }
        public string? EMPRESA { get; set; }
        public string? COORDINADOR { get; set; }
        public string? GABIN { get; set; }
        public string? PEOPLE { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de fecha de proyecto es inválido")]
        public DateTime? FECHA_PROYECTO { get; set; }
        public DateTime? FECHA_CESE { get; set; }
        public double? DIAS_AL_CESE { get; set; }
        public string? PERIODO_PRUEBA { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de fecha de ingreso es inválido")]
        public DateTime? INGRESO_INDRA { get; set; }
        public int? DIAS_EMPRESA { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de fecha de vacaciones es inválido")]
        public DateTime? VACACIONES_URGENTES { get; set; }
        public string? Equipo { get; set; }
        public double? CELULAR { get; set; }
        public string? CORREO { get; set; }
        public string? CPERSONAL { get; set; }
        public string? DIRECCION { get; set; }
        public string? DISTRITO { get; set; }
        public string? PROVINCIA { get; set; }
        public string? DEPARTAMENTO { get; set; }
        public string? OBSERVACION { get; set; }
        public string? F31 { get; set; }
        public string? ESTADO { get; set; }
        public string? ARCHIVOPDF { get; set; }
    }
}
