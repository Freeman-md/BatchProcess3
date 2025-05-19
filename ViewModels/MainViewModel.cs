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
    private ViewModelBase _currentPage;
    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool ProcessPageIsActive => CurrentPage == _processPage;

    private readonly HomePageViewModel _homePage = new();
    private readonly ProcessPageViewModel _processPage = new();

    public MainViewModel()
    {
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
    
}