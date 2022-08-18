using UnityEngine;

namespace Game.Collisions
{
	[AddComponentMenu("Game/Colisões/Detecção de Colisão")]
	public class CollisionDetection : MonoBehaviour
	{
		[SerializeField]
		private CollisionUnityEvent _onCollisionAction;

		public CollisionUnityEvent OnCollisionAction => _onCollisionAction;

		private void OnCollisionEnter(Collision collision)
		{
			OnCollisionAction.Invoke(collision);
		}
	}
}