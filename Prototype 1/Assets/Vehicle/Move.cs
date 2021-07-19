using UnityEngine;

namespace Game.Vehicle
{
	[RequireComponent(typeof(Rigidbody))]
	[AddComponentMenu("Game/Veículo/Movimento")]
	public class Move : MonoBehaviour
	{
		#region Velocidade	
		[SerializeField] private float speed = 20;

		private float acceleration = 0;
		
		public float Acceleration
		{
			get => acceleration;
			set
			{
				acceleration = value;
			}
		}
		#endregion
		
		#region Direção	
		[SerializeField] private float steerSpeed = 1;
		private float direction = 0;

		public float SteerDirection
		{
			get => direction;
			set
			{
				direction = value;
			}
		}
		#endregion

		private void FixedUpdate()
		{
			transform.Translate(Vector3.forward * Time.fixedDeltaTime * Acceleration * speed);
			transform.Rotate(Vector3.up, Time.fixedDeltaTime * SteerDirection * steerSpeed);
		}
	}
}