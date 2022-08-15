using UnityEngine;
using UnityEngine.Events;

namespace Game.Enemies
{
	[AddComponentMenu("Game/Inimigos/Medidor de Fome")]
    public class HungryMeter : MonoBehaviour, IHungryMeter
    {
		[Min(1)]
		[SerializeField]
		private int _max;
		[Space]
		[SerializeField]
		private UnityEvent _onSatisfiedAction;
		[SerializeField]
		private HungerChangeUnityEvent _onChangeAction;

		private int current;
		public float Fullness => current / (float)_max;

		public void Feed(int value = 1)
		{
			current -= value;

			if(current < 0)
			{
				current = 0;
				_onSatisfiedAction.Invoke();
			}
			_onChangeAction.Invoke(Fullness);
		}

		public void Reset()
		{
			if (!Application.isPlaying)
				return;

			current = _max;
		}

		private void Awake()
		{
			Reset();
		}
	}
}