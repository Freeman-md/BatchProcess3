using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BatchProcess3.Data;
using BatchProcess3.Factories;
using BatchProcess3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BatchProcess3;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        
        DataTemplates.Add(new ViewLocator());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();

        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<ProcessPageViewModel>();
        collection.AddTransient<ActionsPageViewModel>();
        collection.AddTransient<MacrosPageViewModel>();
        collection.AddTransient<HistoryPageViewModel>();
        collection.AddTransient<ReporterPageViewModel>();
        collection.AddTransient<SettingsPageViewModel>();

        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Home => x.GetRequiredService<HomePageViewModel>(),
            ApplicationPageNames.Process => x.GetRequiredService<ProcessPageViewModel>(),
            ApplicationPageNames.Actions => x.GetRequiredService<ActionsPageViewModel>(),
            ApplicationPageNames.Macros => x.GetRequiredService<MacrosPageViewModel>(),
            ApplicationPageNames.Reporter => x.GetRequiredService<ReporterPageViewModel>(),
            ApplicationPageNames.History => x.GetRequiredService<HistoryPageViewModel>(),
            ApplicationPageNames.Settings => x.GetRequiredService<SettingsPageViewModel>(),
            _ => throw new InvalidOperationException()
        });

        collection.AddSingleton<PageFactory>();
        
        var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Views.MainView
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}