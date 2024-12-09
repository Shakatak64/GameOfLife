using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Media;


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

	[ObservableProperty]
	private string soundPath;

    public SoundPlayer sound;



	
	public Animal(Point location, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime, string soundPath) : base(location, health, energy)
	{
        this.contactRadius = contactRadius;
		this.visionRadius = visionRadius;
		this.gender = gender;
		this.reproductionTime = reproductionTime;
		SoundPath = soundPath;
		sound = new SoundPlayer(soundPath);
		playSound();
    }

	public Waste Poop()
	{
		return new Waste(Location);
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

	public void playSound()
	{
        sound.Play();
    }

	public abstract Animal GiveBirth();
}