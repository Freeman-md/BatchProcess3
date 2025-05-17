using CommunityToolkit.Mvvm.ComponentModel;

namespace BatchProcess3.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _test = "test";
}