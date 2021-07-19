using UnityEngine;
using UnityEngine.InputSystem;
using Game.Vehicle;

namespace Game.Player
{
	[AddComponentMenu("Game/Jogador/Controles de Direção")]
	public class DriveControl : MonoBehaviour
	{
		#region Inicialização	
		public void Initialize()
		{
			if(steerAction)
			{
				steerAction.action.performed += Steer;
				steerAction.action.canceled += Steer;
			}

			if(accelerationAction)
			{
				accelerationAction.action.performed += Accelerate;
				accelerationAction.action.canceled += Accelerate;
			}
		}
		
		private void Start()
		{
			Initialize();
		}
		#endregion

		#region Inputs	
		[SerializeField] private InputActionReference steerAction = null;
		[SerializeField] private InputActionReference accelerationAction = null;
		
		void OnEnable()
		{
			if(!move)
			{
				enabled = false;
				return;
			}

			steerAction?.action.Enable();
			accelerationAction?.action.Enable();
		}

		void OnDisable()
		{
			steerAction?.action.Disable();
			accelerationAction?.action.Disable();
		}
		#endregion

		#region Movimento	
		[SerializeField] private Move move = null;
		#endregion

		#region Virar	
		private void Steer (InputAction.CallbackContext context)
		{
			var value = context.ReadValue<float>();

			move.SteerDirection = value;
		}
		#endregion

		#region Acelerar	
		private void Accelerate (InputAction.CallbackContext context)
		{
			var value = context.ReadValue<float>();

			move.Acceleration = value;
		}
		#endregion
	}
}