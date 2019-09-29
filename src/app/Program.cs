using System;
using System.Threading.Tasks;
using App.Utils;
using Core.Models;
using Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public class Program : ConfigureServices
    {
        private static async Task Main()
        {
            RegisterServices();
            var service = ServiceProvider.GetService<IFindWater>();

            // Prepare data:
            Console.Write("Column (i):");
            var column = Console.ReadLine();
            Console.Write("Row (j):");
            var row = Console.ReadLine();
            Console.Write("Water flow:");
            var waterFlow = Console.ReadLine();

            var glass = new Glass
            {
                Column = int.Parse(column ?? throw new InvalidOperationException()),
                Row = int.Parse(row ?? throw new InvalidOperationException())
            };
            var water = new Water { Flow = int.Parse(waterFlow ?? throw new InvalidOperationException()) };

            var res = await service.FindWaterFlow(glass, water);

            Console.WriteLine($"Result: {res}");
            Console.Read();

            DisposeServices();
        }


    }
}