using StructureMap;

namespace GotNext.Web.Infrastructure.StructureMap
{
    public static class IoC
    {
        public static IContainer Container { get; set; }

        static IoC()
        {
            Container = new Container();
        }
    }
}