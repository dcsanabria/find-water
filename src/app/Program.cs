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
        private const string Title = "Water Flow Problem";
        private const string Separators = "--------------------------------------";

        private static void Main()
        {

            RegisterServices();
            Console.WriteLine(Separators);
            Console.WriteLine(Title.ToUpper());
            Console.WriteLine("By default the Maximum of water per glass is 250ml, to find the amount of water in a given glass please enter the data:");
            Console.WriteLine(Separators);

            try
            {
                CalculateWaterFlow();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            DisposeServices();
        }


        private static void CalculateWaterFlow()
        {
            while (true)
            {
                var service = ServiceProvider.GetService<IFindWater>();

                // Prepare data:
                Console.Write("Please enter the Column for the glass (i):");
                var column = Console.ReadLine();
                Console.Write("Please enter the Row for the glass (j):");
                var row = Console.ReadLine();
                Console.Write("How much water you want to sever:");
                var waterFlow = Console.ReadLine();

                if (string.IsNullOrEmpty(column) || string.IsNullOrEmpty(row) || string.IsNullOrEmpty(waterFlow))
                {
                    Console.WriteLine("Data cannot be null, empty or negative.");
                    CalculateWaterFlow();
                }

                var glass = new Glass
                {
                    Column = int.Parse(column),
                    Row = int.Parse(row)
                };
                var water = new Water { Flow = int.Parse(waterFlow ?? throw new InvalidOperationException()) };

                var res = service.FindWaterFlow(glass, water);

                Console.WriteLine($"Result: {res}");
                Console.WriteLine("Would you like to try again? (Y/N)");

                var input = Console.ReadKey();
                Console.WriteLine();

                if (input.KeyChar == 'Y' || input.KeyChar == 'y')
                {
                    Console.WriteLine(Separators);
                    continue;
                }

                break;
            }
        }

      
    }
}