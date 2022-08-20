using UnityEngine;

namespace Game.Collisions
{
	[RequireComponent(typeof(Collider))]
	[AddComponentMenu("Game/Colisões/Desativar ao Sair da Área")]
	public class DisableOnLeaveArea : MonoBehaviour
	{
		[SerializeField]
		private ColliderUnityEvent _onTriggerEnterAction;

		private void OnTriggerExit(Collider other)
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