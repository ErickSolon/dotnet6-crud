using EstudoRepositories.Models.DTOs;
using ExportData.Utils;
using Newtonsoft.Json;

public class Program
{
    private static async Task Main(string[] args)
    {
        using (var Http = new HttpClient())
        {
            var Response = await Http.GetStringAsync("https://localhost:7042/api/Detran");
            List<MultadosDTO> Result = JsonConvert.DeserializeObject<List<MultadosDTO>>(Response);

            var pdf = new PDFWriter();
            pdf.PDFWrite(Result);

            Console.WriteLine($"Dados adicionados, Total de itens: {Result.Count}");
            
        }

        await Task.Delay(2000);
    }
}