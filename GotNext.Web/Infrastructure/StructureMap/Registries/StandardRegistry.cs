using System.Linq;
using System.Reflection;
using GotNext.Core;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace GotNext.Web.Infrastructure.StructureMap.Registries
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            var projects = AppAssemblies.AsEnumerable().Where(x => x != Assembly.GetExecutingAssembly() && x.FullName.StartsWith("GotNext."));

            this.Scan(scan =>
                    {
                        foreach (var project in projects)
                        {
                            scan.Assembly(project);
                        }

                        scan.WithDefaultConventions();
                        scan.LookForRegistries();
                    });
        }
    }
}