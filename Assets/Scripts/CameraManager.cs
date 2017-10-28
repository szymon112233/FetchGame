using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Transform playerTransform;
    public float CameraScrollSpeed = 20;

	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z - 10.0f);

        if (Input.mouseScrollDelta.y != 0.0f)
        {
            transform.position += new Vector3(0, -Input.mouseScrollDelta.y * CameraScrollSpeed * Time.deltaTime, 0);
            transform.LookAt(playerTransform);
        }
        
	}
}
