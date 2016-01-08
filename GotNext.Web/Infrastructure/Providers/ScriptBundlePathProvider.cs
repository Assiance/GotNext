using System.Web.Hosting;

namespace GotNext.Web.Infrastructure.Providers
{
    public class ScriptBundlePathProvider : VirtualPathProvider
    {
        private readonly VirtualPathProvider _virtualPathProvider;

        public ScriptBundlePathProvider(VirtualPathProvider virtualPathProvider)
        {
            _virtualPathProvider = virtualPathProvider;
        }

        public override bool FileExists(string virtualPath)
        {
            return _virtualPathProvider.FileExists(virtualPath);
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            return _virtualPathProvider.GetFile(virtualPath);
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            return _virtualPathProvider.GetDirectory(virtualDir);
        }

        public override bool DirectoryExists(string virtualDir)
        {
            return _virtualPathProvider.DirectoryExists(virtualDir);
        }
    }
}