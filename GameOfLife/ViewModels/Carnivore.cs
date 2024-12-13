using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace gol.ViewModels;

public partial class Carnivore : Animal
{

	public Carnivore(Point location, int health, int energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime, string soundPath) : base(location, 4 , health, energy, visionRadius, contactRadius, gender, reproductionTime, soundPath)
	{
		
	}


    public void eat(ObservableCollection<GameObject> objects)
    {
        foreach (GameObject obj in objects.ToList())
        {
            if (obj is Herbivore)
            {
                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(ContactRadius, 2))
                {
                    Herbivore herbivore = (Herbivore)obj;
                    herbivore.Health -= 10;
                    playEatSound();
                }
            }
            if (obj is Meat)
            {
                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(ContactRadius, 2))
                {
                    Meat meat = (Meat)obj;
                    objects.Remove(meat);
                    Health += 10;
                    playEatSound();
                }
            }
        }
    }

    public override Animal GiveBirth()
	{
        Pregnant = false;
        Random r = new Random();
		if (r.Next() == 0) return new Carnivore(Location, 200, 100, VisionRadius, ContactRadius, Gender.MALE, ReproductionTime, SoundPath);
		else return new Carnivore(Location, 200, 100, VisionRadius, ContactRadius, Gender.FEMALE, ReproductionTime, SoundPath);
	}
}