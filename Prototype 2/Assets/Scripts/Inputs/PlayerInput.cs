using UnityEngine;
using UnityEngine.Events;

namespace Game.Inputs
{
	[AddComponentMenu("Game/Jogador/Entrada de Comandos")]
	public class PlayerInput : MonoBehaviour, IHorizontalInput, IShotInput
	{
		[SerializeField]
		private UnityEvent _shotAction;
		private float horizontalInput;

		public float HorizontalInput => horizontalInput;
		public UnityEvent ShotAction => _shotAction;

		private void OnDisable()
		{
			horizontalInput = 0f;
		}

		private void Update()
		{
			horizontalInput = Input.GetAxis("Horizontal");

			if (Input.GetKeyDown(KeyCode.Space))
				_shotAction.Invoke();
		}
	}
}