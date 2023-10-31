using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Application.Initialization;

public class ApplicationInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Component.For<System.Windows.Application>()
                 .ImplementedBy<App>()
                 .DependsOn(new Dependency[] {
                     Dependency.OnComponent(typeof(System.Windows.Window), "mainWindow")
                 })
                 .StartUsingMethod("Run")
                 .Interceptors(InterceptorReference.ForKey("appLogger"))
                 .Anywhere
        );
    }
}