using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Types;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SalesTaxes
{
    public static class Bootstrapper
    {
        public static ServiceProvider Bootstrap()
        {
            PrimeAppDomain();
            var serviceCollection = new ServiceCollection();                
            LoadModules(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        private static void PrimeAppDomain()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic).ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "SalesTaxes.*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }

        static void LoadModules(IServiceCollection serviceCollection)
        {
            var moduleInterface = typeof(IModule);
            var moduleTypes = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic && x.FullName.StartsWith("SalesTaxes.")).SelectMany(x => x.GetTypes())
                .Where(x => moduleInterface.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

            foreach (var moduleType in moduleTypes)
            {
                var module = (IModule)Activator.CreateInstance(moduleType);
                module.RegisterTypes(serviceCollection);
            }
        }
    }
}
