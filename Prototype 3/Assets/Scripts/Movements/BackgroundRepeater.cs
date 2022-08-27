using UnityEngine;

namespace Game.Movements
{
	[AddComponentMenu("Game/Movimentos/Repetidor de Fundo")]
	public class BackgroundRepeater : MonoBehaviour
	{
		private Vector3 startPosition;
		private float repeatWidth;

		private void Awake()
		{
			startPosition = transform.position;
			var sprite = GetComponent<SpriteRenderer>();
			repeatWidth = sprite.bounds.extents.x;
		}

		private void FixedUpdate()
		{
			if (transform.position.x > startPosition.x - repeatWidth)
				return;

			transform.position = startPosition;
		}
	}
}