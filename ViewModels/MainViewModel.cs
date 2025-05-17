using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BatchProcess3.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _sideMenuExpanded = true;


    [RelayCommand]
    private void SideMenuResized()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }
    
}