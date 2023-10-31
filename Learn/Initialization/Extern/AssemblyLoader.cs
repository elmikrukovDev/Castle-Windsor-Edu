using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Application.Initialization.Extern;

internal class AssemblyLoader : IAssemblyLoader
{
    public List<Assembly> Load()
    {
        return Directory
            .GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll")
            .Select(Assembly.LoadFrom)
            .ToList();
    }
}
