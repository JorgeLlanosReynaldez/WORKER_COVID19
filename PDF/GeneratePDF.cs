using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL.MODEL;

namespace PDF
{
    public class GeneratePDF : IGeneratePDF
    {
        public void ExportListToPdf(List<Report> listReport, string outputFilePath)
        {
            try
            {
                using (FileStream fs = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    Paragraph title = new Paragraph("Reporte de COVID-19", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    document.Add(title);

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 1.5f, 1f, 1f, 1.5f });

                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    PdfPCell headerCell;
                    BaseColor headerBackgroundColor = new BaseColor(0, 42, 141);

                    headerCell = new PdfPCell(new Phrase("Casos", headerFont))
                    {
                        BackgroundColor = headerBackgroundColor,
                        Padding = 10f,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Macrodistrito", headerFont))
                    {
                        BackgroundColor = headerBackgroundColor,
                        Padding = 10f,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Distrito", headerFont))
                    {
                        BackgroundColor = headerBackgroundColor,
                        Padding = 10f,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Estado", headerFont))
                    {
                        BackgroundColor = headerBackgroundColor,
                        Padding = 10f,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Zona", headerFont))
                    {
                        BackgroundColor = headerBackgroundColor,
                        Padding = 10f,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(headerCell);

                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    foreach (var report in listReport)
                    {
                        table.AddCell(new PdfPCell(new Phrase(report.Casos.ToString(), cellFont)) { Padding = 8f });
                        table.AddCell(new PdfPCell(new Phrase(report.Macrodistrito, cellFont)) { Padding = 8f });
                        table.AddCell(new PdfPCell(new Phrase(report.Distrito.ToString(), cellFont)) { Padding = 8f });
                        table.AddCell(new PdfPCell(new Phrase(report.Estado, cellFont)) { Padding = 8f });
                        table.AddCell(new PdfPCell(new Phrase(report.Zona, cellFont)) { Padding = 8f });
                    }

                    document.Add(table);
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating PDF: {ex.Message}");
            }
        }

    }
}
