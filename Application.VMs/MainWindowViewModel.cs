using ReactiveUI;

namespace Application.ViewModels;

public class MainWindowViewModel : ReactiveObject, System.IDisposable
{
    private string test = string.Empty;

    public string Test
    {
        get => test;
        set => this.RaiseAndSetIfChanged(ref test, value);
    }

    public MainWindowViewModel()
    {
        Test = "Test";
    }

    public void Dispose()
    {

    }
}