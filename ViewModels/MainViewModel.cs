using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BatchProcess3.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const string buttonActiveClass = "active";
    
    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ActionsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(MacrosPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ReporterPageIsActive))]
    [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
    [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
    private ViewModelBase _currentPage;
    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool ProcessPageIsActive => CurrentPage == _processPage;
    public bool ActionsPageIsActive => CurrentPage == _actionsPage;
    public bool MacrosPageIsActive => CurrentPage == _macrosPage;
    public bool ReporterPageIsActive => CurrentPage == _reporterPage;
    public bool HistoryPageIsActive => CurrentPage == _historyPage;
    public bool SettingsPageIsActive => CurrentPage == _settingsPage;
    
    private readonly HomePageViewModel _homePage;
    private readonly ProcessPageViewModel _processPage;
    private readonly ActionsPageViewModel _actionsPage;
    private readonly MacrosPageViewModel _macrosPage;
    private readonly ReporterPageViewModel _reporterPage;
    private readonly HistoryPageViewModel _historyPage;
    private readonly SettingsPageViewModel _settingsPage;

    public MainViewModel(
        HomePageViewModel homePage,
        ProcessPageViewModel processPage,
        ActionsPageViewModel actionsPage,
        MacrosPageViewModel macrosPage,
        ReporterPageViewModel reporterPage,
        HistoryPageViewModel historyPage,
        SettingsPageViewModel settingsPage)
    {
        _homePage = homePage;
        _processPage = processPage;
        _actionsPage = actionsPage;
        _macrosPage = macrosPage;
        _reporterPage = reporterPage;
        _historyPage = historyPage;
        _settingsPage = settingsPage;
        
        CurrentPage = _homePage;
    }

    [RelayCommand]
    private void SideMenuResized()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }

    [RelayCommand]
    private void GoToHome()
    {
        CurrentPage = _homePage;
    }
    
    [RelayCommand]
    private void GoToProcess()
    {
        CurrentPage = _processPage;
    }
    
    [RelayCommand]
    private void GoToActions()
    {
        CurrentPage = _actionsPage;
    }

    [RelayCommand]
    private void GoToMacros()
    {
        CurrentPage = _macrosPage;
    }

    [RelayCommand]
    private void GoToReporter()
    {
        CurrentPage = _reporterPage;
    }

    [RelayCommand]
    private void GoToHistory()
    {
        CurrentPage = _historyPage;
    }

    [RelayCommand]
    private void GoToSettings()
    {
        CurrentPage = _settingsPage;
    }
    
}