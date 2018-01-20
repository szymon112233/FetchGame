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
        GameObject go = null; 
        if (prefab != null)
            prefabToSpawn = prefab;
        if (prefabToSpawn != null)
        {
            go = Instantiate(prefabToSpawn, transform.position, transform.rotation);
            go.SetActive(true);
            SpawnManager.Instance.spawnedEnemies.Add(go);
        }
            
                
        
        
    }

}
