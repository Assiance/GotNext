using StructureMap;
using StructureMap.Graph;

namespace GotNext.Domain.Registries
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            //any spefic implementation   
        }
    }
}
