using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Utility
{
	[AddComponentMenu("Game/Utilidades/Ação temporizada")]
    public class TimedAction : MonoBehaviour
    {
		[SerializeField]
		private float _time;
		[SerializeField]
		private bool _executeOnEnable;
		[Space]
		[SerializeField]
		private UnityEvent _onTimeUpAction;

		public void StartTimer()
		{
			StartCoroutine(WaitCoroutine());
		}

		private void OnEnable()
		{
			if (!_executeOnEnable)
				return;

			StartTimer();
		}

		private IEnumerator WaitCoroutine()
		{
			yield return new WaitForSeconds(_time);
			_onTimeUpAction.Invoke();
		}
    }
}