using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Media;
using System.Runtime.Intrinsics.X86;


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

	[ObservableProperty]
	private bool pregnant = false;

    [ObservableProperty]
	private string text = "";

    public SoundPlayer sound;

	private Point randomPosition;

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
        randomPosition = new Point(r.NextInt64(0, 1000), r.NextInt64(0,1000));
    }

	public Waste Poop()
	{
		return new Waste(Location);
	}

	public abstract void eat(ObservableCollection<GameObject> objects);

	public bool CanReproduce()
	{
		return base.counter > NextBirth; 
	}

	public bool CanGiveBirth()
	{
		return base.counter == NextBirth & Gender == Gender.FEMALE & Pregnant;
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
		Point target = randomPosition;
        foreach (GameObject obj in objects)
        {
			if (obj is Animal)
			{
				Animal an = (Animal)obj;

				if ((this is Carnivore & (an is Herbivore | (an is Meat && (Health < maxHealth | Energy < maxEnergy)))) | (this is Herbivore && an is Plant && (Health < maxHealth | Energy < maxEnergy)) | (this is Herbivore && an is Herbivore && CanReproduce() && an.CanReproduce() && an.Gender != Gender ) | (this is Carnivore && an is Carnivore && CanReproduce() && an.CanReproduce() && an.Gender != Gender))
				{
					if (Math.Pow(an.Location.X - Location.X, 2) + Math.Pow(an.Location.Y - Location.Y, 2) <= Math.Pow(VisionRadius, 2))
					{
						target = an.Location;
					}
				}
			}
        }
        Vector direction = target - Location;
        if (Math.Abs(direction.X) < 1 | Math.Abs(direction.Y) < 1) return;
        Location += direction.Normalize() * Speed;
    }

	public void HaveSxx(ObservableCollection<GameObject> objects)
    {
        
        foreach (GameObject obj in objects)
        {
            if ((this is Carnivore && obj is Carnivore) | (this is Herbivore && obj is Herbivore))
            {
                if (Math.Pow(obj.Location.X - Location.X, 2) + Math.Pow(obj.Location.Y - Location.Y, 2) <= Math.Pow(ContactRadius, 2))
                {
                    Animal withAnimal = (Animal) obj;
                    if (withAnimal.Gender != Gender)
                    {
                        if (CanReproduce() && withAnimal.CanReproduce())
                        {
                            NextBirth = base.counter + ReproductionTime;
							if(Gender == Gender.FEMALE) Pregnant = true;
                        }
                    }
                }
            }
        }
        
    }

    public abstract Animal GiveBirth();


	public override void Tick(ObservableCollection<GameObject> objects)
	{
		base.Tick(objects);
		counter++;
		Text = String.Format("Health: {0}\nEnergy: {1}\nPregnant: {2}", Health, Energy, Pregnant);

        Move(objects);
        HaveSxx(objects);

        if (CanGiveBirth()) objects.Add(GiveBirth());

        if (Ticks % 25 == 0) eat(objects);

        if (Health < 1)
        {
            objects.Remove(this);
            objects.Add(new Meat(Location));
        }

        if (Ticks % 100 == 0)
		{
			Random r = new Random();
            randomPosition = new Point(r.NextInt64(0, 1000), r.NextInt64(0, 1000));
        }
    }
}

