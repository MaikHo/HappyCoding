using Avalonia.Controls;

namespace HappyCoding.AvaloniaViewModelValidationByViewModel;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (!Design.IsDesignMode)
        {
            this.DataContext = new MainWindowViewModel();
        }
    }
}