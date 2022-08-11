using UnityEngine;
using UnityEngine.Events;

namespace Game.Inputs
{
	[AddComponentMenu("Game/Jogador/Entrada de Comandos")]
	public class PlayerInput : MonoBehaviour, IHorizontalInput
	{
		public float horizontalInput;

		public float HorizontalInput => horizontalInput;

		void Update()
		{
			horizontalInput = Input.GetAxis("Horizontal");

			//if(Input.GetKeyDown(KeyCode.Space))

		}
	}
}