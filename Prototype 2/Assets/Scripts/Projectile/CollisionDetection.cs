using UnityEngine;

namespace Game.Projectile
{
	[AddComponentMenu("Game/Projeteis/Detecção de Colisão")]
	public class CollisionDetection : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			gameObject.SetActive(false);
			collision.gameObject.SetActive(false);
		}
	}
}