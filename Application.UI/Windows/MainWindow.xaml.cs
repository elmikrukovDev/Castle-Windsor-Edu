namespace Application.UI.Windows;

public partial class MainWindow {
    public MainWindow() {

    }

    public MainWindow(Common.ViewModelBase viewModel) {
        InitializeComponent();
        DataContext = viewModel;
    }
}
