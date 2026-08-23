using Avalonia;
using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using HappyCoding.AvaloniaWithAsyncRelayCommand.Services;
using HappyCoding.AvaloniaWithAsyncRelayCommand.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace HappyCoding.AvaloniaWithAsyncRelayCommand;

public static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        ConfigureServices();
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        // ViewModels
        services.AddTransient<MainWindowViewModel>();
        
        // Business logic and faked data access layer
        services.AddScoped<IUserRepository, RandomGeneratedUserRepository>();
        services.AddScoped<GetAllUsersUseCase>();
        
        Ioc.Default.ConfigureServices(services.BuildServiceProvider());
    }
}