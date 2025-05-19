using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BatchProcess3.ViewModels;

namespace BatchProcess3;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        return null;
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}