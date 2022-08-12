using UnityEngine;
using UnityEngine.Events;

namespace Game.Stage
{
	[AddComponentMenu("Game/Fase/Fim de Jogo")]
    public class GameOver : MonoBehaviour
    {
		[SerializeField]
		private UnityEvent _onGameOverAction;

        public void End()
		{
			_onGameOverAction.Invoke();
		}
    }
}