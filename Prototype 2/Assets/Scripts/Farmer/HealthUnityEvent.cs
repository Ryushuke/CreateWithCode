using System;
using UnityEngine.Events;

namespace Game.Player
{
	[Serializable]
	public class HealthUnityEvent : UnityEvent<int, int> { }
}