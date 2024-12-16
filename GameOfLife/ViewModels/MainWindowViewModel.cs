using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        r = new Random();

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                GameObjects.Add(new Plant(new Point(r.NextInt64(1000), r.NextInt64(1000)), 100, 100, 100, 100));
            }
            else if (i % 3 == 0)
            {
                GameObjects.Add(new Herbivore(new Point(r.NextInt64(1000), r.NextInt64(1000)), 50, 100, 500, 100, Gender.MALE, 100, @"..\..\..\Assets\sheep.wav"));
            }
            else if (i % 5 == 0)
            {
                GameObjects.Add(new Carnivore(new Point(r.NextInt64(1000), r.NextInt64(1000)), 100, 100, 1000, 100, Gender.MALE, 100, @"..\..\..\Assets\wolf.wav"));
            }
        }

        GameObjects.Add(new Plant(new Point(120, 600), 100, 100, 100, 100));
        GameObjects.Add(new Herbivore(new Point(700, 600), 50, 100, 500, 100, Gender.FEMALE, 100, @"..\..\..\Assets\sheep.wav"));
        GameObjects.Add(new Carnivore(new Point(200, 0), 100, 100, 1000, 100, Gender.FEMALE, 100, @"..\..\..\Assets\wolf.wav"));
    }

    protected override void Tick()
    {
        foreach (GameObject obj in GameObjects.ToList())
        {
            obj.Tick(GameObjects);
        }
    }

    public void addLifeForm(LifeForm lifeForm)
    {
        GameObjects.Add(lifeForm);
    }
}
