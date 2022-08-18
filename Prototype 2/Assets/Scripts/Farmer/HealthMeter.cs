using UnityEngine;

namespace Game.Player
{
	[AddComponentMenu("Game/Jogador/Medidor de Saúde")]
	public class HealthMeter : MonoBehaviour
	{
		[Min(1)]
		[SerializeField]
		private int _maximum;
		[Space]
		[SerializeField]
		private HealthUnityEvent _onChangeAction;

		public HealthUnityEvent OnChangeAction => _onChangeAction;

		public int Current { get; private set; }
		public int Maximum { get; private set; }

		public bool Add(int value)
		{
			if (value < 1
				|| Current >= Maximum)
				return false;

			Set(value);
			return true;
		}

		public bool Remove(int value)
		{
			if (value > 0
				|| Current < 1)
				return false;

			Set(value);
			return true;
		}

		public void Reset()
		{
			if (!Application.isPlaying)
				return;

			Current = Maximum;
		}

		private void Awake()
		{
			Maximum = _maximum;
			Reset();
		}

		private void Set(int value)
		{
			int oldValue =	Current;
			int newValue = Current + value;
			Current = Mathf.Clamp(newValue, 0, Maximum);
			OnChangeAction.Invoke(oldValue, Current);
		}
	}
}