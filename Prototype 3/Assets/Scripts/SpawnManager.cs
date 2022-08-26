using Game.Objects;
using UnityEngine;

namespace Game
{
	[AddComponentMenu("Game/Instanciador de Elementos")]
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField]
		private ObjectPoolBehaviour _pool;
		[SerializeField]
		private float intervalTime;

		public void SetIntervalTime(float time)
		{
			CancelInvoke(nameof(Spawn));
			intervalTime = time;
			Start();
		}

		[ContextMenu("Instanciar")]
		public void Spawn()
		{
			GameObject obstacle = _pool.Get();

			if (!obstacle)
				return;

			obstacle.transform.position = transform.position;
			obstacle.SetActive(true);
		}

		public void Start()
		{
			InvokeRepeating(nameof(Spawn), intervalTime, intervalTime);
		}
	}
}