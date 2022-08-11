using Game.Objects;
using UnityEngine;

namespace Game.Projectile
{
	[AddComponentMenu("Game/Projeteis/Pool de Projeteis")]
	public class ProjectilePool : MonoBehaviour
	{
		[SerializeField]
		private ObjectPoolBehaviour _pool;

		public GameObject Get() => _pool.Get();

		private void Awake()
		{
			_pool.OnReleaseAction.AddListener(OnRelease);
		}

		private void OnDestroy()
		{
			_pool.OnReleaseAction.RemoveListener(OnRelease);
		}

		private void OnRelease(PoolableBehaviour projectile)
		{
			projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
		}
	}
}