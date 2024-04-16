using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "El cumpleaños del empleado es requerido")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha de cumpleaños inválido")]
        public DateTime? CUMPLEAÑOS { get; set; }

        [Required(ErrorMessage = "El puesto del empleado es requerido")]
        public string? PUESTO { get; set; }

        [Required(ErrorMessage = "El cargo del empleado es requerido")]
        public string? CARGO { get; set; }

        //[Required(ErrorMessage = "La función del empleado es requerida")]
        public string? FUNCION { get; set; }

        [Required(ErrorMessage = "La modalidad de trabajo del empleado es requerida")]
        public string? MODALIDAD { get; set; }

        //Required(ErrorMessage = "El rol empleado es requerido")]
        public string? ROL { get; set; }

        [Required(ErrorMessage = "La tasa empleado es requerida")]
        public string? TASA { get; set; }

        //[Required(ErrorMessage = "La empresa empleado es requerida")]
        public string? EMPRESA { get; set; }

        [Required(ErrorMessage = "El coordinador del empleado es requerido")]
        public string? COORDINADOR { get; set; }

        [Required(ErrorMessage = "El gabin empleado es requerido")]
        public string? GABIN { get; set; }

        [Required(ErrorMessage = "El people empleado es requerido")]
        public string? PEOPLE { get; set; }

        [Required(ErrorMessage = "La fecha del proyecto del empleado es requerido")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha de proyecto es inválido")]
        public DateTime? FECHA_PROYECTO { get; set; }

        //[DataType(DataType.Date, ErrorMessage = "Formato de fecha de cese es inválido")]
        public DateTime? FECHA_CESE { get; set; }
        public double? DIAS_AL_CESE { get; set; }
        public string? PERIODO_PRUEBA { get; set; }

        [Required(ErrorMessage = "La fecha del ingreso del empleado es requerido")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha de ingreso es inválido")]
        public DateTime? INGRESO_INDRA { get; set; }
        public int? DIAS_EMPRESA { get; set; }

        //[DataType(DataType.Date, ErrorMessage = "Formato de fecha de vacaciones es inválido")]
        public DateTime? VACACIONES_URGENTES { get; set; }

        [Required(ErrorMessage = "El equipo del empleado es requerido")]
        public string? Equipo { get; set; }

        [Required(ErrorMessage = "El número celular del empleado es requerido")]
        public double? CELULAR { get; set; }

        [Required(ErrorMessage = "El correo del empleado es requerido")]
        public string? CORREO { get; set; }

        [Required(ErrorMessage = "El correo personal del empleado es requerido")]
        public string? CPERSONAL { get; set; }

        [Required(ErrorMessage = "La dirección del empleado es requerida")]
        public string? DIRECCION { get; set; }

        [Required(ErrorMessage = "El distrito del empleado es requerido")]
        public string? DISTRITO { get; set; }

        [Required(ErrorMessage = "La provincia del empleado es requerida")]
        public string? PROVINCIA { get; set; }

        [Required(ErrorMessage = "El departamento del empleado es requerido")]
        public string? DEPARTAMENTO { get; set; }
        public string? OBSERVACION { get; set; }
        public string? F31 { get; set; }
        public string? ESTADO { get; set; }
    }
}
