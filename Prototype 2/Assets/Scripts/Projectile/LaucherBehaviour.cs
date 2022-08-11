using Game.Inputs;
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

		private IShotInput input;

		[ContextMenu("Lançar")]
		public void Launch()
		{
			var projectile = _projectile.Get();
			projectile.transform.SetPositionAndRotation(_launchPoint.position, _launchPoint.rotation);
			projectile.SetActive(true);
		}

		private void Awake()
		{
			input = GetComponent<IShotInput>();
		}

		private void OnDisable()
		{
			input?.ShotAction.RemoveListener(Launch);
		}

		private void OnEnable()
		{
			input?.ShotAction.AddListener(Launch);
		}
	}
}