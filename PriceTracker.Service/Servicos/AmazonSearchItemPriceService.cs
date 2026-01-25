using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceTracker.Service;

public class AmazonSearchItemPriceService : IServicoExecutor
{
    public int IdServico => 1;
    public async Task ExecuteAsync()
    {
        // Lógica para buscar o preço do item na Amazon
        await Task.Delay(1000); // Simulação de operação assíncrona
        Console.WriteLine("Preço do item da Amazon verificado.");
    }   
}
