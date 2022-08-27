using Game.Movements;
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

		private MoveLeft currentObjstacle;

		public void SetIntervalTime(float time)
		{
			Stop();
			intervalTime = time;
			Start();
		}

		[ContextMenu("Instanciar")]
		public void Spawn()
		{
			var obstacle = _pool.Get<MoveLeft>();

			if (!obstacle)
				return;

			obstacle.transform.position = transform.position;
			obstacle.gameObject.SetActive(true);
			currentObjstacle = obstacle;
		}

		public void Start()
		{
			InvokeRepeating(nameof(Spawn), intervalTime, intervalTime);
		}

		public void Stop()
		{
			CancelInvoke(nameof(Spawn));
		}

		private void OnDisable()
		{
			Stop();
			currentObjstacle.enabled = false;
		}
	}
}