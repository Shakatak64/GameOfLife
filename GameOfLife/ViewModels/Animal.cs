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
	private int remainingReproductionCooldown;
	
	public Animal(Point location, int health, int visionRadius, int contactRadius, Gender gender) : base(location, health)
	{
		this.contactRadius = contactRadius;
		this.visionRadius = visionRadius;
		this.gender = gender;

	}

    public void Reproduce(LifeForm with)
    {
        if (with is Animal)
		{
			//...
		}
    }
}