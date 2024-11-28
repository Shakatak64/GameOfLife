using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

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
	
	public Animal(Point location, int health, int visionRadius, int contactRadius, Gender gender, int reproductionTime) : base(location, health)
	{
		this.contactRadius = contactRadius;
		this.visionRadius = visionRadius;
		this.gender = gender;
		this.reproductionTime = reproductionTime;

	}

    public override void Reproduce(LifeForm with)
    {
        if (with is Animal)
		{
			Animal withAnimal = (Animal) with;
            if (withAnimal.Gender != Gender)
			{
				if(CanReproduce() && withAnimal.CanReproduce())
				{

				}
			}
		}
    }

	public bool CanReproduce()
	{
		return base.counter > NextBirth; 
	}

	public new void Tick()
	{
		base.Tick();
		if(CanReproduce() && Gender == Gender.FEMALE)
		{
			//naissance d'un petit
		}	
	}
}