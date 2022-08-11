using System;
using UnityEngine.Events;

namespace Game.Objects
{
	[Serializable]
	public class PoolableUnityEvent : UnityEvent<PoolableBehaviour> { }
}