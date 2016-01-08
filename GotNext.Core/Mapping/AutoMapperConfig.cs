using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using GotNext.Core.Tasks;

namespace GotNext.Core.Mapping
{
    public class AutoMapperConfig : IRunAtInit
    {
        public void Execute()
        {
            var types = new List<Type>();

            var projects = AppAssemblies.AsEnumerable().Where(x => x.FullName.StartsWith("GotNext."));

            foreach (var project in projects)
            {
                types.AddRange(project.GetExportedTypes().AsEnumerable());
            }

            LoadStandardMappings(types);
            LoadCustomMappings(types);
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var fromMaps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in fromMaps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }

            var toMaps = (from t in types
                            from i in t.GetInterfaces()
                            where i.IsGenericType &&
                                  i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                                  !t.IsAbstract &&
                                  !t.IsInterface
                            select new
                            {
                                Source = t,
                                Destination = i.GetGenericArguments()[0]
                            }).ToArray();

            foreach (var map in toMaps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types 
                            from i in t.GetInterfaces()
                            where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                                !t.IsAbstract &&
                                !t.IsInterface
                            select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }
    }
}