using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

	public GameObject NPC;
	public float jedaSpawn = 2f;
	public float minSpawn = 1f;
	public float maxSpawn = 3f;

	public Transform[] SpawnPoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnNPC", Random.Range (minSpawn, maxSpawn), jedaSpawn);	
	}
	
	public void spawnNPC(){
		Transform selectedSpawnPos = SpawnPoint [Random.Range (0, SpawnPoint.Length)];
		Instantiate (NPC, selectedSpawnPos.position, Quaternion.identity);
	}
}
