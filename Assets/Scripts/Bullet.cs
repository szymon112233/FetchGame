using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 30.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
