using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Adapters;

namespace IocPerformance
{
    internal static class ContainerAdapterFactory
    {
        public static IEnumerable<IContainerAdapter> CreateAdapters()
        {
            yield return new NoContainerAdapter();

            var containers = typeof(ContainerAdapterFactory).Assembly.GetTypes()
                 .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IContainerAdapter)))
                 .Where(t => !t.Equals(typeof(NoContainerAdapter)))
                 .Select(t => Activator.CreateInstance(t))
                 .Cast<IContainerAdapter>()
                 .OrderBy(c => c.Name);

            if (containers.Count() != containers.Select(b => b.Name).Distinct().Count())
            {
                var duplicateNames = containers
                    .GroupBy(b => b.Name)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key);

                throw new InvalidOperationException(string.Format(
                    "ContainerAdapters must have unique names, the following names are used several times: {0}",
                    string.Join(", ", duplicateNames)));
            }

            var selected = containers.Where(c =>
            {
                //return c.Name == "Grace" || c.Name == "Microsoft Extensions DependencyInjection"
                //    || c.Name == "LightInject" || c.Name == "Unity" || c.Name == "Valles";

                //return c.Name == "Grace" || c.Name == "Microsoft Extensions DependencyInjection"
                //    c.Name == "Valles";

                return c.Name == "Valles";
            });

            foreach (var container in selected)
            {
                yield return container;
            }
        }
    }
}
