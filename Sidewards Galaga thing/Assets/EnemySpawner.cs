using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[Tooltip("In Seconds")]
	public float SpawnFrequency = 3f;
	public GameObject EnemyPrefab;

	private float spawnTimer;

	// Use this for initialization
	void Start ()
	{
		spawnTimer = SpawnFrequency;
	}
	
	// Update is called once per frame
	void Update ()
	{
		spawnTimer -= Time.deltaTime;
		if(spawnTimer < 0)
		{
			Instantiate(EnemyPrefab);
			spawnTimer = SpawnFrequency;
		}
	}
}
