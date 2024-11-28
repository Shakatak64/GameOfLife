using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;


namespace gol.ViewModels;

public enum Gender
{
	MALE,FEMALE
}

public partial class Animal : LifeForm
{
	[ObservableProperty]
	private int visionRadius;

	[ObservableProperty]
	private int contactRadius;

	[ObservableProperty]
	private Gender gender;

	[ObservableProperty]
	private int reproductionTime;

	[ObservableProperty]
	private int nextBirth = 0;


	
	public Animal(Point location, uint health, int visionRadius, int contactRadius, Gender gender, int reproductionTime) : base(location, health)
	{
		this.contactRadius = contactRadius;
		this.visionRadius = visionRadius;
		this.gender = gender;
		this.reproductionTime = reproductionTime;

	}

    public void HaveSxx(LifeForm with)
    {
        if (with is Animal)
		{
			Animal withAnimal = (Animal) with;
            if (withAnimal.Gender != Gender)
			{
				if(CanReproduce() && withAnimal.CanReproduce())
				{
					NextBirth = base.counter + ReproductionTime;
				}
			}
		}
    }

	public bool CanReproduce()
	{
		return base.counter > NextBirth; 
	}

	public bool CanGiveBirth()
	{
		return base.counter == NextBirth & Gender == Gender.FEMALE;
	}

	public Animal GiveBirth()
	{
		Random r = new Random();
		if(r.Next() == 0) return new Animal(Location, 100, visionRadius, contactRadius, Gender.MALE, ReproductionTime);
		else return new Animal(Location, 100, visionRadius, contactRadius, Gender.FEMALE, ReproductionTime);
	}
}