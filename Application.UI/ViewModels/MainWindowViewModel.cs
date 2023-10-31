using ReactiveUI.Fody.Helpers;
using System;

namespace Application.UI.ViewModels;

public class MainWindowViewModel : Common.ViewModelBase, IDisposable {

    [Reactive]
    public string Title { get; set; }

    public MainWindowViewModel() {
        Title = "Test";
    }

    public void Dispose() {

    }
}