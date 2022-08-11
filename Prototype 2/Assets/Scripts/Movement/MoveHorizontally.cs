using UnityEngine;
using Game.Inputs;

namespace Game.Movement
{
	[RequireComponent(typeof(IHorizontalInput))]
	[AddComponentMenu("Game/Movimento/Horizontalmente")]
	public class MoveHorizontally : Move
	{
		public float xRange = 10;
		private IHorizontalInput controlHorizontalInput;

		void Start()
		{
			controlHorizontalInput = GetComponent<IHorizontalInput>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			if(transform.position.x < -xRange)
			{
				transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
				return;
			}

			if(transform.position.x > xRange)
			{
				transform.position = new Vector3 (xRange, transform.position.y, transform.position.z);
				return;
			}

			transform.Translate(Vector3.right * controlHorizontalInput.HorizontalInput * speed * Time.fixedDeltaTime);
		}
	}
}