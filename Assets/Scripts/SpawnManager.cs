using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    EnemySpawner[] spawners = null;

    public GameObject[] enemiesPrefabs = null;
    public float spawnInterval = 5.0f;

    float spawnTimer = 0.0f;


    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Spawner");
        spawners = new EnemySpawner[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            spawners[i] = objects[i].GetComponent<EnemySpawner>();
        }

        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < Mathf.Epsilon)
        {
            spawnTimer = spawnInterval;

            int randomSpanwer = Random.Range(0, spawners.Length);
            int randomEnemy = Random.Range(0, enemiesPrefabs.Length);

            spawners[randomSpanwer].Spawn(enemiesPrefabs[randomEnemy]);
        }
    }

}
