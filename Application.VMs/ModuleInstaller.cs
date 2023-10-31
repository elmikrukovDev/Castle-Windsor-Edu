using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ReactiveUI;

namespace Application.ViewModels;

public class ModuleInstaller : IWindsorInstaller {
    public void Install(IWindsorContainer container, IConfigurationStore store) {
        container.Register(
            Component.For<ReactiveObject>()
                     .ImplementedBy<MainWindowViewModel>()
                     .Named("MainWindowViewModel")
        );
    }
}
