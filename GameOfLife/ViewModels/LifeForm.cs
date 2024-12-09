using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class LifeForm : GameObject {
    [ObservableProperty]
    private uint health;
    [ObservableProperty]
    private uint energy;

    protected int counter = 0;

    public LifeForm(Point location, uint health, uint energy) : base(location) {
        this.health = health; 
        this.energy = energy;
    }

    public void decreaseHealth(uint amount)
    {
        if(health > 0) health -= amount;
        else energy -= amount;
    }

}