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

	private Vector randomPosition;

	private string foodSoundPath = @"..\..\..\Assets\food.wav";
	private SoundPlayer foodSound;






    public Animal(Point location, int speed, int health, int energy, int visionRadius, int contactRadius, Gender gender, int reproductionTime, string soundPath) : base(location, health, energy)
	{
        this.speed = speed;
        this.contactRadius = contactRadius;
		this.visionRadius = visionRadius;
		this.gender = gender;
		this.reproductionTime = reproductionTime;
		SoundPath = soundPath;
		sound = new SoundPlayer(soundPath);
		foodSound = new SoundPlayer(foodSoundPath);
		playSound();

		Random r = new Random();
        randomPosition = new Vector(r.NextInt64(-1000, 1000), r.NextInt64(-1000,1000));
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

	public void playEatSound() { 
		foodSound.Play(); 
	}

    public void Move(ObservableCollection<GameObject> objects)
	{
        foreach (GameObject obj in objects)
        {
            if ((this is Carnivore && (obj is Herbivore | obj is Meat)) | (this is Herbivore && obj is Plant))
            {

                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(VisionRadius, 2))
                {
                    Vector direction = obj.Location - Location;
                    if (direction.Length < 10) return;
                    Location += direction.Normalize() * Speed;
					return;
                }
            }
        }
        
        Location += randomPosition.Normalize()*Speed;
    }

	public abstract Animal GiveBirth();

	public override void Tick()
    {
        base.Tick();
		if(Ticks % 100 == 0)
		{
			Random r = new Random();
            randomPosition = new Vector(r.NextInt64(-1000, 1000), r.NextInt64(-1000, 1000));
        }
    }
}

