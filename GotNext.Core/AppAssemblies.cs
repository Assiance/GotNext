using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Core
{
    public static class AppAssemblies
    {
        public static IEnumerable<Assembly> AsEnumerable()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            foreach (Assembly assembly in Directory.GetFiles(baseDirectory)
                     .Where(x => Path.GetExtension(x).Equals(".dll", StringComparison.OrdinalIgnoreCase))
                     .Select(Assembly.LoadFrom))
            {
                yield return assembly;
            }

            string binPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
            if (!Directory.Exists(binPath))
            {
                yield break;
            }

            foreach (Assembly assembly in Directory.GetFiles(binPath)
                     .Where(x => Path.GetExtension(x).Equals(".dll", StringComparison.OrdinalIgnoreCase))
                     .Select(Assembly.LoadFrom))
            {
                yield return assembly;
            }
        }
    }
}
