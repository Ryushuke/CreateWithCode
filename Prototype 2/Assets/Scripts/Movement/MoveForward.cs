using UnityEngine;

namespace Game.Movement
{
	[AddComponentMenu("Game/Movimento/Frente e Trás")]
	public class MoveForward : Move
	{
		private void FixedUpdate()
		{
			transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
		}
	}
}