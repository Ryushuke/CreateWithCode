using UnityEngine;

namespace Game.Collisions
{
	[AddComponentMenu("Game/Colisões/Detecção de Gatilhos")]
	public class TriggerDetection : MonoBehaviour
    {
		[SerializeField]
		private ColliderUnityEvent _onTriggerEnterAction;

		private void OnTriggerEnter(Collider other)
		{
			_onTriggerEnterAction.Invoke(other);
		}
	}
}