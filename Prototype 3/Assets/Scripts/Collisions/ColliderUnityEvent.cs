using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Collisions
{
	[Serializable]
	public class ColliderUnityEvent : UnityEvent<Collider> { }
}