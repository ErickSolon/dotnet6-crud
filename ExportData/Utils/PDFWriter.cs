using EstudoRepositories.Models.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ExportData.Utils;
public class PDFWriter
{
    public PDFWriter()
    {

    }

    public void PDFWrite(List<MultadosDTO> infos)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.Background(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11));

                page.Header()
                    .Text("Pessoas Multadas!")
                    .SemiBold().FontSize(25).FontColor(Colors.Green.Medium);

                page.Content()
                .PaddingVertical(1, Unit.Centimetre)
                .Column(x =>
                {
                    foreach (var item in infos)
                    {
                        x.Item().Text($"\n\nId: {item.Id}");
                        x.Item().Text($"Marca: {item.Marca}");
                        x.Item().Text($"MultaStatus: {item.MultaStatus}");
                        x.Item().Text($"VeiculoId: {item.VeiculoId}");
                        x.Item().Text($"CPF: {item.CPF}");
                        x.Item().Text($"NomeCompleto: {item.NomeCompleto}");
                        x.Item().Text($"Placa: {item.Placa}\n\n");
                    }
                });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span($"Total de pessoas multadas: {infos.Count}\n");
                        x.CurrentPageNumber();
                    });
            });
        })
        .GeneratePdf($"Multados-{DateTime.Now.ToString(@"dd-MM-yyyy")}.pdf");
    }
}
