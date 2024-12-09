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

    public MainWindowViewModel()
    {
        GameObjects.Add(new Plant(new Avalonia.Point(120, 600), 100, 100, 100, 100));
        GameObjects.Add(new Herbivore(new Avalonia.Point(40, 600), 100, 100, 500, 100, Gender.MALE, 100, @"C:\Users\Hugo\source\repos\GameOfLifeVicto\GameOfLife\Assets\sheep.wav"));
        GameObjects.Add(new Carnivore(new Avalonia.Point(200, 0), 100, 100, 1000, 100, Gender.MALE, 100, @"C:\Users\Hugo\source\repos\GameOfLifeVicto\GameOfLife\Assets\sheep.wav"));
    }

    protected override void Tick()
    {
        foreach (GameObject obj in GameObjects)
        {
            obj.Tick();
            if (obj is Animal)
            {
                Animal animal = (Animal)obj;
                animal.Move(animal.DefineTarget(GameObjects));
            }
        }
    }

    public void addLifeForm(LifeForm lifeForm)
    {
        GameObjects.Add(lifeForm);
    }
}
