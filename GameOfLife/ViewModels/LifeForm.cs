using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class LifeForm : GameObject {
    [ObservableProperty]
    private int health;
    [ObservableProperty]
    private int energy;

    public int maxHealth { get; }
    public int maxEnergy { get; }

    public LifeForm(Point location, int health, int energy) : base(location) {
        this.health = health; 
        this.energy = energy;
        this.maxHealth = health;
        this.maxEnergy = energy;
    }

    public void decreaseEnergy(int amount)
    {
        if(energy < 1) health -= amount;
        else if(energy < amount) { 
            health-= Math.Abs(energy-amount);
            energy = 0;
        }
        else energy -= amount;
    }

}