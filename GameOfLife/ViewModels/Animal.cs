using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;


namespace gol.ViewModels;

public enum Gender
{
	MALE,FEMALE
}

public abstract partial class Animal : LifeForm
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


	
	public Animal(Point location, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime) : base(location, health, energy)
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

	public abstract Animal GiveBirth();
}