using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


    #region singleton
    public static EnemyManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Init();
    }
    #endregion

    public List<GameObject> modelsList;
    public GameObject emptyEnemyPrefab = null;
    public List<GameObject> createdEnemies;
    public List<GameObject> cachedEnemies;

    private void Init()
    {
        createdEnemies = new List<GameObject>();
    }


    public GameObject CreateFromData(EnemySerialized data, Transform parent = null)
    {
        GameObject go = Instantiate(emptyEnemyPrefab, parent);
        DontDestroyOnLoad(go);
        go.SetActive(false);
        go.name = string.Format("Enemy{0}", data.name);
        GameObject model = Instantiate(modelsList[data.modelID], go.transform);

        Enemy enemyComponent = go.GetComponent<Enemy>();
        enemyComponent.animator = model.GetComponent<Animator>();
        enemyComponent.speed = data.speed;
        enemyComponent.maxHP = data.health;
        enemyComponent.visionRadius = data.vision_range;
        enemyComponent.attackDistance = data.chase_range;
        enemyComponent.damage = data.damage;

        createdEnemies.Add(go);

        return go;


    }

    public void LoadCachedEnemies()
    {
        createdEnemies = new List<GameObject>(cachedEnemies);
    }

}
