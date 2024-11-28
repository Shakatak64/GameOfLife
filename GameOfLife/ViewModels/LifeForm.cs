using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace gol.ViewModels;

public abstract partial class LifeForm : GameObject {
    [ObservableProperty]
    private int health;

    private int counter = 0;

    public LifeForm(Point location, int health) : base(location) {
        this.health = health;
    }

    public abstract void Reproduce();

    public void Tick() {
        counter++;    
    }
}