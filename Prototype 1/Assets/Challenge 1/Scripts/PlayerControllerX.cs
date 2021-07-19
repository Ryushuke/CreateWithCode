using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;
	public float verticalInput;

	// Start is called before the first frame update
	void Start()
	{
		steerVerticalAction.action.performed += VerticalSteering;
		steerVerticalAction.action.canceled += VerticalSteering;
		steerVerticalAction.action.Enable();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// move the plane forward at a constant rate
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		// tilt the plane up/down based on up/down arrow keys
		transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
	}

	#region Inputs	
	[SerializeField] private InputActionReference steerVerticalAction = null;

	private void VerticalSteering(InputAction.CallbackContext context)
	{
		var value = context.ReadValue<float>();

		verticalInput = value;
	}
	#endregion
}
