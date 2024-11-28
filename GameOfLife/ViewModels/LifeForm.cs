using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class LifeForm : GameObject {
    [ObservableProperty]
    private uint health;

    protected int counter = 0;

    public LifeForm(Point location, uint health) : base(location) {
        this.health = health;
    }

    public override void Tick() {
        counter++;    
    }
}