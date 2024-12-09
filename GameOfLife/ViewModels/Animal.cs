using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	private int speed;

	[ObservableProperty]
	private int nextBirth = 0;

	[ObservableProperty]
	private string soundPath;

    public SoundPlayer sound;



	
	public Animal(Point location, int speed, uint health, uint energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime, string soundPath) : base(location, health, energy)
	{
        this.speed = speed;
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


	public Point DefineTarget(ObservableCollection<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            if((this is Carnivore & obj is Herbivore) | (this is Herbivore && obj is Plant))
			{
				if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(VisionRadius, 2))
				{
					return obj.Location;
				}
            } 
        }
        return new Point(128,128);
    }

    public void Move(Point target)
	{
		Vector direction = target-Location;
		Location += direction.Normalize()*Speed;
    }

	public abstract Animal GiveBirth();
}