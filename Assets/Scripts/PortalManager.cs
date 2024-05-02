using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
	public GameObject EnemyPrefab;
	public float EnemyPeriod;
	void Start()
	{
		InvokeRepeating("InvokeEnemy", 0, EnemyPeriod);
	}

	void InvokeEnemy()
	{
		GameObject obj = Instantiate(EnemyPrefab, transform.position, transform.rotation);
	}
}