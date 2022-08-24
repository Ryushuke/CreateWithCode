using UnityEngine;

namespace Game.Movements
{
	[AddComponentMenu("Game/Movimentos/Pulo")]
	public class JumpBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _jumpForce;

		private Rigidbody rigidBody;

		[ContextMenu("Pular")]
		public void Jump()
		{
			Vector3 force = Vector3.up * _jumpForce;
			rigidBody.AddForce(force, ForceMode.Impulse);
		}

		private void Awake()
		{
			rigidBody = GetComponent<Rigidbody>();
		}
	}
}