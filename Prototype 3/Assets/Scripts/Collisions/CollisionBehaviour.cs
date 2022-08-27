using UnityEngine;
using UnityEngine.Events;

namespace Game.Collisions
{
	[RequireComponent(typeof(Rigidbody))]
	[AddComponentMenu("Game/Colisões/Colisão")]
	public class CollisionBehaviour : MonoBehaviour
	{
		[SerializeField]
		private string _obstacleTag;
		[SerializeField]
		private string _groundTag;
		[Space]
		[SerializeField]
		private GroundedEvent _onGroundedStateChange;
		[SerializeField]
		private UnityEvent _onObstacleHit;

		private bool grounded;

		private void ChangeGroundedState(bool value)
		{
			grounded = value;
			_onGroundedStateChange.Invoke(value);
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!grounded
				&& collision.gameObject.CompareTag(_groundTag))
			{
				ChangeGroundedState(true);
				return;
			}

			if (!collision.gameObject.CompareTag(_obstacleTag))
				return;

			_onObstacleHit.Invoke();
		}

		private void OnCollisionExit(Collision collision)
		{
			if (!grounded)
				return;

			ChangeGroundedState(false);
		}
	}
}