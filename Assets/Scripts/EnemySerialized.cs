using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyListSerialized
{
    public List<EnemySerialized> enemies;
}


[System.Serializable]
public class EnemySerialized {

    public string name;
    public float damage;
    public float health;
    public float speed;
    public float vision_range;
    public float chase_range;
    public int modelID;
    public int id;
}
