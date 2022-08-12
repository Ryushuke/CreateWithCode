using UnityEditor;
using UnityEngine;

namespace Game.Enemies
{
	[AddComponentMenu("Game/Inimigos/Ponto de Inserção")]
	public class SpawnPoint : MonoBehaviour
	{
		[SerializeField]
		private float _xMax;
		[SerializeField]
		private float _xMin;

		public Vector3 GetPosition()
		{
			float x = Random.Range(_xMin, _xMax);
			return new Vector3(x, transform.position.y, transform.position.z);
		}

		public Quaternion GetRotation()
		{
			return transform.rotation;
		}

		private void OnDrawGizmos()
		{
			Vector3 a = transform.position;
			Vector3 b = a;
			a.x = _xMin;
			b.x = _xMax;
			Gizmos.DrawLine(a, b);
		}
	}
}