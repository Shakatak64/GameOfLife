using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;


namespace gol.ViewModels;

public partial class Herbivore : Animal
{
	
	public Herbivore(Point location, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime) : base(location, health, energy, visionRadius, contactRadius, gender, reproductionTime)
	{
		
	}

    public override Animal GiveBirth()
    {
        Random r = new Random();
        if (r.Next() == 0) return new Herbivore(Location, 100, 100, VisionRadius, ContactRadius, Gender.MALE, ReproductionTime);
        else return new Herbivore(Location, 100, 100, VisionRadius, ContactRadius, Gender.FEMALE, ReproductionTime);
    }
}