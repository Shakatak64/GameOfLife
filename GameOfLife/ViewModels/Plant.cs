using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace gol.ViewModels;

public partial class Plant : LifeForm {
    [ObservableProperty]
    private float rootRadius;
    [ObservableProperty]
    private float seedRadius;

    public Plant(Point location, int health, float rootRadius, float seedRadius) : base(location, health) {
        this.rootRadius = rootRadius;
        this.seedRadius = seedRadius;
    }

    public override void Reproduce(LifeForm with)
    {
        if (with is Plant)
        {
            //...
        }
    }
}