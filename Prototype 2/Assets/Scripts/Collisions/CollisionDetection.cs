using UnityEngine;

namespace Game.Collisions
{
	[AddComponentMenu("Game/Projeteis/Detecção de Colisão")]
	public class CollisionDetection : MonoBehaviour
	{
		[SerializeField]
		private ColliderUnityEvent _onCollisionAction;

		public ColliderUnityEvent OnCollisionAction => _onCollisionAction;

		private void OnCollisionEnter(Collision collision)
		{
			gameObject.SetActive(false);
			OnCollisionAction.Invoke(collision.collider);
		}
	}
}