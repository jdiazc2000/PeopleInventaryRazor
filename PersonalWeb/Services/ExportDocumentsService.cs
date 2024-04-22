using BlazorDownloadFile;
using ClosedXML.Excel;
using Entities;
using Microsoft.JSInterop;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace PersonalWeb.Services
{
    public interface IExportDocumentsService
    {
        Task ExportExcel(List<PersonalEntity> data);
        Task ExportPdf(List<PersonalEntity> data);
        PdfDocument ExportPdfToBeSendedToAnEmail(List<PersonalEntity> data);
    }

    public class ExportDocumentsService : CalcServices , IExportDocumentsService
    {
        private readonly IJSRuntime _jsService;
        private readonly IBlazorDownloadFileService _BlazorDownloadFileService;

        public ExportDocumentsService(IJSRuntime jsRuntime, IBlazorDownloadFileService BlazorDownloadFileService )
        {
            _jsService = jsRuntime;
            _BlazorDownloadFileService = BlazorDownloadFileService;
        }

        private void DrawCell(XGraphics gfx, string text, XFont font, XPoint point, double width, double height)
        {
            gfx.DrawRectangle(XPens.Black, point.X, point.Y, width, height);

            // Dividir el texto en líneas que quepan dentro de la celda
            List<string> lines = SplitTextToFit(gfx, text, font, width);

            // Calcular la altura de cada línea
            double lineHeight = height / lines.Count;

            // Dibujar cada línea de texto
            double y = point.Y;
            foreach (string line in lines)
            {
                gfx.DrawString(line, font, XBrushes.Black, new XRect(point.X, y, width, lineHeight), XStringFormats.Center);
                y += lineHeight;
            }
        }

        private List<string> SplitTextToFit(XGraphics gfx, string text, XFont font, double width)
        {
            List<string> lines = new List<string>();

            // Si el texto ya cabe en la celda, no es necesario dividirlo
            if (gfx.MeasureString(text, font).Width <= width)
            {
                lines.Add(text);
                return lines;
            }

            // Dividir el texto en dos partes
            int middleIndex = text.Length / 2;
            string firstHalf = text.Substring(0, middleIndex);
            string secondHalf = text.Substring(middleIndex);

            // Agregar las dos partes al resultado
            lines.Add(firstHalf);
            lines.Add(secondHalf);

            return lines;
        }

        public async Task ExportExcel(List<PersonalEntity> data)
        {
            using (var libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Empleados");

                hoja.Cell(1, 1).Value = "ID";
                hoja.Cell(1, 2).Value = "DNI";
                hoja.Cell(1, 3).Value = "Nombre Completo";
                hoja.Cell(1, 4).Value = "Celular";
                hoja.Cell(1, 5).Value = "Equipo";
                hoja.Cell(1, 6).Value = "Fecha de Ingreso a Indra";
                hoja.Cell(1, 7).Value = "Fecha de Nacimiento";
                hoja.Cell(1, 8).Value = "Días en Indra";
                hoja.Cell(1, 9).Value = "Estado Laboral";
                hoja.Cell(1, 10).Value = "Puesto";
                hoja.Cell(1, 11).Value = "Cargo";
                hoja.Cell(1, 12).Value = "Función";
                hoja.Cell(1, 13).Value = "Modalidad de Contrato";
                hoja.Cell(1, 14).Value = "Rol";
                hoja.Cell(1, 15).Value = "Tasa";
                hoja.Cell(1, 16).Value = "Empresa";
                hoja.Cell(1, 17).Value = "Coordinador";
                hoja.Cell(1, 18).Value = "Gabinete";
                hoja.Cell(1, 19).Value = "People";
                hoja.Cell(1, 20).Value = "Fecha de Proyecto";
                hoja.Cell(1, 21).Value = "Fecha de Cese";
                hoja.Cell(1, 22).Value = "Días al Cese";
                hoja.Cell(1, 23).Value = "Periodo de Prueba";
                hoja.Cell(1, 24).Value = "Vacaciones Urgentes";
                hoja.Cell(1, 25).Value = "Correo Electrónico";
                hoja.Cell(1, 26).Value = "correo Personal";
                hoja.Cell(1, 27).Value = "Dirección";
                hoja.Cell(1, 28).Value = "Departamento";
                hoja.Cell(1, 29).Value = "Provincia";
                hoja.Cell(1, 30).Value = "Distrito";
                hoja.Cell(1, 31).Value = "Observación";
                hoja.Cell(1, 32).Value = "F31";



                for (int fila = 1; fila <= data.Count; fila++)
                {
                    foreach (var personal in data)
                    {

                        var diasEmpresa = CalcularDiasDeDiferencia(personal.INGRESO_INDRA);
                        personal.DIAS_EMPRESA = Int32.Parse(diasEmpresa);
                    }

                    foreach (var personal in data)
                    {
                        var diasCese = CalcularDiasCese(personal.FECHA_CESE);
                        personal.DIAS_AL_CESE = Convert.ToDouble(diasCese);
                    }


                    hoja.Cell(fila + 1, 1).Value = data[fila - 1].ID;
                    hoja.Cell(fila + 1, 2).Value = data[fila - 1].DNI;
                    hoja.Cell(fila + 1, 3).Value = data[fila - 1].PERSONAL;
                    hoja.Cell(fila + 1, 4).Value = data[fila - 1].CELULAR;
                    hoja.Cell(fila + 1, 5).Value = data[fila - 1].Equipo;
                    hoja.Cell(fila + 1, 6).Value = data[fila - 1].INGRESO_INDRA?.ToString("dd-MM-yyyy");
                    hoja.Cell(fila + 1, 7).Value = data[fila - 1].CUMPLEAÑOS?.ToString("dd/MM/yyyy");
                    hoja.Cell(fila + 1, 8).Value = data[fila - 1].DIAS_EMPRESA;
                    hoja.Cell(fila + 1, 9).Value = data[fila - 1].ESTADO;
                    hoja.Cell(fila + 1, 10).Value = data[fila - 1].PUESTO;
                    hoja.Cell(fila + 1, 11).Value = data[fila - 1].CARGO;
                    hoja.Cell(fila + 1, 12).Value = data[fila - 1].FUNCION;
                    hoja.Cell(fila + 1, 13).Value = data[fila - 1].MODALIDAD;
                    hoja.Cell(fila + 1, 14).Value = data[fila - 1].ROL;
                    hoja.Cell(fila + 1, 15).Value = data[fila - 1].TASA;
                    hoja.Cell(fila + 1, 16).Value = data[fila - 1].EMPRESA;
                    hoja.Cell(fila + 1, 17).Value = data[fila - 1].COORDINADOR;
                    hoja.Cell(fila + 1, 18).Value = data[fila - 1].GABIN;
                    hoja.Cell(fila + 1, 19).Value = data[fila - 1].PEOPLE;
                    hoja.Cell(fila + 1, 20).Value = data[fila - 1].FECHA_PROYECTO?.ToString("dd-MM-yyyy");
                    hoja.Cell(fila + 1, 21).Value = data[fila - 1].FECHA_CESE?.ToString("dd/MM/yyyy");
                    hoja.Cell(fila + 1, 22).Value = data[fila - 1].DIAS_AL_CESE;
                    hoja.Cell(fila + 1, 23).Value = data[fila - 1].PERIODO_PRUEBA;
                    hoja.Cell(fila + 1, 24).Value = data[fila - 1].VACACIONES_URGENTES?.ToString("dd/MM/yyyy");
                    hoja.Cell(fila + 1, 25).Value = data[fila - 1].CORREO;
                    hoja.Cell(fila + 1, 26).Value = data[fila - 1].CPERSONAL;
                    hoja.Cell(fila + 1, 27).Value = data[fila - 1].DIRECCION;
                    hoja.Cell(fila + 1, 28).Value = data[fila - 1].DEPARTAMENTO;
                    hoja.Cell(fila + 1, 29).Value = data[fila - 1].PROVINCIA;
                    hoja.Cell(fila + 1, 30).Value = data[fila - 1].DISTRITO;
                    hoja.Cell(fila + 1, 31).Value = data[fila - 1].OBSERVACION;
                    hoja.Cell(fila + 1, 32).Value = data[fila - 1].F31;

                }

                using (var memoria = new MemoryStream())
                {
                    libro.SaveAs(memoria);
                    var nombreExcel = string.Concat("Reporte de Personal ", DateTime.Now.ToString(), ".xlsx");

                    await _jsService.InvokeAsync<object>(
                        "ExportExcel",
                        nombreExcel,
                        Convert.ToBase64String(memoria.ToArray())
                    );
                }
            }
        }

        public async Task ExportPdf(List<PersonalEntity> data)
        {
            PdfDocument document = new PdfDocument();

            double pageWidth = 73.8;

            // Configurar tamaño de página y orientación para todas las páginas
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharpCore.PageOrientation.Landscape;
            page.Width = XUnit.FromInch(pageWidth); // Ancho en pulgadas
            page.Height = XUnit.FromInch(8.5); // Alto en pulgadas

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

            int yPoint = 20; // Comenzar después del margen superior
            int cellWidth = 90;
            int cellHeight = 30;

            // Dibujar las cabeceras de la tabla en la primera página
            DrawCell(gfx, "ID", font, new XPoint(10, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Nombre", font, new XPoint(100, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Personal", font, new XPoint(190, yPoint), 300, cellHeight);
            DrawCell(gfx, "Cumpleaños", font, new XPoint(490, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Puesto", font, new XPoint(580, yPoint), 180, cellHeight);
            DrawCell(gfx, "Cargo", font, new XPoint(760, yPoint), 310, cellHeight);
            DrawCell(gfx, "Función", font, new XPoint(1070, yPoint), 390, cellHeight);
            DrawCell(gfx, "Modalidad", font, new XPoint(1460, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Rol", font, new XPoint(1550, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Tasa", font, new XPoint(1640, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Empresa", font, new XPoint(1730, yPoint), 170, cellHeight);
            DrawCell(gfx, "Coordinador", font, new XPoint(1900, yPoint), 165, cellHeight);
            DrawCell(gfx, "Gabin", font, new XPoint(2065, yPoint), 165, cellHeight);
            DrawCell(gfx, "People", font, new XPoint(2230, yPoint), 165, cellHeight);
            DrawCell(gfx, "Fecha proyecto", font, new XPoint(2395, yPoint), 110, cellHeight);
            DrawCell(gfx, "Fecha cese", font, new XPoint(2505, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Dias al Cese", font, new XPoint(2595, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Periodo Prueba", font, new XPoint(2685, yPoint), 105, cellHeight);
            DrawCell(gfx, "Ingreso Indra", font, new XPoint(2790, yPoint), 105, cellHeight);
            DrawCell(gfx, "Dias empresa", font, new XPoint(2895, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Vacaciones urgentes", font, new XPoint(2985, yPoint), 130, cellHeight);
            DrawCell(gfx, "Equipo", font, new XPoint(3115, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Celular", font, new XPoint(3205, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Correo", font, new XPoint(3295, yPoint), 230, cellHeight);
            DrawCell(gfx, "Correo Personal", font, new XPoint(3525, yPoint), 230, cellHeight);
            DrawCell(gfx, "Dirección", font, new XPoint(3755, yPoint), 600, cellHeight);
            DrawCell(gfx, "Departamento", font, new XPoint(4355, yPoint), 110, cellHeight);
            DrawCell(gfx, "Provincia", font, new XPoint(4465, yPoint), 145, cellHeight);
            DrawCell(gfx, "Distrito", font, new XPoint(4610, yPoint), 145, cellHeight);
            DrawCell(gfx, "Observación", font, new XPoint(4755, yPoint), 230, cellHeight);
            DrawCell(gfx, "F31", font, new XPoint(4985, yPoint), 230, cellHeight);
            DrawCell(gfx, "Estado", font, new XPoint(5215, yPoint), cellWidth, cellHeight);
            yPoint += cellHeight; // Aumentar el valor de yPoint después de dibujar las cabeceras

            // Dibujar los datos de la tabla
            foreach (var item in data)
            {
                // Si hemos alcanzado el límite de filas por página, agregamos una nueva página
                if (yPoint + cellHeight > page.Height.Point)
                {
                    page = document.AddPage(); // Agregar nueva página
                    page.Orientation = PdfSharpCore.PageOrientation.Landscape; // Configurar orientación horizontal
                    page.Width = XUnit.FromInch(pageWidth); // Anchoen pulgadas
                    page.Height = XUnit.FromInch(8.5); // Alto en pulgadas
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = 20; // Reiniciar la posición vertical, comenzando después del margen superior

                    // Dibujar las cabeceras de la tabla en la nueva página
                    DrawCell(gfx, "ID", font, new XPoint(10, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Nombre", font, new XPoint(100, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Personal", font, new XPoint(190, yPoint), 300, cellHeight);
                    DrawCell(gfx, "Cumpleaños", font, new XPoint(490, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Puesto", font, new XPoint(580, yPoint), 180, cellHeight);
                    DrawCell(gfx, "Cargo", font, new XPoint(760, yPoint), 310, cellHeight);
                    DrawCell(gfx, "Función", font, new XPoint(1070, yPoint), 390, cellHeight);
                    DrawCell(gfx, "Modalidad", font, new XPoint(1460, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Rol", font, new XPoint(1550, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Tasa", font, new XPoint(1640, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Empresa", font, new XPoint(1730, yPoint), 170, cellHeight);
                    DrawCell(gfx, "Coordinador", font, new XPoint(1900, yPoint), 165, cellHeight);
                    DrawCell(gfx, "Gabin", font, new XPoint(2065, yPoint), 165, cellHeight);
                    DrawCell(gfx, "People", font, new XPoint(2230, yPoint), 165, cellHeight);
                    DrawCell(gfx, "Fecha proyecto", font, new XPoint(2395, yPoint), 110, cellHeight);
                    DrawCell(gfx, "Fecha cese", font, new XPoint(2505, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Dias al Cese", font, new XPoint(2595, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Periodo Prueba", font, new XPoint(2685, yPoint), 105, cellHeight);
                    DrawCell(gfx, "Ingreso Indra", font, new XPoint(2790, yPoint), 105, cellHeight);
                    DrawCell(gfx, "Dias empresa", font, new XPoint(2895, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Vacaciones urgentes", font, new XPoint(2985, yPoint), 130, cellHeight);
                    DrawCell(gfx, "Equipo", font, new XPoint(3115, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Celular", font, new XPoint(3205, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Correo", font, new XPoint(3295, yPoint), 230, cellHeight);
                    DrawCell(gfx, "Correo Personal", font, new XPoint(3525, yPoint), 230, cellHeight);
                    DrawCell(gfx, "Dirección", font, new XPoint(3755, yPoint), 600, cellHeight);
                    DrawCell(gfx, "Departamento", font, new XPoint(4355, yPoint), 110, cellHeight);
                    DrawCell(gfx, "Provincia", font, new XPoint(4465, yPoint), 145, cellHeight);
                    DrawCell(gfx, "Distrito", font, new XPoint(4610, yPoint), 145, cellHeight);
                    DrawCell(gfx, "Observación", font, new XPoint(4755, yPoint), 230, cellHeight);
                    DrawCell(gfx, "F31", font, new XPoint(4985, yPoint), 230, cellHeight);
                    DrawCell(gfx, "Estado", font, new XPoint(5215, yPoint), cellWidth, cellHeight);
                    yPoint += cellHeight; // Aumentar el valor de yPoint después de dibujar las cabeceras
                }

                string puesto = item.PUESTO ?? "";
                string cargo = item.CARGO ?? "";
                string funcion = item.FUNCION ?? "";
                string modalidad = item.MODALIDAD ?? "";
                string rol = item.ROL ?? "";
                string tasa = item.TASA ?? "";
                string empresa = item.EMPRESA ?? "";
                string coordinador = item.COORDINADOR ?? "";
                string gabin = item.GABIN ?? "";
                string people = item.PEOPLE ?? "";
                string fechacese = item.FECHA_CESE?.ToString("dd/MM/yyyy") ?? "";
                string diascese = CalcularDiasCese(item.FECHA_CESE) ?? "";
                string periodoprueba = item.PERIODO_PRUEBA ?? "";
                string diasempresa = CalcularDiasDeDiferencia(item.INGRESO_INDRA) ?? "";
                string vacacionesurgentes = item.VACACIONES_URGENTES?.ToString("dd/MM/yyyy") ?? "";
                string equipo = item.Equipo ?? "";
                string correo = item.CORREO ?? "";
                string correopersonal = item.CPERSONAL ?? "";
                string direccion = item.DIRECCION ?? "";
                string departamento = item.DEPARTAMENTO ?? "";
                string provincia = item.PROVINCIA ?? "";
                string distrito = item.DISTRITO ?? "";
                string observacion = item.OBSERVACION ?? "";
                string f31 = item.F31 ?? "";
                string estado = item.ESTADO ?? "";

                // Dibujar los datos en la página actual
                DrawCell(gfx, item.ID.ToString(), font, new XPoint(10, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, item.DNI, font, new XPoint(100, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, item.PERSONAL, font, new XPoint(190, yPoint), 300, cellHeight);
                DrawCell(gfx, item.CUMPLEAÑOS?.ToString("dd/MM/yyyy"), font, new XPoint(490, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, puesto, font, new XPoint(580, yPoint), 180, cellHeight);
                DrawCell(gfx, cargo, font, new XPoint(760, yPoint), 310, cellHeight);
                DrawCell(gfx, funcion, font, new XPoint(1070, yPoint), 390, cellHeight);
                DrawCell(gfx, modalidad, font, new XPoint(1460, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, rol, font, new XPoint(1550, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, tasa, font, new XPoint(1640, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, empresa, font, new XPoint(1730, yPoint), 170, cellHeight);
                DrawCell(gfx, coordinador, font, new XPoint(1900, yPoint), 165, cellHeight);
                DrawCell(gfx, gabin, font, new XPoint(2065, yPoint), 165, cellHeight);
                DrawCell(gfx, people, font, new XPoint(2230, yPoint), 165, cellHeight);
                DrawCell(gfx, item.FECHA_PROYECTO?.ToString("dd/MM/yyyy"), font, new XPoint(2395, yPoint), 110, cellHeight);
                DrawCell(gfx, fechacese, font, new XPoint(2505, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, diascese, font, new XPoint(2595, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, periodoprueba, font, new XPoint(2685, yPoint), 105, cellHeight);
                DrawCell(gfx, item.INGRESO_INDRA?.ToString("dd/MM/yyyy"), font, new XPoint(2790, yPoint), 105, cellHeight);
                DrawCell(gfx, diasempresa, font, new XPoint(2895, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, vacacionesurgentes, font, new XPoint(2985, yPoint), 130, cellHeight);
                DrawCell(gfx, equipo, font, new XPoint(3115, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, item.CELULAR.ToString(), font, new XPoint(3205, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, correo, font, new XPoint(3295, yPoint), 230, cellHeight);
                DrawCell(gfx, correopersonal, font, new XPoint(3525, yPoint), 230, cellHeight);
                DrawCell(gfx, direccion, font, new XPoint(3755, yPoint), 600, cellHeight);
                DrawCell(gfx, departamento, font, new XPoint(4355, yPoint), 110, cellHeight);
                DrawCell(gfx, provincia, font, new XPoint(4465, yPoint), 145, cellHeight);
                DrawCell(gfx, distrito, font, new XPoint(4610, yPoint), 145, cellHeight);
                DrawCell(gfx, distrito, font, new XPoint(4610, yPoint), 145, cellHeight);
                DrawCell(gfx, observacion, font, new XPoint(4755, yPoint), 230, cellHeight);
                DrawCell(gfx, observacion, font, new XPoint(4755, yPoint), 230, cellHeight);
                DrawCell(gfx, f31, font, new XPoint(4985, yPoint), 230, cellHeight);
                DrawCell(gfx, estado, font, new XPoint(5215, yPoint), cellWidth, cellHeight);
                yPoint += cellHeight;
            }

            using MemoryStream stream = new MemoryStream();
                document.Save(stream, false);
                var bytes = stream.ToArray();
                string fileName = "Tabla.pdf";

                // Convertir los bytes a base64
                string base64 = Convert.ToBase64String(bytes);

                // Descargar el archivo PDF
                await _BlazorDownloadFileService.DownloadFile(fileName, base64, "application/pdf");
            }

        public PdfDocument ExportPdfToBeSendedToAnEmail(List<PersonalEntity> data)
        {
            PdfDocument document = new PdfDocument();

            double pageWidth = 73.8;

            // Configurar tamaño de página y orientación para todas las páginas
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharpCore.PageOrientation.Landscape;
            page.Width = XUnit.FromInch(pageWidth); // Ancho en pulgadas
            page.Height = XUnit.FromInch(8.5); // Alto en pulgadas

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

            int yPoint = 20; // Comenzar después del margen superior
            int cellWidth = 90;
            int cellHeight = 30;

            // Dibujar las cabeceras de la tabla en la primera página
            DrawCell(gfx, "ID", font, new XPoint(10, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Nombre", font, new XPoint(100, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Personal", font, new XPoint(190, yPoint), 300, cellHeight);
            DrawCell(gfx, "Cumpleaños", font, new XPoint(490, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Puesto", font, new XPoint(580, yPoint), 180, cellHeight);
            DrawCell(gfx, "Cargo", font, new XPoint(760, yPoint), 310, cellHeight);
            DrawCell(gfx, "Función", font, new XPoint(1070, yPoint), 390, cellHeight);
            DrawCell(gfx, "Modalidad", font, new XPoint(1460, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Rol", font, new XPoint(1550, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Tasa", font, new XPoint(1640, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Empresa", font, new XPoint(1730, yPoint), 170, cellHeight);
            DrawCell(gfx, "Coordinador", font, new XPoint(1900, yPoint), 165, cellHeight);
            DrawCell(gfx, "Gabin", font, new XPoint(2065, yPoint), 165, cellHeight);
            DrawCell(gfx, "People", font, new XPoint(2230, yPoint), 165, cellHeight);
            DrawCell(gfx, "Fecha proyecto", font, new XPoint(2395, yPoint), 110, cellHeight);
            DrawCell(gfx, "Fecha cese", font, new XPoint(2505, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Dias al Cese", font, new XPoint(2595, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Periodo Prueba", font, new XPoint(2685, yPoint), 105, cellHeight);
            DrawCell(gfx, "Ingreso Indra", font, new XPoint(2790, yPoint), 105, cellHeight);
            DrawCell(gfx, "Dias empresa", font, new XPoint(2895, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Vacaciones urgentes", font, new XPoint(2985, yPoint), 130, cellHeight);
            DrawCell(gfx, "Equipo", font, new XPoint(3115, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Celular", font, new XPoint(3205, yPoint), cellWidth, cellHeight);
            DrawCell(gfx, "Correo", font, new XPoint(3295, yPoint), 230, cellHeight);
            DrawCell(gfx, "Correo Personal", font, new XPoint(3525, yPoint), 230, cellHeight);
            DrawCell(gfx, "Dirección", font, new XPoint(3755, yPoint), 600, cellHeight);
            DrawCell(gfx, "Departamento", font, new XPoint(4355, yPoint), 110, cellHeight);
            DrawCell(gfx, "Provincia", font, new XPoint(4465, yPoint), 145, cellHeight);
            DrawCell(gfx, "Distrito", font, new XPoint(4610, yPoint), 145, cellHeight);
            DrawCell(gfx, "Observación", font, new XPoint(4755, yPoint), 230, cellHeight);
            DrawCell(gfx, "F31", font, new XPoint(4985, yPoint), 230, cellHeight);
            DrawCell(gfx, "Estado", font, new XPoint(5215, yPoint), cellWidth, cellHeight);
            yPoint += cellHeight; // Aumentar el valor de yPoint después de dibujar las cabeceras

            // Dibujar los datos de la tabla
            foreach (var item in data)
            {
                // Si hemos alcanzado el límite de filas por página, agregamos una nueva página
                if (yPoint + cellHeight > page.Height.Point)
                {
                    page = document.AddPage(); // Agregar nueva página
                    page.Orientation = PdfSharpCore.PageOrientation.Landscape; // Configurar orientación horizontal
                    page.Width = XUnit.FromInch(pageWidth); // Anchoen pulgadas
                    page.Height = XUnit.FromInch(8.5); // Alto en pulgadas
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = 20; // Reiniciar la posición vertical, comenzando después del margen superior

                    // Dibujar las cabeceras de la tabla en la nueva página
                    DrawCell(gfx, "ID", font, new XPoint(10, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Nombre", font, new XPoint(100, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Personal", font, new XPoint(190, yPoint), 300, cellHeight);
                    DrawCell(gfx, "Cumpleaños", font, new XPoint(490, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Puesto", font, new XPoint(580, yPoint), 180, cellHeight);
                    DrawCell(gfx, "Cargo", font, new XPoint(760, yPoint), 310, cellHeight);
                    DrawCell(gfx, "Función", font, new XPoint(1070, yPoint), 390, cellHeight);
                    DrawCell(gfx, "Modalidad", font, new XPoint(1460, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Rol", font, new XPoint(1550, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Tasa", font, new XPoint(1640, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Empresa", font, new XPoint(1730, yPoint), 170, cellHeight);
                    DrawCell(gfx, "Coordinador", font, new XPoint(1900, yPoint), 165, cellHeight);
                    DrawCell(gfx, "Gabin", font, new XPoint(2065, yPoint), 165, cellHeight);
                    DrawCell(gfx, "People", font, new XPoint(2230, yPoint), 165, cellHeight);
                    DrawCell(gfx, "Fecha proyecto", font, new XPoint(2395, yPoint), 110, cellHeight);
                    DrawCell(gfx, "Fecha cese", font, new XPoint(2505, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Dias al Cese", font, new XPoint(2595, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Periodo Prueba", font, new XPoint(2685, yPoint), 105, cellHeight);
                    DrawCell(gfx, "Ingreso Indra", font, new XPoint(2790, yPoint), 105, cellHeight);
                    DrawCell(gfx, "Dias empresa", font, new XPoint(2895, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Vacaciones urgentes", font, new XPoint(2985, yPoint), 130, cellHeight);
                    DrawCell(gfx, "Equipo", font, new XPoint(3115, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Celular", font, new XPoint(3205, yPoint), cellWidth, cellHeight);
                    DrawCell(gfx, "Correo", font, new XPoint(3295, yPoint), 230, cellHeight);
                    DrawCell(gfx, "Correo Personal", font, new XPoint(3525, yPoint), 230, cellHeight);
                    DrawCell(gfx, "Dirección", font, new XPoint(3755, yPoint), 600, cellHeight);
                    DrawCell(gfx, "Departamento", font, new XPoint(4355, yPoint), 110, cellHeight);
                    DrawCell(gfx, "Provincia", font, new XPoint(4465, yPoint), 145, cellHeight);
                    DrawCell(gfx, "Distrito", font, new XPoint(4610, yPoint), 145, cellHeight);
                    DrawCell(gfx, "Observación", font, new XPoint(4755, yPoint), 230, cellHeight);
                    DrawCell(gfx, "F31", font, new XPoint(4985, yPoint), 230, cellHeight);
                    DrawCell(gfx, "Estado", font, new XPoint(5215, yPoint), cellWidth, cellHeight);
                    yPoint += cellHeight; // Aumentar el valor de yPoint después de dibujar las cabeceras
                }

                string puesto = item.PUESTO ?? "";
                string cargo = item.CARGO ?? "";
                string funcion = item.FUNCION ?? "";
                string modalidad = item.MODALIDAD ?? "";
                string rol = item.ROL ?? "";
                string tasa = item.TASA ?? "";
                string empresa = item.EMPRESA ?? "";
                string coordinador = item.COORDINADOR ?? "";
                string gabin = item.GABIN ?? "";
                string people = item.PEOPLE ?? "";
                string fechacese = item.FECHA_CESE?.ToString("dd/MM/yyyy") ?? "";
                string diascese = CalcularDiasCese(item.FECHA_CESE) ?? "";
                string periodoprueba = item.PERIODO_PRUEBA ?? "";
                string diasempresa = CalcularDiasDeDiferencia(item.INGRESO_INDRA) ?? "";
                string vacacionesurgentes = item.VACACIONES_URGENTES?.ToString("dd/MM/yyyy") ?? "";
                string equipo = item.Equipo ?? "";
                string correo = item.CORREO ?? "";
                string correopersonal = item.CPERSONAL ?? "";
                string direccion = item.DIRECCION ?? "";
                string departamento = item.DEPARTAMENTO ?? "";
                string provincia = item.PROVINCIA ?? "";
                string distrito = item.DISTRITO ?? "";
                string observacion = item.OBSERVACION ?? "";
                string f31 = item.F31 ?? "";
                string estado = item.ESTADO ?? "";

                // Dibujar los datos en la página actual
                DrawCell(gfx, item.ID.ToString(), font, new XPoint(10, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, item.DNI, font, new XPoint(100, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, item.PERSONAL, font, new XPoint(190, yPoint), 300, cellHeight);
                DrawCell(gfx, item.CUMPLEAÑOS?.ToString("dd/MM/yyyy"), font, new XPoint(490, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, puesto, font, new XPoint(580, yPoint), 180, cellHeight);
                DrawCell(gfx, cargo, font, new XPoint(760, yPoint), 310, cellHeight);
                DrawCell(gfx, funcion, font, new XPoint(1070, yPoint), 390, cellHeight);
                DrawCell(gfx, modalidad, font, new XPoint(1460, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, rol, font, new XPoint(1550, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, tasa, font, new XPoint(1640, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, empresa, font, new XPoint(1730, yPoint), 170, cellHeight);
                DrawCell(gfx, coordinador, font, new XPoint(1900, yPoint), 165, cellHeight);
                DrawCell(gfx, gabin, font, new XPoint(2065, yPoint), 165, cellHeight);
                DrawCell(gfx, people, font, new XPoint(2230, yPoint), 165, cellHeight);
                DrawCell(gfx, item.FECHA_PROYECTO?.ToString("dd/MM/yyyy"), font, new XPoint(2395, yPoint), 110, cellHeight);
                DrawCell(gfx, fechacese, font, new XPoint(2505, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, diascese, font, new XPoint(2595, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, periodoprueba, font, new XPoint(2685, yPoint), 105, cellHeight);
                DrawCell(gfx, item.INGRESO_INDRA?.ToString("dd/MM/yyyy"), font, new XPoint(2790, yPoint), 105, cellHeight);
                DrawCell(gfx, diasempresa, font, new XPoint(2895, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, vacacionesurgentes, font, new XPoint(2985, yPoint), 130, cellHeight);
                DrawCell(gfx, equipo, font, new XPoint(3115, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, item.CELULAR.ToString(), font, new XPoint(3205, yPoint), cellWidth, cellHeight);
                DrawCell(gfx, correo, font, new XPoint(3295, yPoint), 230, cellHeight);
                DrawCell(gfx, correopersonal, font, new XPoint(3525, yPoint), 230, cellHeight);
                DrawCell(gfx, direccion, font, new XPoint(3755, yPoint), 600, cellHeight);
                DrawCell(gfx, departamento, font, new XPoint(4355, yPoint), 110, cellHeight);
                DrawCell(gfx, provincia, font, new XPoint(4465, yPoint), 145, cellHeight);
                DrawCell(gfx, distrito, font, new XPoint(4610, yPoint), 145, cellHeight);
                DrawCell(gfx, distrito, font, new XPoint(4610, yPoint), 145, cellHeight);
                DrawCell(gfx, observacion, font, new XPoint(4755, yPoint), 230, cellHeight);
                DrawCell(gfx, observacion, font, new XPoint(4755, yPoint), 230, cellHeight);
                DrawCell(gfx, f31, font, new XPoint(4985, yPoint), 230, cellHeight);
                DrawCell(gfx, estado, font, new XPoint(5215, yPoint), cellWidth, cellHeight);
                yPoint += cellHeight;
            }

            return document;
        }
    }
}
    