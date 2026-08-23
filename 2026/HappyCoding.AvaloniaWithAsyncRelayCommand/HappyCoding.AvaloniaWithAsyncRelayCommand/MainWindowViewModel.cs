using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HappyCoding.AvaloniaWithAsyncRelayCommand.Model;
using HappyCoding.AvaloniaWithAsyncRelayCommand.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace HappyCoding.AvaloniaWithAsyncRelayCommand;

public partial class MainWindowViewModel : ObservableObject
{
    public static MainWindowViewModel DesignViewModel => new MainWindowViewModel();
    
    private readonly IServiceProvider? _serviceProvider;
    
    [ObservableProperty]
    private IReadOnlyList<UserInfo> _userInfos = [];
    
    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Constructor for DesignMode
    /// </summary>
    public MainWindowViewModel()
    {
        _userInfos =
        [
            new UserInfo()
            {
                EMail = "roland.koenig@rolandk.de",
                FirstName = "Roland",
                Gender = "Male",
                LastName = "König",
                UserName = "RolandK"
            }
        ];
    }
    
    [RelayCommand]
    private void Clear()
    {
        this.UserInfos = [];
    }
    
    [RelayCommand]
    private async Task LoadUsersAsync(CancellationToken cancellationToken)
    {
        if (_serviceProvider == null) { return; } // DesignMode
        
        await using var serviceScope = _serviceProvider.CreateAsyncScope();
        var services = serviceScope.ServiceProvider;

        var getAllUsersUseCase = services.GetRequiredService<GetAllUsersUseCase>();
        this.UserInfos = await getAllUsersUseCase.GetAllUsersAsync(cancellationToken);
    }
}