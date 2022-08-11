using UnityEngine;

namespace Game.Projectile
{
	[AddComponentMenu("Game/Jogador/Lançar Projeteis")]
	public class LaucherBehaviour : MonoBehaviour
	{
		[SerializeField]
		private ProjectilePool _projectile;
		[SerializeField]
		private Transform _launchPoint;

		[ContextMenu("Lançar")]
		public void Launch()
		{
			var projectile = _projectile.Get();
			projectile.transform.SetPositionAndRotation(_launchPoint.position, _launchPoint.rotation);
			projectile.SetActive(true);
		}
	}
}