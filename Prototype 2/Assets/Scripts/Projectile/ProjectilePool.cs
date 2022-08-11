using UnityEngine;
using UnityEngine.Pool;

namespace Game.Projectile
{
	[AddComponentMenu("Game/Projeteis/Pool de Projeteis")]
	public class ProjectilePool : MonoBehaviour
	{
		[SerializeField]
		private GameObject _projectile;
		[Min(1)]
		[SerializeField]
		private int _capacity;

		private ObjectPool<GameObject> pool;

		public GameObject Get() => pool.Get();

		private void Awake()
		{
			pool = new ObjectPool<GameObject>(Create,
				actionOnRelease: OnRelease,
				defaultCapacity: _capacity);
		}

		private GameObject Create()
		{
			GameObject go = Instantiate(_projectile, transform);
			go.name = string.Format("{0} ({1:00})",
				_projectile.name,
				pool.CountAll);
			return go;
		}

		private void OnRelease(GameObject projectile)
		{
			projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
		}
	}
}