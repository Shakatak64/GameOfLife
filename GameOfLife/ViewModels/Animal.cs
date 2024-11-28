using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace gol.ViewModels;

public class Animal : LifeForm
{
	[ObservableProperty]
	private int visionZone;

	[ObservableProperty]
	private int contactZone;

	public Animal(Point location, int health, int visionZone, int contactZone) : base(location, health)
	{
		this.contactZone = contactZone;
		this.visionZone = visionZone;
	}
}