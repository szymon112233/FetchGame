using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager Instance = null;

    [SerializeField]
    EnemySpawner[] spawners = null;

    public GameObject[] enemiesPrefabs = null;
    public float spawnInterval = 5.0f;

    public List<GameObject> spawnedEnemies;
    public const int MAX_ENEMIES = 100; 

    float spawnTimer = 0.0f;


    private void Awake()
    {
        enemiesPrefabs = EnemyManager.instance.createdEnemies.ToArray();

        Instance = this;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Spawner");
        spawnedEnemies = new List<GameObject>();
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

        if (spawnTimer < Mathf.Epsilon && spawnedEnemies.Count < MAX_ENEMIES)
        {
            spawnTimer = spawnInterval;

            int randomSpanwer = Random.Range(0, spawners.Length);
            int randomEnemy = Random.Range(0, enemiesPrefabs.Length);

            spawners[randomSpanwer].Spawn(enemiesPrefabs[randomEnemy]);
        }
    }

}
