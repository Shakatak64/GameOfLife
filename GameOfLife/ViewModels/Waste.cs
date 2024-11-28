using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class Waste : GameObject {
    [ObservableProperty]
    protected int counter = 0;

    public Waste(Point location) : base(location) {
    }

    public override void Tick() {}
}