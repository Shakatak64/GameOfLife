using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace gol.ViewModels;

public abstract partial class Waste : GameObject {

    public Waste(Point location) : base(location) {
    }


}