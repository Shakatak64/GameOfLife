using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;


namespace gol.ViewModels;

public partial class Carnivore : Animal
{
	
	public Carnivore(Point location, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime) : base(location, health, energy, visionRadius, contactRadius, gender, reproductionTime)
	{
		
	}

	public override Animal GiveBirth()
	{
		Random r = new Random();
		if (r.Next() == 0) return new Carnivore(Location, 200, 100, VisionRadius, ContactRadius, Gender.MALE, ReproductionTime);
		else return new Carnivore(Location, 200, 100, VisionRadius, ContactRadius, Gender.FEMALE, ReproductionTime);
	}
}