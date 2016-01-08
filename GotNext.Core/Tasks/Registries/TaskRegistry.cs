using System.Linq;
using System.Reflection;
using GotNext.Web.Infrastructure.Tasks;
using StructureMap.Configuration.DSL;

namespace GotNext.Core.Tasks.Registries
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            var projects = AppAssemblies.AsEnumerable().Where(x => x.FullName.StartsWith("GotNext."));

            this.Scan(
                scan =>
                    {
                        foreach (var project in projects)
                        {
                            scan.Assembly(project);
                            scan.AddAllTypesOf<IRunAtInit>();
                            scan.AddAllTypesOf<IRunAtStartup>();
                            scan.AddAllTypesOf<IRunOnEachRequest>();
                            scan.AddAllTypesOf<IRunOnError>();
                            scan.AddAllTypesOf<IRunAfterEachRequest>();
                        }
                    });
        }
    }
}