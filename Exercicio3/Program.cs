using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;

class Program
{
    class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    static void Main()
    {
        string jsonPath = "../../../dados.json";
        string xmlPath = "../../../dados.xml";

        if (File.Exists(jsonPath))
        {
            Console.WriteLine("Resultados JSON:");
            List<Faturamento> faturamentoJson = LerJson(jsonPath);
            ProcessarFaturamento(faturamentoJson);
        }
        else
        {
            Console.WriteLine($"Arquivo JSON nao encontrado: {jsonPath}");
        }

        if (File.Exists(xmlPath))
        {
            Console.WriteLine("\nResultados XML:");
            List<Faturamento> faturamentoXml = LerXmlComRaiz(xmlPath);
            ProcessarFaturamento(faturamentoXml);
        }
        else
        {
            Console.WriteLine($"Arquivo XML nao encontrado: {xmlPath}");
        }
    }

    static List<Faturamento> LerJson(string path)
    {
        string jsonData = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Faturamento>>(jsonData);
    }

    static List<Faturamento> LerXmlComRaiz(string path)
    {
        string xmlData = File.ReadAllText(path);

        string xmlComRaiz = $"<rows>{xmlData}</rows>";

        XDocument xmlDoc = XDocument.Parse(xmlComRaiz);

        return xmlDoc.Root.Elements("row")
            .Select(x => new Faturamento
            {
                Dia = int.Parse(x.Element("dia").Value),
                Valor = double.Parse(x.Element("valor").Value)
            }).ToList();
    }

    static void ProcessarFaturamento(List<Faturamento> faturamento)
    {
        var valoresValidos = faturamento.Where(f => f.Valor > 0).Select(f => f.Valor).ToList();

        if (!valoresValidos.Any())
        {
            Console.WriteLine("Nenhum dia com faturamento valido encontrado.");
            return;
        }

        double menorValor = valoresValidos.Min();
        double maiorValor = valoresValidos.Max();
        double mediaMensal = valoresValidos.Average();
        int diasAcimaMedia = valoresValidos.Count(v => v > mediaMensal);

        Console.WriteLine($"Menor faturamento: {menorValor:F2}");
        Console.WriteLine($"Maior faturamento: {maiorValor:F2}");
        Console.WriteLine($"Dias acima da media: {diasAcimaMedia}");
    }
}
