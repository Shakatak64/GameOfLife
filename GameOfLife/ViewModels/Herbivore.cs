using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;


namespace gol.ViewModels;

public partial class Herbivore : Animal
{
	
	public Herbivore(Point location, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime, string soundPath) : base(location, 4, health, energy, visionRadius, contactRadius, gender, reproductionTime, soundPath)
	{
		
	}

    public void eat(List<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            if (obj is Plant)
            {
                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(ContactRadius, 2))
                {
                    Plant plt = (Plant)obj;
                    if (Health < 100)
                    {
                        plt.Health -= 20;
                        Health += 20;
                    }
                }
            }
        }
    }

    public override Animal GiveBirth()
    {
        Random r = new Random();
        if (r.Next() == 0) return new Herbivore(Location, 100, 100, VisionRadius, ContactRadius, Gender.MALE, ReproductionTime, SoundPath);
        else return new Herbivore(Location, 100, 100, VisionRadius, ContactRadius, Gender.FEMALE, ReproductionTime, SoundPath);
    }
}