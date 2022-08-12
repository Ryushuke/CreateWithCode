using Game.Objects;
using UnityEngine;

namespace Game.Enemies
{
	[AddComponentMenu("Game/Inimigos/Gerenciador de Inimigos")]
	public class EnemyManager : MonoBehaviour
	{
		[SerializeField]
		private ObjectPoolBehaviour[] _enemyPools;
		[SerializeField]
		private SpawnPoint _spawnPoint;

		[ContextMenu("Colocar inimigo")]
		public void SpawnEnemy()
		{
			int index = Random.Range(0, _enemyPools.Length);
			var enemy = _enemyPools[index].Get();

			if (!enemy)
				return;

			Intantiate(enemy);
		}

		private void Intantiate(GameObject enemy)
		{
			Vector3 position = _spawnPoint.GetPosition();
			Quaternion rotation = _spawnPoint.GetRotation();
			enemy.transform.SetPositionAndRotation(position, rotation);
			enemy.SetActive(true);
		}
	}
}