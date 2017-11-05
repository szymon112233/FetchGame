using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour {

    public float autodestroyTime = 2.0f;
	
	void Update () {
        if (autodestroyTime < 0.0f)
            Destroy(gameObject);
        autodestroyTime -= Time.deltaTime;
	}
}
