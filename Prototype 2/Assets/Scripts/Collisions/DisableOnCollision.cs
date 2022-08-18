using UnityEngine;

namespace Game.Collisions
{
	[RequireComponent(typeof(Collider))]
	[AddComponentMenu("Game/Fase/Desativar ao Colidir")]
	public class DisableOnCollision : MonoBehaviour
	{
		[SerializeField]
		private ColliderUnityEvent _onTriggerEnterAction;

		private void OnTriggerEnter(Collider other)
		{
			other.gameObject.SetActive(false);
			_onTriggerEnterAction.Invoke(other);
		}

#if UNITY_EDITOR
		private void Reset()
		{
			var collider = GetComponent<Collider>();
			collider.isTrigger = true;
		}
#endif
	}
}