using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BatchProcess3.ViewModels;
using BatchProcess3.Views;

namespace BatchProcess3;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        return new HomePageView();
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}