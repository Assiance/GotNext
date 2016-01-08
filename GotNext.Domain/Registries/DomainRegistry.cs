using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap.Configuration.DSL;
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
