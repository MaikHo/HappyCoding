using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace HappyCoding.AvaloniaWithDependencyInjection;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (!Design.IsDesignMode)
        {
            this.DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
        }
    }
}