using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Stage
{
	[Serializable]
	public class ColliderUnityEvent : UnityEvent<Collider> { }
}