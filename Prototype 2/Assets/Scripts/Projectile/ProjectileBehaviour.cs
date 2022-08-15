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

		public bool Initialized { get; private set; } = false;
		private CollisionDetection collisionDetection;

		public void Initialize()
		{
			if (Initialized)
				return;

			collisionDetection = GetComponentInChildren<CollisionDetection>(true);
			collisionDetection.OnCollisionAction.AddListener(OnCollision);
			Initialized = true;
		}

		private void Awake()
		{
			Initialize();
		}

		private void OnCollision(Collider collider)
		{
			var hungerMeter = collider.GetComponent<IHungryMeter>();

			if (hungerMeter == null)
				return;

			hungerMeter.Feed(_value);
		}

		private void OnDestroy()
		{
			if (!collisionDetection)
				return;

			collisionDetection.OnCollisionAction.RemoveListener(OnCollision);
		}
	}
}