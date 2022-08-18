using UnityEngine;
using UnityEngine.Events;

namespace Game.Player
{
	[AddComponentMenu("Game/Jogador/Comportamento do Dano")]
	public class DamageBehaviour : MonoBehaviour
	{
		[Min(1)]
		[SerializeField]
		private int _value;
		[Space]
		[SerializeField]
		private HealthMeter _meter;
		[Space]
		[SerializeField]
		private UnityEvent _onDamagedAction;

		public void OnCollision(Collision collision)
		{
			if (!_meter.Remove(-_value))
				return;

			_onDamagedAction.Invoke();
		}
	}
}