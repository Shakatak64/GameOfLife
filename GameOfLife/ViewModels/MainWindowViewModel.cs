using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gol.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1000;
    public int Height { get; } = 1000;

    private Random r;

    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel()
    {
        GameObjects.Add(new Plant(new Point(120, 600), 100, 100, 100, 100));
        GameObjects.Add(new Herbivore(new Point(700, 600), 100, 100, 500, 100, Gender.MALE, 100, @"..\..\..\Assets\sheep.wav"));
        GameObjects.Add(new Carnivore(new Point(200, 0), 100, 100, 1000, 100, Gender.MALE, 100, @"..\..\..\Assets\sheep.wav"));
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
        if(CurrentTick % 10 == 0)
        {
            GameObjects.Add(new Waste(new Avalonia.Point(r.NextInt64(0,1000), r.NextInt64(0,1000))));
        }
    }

    public void addLifeForm(LifeForm lifeForm)
    {
        GameObjects.Add(lifeForm);
    }
}
