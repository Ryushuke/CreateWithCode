using UnityEngine;

namespace Game.Movements
{
	[AddComponentMenu("Game/Movimentos/Mover para Esquerda")]
	public class MoveLeft : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		private void FixedUpdate()
		{
			Vector3 vector = Time.deltaTime * _speed * Vector3.left;
			transform.Translate(vector);
		}
	}
}