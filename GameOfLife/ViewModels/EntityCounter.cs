using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace gol.ViewModels;

public partial class EntityCounter : GameObject {

    [ObservableProperty]
    public int objectCount = 0;

    public EntityCounter() : base(new Point(0,0)) {
    }

    public override void Tick(ObservableCollection<GameObject> GameObjects)
    {
        base.Tick(GameObjects);
        ObjectCount = GameObjects.Count;
    }
}