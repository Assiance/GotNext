using StructureMap;
using StructureMap.Graph;

namespace GotNext.Core.Registries
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
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
