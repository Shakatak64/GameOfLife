using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace gol.ViewModels;

// représente un objet affichable sur l'interface
public abstract partial class GameObject : ViewModelBase
{
    [ObservableProperty]
    private Point _location;

    [ObservableProperty]
    private int ticks = 0;


    protected GameObject(Point location)
    {
        Location = location;
    }

    public virtual void Tick(ObservableCollection<GameObject> GameObjects)
    {
        Ticks++;
    }
}