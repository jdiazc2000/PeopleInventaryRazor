using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class PersonalEntity
    {
        [Key]
        public double? ID { get; set; }
        public string? DNI { get; set; }
        public string? PERSONAL { get; set; }
        public string? CUMPLEAÑOS { get; set; }
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
        public string? FECHA_PROYECTO { get; set; } 
        public string? FECHA_CESE { get; set; } 
        public int? DIAS_AL_CESE { get; set; }
        public string? PERIODO_PRUEBA { get; set; }
        public string? INGRESO_INDRA { get; set; } 
        public double? DIAS_EMPRESA { get; set; }
        public string? VACACIONES_URGENTES { get; set; }
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
    }
}
