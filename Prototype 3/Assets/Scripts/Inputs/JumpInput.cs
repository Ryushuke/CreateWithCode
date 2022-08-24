using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Inputs
{
	[AddComponentMenu("Game/Comandos/Pulo (Comando)")]
	public class JumpInput : MonoBehaviour
	{
		[SerializeField]
		private bool _anyKey;
		[SerializeField]
		private KeyCode _jumpKey;
		[SerializeField]
		private UnityEvent _triggerAction;

		private void ListenKeys()
		{
			StopAllCoroutines();
			Func<bool> func;
			if (_anyKey)
				func = () => Input.anyKeyDown;
			else
				func = () => Input.GetKeyDown(_jumpKey);

			StartCoroutine(ListenKeysCoroutine(func));
		}

		private IEnumerator ListenKeysCoroutine(Func<bool> listenMethod)
		{
			while (enabled)
			{
				yield return null;

				if (!listenMethod.Invoke())
					continue;

				_triggerAction.Invoke();
			}
		}

		private void OnEnable()
		{
			ListenKeys();
		}
	}
}