using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;


namespace gol.ViewModels;

public partial class Herbivore : Animal
{
	
	public Herbivore(Point location, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime, string soundPath) : base(location, health, energy, visionRadius, contactRadius, gender, reproductionTime, soundPath)
	{
		
	}

    public override Animal GiveBirth()
    {
        Random r = new Random();
        if (r.Next() == 0) return new Herbivore(Location, 100, 100, VisionRadius, ContactRadius, Gender.MALE, ReproductionTime, SoundPath);
        else return new Herbivore(Location, 100, 100, VisionRadius, ContactRadius, Gender.FEMALE, ReproductionTime, SoundPath);
    }
}