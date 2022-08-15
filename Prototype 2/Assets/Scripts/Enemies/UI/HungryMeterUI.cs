using UnityEngine;
using UnityEngine.UI;

namespace Game.Enemies.UI
{
	[AddComponentMenu("Game/Inimigos/UI/Medidor de Fome (UI)")]
	public class HungryMeterUI : MonoBehaviour
	{
		[SerializeField]
		private Gradient _color;
		[SerializeField]
		private Image _image;

		public void SetValue(float value)
		{
			Color color = _color.Evaluate(value);
			_image.color = color;
			_image.fillAmount = value;
		}
	}
}
