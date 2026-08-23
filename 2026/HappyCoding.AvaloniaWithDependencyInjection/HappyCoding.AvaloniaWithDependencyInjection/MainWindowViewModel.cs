using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HappyCoding.AvaloniaWithDependencyInjection.Model;
using HappyCoding.AvaloniaWithDependencyInjection.Services;

namespace HappyCoding.AvaloniaWithDependencyInjection;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IUserService _userService;

    [ObservableProperty]
    private IReadOnlyList<UserInfo> _userInfos = [];

    public static MainWindowViewModel DesignViewModel 
        => new MainWindowViewModel(new DesignDataUserService());
    
    public MainWindowViewModel(IUserService userService)
    {
        _userService = userService;
        
        LoadUsersCommand.Execute(null);
    }

    [RelayCommand]
    private void Clear()
    {
        this.UserInfos = [];
    }
    
    [RelayCommand]
    private void LoadUsers()
    {
        this.UserInfos = _userService.GetAllUsers();
    }
}