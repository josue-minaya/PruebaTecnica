
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
using Document = QuestPDF.Fluent.Document;
using PrubaTecnica.Service;

namespace PrubaTecnica.Controllers
{
    [ApiController]
    [Route("api")]
    public class ReporteController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ReporteController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("pdf")]
        public IActionResult GenerarPdf()
        {
            var productos = _productoService.GetAll();

            // Crear el documento PDF
            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Content()
                        .Column(column =>
                        {
                            column.Spacing(10);
                            column.Item().Text("Reporte de Productos").Bold().FontSize(18).AlignCenter();
                            column.Item().Text($"Fecha: {DateTime.Now.ToShortDateString()}").AlignRight();

                            column.Item().PaddingTop(20);
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();  // Columna para el Nombre
                                    columns.RelativeColumn();  // Columna para el Precio
                                    columns.RelativeColumn();  // Columna para la Cantidad
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Text("Nombre").Bold();
                                    header.Cell().Text("Precio").Bold();
                                    header.Cell().Text("Cantidad").Bold();
                                });

                                // Poner los datos de los productos
                                foreach (var producto in productos)
                                {
                                    table.Cell().Text(producto.Nombre);
                                    table.Cell().Text(producto.Precio.ToString("C"));
                                    table.Cell().Text(producto.Cantidad.ToString());
                                }
                            });
                        });
                });
            });

            // Generar el archivo PDF
            var pdfBytes = pdfDocument.GeneratePdf();

            // Devolver el PDF como archivo
            return File(pdfBytes, "application/pdf", "ReporteProductos.pdf");
        }
    }
}
