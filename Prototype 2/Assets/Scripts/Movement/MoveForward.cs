using System;
using UnityEngine;

namespace Game.Movement
{
	[AddComponentMenu("Game/Movimento/Frente e Trás")]
	public class MoveForward : Move
	{
		private Rigidbody body;
		private Action<Vector3> moveAction;

		private void Awake()
		{
			body = GetComponent<Rigidbody>();
			moveAction = body ? Move : transform.Translate;
		}

		private void FixedUpdate()
		{
			Vector3 position = speed * Time.fixedDeltaTime * Vector3.forward;
			moveAction?.Invoke(position);
		}

		private void Move(Vector3 position)
		{
			position = transform.TransformPoint(position);
			body.MovePosition(position);
		}
	}
}