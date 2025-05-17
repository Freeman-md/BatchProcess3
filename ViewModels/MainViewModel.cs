using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BatchProcess3.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SideMenuImage))]
    private bool _sideMenuExpanded = true;

    
    public SvgImage SideMenuImage => new SvgImage
    {
        Source = SvgSource.Load($"avares://{nameof(BatchProcess3)}/Assets/Images/{(SideMenuExpanded ? "logo" : "icon")}.svg")
    };

    [RelayCommand]
    private void SideMenuResized()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }
    
}