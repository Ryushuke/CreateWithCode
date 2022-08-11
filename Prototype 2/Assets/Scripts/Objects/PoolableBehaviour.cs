using UnityEngine;

namespace Game.Objects
{
	[AddComponentMenu("Game/Objetos/Tornar Agrupável")]
	public class PoolableBehaviour : MonoBehaviour
	{
		private ObjectPoolBehaviour pool;

		public void SetPool(ObjectPoolBehaviour pool)
		{
			this.pool = pool;
		}

		public void Release()
		{
			if(!pool)
				return;

			pool.Release(this);
		}

		private void OnDisable()
		{
			Release();
		}
	}
}