using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCoding.AvaloniaWinFormsIntegration.Views;

internal partial class AvaloniaMainViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    private string _name = "Roland";

    public string Greeting => $"Hello, {this.Name}!";
}
