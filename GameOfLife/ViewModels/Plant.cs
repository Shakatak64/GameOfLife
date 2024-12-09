using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Collections.ObjectModel;
using System.Linq;

namespace gol.ViewModels;

public partial class Plant : LifeForm {
    [ObservableProperty]
    private float rootRadius;
    [ObservableProperty]
    private float seedRadius;
    [ObservableProperty]
    private float rootRenderDelta;
    [ObservableProperty]
    private float seedRenderDelta;

    public Plant(Point location, int health, int energy, float rootRadius, float seedRadius) : base(location, health, energy) {
        this.rootRadius = rootRadius;
        this.seedRadius = seedRadius;
        this.rootRenderDelta = -rootRadius / 2 + 3;
        this.seedRenderDelta = -seedRadius / 2 + 3;
    }

    public override void Tick()
    {
        base.Ticks++;
        if (base.Ticks % 1000 == 0) // very slow
        {
            grow();
        }
    }

    public Plant Reproduce()
    {
        Random rng = new();
        double radius = rng.NextDouble() * SeedRadius;
        double angle = rng.NextDouble() * 2*Math.PI;
        Point location = new Point(Location.X+radius*Math.Cos(angle), Location.Y+radius*Math.Sin(angle));
        return new Plant(location, 100, 100, 1, 10);
    }

    private void grow()
    {
        RootRadius += 1.5f;
        SeedRadius *= 1.05f;
        RootRenderDelta = -RootRadius / 2 + 3;
        SeedRenderDelta = -SeedRadius / 2 + 3;
    }

    public void eat(ObservableCollection<GameObject> objects)
    {
        foreach (GameObject obj in objects.ToList())
        {
            if (obj is Waste)
            {
                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(RootRadius / 2 + 10, 2)) // +10 arbitrary value to make nice on screen
                {
                    objects.Remove(obj);
                    if (Health >= 100)
                    {
                        grow();
                    }
                    else
                    {
                        Health += 20;
                    }
                }
            }
        }
    }
}