using Avalonia;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gol.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1000;
    public int Height { get; } = 1000;

    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        GameObjects.Add(new Herbivore(new Avalonia.Point(600, 600), 100, 100, 100, 100, Gender.MALE, 100, @"C:\Users\Hugo\source\repos\GameOfLifeVicto\GameOfLife\Assets\sheep.wav"));
    }

    protected override void Tick()
    {
        foreach (GameObject obj in GameObjects)
        {
            obj.Tick();
        }
    }

    public void addLifeForm(LifeForm lifeForm)
    {
        GameObjects.Add(lifeForm);
    }
}
