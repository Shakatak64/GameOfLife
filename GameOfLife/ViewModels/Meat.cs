using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class Meat : GameObject {

    public Meat(Point location) : base(location) {
    }

}