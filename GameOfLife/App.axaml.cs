using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using gol.ViewModels;
using gol.Views;

namespace gol;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            MainWindowViewModel game = new MainWindowViewModel();
            game.Start();
            desktop.MainWindow = new MainWindow
            {
                DataContext = game,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}