using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application.Initialization.Extern;

public interface IAssemblyLoader {
    public List<Assembly> Load();
}

internal class ModuleLoader {
    private readonly IWindsorContainer _mainContainer;
    private readonly IAssemblyLoader _assemblyLoader;

    public ModuleLoader(IWindsorContainer mainContainer,
                        IAssemblyLoader assemblyLoader) {
        _mainContainer = mainContainer;
        _assemblyLoader = assemblyLoader;
    }

    public void Load() {
        try {
            var assemblies = _assemblyLoader.Load();
            foreach(Assembly assembly in assemblies) {
                if(assembly.Equals(Assembly.GetExecutingAssembly()))
                    continue;

                Type? installer = assembly.DefinedTypes
                    .SingleOrDefault(x => x.ImplementedInterfaces.Contains(typeof(IWindsorInstaller)));
                if(installer == null)
                    continue;

                _mainContainer.Install(installer.CreateInstance<IWindsorInstaller>());
            }
        } catch(Exception ex) {
            ex.ToString();
        }
    }
}