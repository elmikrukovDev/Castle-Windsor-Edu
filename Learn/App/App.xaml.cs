using System.Windows;

namespace Application;

public partial class App {
    protected override void OnStartup(StartupEventArgs e) {
        ShutdownMode = ShutdownMode.OnMainWindowClose;
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e) {
        base.OnExit(e);
    }

    private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
        e.Handled = true;
        OnExit(null);
    }
}
