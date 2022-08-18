using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Collisions
{
	[Serializable]
	public class CollisionUnityEvent : UnityEvent<Collision> { }
}