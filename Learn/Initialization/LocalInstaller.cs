using Application.Initialization.Extern;
using Application.Interceptors;
using Castle.DynamicProxy;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Application.Initialization;

public class LocalInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Component.For<IWindsorContainer>().Instance(container),

            Component.For<IInterceptor>()
                     .ImplementedBy<AppInterceptor>()
                     .LifestyleTransient()
                     .Named("appLogger"),

            Component.For<IAssemblyLoader>()
                     .ImplementedBy<AssemblyLoader>()
                     .LifestyleTransient(),
            Component.For<ModuleLoader>()
                     .StartUsingMethod("Load")
                     .LifestyleTransient()
        );
    }
}