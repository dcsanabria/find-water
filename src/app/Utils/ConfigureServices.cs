using System;
using System.Collections.Generic;
using System.Text;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Utils
{
    public class ConfigureServices
    {
        public static IServiceProvider ServiceProvider;

        public static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IFindWater, FindWater>();
            ServiceProvider = collection.BuildServiceProvider();
        }

        public static void DisposeServices()
        {
            switch (ServiceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }
}
