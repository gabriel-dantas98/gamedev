using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;                // The prefab to be spawned.
	public float spawnTime = 0.3f;            // How long between each spawn.
	private Vector3 spawnPosition;

	// Use this for initialization
	void Start () 
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", 0, spawnTime);

	}

	void Spawn ()
	{
		spawnPosition.x = Random.Range (-10, 11);
		spawnPosition.y = 0.5f;
		spawnPosition.z = Random.Range (-10, 11);

		Instantiate(enemies[Random.Range(0, 2)], spawnPosition, Quaternion.identity);
	}

}
