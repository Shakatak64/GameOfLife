using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gol.ViewModels;

public partial class Plant : LifeForm {
    [ObservableProperty]
    private float rootRadius;
    [ObservableProperty]
    private float seedRadius;

    public Plant(Point location, uint health, float rootRadius, float seedRadius) : base(location, health) {
        this.rootRadius = rootRadius;
        this.seedRadius = seedRadius;
    }

    public Plant Reproduce()
    {
        Random rng = new();
        double radius = rng.NextDouble() * SeedRadius;
        double angle = rng.NextDouble() * 2*Math.PI;
        Point location = new Point(Location.X+radius*Math.Cos(angle), Location.Y+radius*Math.Sin(angle));
        return new Plant(location, 20, 1, 10);
    }

    private void grow()
    {
        RootRadius += 1.2f;
        SeedRadius *= 1.2f;
    }

    public void eat(List<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            if (obj is Waste)
            {
                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(RootRadius, 2))
                {
                    objects.Remove(obj);
                    if (Health >= 20)
                    {
                        grow();
                    }
                    else
                    {
                        Health += 5;
                    }
                }
            }
        }
    }
}