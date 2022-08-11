using UnityEngine;

namespace Game.Stage
{
	[RequireComponent(typeof(Collider))]
	[AddComponentMenu("Game/Fase/Desativar ao Colidir")]
	public class DisableOnCollision : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			other.gameObject.SetActive(false);
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