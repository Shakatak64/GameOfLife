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
        GameObjects.Add(new Plant(new Point(120, 600), 100, 100, 100, 100));
        GameObjects.Add(new Herbivore(new Point(700, 600), 50, 100, 500, 100, Gender.MALE, 100, @"..\..\..\Assets\sheep.wav"));
        GameObjects.Add(new Carnivore(new Point(200, 0), 100, 100, 1000, 100, Gender.MALE, 100, @"..\..\..\Assets\wolf.wav"));
    }

    protected override void Tick()
    {
        foreach (GameObject obj in GameObjects.ToList())
        {
            obj.Tick();
            if (obj is Carnivore)
            {
                Carnivore animal = (Carnivore) obj;
                animal.Move(GameObjects);

                if (CurrentTick % 25 == 0) animal.eat(GameObjects);
            }
            else if (obj is Herbivore)
            {
                Herbivore animal = (Herbivore)obj;
                animal.Move(GameObjects);

                // TO-DO: il faut utiliser les ticks propres de chaque animal
                if (CurrentTick % 25 == 0) animal.eat(GameObjects);
                if (animal.Health < 1) {
                    GameObjects.Remove(animal);
                    GameObjects.Add(new Meat(animal.Location));
                }

            }
            else if (obj is Plant)
            {
                Plant plant = (Plant)obj;
                plant.eat(GameObjects);
            }
            else if (obj is Meat)
            {
                Meat meat = (Meat)obj;
                if (meat.Ticks > 500)
                {
                    GameObjects.Remove(meat);
                    GameObjects.Add(new Waste(meat.Location));
                }
            }
        }

        if(CurrentTick % 25 == 0)
        {
            GameObjects.Add(new Waste(new Avalonia.Point(r.NextInt64(0,1000), r.NextInt64(0,1000))));
        }
    }

    public void addLifeForm(LifeForm lifeForm)
    {
        GameObjects.Add(lifeForm);
    }
}
