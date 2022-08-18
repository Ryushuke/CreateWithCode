using Game.Enemies;
using UnityEngine;

namespace Game.Projectile
{
	[AddComponentMenu("Game/Projeteis/Comportamento do Projetil")]
	public class ProjectileBehaviour : MonoBehaviour
	{
		[Min(1)]
		[SerializeField]
		private int _value;

		public void OnCollision(Collision collision)
		{
			if (!collision.collider.TryGetComponent<IHungryMeter>(out var hungerMeter))
				return;

			hungerMeter.Feed(_value);
		}
	}
}