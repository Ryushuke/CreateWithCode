using UnityEngine;

namespace Game.Collisions
{
	[RequireComponent(typeof(Rigidbody))]
	[AddComponentMenu("Game/Colisões/Colisão")]
	public class CollisionBehaviour : MonoBehaviour
	{
		[SerializeField]
		private GroundedEvent _onGroundedStateChange;

		private bool grounded;

		private void OnCollisionEnter(Collision collision)
		{
			if (grounded)
				return;

			grounded = true;
			_onGroundedStateChange.Invoke(true);
		}

		private void OnCollisionExit(Collision collision)
		{
			if (!grounded)
				return;

			grounded = false;
			_onGroundedStateChange.Invoke(false);
		}
	}
}