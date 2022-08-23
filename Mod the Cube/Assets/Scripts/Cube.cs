using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
	public MeshRenderer Renderer;
	[SerializeField]
	[Min(10)]
	private float _baseTime;
	[SerializeField]
	[Min(1)]
	private float _rotateSpeed;

	private void ChangeColor()
	{
		StopCoroutine(nameof(ColorCoroutine));
		Color target = Random.ColorHSV(0, 1, .5f, 1);
		StartCoroutine(ColorCoroutine(target));
	}

	private void ChangeRotation()
	{
		StopCoroutine(nameof(RotateCoroutine));
		Vector3 rotation = Random.insideUnitSphere * _rotateSpeed;
		StartCoroutine(RotateCoroutine(rotation));
	}

	private void ChangeScale()
	{
		StopCoroutine(nameof(ScaleCoroutine));
		float scale = Random.Range(.5f, 2);
		StartCoroutine(ScaleCoroutine(scale));
	}

	private IEnumerator ColorCoroutine(Color target)
	{
		Material material = Renderer.material;
		Color current = material.color;
		float time = Random.value * _baseTime;
		float currentTime = 0;

		while (currentTime < time)
		{
			yield return null;
			float t = currentTime / time;
			Color next = Color.Lerp(current, target, t);
			currentTime += Time.deltaTime;
			material.color = next;
		}

		ChangeColor();
	}

	private IEnumerator RotateCoroutine(Vector3 rotation)
	{
		float time = Random.value * _baseTime;

		do
		{
			yield return null;
			time -= Time.deltaTime;
			transform.Rotate(rotation * Time.deltaTime);
		}
		while (time > 0);

		ChangeRotation();
	}

	private IEnumerator ScaleCoroutine(float size)
	{
		float time = Random.value * _baseTime;
		float initial = transform.localScale.x;
		float current = 0;

		while (current < time)
		{
			yield return null;
			current += Time.deltaTime;
			float t = current / time;
			float scale = Mathf.Lerp(initial, size, t);
			transform.localScale = Vector3.one * scale;
		}

		ChangeScale();
	}

	private void Start()
	{
		transform.localScale = Vector3.one * 1.3f;
		Material material = Renderer.material;
		material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

		ChangeColor();
		ChangeRotation();
		ChangeScale();
	}
}