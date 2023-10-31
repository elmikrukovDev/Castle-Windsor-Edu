using Castle.Facilities.Startable;
using Castle.Windsor;
using NLog;

namespace Application;

public class Program {
    private static System.IDisposable? _container;

    [System.STAThread]
    public static void Main(string[] args) {
        try {
            Start();
        } catch(System.Exception e) {
            LogManager.GetCurrentClassLogger().Fatal(e);
        } finally {
            _container?.Dispose();
        }
    }

    private static void Start() {
        var container = new WindsorContainer();
        container.AddFacility<StartableFacility>(f => f.DeferredStart());
        container.Install(new Initialization.LocalInstaller());
        container.Install(new Initialization.ApplicationInstaller());
        _container = container;
    }
}
