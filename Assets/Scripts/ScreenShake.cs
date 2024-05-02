using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShake : MonoBehaviour
{
	private float trauma = 0f;
	private float shake = 0f;
	[SerializeField] private float traumaDecrease = 1f;
	[SerializeField] private float maxAngle = 10f;
	[SerializeField] private float maxOffset = 10f;

	[SerializeField] private Slider traumaSlider;
	[SerializeField] private Slider shakeSlider;

	public float t = 0.1f;
	private void Update()
	{
		if (trauma > 0f)
			trauma -= Time.deltaTime * traumaDecrease;
		shake = Mathf.Pow(trauma, 3);
		traumaSlider.value = trauma;
		shakeSlider.value = shake;

		float angle = maxAngle * shake * RandomFNegOneToOne(0f);
		float offsetX = maxOffset * shake * RandomFNegOneToOne(1f);
		float offsetY = maxOffset * shake * RandomFNegOneToOne(2f);

		transform.localEulerAngles = new Vector3(0f, 0f, angle);
		transform.localPosition = new Vector3(offsetX, offsetY, 0f);

		if (Input.GetKeyDown(KeyCode.K))
		{
			AddTrauma(t);
		}
	}

	public void AddTrauma(float amount)
	{
		trauma = Mathf.Clamp01(trauma + amount);
	}

	float RandomFNegOneToOne(float delta)
	{
		return ((Mathf.PerlinNoise1D(Time.time * 1000 + delta)) - 0.5f) * 2;
	}
}
