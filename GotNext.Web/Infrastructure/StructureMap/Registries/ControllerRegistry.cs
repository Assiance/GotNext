using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace GotNext.Web.Infrastructure.StructureMap.Registries
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            this.Scan(scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.With(new ControllerConvention());
                    });
        }
    }
}