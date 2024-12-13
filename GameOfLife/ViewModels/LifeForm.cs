using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class LifeForm : GameObject {
    [ObservableProperty]
    private int health;
    [ObservableProperty]
    private int energy;

    public int maxHealth { get; }
    public int maxEnergy { get; }

    protected int counter = 0;

    public LifeForm(Point location, int health, int energy) : base(location) {
        this.health = health; 
        this.energy = energy;
        this.maxHealth = health;
        this.maxEnergy = energy;
    }

    public void decreaseEnergy(int amount)
    {
        if(energy > 0) energy -= amount;
        else health -= amount;
    }

}