using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Newe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPersonal",
                columns: table => new
                {
                    ID = table.Column<double>(type: "float", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUMPLEAÑOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PUESTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CARGO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FUNCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODALIDAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ROL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TASA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMPRESA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COORDINADOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GABIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PEOPLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_PROYECTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_CESE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIAS_AL_CESE = table.Column<double>(type: "float", nullable: true),
                    PERIODO_PRUEBA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INGRESO_INDRA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIAS_EMPRESA = table.Column<double>(type: "float", nullable: true),
                    VACACIONES_URGENTES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CELULAR = table.Column<double>(type: "float", nullable: true),
                    CORREO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPERSONAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIRECCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISTRITO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROVINCIA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPARTAMENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBSERVACION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F31 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPersonal", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPersonal");
        }
    }
}
