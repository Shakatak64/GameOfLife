using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gol.ViewModels;

public partial class Meat : GameObject {

    public Meat(Point location) : base(location) {
    }

    public override void Tick(ObservableCollection<GameObject> GameObjects)
    {
        base.Tick(GameObjects);
        if (Ticks > 500)
        {
            GameObjects.Remove(this);
            GameObjects.Add(new Waste(Location));
        }
    }

}