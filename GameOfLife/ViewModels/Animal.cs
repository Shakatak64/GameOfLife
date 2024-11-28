using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace gol.ViewModels;

public partial class Animal : LifeForm
{
	[ObservableProperty]
	private int visionRadius;

	[ObservableProperty]
	private int contactRadius;

	public Animal(Point location, int health, int visionRadius, int contactRadius) : base(location, health)
	{
		this.contactRadius = contactRadius;
		this.visionRadius = visionRadius;
	}
}