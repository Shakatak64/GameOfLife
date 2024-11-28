using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

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
}