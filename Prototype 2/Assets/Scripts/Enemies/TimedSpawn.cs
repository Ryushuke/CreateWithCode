using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Enemies
{
	[AddComponentMenu("Game/Inimigos/Inserir inimigos (Temporizador)")]
	public class TimedSpawn : MonoBehaviour
	{
		[SerializeField]
		private float _maxTime;
		[SerializeField]
		private float _minTime;
		[Space]
		[SerializeField]
		private UnityEvent _onTimeOutAction;

		private float GetTime()
		{
			return Random.Range(_minTime, _maxTime);
		}

		private void OnEnable()
		{
			StartCoroutine(WaitCoroutine());
		}

		private IEnumerator WaitCoroutine()
		{
			while (enabled)
			{
				float time = GetTime();
				yield return new WaitForSeconds(time);
				_onTimeOutAction.Invoke();
			}
		}
	}
}