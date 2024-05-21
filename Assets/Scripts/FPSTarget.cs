using UnityEngine;

public class FPSTarget : MonoBehaviour
{
	public bool limitFPS = true;
	public int target = 60;

	void Awake()
	{
		if (limitFPS)
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = target;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = -1;
		}
	}

	void Update()
	{
		if (Application.targetFrameRate != target && limitFPS)
			Application.targetFrameRate = target;
	}
}