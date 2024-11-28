using System;
using System.Collections.Generic;
using Avalonia.Threading;

namespace gol.ViewModels;

// Impose d'implémenter la méthode Tick() et s'occupe de l'appeler 60 fois par seconde.
// Cela sert de "boucle" principale pour notre application graphique.
public abstract class GameBase: ViewModelBase
{
    public const int TicksPerSecond = 60;
    private readonly DispatcherTimer _timer = new() { Interval = new TimeSpan(0, 0, 0, 0, 1000 / TicksPerSecond) };
    private List<GameObject> objects = new List<GameObject>();

    protected GameBase()
    {
        _timer.Tick += delegate { DoTick(); };
    }

    public long CurrentTick { get; private set; }


    private void DoTick()
    {
        foreach (GameObject obj in objects)
        {
            obj.Tick();
        }
        Tick();
        CurrentTick++;
    }

    public void addLifeForm(LifeForm lifeForm)
    {
        lifeForms.Add(lifeForm);
    }

    protected abstract void Tick();

    // Appelé dans App.axaml.cs
    public void Start()
    {
        _timer.IsEnabled = true;
    }

    public void Stop()
    {
        _timer.IsEnabled = false;
    }
}