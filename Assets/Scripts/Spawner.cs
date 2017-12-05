using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] zombiePrefab;

    public Transform target;

    public float spawnRadius = 1f;
    public float spawnRate = 20;
    public float minSpawnRate = 2;

    public int spawnAmount = 1;
    public int currentSpawn;
    public int maxSpawn = 10000;
    

    private bool canSpawn = true;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

	// Use this for initialization
	void Start () {
        currentSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(canSpawn && currentSpawn < maxSpawn)
        {
            StartCoroutine(Spawn());
            currentSpawn++;
        }
	}
    IEnumerator Spawn()
    {
        canSpawn = false;

        SpawnZombie();

        yield return new WaitForSeconds(spawnRate);

        if (spawnRate > minSpawnRate)
        {
            spawnRate = spawnRate - 0.2f;
        }

        canSpawn = true;
        
    }
    void SpawnZombie()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int randomNumber = Random.Range(0, zombiePrefab.Length);

            GameObject randomZombie = zombiePrefab[randomNumber];

            GameObject clone = Instantiate(randomZombie);

            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;

            clone.transform.position = randomPos;

            AIAgent aiAgent =clone.GetComponent<AIAgent>();

            aiAgent.target = target;
        }
    }
}
