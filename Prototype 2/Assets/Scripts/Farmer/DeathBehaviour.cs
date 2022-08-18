using UnityEngine;
using UnityEngine.Events;

namespace Game.Player
{
	[AddComponentMenu("Game/Jogador/Comportamento Morte")]
    public class DeathBehaviour : MonoBehaviour
    {
		[SerializeField]
		private UnityEvent _onDeathAction;

		public void OnHealthChange(int oldValue, int newValue)
		{
			if (newValue > 0)
				return;

			_onDeathAction.Invoke();
		}
    }
}