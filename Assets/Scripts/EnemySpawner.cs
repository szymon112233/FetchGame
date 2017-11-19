using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    GameObject prefabToSpawn = null;
    float spawnInterval = 10.0f;


    
    public void DeleyedSpawn()
    {

    }

    public void Spawn(GameObject prefab = null)
    {
        if (prefab != null)
            prefabToSpawn = prefab;
        if (prefabToSpawn != null)
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
        
    }

}
