using UnityEngine.Events;

namespace Game.Inputs
{
	public interface IShotInput
	{
		UnityEvent ShotAction { get; }
	}
}