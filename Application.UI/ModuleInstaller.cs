using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Application.UI;

public class ModuleInstaller : IWindsorInstaller {
    public void Install(IWindsorContainer container, IConfigurationStore store) {
        container.Register(
            Component.For<Common.ViewModelBase>()
                     .ImplementedBy<ViewModels.MainWindowViewModel>()
                     .Named("MainWindowViewModel"),
            Component.For<Windows.MainWindow>()
                     .DependsOn(new Dependency[] {
                         Dependency.OnComponent(typeof(ReactiveUI.ReactiveObject), "MainWindowViewModel")
                     })
                     .Named("mainWindow")
        );
    }
}
