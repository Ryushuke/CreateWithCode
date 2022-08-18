using UnityEngine;
using UnityEngine.UI;

namespace Game.Player.UI
{
	[AddComponentMenu("Game/Jogador/UI/Medidor de Vida")]
    public class HealthMeterUIBehaviour : MonoBehaviour
    {
		[SerializeField]
		private HealthMeter _meter;
		[SerializeField]
		private Image _image;

		public void SetValue(float value)
		{
			_image.fillAmount = value;
		}

		public void SetValue(int oldValue, int newValue)
		{
			float fill = newValue / (float)_meter.Maximum;
			SetValue(fill);
		}

		private void Awake()
		{
			_meter.OnChangeAction.AddListener(SetValue);
		}

		private void OnDestroy()
		{
			if (!_meter)
				return;

			_meter.OnChangeAction.RemoveListener(SetValue);
		}
	}
}