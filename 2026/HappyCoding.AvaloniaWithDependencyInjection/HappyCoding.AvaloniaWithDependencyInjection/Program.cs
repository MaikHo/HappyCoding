using Avalonia;
using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using HappyCoding.AvaloniaWithDependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HappyCoding.AvaloniaWithDependencyInjection;

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

    /// <summary>
    /// Configure DependencyInjection
    /// </summary>
    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IUserService, RandomGeneratedUserService>();
        services.AddTransient<MainWindowViewModel>();
        
        Ioc.Default.ConfigureServices(services.BuildServiceProvider());
    }
}