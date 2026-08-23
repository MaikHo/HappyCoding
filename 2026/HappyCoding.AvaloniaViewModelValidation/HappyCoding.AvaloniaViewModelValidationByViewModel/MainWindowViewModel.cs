using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HappyCoding.AvaloniaViewModelValidationByViewModel;

public partial class MainWindowViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [MinLength(1, ErrorMessage = "This field is required")]
    [MaxLength(100, ErrorMessage = "Too many characters (max 100)")]
    private string _firstName = "Max";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [MinLength(1, ErrorMessage = "This field is required")]
    [MaxLength(100, ErrorMessage = "Too many characters (max 100)")]
    private string _lastName = string.Empty;
    
    public string Greeting => this.HasErrors ? "-" : $"Hello, {this.FirstName} {this.LastName}";

    public MainWindowViewModel()
    {
        this.ValidateAllProperties();
    }
}