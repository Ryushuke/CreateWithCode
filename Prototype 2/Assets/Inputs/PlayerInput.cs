using UnityEngine;

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
		}
	}
}