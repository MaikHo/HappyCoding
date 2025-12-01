using HappyCoding.AvaloniaWinFormsIntegration.Views;

namespace HappyCoding.AvaloniaWinFormsIntegration
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            _avaloniaHost.Content = new AvaloniaMainView()
            {
                DataContext = new AvaloniaMainViewModel()
            };
        }
    }
}
